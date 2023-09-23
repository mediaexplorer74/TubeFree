// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.AdMediatorCore
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Algorithms;
using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Handlers;
using Microsoft.AdMediator.Core.Managers;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Models.Runtime;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core
{
  internal class AdMediatorCore : IAdMediatorCore, IDisposable
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (AdMediatorCore));
    private static readonly TimeSpan DefaultAdSdkTimeout = TimeSpan.FromSeconds(15.0);
    private static readonly TimeSpan EmulatorRefreshRate = TimeSpan.FromSeconds(30.0);
    private readonly string adControlId;
    private readonly AdSdkParameters adSdkParameters;
    private readonly IDictionary<string, TimeSpan> adSdkTimeouts;
    private readonly IConfigurationManager configurationManager;
    private readonly IEventLogger eventLogger;
    private readonly object runnerUpdateLock = new object();
    private readonly IStateManager stateManager;
    private readonly IConfigurationUpdater configurationUpdater;
    private AdMediatorRunner adMediatorRunner;
    private bool disposed;
    private bool disabled;

    public AdMediatorCore(
      string adControlId,
      IAdAdapterProvider adAdapterProvider,
      IConfigurationManager configurationManager,
      IStateManager stateManager,
      AdSdkParameters adSdkParameters,
      ILocationHandler locationHandler,
      IEventLogger eventLogger,
      IDictionary<string, TimeSpan> adSdkTimeouts,
      IConfigurationUpdater configurationUpdater)
    {
      this.stateManager = stateManager;
      this.adControlId = adControlId;
      this.adSdkParameters = adSdkParameters;
      this.configurationManager = configurationManager;
      this.eventLogger = eventLogger;
      this.adSdkTimeouts = adSdkTimeouts;
      this.configurationUpdater = configurationUpdater;
      this.adMediatorRunner = new AdMediatorRunner(adAdapterProvider, locationHandler, eventLogger);
      this.adMediatorRunner.AdFilled += (EventHandler<AdSdkEventArgs>) ((sender, args) => this.ReportAdSdkFilled(args));
      this.adMediatorRunner.AdMediatorError += (EventHandler<AdMediatorFailedEventArgs>) ((sender, args) => this.ReportAdMediatorError(args));
      this.adMediatorRunner.AdSdkError += (EventHandler<AdFailedEventArgs>) ((sender, args) => this.ReportAdSdkError(args));
      this.adMediatorRunner.AdSdkEvent += (EventHandler<AdSdkEventArgs>) ((sender, args) => this.ReportSdkEvent(args));
      this.adMediatorRunner.PauseForInterstitialEvent += (EventHandler<AdSdkEventArgs>) ((sender, args) => this.ReportPauseForInterstitialEvent(args));
      this.adMediatorRunner.ResumeForInterstitialEvent += (EventHandler<AdSdkEventArgs>) ((sender, args) => this.ReportResumeForInterstitialEvent(args));
      configurationUpdater.ConfigurationUpdated += new EventHandler<EventArgs>(this.ConfigurationUpdated);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    public event EventHandler<AdMediatorFailedEventArgs> AdMediatorError;

    public event EventHandler<AdFailedEventArgs> AdSdkError;

    public event EventHandler<AdSdkEventArgs> AdFilled;

    public event EventHandler<AdSdkEventArgs> AdSdkEvent;

    public event EventHandler<AdSdkEventArgs> PauseForInterstitialEvent;

    public event EventHandler<AdSdkEventArgs> ResumeForInterstitialEvent;

    public void Start()
    {
      lock (this.runnerUpdateLock)
      {
        if (this.disabled)
          return;
        if (this.adMediatorRunner.IsRunning())
        {
          this.adMediatorRunner.Resume();
        }
        else
        {
          Task.Run((Func<Task>) (() => this.StartAdMediatorAsync()));
          Task.Run((Func<Task>) (() => this.StartAdMediatorBackgroundJobsAsync()));
        }
      }
    }

    public void StopExecution()
    {
      lock (this.runnerUpdateLock)
      {
        this.disabled = true;
        this.adMediatorRunner.StopExecution();
      }
    }

    public void Pause()
    {
      lock (this.runnerUpdateLock)
        this.adMediatorRunner.Pause();
    }

    public void Resume()
    {
      lock (this.runnerUpdateLock)
      {
        if (this.disabled)
        {
          this.disabled = false;
          this.Start();
        }
        else
          this.adMediatorRunner.Resume();
      }
    }

    private async Task StartAdMediatorAsync()
    {
      if (this.adMediatorRunner.IsRunning())
        return;
      try
      {
        AdMediatorRuntimeConfiguration configurationAsync = await this.configurationManager.GetAdControlConfigurationAsync(this.adControlId);
        IList<AdAdapterRuntimeInfo> adAdapters = configurationAsync.AdAdapters;
        if (adAdapters == null || adAdapters.Count <= 0)
        {
          AdMediatorCore.Log.Warning("No adapter configured");
          this.ReportAdMediatorError(new AdMediatorFailedEventArgs()
          {
            Error = (Exception) new AdMediatorException("No Ad Network configured"),
            ErrorCode = AdMediatorErrorCode.ConfigurationError
          });
        }
        else
        {
          TimeSpan refreshRate = TimeSpan.FromSeconds((double) configurationAsync.RefreshRate);
          if (this.stateManager.IsTestMode)
            refreshRate = AdMediatorCore.EmulatorRefreshRate;
          IRotationAlgorithm rotationAlgorithm = RotationAlgorithmProvider.GetRotationAlgorithm(configurationAsync.RotationAlgorithm, adAdapters);
          TimeoutInformation overrideSdkTimeouts = TimeoutProvider.GetOverrideSdkTimeouts(adAdapters, this.adSdkTimeouts);
          Dictionary<string, TimeSpan> timeouts = overrideSdkTimeouts.Timeouts;
          foreach (string error in overrideSdkTimeouts.Errors)
          {
            ArgumentOutOfRangeException ofRangeException = new ArgumentOutOfRangeException(error);
            this.ReportAdMediatorError(new AdMediatorFailedEventArgs()
            {
              Error = (Exception) ofRangeException,
              ErrorCode = AdMediatorErrorCode.AdSdkConfigurationError
            });
          }
          TimeSpan defaultTimeout = AdMediatorCore.DefaultAdSdkTimeout;
          if (adAdapters.Count == 1)
            defaultTimeout = refreshRate;
          lock (this.runnerUpdateLock)
          {
            if (this.disabled || this.adMediatorRunner.IsRunning())
              return;
            this.adMediatorRunner.Run(rotationAlgorithm, this.adSdkParameters, (IDictionary<string, TimeSpan>) timeouts, refreshRate, defaultTimeout);
            AdMediatorCore.Log.Trace("Started update loop at interval {0} seconds", (object) refreshRate);
          }
        }
      }
      catch (Exception ex)
      {
        AdMediatorCore.Log.Error(ex, "Failed to start AdMediator");
        this.ReportAdMediatorError(new AdMediatorFailedEventArgs()
        {
          Error = (Exception) new AdMediatorException("Unable to start ad mediator", ex),
          ErrorCode = AdMediatorErrorCode.ConfigurationError
        });
      }
    }

    private async Task StartAdMediatorBackgroundJobsAsync()
    {
      try
      {
        if (this.stateManager.IsTestMode)
          return;
        await this.eventLogger.Initialize();
        this.configurationUpdater.Start();
      }
      catch (Exception ex)
      {
        AdMediatorCore.Log.Error(ex, "Failed to process background tasks");
      }
    }

    private void ReportSdkEvent(AdSdkEventArgs adControlEventArgs) => this.ReportEvent<AdSdkEventArgs>(this.AdSdkEvent, adControlEventArgs);

    private void ReportPauseForInterstitialEvent(AdSdkEventArgs adControlEventArgs)
    {
      this.Pause();
      this.ReportEvent<AdSdkEventArgs>(this.PauseForInterstitialEvent, adControlEventArgs);
    }

    private void ReportResumeForInterstitialEvent(AdSdkEventArgs adControlEventArgs)
    {
      this.Resume();
      this.ReportEvent<AdSdkEventArgs>(this.ResumeForInterstitialEvent, adControlEventArgs);
    }

    private void ReportAdMediatorError(AdMediatorFailedEventArgs adControlEventArgs) => this.ReportEvent<AdMediatorFailedEventArgs>(this.AdMediatorError, adControlEventArgs);

    private void ReportAdSdkError(AdFailedEventArgs adControlEventArgs) => this.ReportEvent<AdFailedEventArgs>(this.AdSdkError, adControlEventArgs);

    private void ReportAdSdkFilled(AdSdkEventArgs adControlEventArgs) => this.ReportEvent<AdSdkEventArgs>(this.AdFilled, adControlEventArgs);

    private void ReportEvent<T>(EventHandler<T> handler, T eventArgs)
    {
      if (handler == null)
        return;
      handler((object) this, eventArgs);
    }

    private void ConfigurationUpdated(object sender, EventArgs e)
    {
      this.StopExecution();
      this.Resume();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
      {
        if (this.adMediatorRunner != null)
        {
          this.adMediatorRunner.Dispose();
          this.adMediatorRunner = (AdMediatorRunner) null;
        }
        this.configurationUpdater.ConfigurationUpdated -= new EventHandler<EventArgs>(this.ConfigurationUpdated);
      }
      this.disposed = true;
    }

    ~AdMediatorCore() => this.Dispose(false);
  }
}
