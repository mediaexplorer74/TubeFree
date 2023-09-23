// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.AdMediatorRunner
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Algorithms;
using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Exceptions;
using Microsoft.AdMediator.Core.Handlers;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Models.Runtime;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core
{
  internal class AdMediatorRunner : IDisposable
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (AdMediatorRunner));
    private static readonly TimeSpan RefreshRateBuffer = TimeSpan.FromSeconds(3.0);
    private readonly IAdAdapterProvider adAdapterProvider;
    private readonly ILocationHandler locationHandler;
    private readonly object runnerTaskLock = new object();
    private readonly object adSdkEventLock = new object();
    private readonly IEventLogger eventLogger;
    private CancellationTokenSource runnerCancellationTokenSource;
    private CancellationTokenSource pauseCancellationTokenSource;
    private IAdAdapter currentAdAdapter;
    private bool disposed;
    private bool isPaused;
    private Location location;
    private Task runnerTask;
    private readonly List<AdFailedEventArgs> adSdkErrors;

    public AdMediatorRunner(
      IAdAdapterProvider adAdapterProvider,
      ILocationHandler locationHandler,
      IEventLogger eventLogger)
    {
      this.adAdapterProvider = adAdapterProvider;
      this.locationHandler = locationHandler;
      this.eventLogger = eventLogger;
      this.adSdkErrors = new List<AdFailedEventArgs>();
      Task.Run((Func<Task>) (() => this.LocationCallback()));
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

    public bool IsRunning() => this.runnerTask != null;

    public void Run(
      IRotationAlgorithm rotationAlgorithm,
      AdSdkParameters sdkParameters,
      IDictionary<string, TimeSpan> adSdkTimeouts,
      TimeSpan refreshRate,
      TimeSpan defaultTimeout)
    {
      if (this.runnerTask != null)
        throw new RunnerTaskAlreadyRunningException("Runner cannot be started twice");
      lock (this.runnerTaskLock)
      {
        if (this.runnerTask != null)
          throw new RunnerTaskAlreadyRunningException("Runner cannot be started twice");
        this.currentAdAdapter = (IAdAdapter) null;
        this.runnerCancellationTokenSource = new CancellationTokenSource();
        this.pauseCancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = this.runnerCancellationTokenSource.Token;
        TimeSpan rotateRate = refreshRate - AdMediatorRunner.RefreshRateBuffer;
        TimeSpan sdkRefreshRate = refreshRate;
        this.runnerTask = this.RunMultipleIterationsAsync(rotationAlgorithm, sdkParameters, adSdkTimeouts, defaultTimeout, rotateRate, sdkRefreshRate, token);
      }
    }

    public void StopExecution()
    {
      if (this.runnerTask == null)
      {
        AdMediatorRunner.Log.Trace("Runner task is null, nothing to stop...");
      }
      else
      {
        lock (this.runnerTaskLock)
        {
          if (this.runnerTask == null)
          {
            AdMediatorRunner.Log.Trace("Runner task is null, nothing to stop...");
          }
          else
          {
            AdMediatorRunner.Log.Trace("Stopping runner task");
            this.runnerCancellationTokenSource.Cancel();
            this.pauseCancellationTokenSource.Cancel();
            try
            {
              this.runnerTask.Wait();
            }
            catch (AggregateException ex1)
            {
              ex1.Handle((Func<Exception, bool>) (ex =>
              {
                if (!(ex is TaskCanceledException))
                  return false;
                AdMediatorRunner.Log.Information((Exception) ex1, "Task has already been canceled.");
                return true;
              }));
            }
            this.currentAdAdapter = (IAdAdapter) null;
            this.runnerCancellationTokenSource = (CancellationTokenSource) null;
            this.pauseCancellationTokenSource = (CancellationTokenSource) null;
            this.isPaused = false;
            this.runnerTask = (Task) null;
            this.adAdapterProvider.ReleaseAdAdapters();
          }
        }
      }
    }

    public void Pause()
    {
      lock (this.runnerTaskLock)
      {
        if (this.isPaused)
        {
          AdMediatorRunner.Log.Trace("Already paused");
        }
        else
        {
          AdMediatorRunner.Log.Trace("Pausing runner");
          this.adAdapterProvider.PauseAdAdapters();
          this.isPaused = true;
        }
      }
    }

    public void Resume()
    {
      lock (this.runnerTaskLock)
      {
        if (!this.isPaused)
        {
          AdMediatorRunner.Log.Trace("Cannot resume, not paused");
        }
        else
        {
          AdMediatorRunner.Log.Trace("Resuming runner");
          this.adAdapterProvider.ResumeAdAdapters();
          this.isPaused = false;
          if (this.pauseCancellationTokenSource != null)
            this.pauseCancellationTokenSource.Cancel();
          this.pauseCancellationTokenSource = new CancellationTokenSource();
        }
      }
    }

    private async Task RunMultipleIterationsAsync(
      IRotationAlgorithm rotationAlgorithm,
      AdSdkParameters sdkParameters,
      IDictionary<string, TimeSpan> sdkTimeouts,
      TimeSpan defaultAdSdkTimeout,
      TimeSpan rotateRate,
      TimeSpan sdkRefreshRate,
      CancellationToken cancellationToken)
    {
      while (!cancellationToken.IsCancellationRequested)
      {
        try
        {
          await this.RunOneIterationAsync(rotationAlgorithm, sdkParameters, sdkTimeouts, defaultAdSdkTimeout, rotateRate, sdkRefreshRate, cancellationToken);
        }
        catch (TaskCanceledException ex)
        {
          AdMediatorRunner.Log.Trace((Exception) ex, "Task was cancelled");
        }
        catch (OperationCanceledException ex)
        {
          AdMediatorRunner.Log.Trace((Exception) ex, "Operation was cancelled");
        }
        catch (Exception ex)
        {
          this.ReportAdMediatorError(new AdMediatorFailedEventArgs()
          {
            Error = ex,
            ErrorCode = AdMediatorErrorCode.NoAdAvailable
          });
        }
      }
    }

    private async Task RunOneIterationAsync(
      IRotationAlgorithm rotationAlgorithm,
      AdSdkParameters sdkParameters,
      IDictionary<string, TimeSpan> sdkTimeouts,
      TimeSpan defaultAdSdkTimeout,
      TimeSpan rotateRate,
      TimeSpan sdkRefreshRate,
      CancellationToken cancellationToken)
    {
      rotationAlgorithm.StartNewIteration();
      DateTime startTimestamp = DateTime.UtcNow;
      while (!cancellationToken.IsCancellationRequested)
      {
        await this.WaitForPauseAsync(sdkRefreshRate);
        if (cancellationToken.IsCancellationRequested)
          break;
        AdAdapterRuntimeInfo nextAdAdapterRuntimeConfiguration = rotationAlgorithm.GetNextAdAdapterRuntimeConfiguration();
        if (nextAdAdapterRuntimeConfiguration == null)
        {
          this.ReportAdMediatorError(new AdMediatorFailedEventArgs()
          {
            Error = (Exception) new AdMediatorException("Failed to load an ad"),
            ErrorCode = AdMediatorErrorCode.NoAdAvailable
          });
          await Task.Delay(rotateRate, cancellationToken);
          break;
        }
        AdMediatorRunner.Log.Trace("Next adapter {0}", (object) nextAdAdapterRuntimeConfiguration.Name);
        IAdAdapter adAdapter = this.currentAdAdapter;
        bool flag = false;
        if (adAdapter == null || adAdapter.Name != nextAdAdapterRuntimeConfiguration.Name)
        {
          try
          {
            adAdapter = this.adAdapterProvider.GetAdAdapter(nextAdAdapterRuntimeConfiguration, sdkParameters[nextAdAdapterRuntimeConfiguration.Name], this.location);
            flag = true;
          }
          catch (Exception ex)
          {
            AdMediatorRunner.Log.Error(ex, "Failed to get adapter for {0}", (object) nextAdAdapterRuntimeConfiguration.Name);
            string message = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Failed to load adapter for AdSdk {0}", (object) nextAdAdapterRuntimeConfiguration.Name);
            AdFailedEventArgs adControlEventArgs = new AdFailedEventArgs();
            adControlEventArgs.Error = (Exception) new AdSdkException(message, ex);
            adControlEventArgs.ErrorCode = AdMediatorErrorCode.AdAdapterError;
            adControlEventArgs.Name = nextAdAdapterRuntimeConfiguration.Name;
            this.ReportAdSdkError(adControlEventArgs);
            continue;
          }
        }
        AdAdapterStatus adAdapterStatus = new AdAdapterStatus();
        using (SemaphoreSlim adAdapterAdShowingWaitSemaphore = new SemaphoreSlim(0, int.MaxValue))
        {
          using (SemaphoreSlim adAdapterAdSdkErrorWaitSemaphore = new SemaphoreSlim(0, int.MaxValue))
          {
            using (SemaphoreSlim adAdapterResultUpdateSemaphore = new SemaphoreSlim(1, 1))
            {
              EventHandler<AdFailedEventArgs> adSdkFailedEventHandler = (EventHandler<AdFailedEventArgs>) ((sender, eventArgs) => this.HandleAdAdapterStatefulEvent(adAdapter, false, (AdSdkEventArgs) null, eventArgs, adAdapterAdShowingWaitSemaphore, adAdapterAdSdkErrorWaitSemaphore, adAdapterResultUpdateSemaphore, adAdapterStatus));
              EventHandler<AdSdkEventArgs> adFilledEventHandler = (EventHandler<AdSdkEventArgs>) ((sender, eventArgs) => this.HandleAdAdapterStatefulEvent(adAdapter, true, eventArgs, (AdFailedEventArgs) null, adAdapterAdShowingWaitSemaphore, adAdapterAdSdkErrorWaitSemaphore, adAdapterResultUpdateSemaphore, adAdapterStatus));
              EventHandler<AdSdkEventArgs> adSdkEventHandler = (EventHandler<AdSdkEventArgs>) ((sender, eventArgs) => this.HandleGeneralEvent(adAdapter, adAdapterStatus, eventArgs, "sdk", new Action<object, AdSdkEventArgs>(this.ReportSdkEvent)));
              EventHandler<AdSdkEventArgs> pauseForInterstitial = (EventHandler<AdSdkEventArgs>) ((sender, eventArgs) => this.HandleGeneralEvent(adAdapter, adAdapterStatus, eventArgs, "pause for interstitial", new Action<object, AdSdkEventArgs>(this.ReportPauseForInterstitialEvent)));
              EventHandler<AdSdkEventArgs> resumeForInterstitial = (EventHandler<AdSdkEventArgs>) ((sender, eventArgs) => this.HandleGeneralEvent(adAdapter, adAdapterStatus, eventArgs, "resume for interstitial", new Action<object, AdSdkEventArgs>(this.ReportResumeForInterstitialEvent)));
              try
              {
                if (this.currentAdAdapter != null && this.currentAdAdapter.Name != adAdapter.Name)
                {
                  this.StopAdAdapter(this.currentAdAdapter);
                  this.currentAdAdapter = (IAdAdapter) null;
                }
                this.SubscribeAdAdapterEvents(adAdapter, adSdkFailedEventHandler, adFilledEventHandler, adSdkEventHandler, pauseForInterstitial, resumeForInterstitial);
                if (flag)
                {
                  if (adAdapter.Name == "MicrosoftAdvertising" || adAdapter.Name == "MicrosoftAdvertisingHouse")
                  {
                    TimeSpan timeSpan = DateTime.UtcNow.Subtract(startTimestamp);
                    if (timeSpan < AdMediatorRunner.RefreshRateBuffer)
                    {
                      try
                      {
                        TimeSpan delay = AdMediatorRunner.RefreshRateBuffer - timeSpan;
                        AdMediatorRunner.Log.Trace("Waiting for {0} for {1}", (object) adAdapter.Name, (object) delay);
                        await Task.Delay(delay, cancellationToken);
                      }
                      catch (TaskCanceledException ex)
                      {
                        AdMediatorRunner.Log.Trace((Exception) ex, "Task was already cancelled, stopping initialization of {0}", (object) adAdapter.Name);
                        break;
                      }
                    }
                  }
                  this.StartAdAdapter(adAdapter, sdkRefreshRate);
                }
                this.currentAdAdapter = adAdapter;
              }
              catch (Exception ex)
              {
                AdMediatorRunner.Log.Error(ex, "Failed to start adapter {0}", (object) adAdapter.Name);
                AdFailedEventArgs adControlEventArgs = new AdFailedEventArgs();
                adControlEventArgs.Name = adAdapter.Name;
                adControlEventArgs.ErrorCode = AdMediatorErrorCode.AdAdapterError;
                adControlEventArgs.Error = ex;
                this.ReportAdSdkError(adControlEventArgs);
                continue;
              }
              bool unsubscribeAdapterEvents = false;
              try
              {
                TimeSpan currentSdkTimeout = defaultAdSdkTimeout;
                if (sdkTimeouts.ContainsKey(adAdapter.Name))
                {
                  TimeSpan sdkTimeout = sdkTimeouts[adAdapter.Name];
                  if (sdkTimeout < TimeSpan.Zero)
                    AdMediatorRunner.Log.Warning("Timeout value must be positive, actual {0}", (object) sdkTimeout);
                  else
                    currentSdkTimeout = sdkTimeout;
                }
                if (!await adAdapterAdShowingWaitSemaphore.WaitAsync(currentSdkTimeout, cancellationToken))
                  this.TimeoutAdAdapter(adAdapter, adAdapterResultUpdateSemaphore, adAdapterAdSdkErrorWaitSemaphore, adAdapterStatus, currentSdkTimeout);
                bool errorReturned = await adAdapterAdSdkErrorWaitSemaphore.WaitAsync(rotateRate, cancellationToken);
                await this.WaitForPauseAsync(sdkRefreshRate);
                this.UnsubscribeAdAdapterEvents(adAdapter, adSdkFailedEventHandler, adFilledEventHandler, adSdkEventHandler);
                unsubscribeAdapterEvents = true;
                if (errorReturned)
                {
                  AdMediatorRunner.Log.Trace("Ad adapter {0} failed", (object) adAdapter.Name);
                  this.StopAdAdapter(this.currentAdAdapter);
                  this.currentAdAdapter = (IAdAdapter) null;
                }
                else
                {
                  AdMediatorRunner.Log.Trace("Finished showing ad for {0}", (object) adAdapter.Name);
                  break;
                }
              }
              catch (OperationCanceledException ex)
              {
                AdMediatorRunner.Log.Trace((Exception) ex, "Operation was already cancelled, unsubscribe all events and exit for adapter {0}", (object) adAdapter.Name);
                if (unsubscribeAdapterEvents)
                  break;
                this.UnsubscribeAdAdapterEvents(adAdapter, adSdkFailedEventHandler, adFilledEventHandler, adSdkEventHandler);
                break;
              }
            }
          }
        }
      }
    }

    private void SubscribeAdAdapterEvents(
      IAdAdapter adAdapter,
      EventHandler<AdFailedEventArgs> adSdkFailedEventHandler,
      EventHandler<AdSdkEventArgs> adFilledEventHandler,
      EventHandler<AdSdkEventArgs> adSdkEventHandler,
      EventHandler<AdSdkEventArgs> pauseForInterstitial,
      EventHandler<AdSdkEventArgs> resumeForInterstitial)
    {
      if (adAdapter == null)
        throw new ArgumentNullException(nameof (adAdapter));
      adAdapter.AdError += adSdkFailedEventHandler;
      adAdapter.AdFilled += adFilledEventHandler;
      adAdapter.AdSdkEvent += adSdkEventHandler;
      adAdapter.PauseForInterstitialEvent += pauseForInterstitial;
      adAdapter.ResumeForInterstitialEvent += resumeForInterstitial;
    }

    private void StartAdAdapter(IAdAdapter adAdapter, TimeSpan refreshrate)
    {
      if (adAdapter == null)
        throw new ArgumentNullException(nameof (adAdapter));
      adAdapter.Start(refreshrate);
      AdMediatorRunner.Log.Trace("Started ad adapter {0}", (object) adAdapter.Name);
    }

    private void UnsubscribeAdAdapterEvents(
      IAdAdapter adAdapter,
      EventHandler<AdFailedEventArgs> adSdkFailedEventHandler,
      EventHandler<AdSdkEventArgs> adFilledEventHandler,
      EventHandler<AdSdkEventArgs> adSdkEventHandler)
    {
      adAdapter.AdError -= adSdkFailedEventHandler;
      adAdapter.AdFilled -= adFilledEventHandler;
      adAdapter.AdSdkEvent -= adSdkEventHandler;
      AdMediatorRunner.Log.Trace("Unsubscribe all events for ad adapter {0}", (object) adAdapter.Name);
    }

    private void StopAdAdapter(IAdAdapter adAdapter)
    {
      try
      {
        adAdapter.StopExecution();
        AdMediatorRunner.Log.Trace("Stopped ad adapter {0}", (object) adAdapter.Name);
      }
      catch (Exception ex)
      {
        AdMediatorRunner.Log.Error(ex, "Failed to stop adapter {0}", (object) adAdapter.Name);
        AdFailedEventArgs adControlEventArgs = new AdFailedEventArgs();
        adControlEventArgs.Name = adAdapter.Name;
        adControlEventArgs.Error = ex;
        adControlEventArgs.ErrorCode = AdMediatorErrorCode.AdAdapterError;
        this.ReportAdSdkError(adControlEventArgs);
      }
    }

    private void ReportSdkEvent(object sender, AdSdkEventArgs adControlEventArgs) => this.ReportEvent<AdSdkEventArgs>(this.AdSdkEvent, adControlEventArgs);

    private void ReportAdMediatorError(AdMediatorFailedEventArgs adControlEventArgs)
    {
      lock (this.adSdkEventLock)
      {
        this.eventLogger.AdMediatorError(adControlEventArgs, (IEnumerable<AdFailedEventArgs>) this.adSdkErrors);
        this.adSdkErrors.Clear();
      }
      this.ReportEvent<AdMediatorFailedEventArgs>(this.AdMediatorError, adControlEventArgs);
    }

    private void ReportAdSdkError(AdFailedEventArgs adControlEventArgs)
    {
      lock (this.adSdkEventLock)
        this.adSdkErrors.Add(adControlEventArgs);
      this.ReportEvent<AdFailedEventArgs>(this.AdSdkError, adControlEventArgs);
    }

    private void ReportAdSdkFilled(AdSdkEventArgs adControlEventArgs)
    {
      lock (this.adSdkEventLock)
      {
        this.eventLogger.AdFilled(adControlEventArgs, (IEnumerable<AdFailedEventArgs>) this.adSdkErrors);
        this.adSdkErrors.Clear();
      }
      this.ReportEvent<AdSdkEventArgs>(this.AdFilled, adControlEventArgs);
    }

    private void ReportPauseForInterstitialEvent(object sender, AdSdkEventArgs adControlEventArgs) => this.ReportEvent<AdSdkEventArgs>(this.PauseForInterstitialEvent, adControlEventArgs);

    private void ReportResumeForInterstitialEvent(object sender, AdSdkEventArgs adControlEventArgs) => this.ReportEvent<AdSdkEventArgs>(this.ResumeForInterstitialEvent, adControlEventArgs);

    private void ReportEvent<T>(EventHandler<T> handler, T eventArgs)
    {
      if (handler == null)
        return;
      handler((object) this, eventArgs);
    }

    private async Task LocationCallback()
    {
      try
      {
        AdMediatorRunner.Log.Trace("Acquiring location");
        AdMediatorRunner adMediatorRunner = this;
        Location location = adMediatorRunner.location;
        Location locationAsync = await this.locationHandler.GetLocationAsync();
        adMediatorRunner.location = locationAsync;
        adMediatorRunner = (AdMediatorRunner) null;
        if (this.location != null)
          return;
        AdMediatorRunner.Log.Information("Location not available");
      }
      catch (Exception ex)
      {
        AdMediatorRunner.Log.Information(ex, "Failed to obtain location");
      }
    }

    private async Task WaitForPauseAsync(TimeSpan sdkRefreshRate)
    {
      if (this.pauseCancellationTokenSource == null)
        return;
      CancellationToken cancellationToken = this.pauseCancellationTokenSource.Token;
      while (this.isPaused && !cancellationToken.IsCancellationRequested)
      {
        AdMediatorRunner.Log.Trace("Runner is paused, waiting for {0} before trying next", (object) sdkRefreshRate);
        await Task.Delay(sdkRefreshRate, cancellationToken);
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
      {
        try
        {
          this.StopExecution();
        }
        catch (Exception ex)
        {
          AdMediatorRunner.Log.Warning(ex, "Failed to stop runner task");
        }
        if (this.runnerCancellationTokenSource != null)
          this.runnerCancellationTokenSource.Dispose();
        if (this.pauseCancellationTokenSource != null)
          this.pauseCancellationTokenSource.Dispose();
        if (this.currentAdAdapter != null)
        {
          this.StopAdAdapter(this.currentAdAdapter);
          this.currentAdAdapter = (IAdAdapter) null;
        }
      }
      this.disposed = true;
    }

    ~AdMediatorRunner() => this.Dispose(false);

    private void TimeoutAdAdapter(
      IAdAdapter adAdapter,
      SemaphoreSlim adAdapterResultUpdateSemaphore,
      SemaphoreSlim adAdapterAdSdkErrorWaitSemaphore,
      AdAdapterStatus adAdapterStatus,
      TimeSpan adSdkTimeout)
    {
      if (!adAdapterStatus.IsActive)
      {
        AdMediatorRunner.Log.Information("Don't timeout ad adapter {0} because it is no longer active", (object) adAdapter.Name);
      }
      else
      {
        adAdapterResultUpdateSemaphore.Wait();
        try
        {
          if (!adAdapterStatus.IsActive)
            AdMediatorRunner.Log.Information("Don't timeout ad adapter {0} because it is no longer active", (object) adAdapter.Name);
          else if (adAdapterStatus.IsSuccessful.HasValue)
          {
            AdMediatorRunner.Log.Information("Status has already been updated right on timeout for adapter {0}", (object) adAdapter.Name);
          }
          else
          {
            adAdapterStatus.IsActive = false;
            adAdapterStatus.IsSuccessful = new bool?(false);
            string message = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "AdSdk {0} failed to load after {1} seconds", (object) adAdapter.Name, (object) adSdkTimeout.TotalSeconds);
            AdFailedEventArgs adFailedEventArgs = new AdFailedEventArgs();
            adFailedEventArgs.Error = (Exception) new AdSdkException(message);
            adFailedEventArgs.ErrorCode = AdMediatorErrorCode.AdSdkTimeout;
            adFailedEventArgs.Name = adAdapter.Name;
            AdFailedEventArgs adControlEventArgs = adFailedEventArgs;
            adAdapterAdSdkErrorWaitSemaphore.Release();
            this.ReportAdSdkError(adControlEventArgs);
          }
        }
        finally
        {
          adAdapterResultUpdateSemaphore.Release();
        }
      }
    }

    private void HandleGeneralEvent(
      IAdAdapter adAdapter,
      AdAdapterStatus adAdapterStatus,
      AdSdkEventArgs eventArgs,
      string eventName,
      Action<object, AdSdkEventArgs> reportEvent)
    {
      try
      {
        if (!adAdapterStatus.IsActive)
          return;
        AdMediatorRunner.Log.Trace("Adapter {0} event '{1}' callback for adapter '{2}'", (object) eventName, (object) eventArgs.EventName, (object) adAdapter.Name);
        reportEvent((object) this, eventArgs);
      }
      catch (Exception ex)
      {
        AdMediatorRunner.Log.Error(ex, "Failed to handle {0} event '{1}' for adapter '{2}'", (object) eventName, (object) eventArgs.EventName, (object) adAdapter.Name);
      }
    }

    private void HandleAdAdapterStatefulEvent(
      IAdAdapter adAdapter,
      bool adFilled,
      AdSdkEventArgs adSdkEventArgs,
      AdFailedEventArgs adFailedEventArgs,
      SemaphoreSlim adAdapterAdShowingWaitSemaphore,
      SemaphoreSlim adAdapterAdSdkErrorWaitSemaphore,
      SemaphoreSlim adAdapterResultUpdateSemaphore,
      AdAdapterStatus adAdapterStatus)
    {
      try
      {
        AdMediatorRunner.Log.Trace("Received terminal event ad filled {0} for ad adapter {1}", (object) adFilled, (object) adAdapter.Name);
        if (!adAdapterStatus.IsActive)
        {
          AdMediatorRunner.Log.Information("Event adfilled {0} is ignored because ad adapter {0} is no longer active", (object) adFilled);
        }
        else
        {
          adAdapterResultUpdateSemaphore.Wait();
          try
          {
            if (!adAdapterStatus.IsActive)
            {
              AdMediatorRunner.Log.Information("Event adfilled {0} is ignored because ad adapter {0} is no longer active", (object) adFilled);
            }
            else
            {
              if (adFilled)
              {
                if (!adAdapterStatus.IsSuccessful.HasValue)
                {
                  AdMediatorRunner.Log.Information("Setting result for adfilled event for {0}", (object) adAdapter.Name);
                  adAdapterStatus.IsSuccessful = new bool?(true);
                  this.ReportAdSdkFilled(adSdkEventArgs);
                }
                else
                  AdMediatorRunner.Log.Information("Ignoring adfilled event for {0} because a terminal event was reached earlier", (object) adAdapter.Name);
              }
              else
              {
                AdMediatorRunner.Log.Information("Event ad error for adapter {0}", (object) adAdapter.Name);
                adAdapterStatus.IsSuccessful = new bool?(false);
                adAdapterStatus.IsActive = false;
                adAdapterAdSdkErrorWaitSemaphore.Release();
                this.ReportAdSdkError(adFailedEventArgs);
              }
              adAdapterAdShowingWaitSemaphore.Release();
            }
          }
          finally
          {
            try
            {
              adAdapterResultUpdateSemaphore.Release();
            }
            catch (ObjectDisposedException ex)
            {
              AdMediatorRunner.Log.Information((Exception) ex, "Result update semaphore could already be disposed (an error event likely happend)");
            }
          }
        }
      }
      catch (Exception ex)
      {
        AdMediatorRunner.Log.Error(ex, "Error when handling event adFilled {0} for ad adapter", (object) adFilled, (object) adAdapter.Name);
      }
    }
  }
}
