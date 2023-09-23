// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.ConfigurationUpdater
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Managers;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core
{
  internal sealed class ConfigurationUpdater : IConfigurationUpdater
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (ConfigurationUpdater));
    private static volatile ConfigurationUpdater instance;
    private static readonly object SyncRoot = new object();
    private readonly IConfigurationManager configurationManager;
    private readonly TimeSpan downloadConfigurationFrequency = TimeSpan.FromHours(6.0);
    private readonly object taskLock = new object();
    private Task updateTask;
    private CancellationTokenSource cancellationTokenSource;

    internal ConfigurationUpdater(IConfigurationManager configurationManager) => this.configurationManager = configurationManager;

    public static ConfigurationUpdater GetInstance(IConfigurationManager aConfigurationManager)
    {
      if (ConfigurationUpdater.instance == null)
      {
        lock (ConfigurationUpdater.SyncRoot)
        {
          if (ConfigurationUpdater.instance == null)
            ConfigurationUpdater.instance = new ConfigurationUpdater(aConfigurationManager);
        }
      }
      return ConfigurationUpdater.instance;
    }

    public event EventHandler<EventArgs> ConfigurationUpdated;

    public void Start()
    {
      if (this.updateTask != null)
        return;
      lock (this.taskLock)
      {
        if (this.updateTask != null)
          return;
        ConfigurationUpdater.Log.Trace("Starting task");
        this.cancellationTokenSource = new CancellationTokenSource();
        this.updateTask = this.UpdateConfigurationAsync();
      }
    }

    public void Stop()
    {
      if (this.updateTask == null)
        return;
      lock (this.taskLock)
      {
        if (this.updateTask == null)
          return;
        ConfigurationUpdater.Log.Trace("Stopping task");
        this.cancellationTokenSource.Cancel();
        try
        {
          this.updateTask.Wait();
        }
        catch (AggregateException ex1)
        {
          ex1.Handle((Func<Exception, bool>) (ex =>
          {
            if (!(ex is TaskCanceledException))
              return false;
            ConfigurationUpdater.Log.Information((Exception) ex1, "Task has already been canceled.");
            return true;
          }));
        }
        this.cancellationTokenSource = (CancellationTokenSource) null;
        this.updateTask = (Task) null;
      }
    }

    private async Task UpdateConfigurationAsync()
    {
      CancellationToken token = this.cancellationTokenSource.Token;
      while (!token.IsCancellationRequested)
      {
        try
        {
          if (await this.configurationManager.DownloadAndSaveNewConfiguration() && this.ConfigurationUpdated != null)
            this.ConfigurationUpdated((object) ConfigurationUpdater.instance, new EventArgs());
          await Task.Delay(this.downloadConfigurationFrequency, token);
        }
        catch (TaskCanceledException ex)
        {
          ConfigurationUpdater.Log.Trace((Exception) ex, "Task was cancelled");
        }
        catch (OperationCanceledException ex)
        {
          ConfigurationUpdater.Log.Trace((Exception) ex, "Operation was cancelled");
        }
      }
    }
  }
}
