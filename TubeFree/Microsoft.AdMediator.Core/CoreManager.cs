// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.CoreManager
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Utilities.Log;
using System;

namespace Microsoft.AdMediator.Core
{
  internal sealed class CoreManager : IDisposable
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (CoreManager));
    private readonly object adMediatorCoreUpdateLock = new object();
    private IAdMediatorCore adMediatorCore;
    private bool disabled;
    private bool paused;
    private bool unloaded;
    private bool disposed;
    private readonly Func<IAdMediatorCore> coreIntializeAction;

    public CoreManager(Func<IAdMediatorCore> coreIntializeAction) => this.coreIntializeAction = coreIntializeAction;

    public void Disable()
    {
      lock (this.adMediatorCoreUpdateLock)
      {
        CoreManager.Log.Trace("Stopping AdMediator");
        if (this.adMediatorCore != null && !this.disabled)
          this.adMediatorCore.StopExecution();
        this.disabled = true;
        this.paused = false;
      }
    }

    public void Pause()
    {
      lock (this.adMediatorCoreUpdateLock)
      {
        if (this.disabled)
        {
          CoreManager.Log.Trace("AdMediator Disabled, cannot pause");
        }
        else
        {
          CoreManager.Log.Trace("Pausing AdMediator");
          if (this.adMediatorCore != null && !this.paused)
            this.adMediatorCore.Pause();
          this.paused = true;
        }
      }
    }

    public void Resume()
    {
      lock (this.adMediatorCoreUpdateLock)
      {
        CoreManager.Log.Trace("Resuming AdMediator");
        if (this.adMediatorCore != null && (this.paused || this.disabled))
          this.adMediatorCore.Resume();
        this.paused = false;
        this.disabled = false;
      }
    }

    public void Start()
    {
      lock (this.adMediatorCoreUpdateLock)
      {
        if (this.adMediatorCore != null)
        {
          CoreManager.Log.Trace("Reloading AdMediator");
          if (this.unloaded && !this.disabled && !this.paused)
            this.adMediatorCore.Resume();
          this.unloaded = false;
        }
        else
        {
          CoreManager.Log.Trace("Starting AdMediator");
          this.adMediatorCore = this.coreIntializeAction();
          if (this.disabled)
          {
            this.adMediatorCore.StopExecution();
          }
          else
          {
            this.adMediatorCore.Start();
            if (this.paused)
              this.adMediatorCore.Pause();
          }
          this.unloaded = false;
        }
      }
    }

    public void Unload()
    {
      lock (this.adMediatorCoreUpdateLock)
      {
        CoreManager.Log.Trace("Unloading AdMediator");
        if (this.adMediatorCore != null && !this.unloaded && !this.disabled && !this.paused)
          this.adMediatorCore.Pause();
        this.unloaded = true;
      }
    }

    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing && this.adMediatorCore != null)
      {
        this.adMediatorCore.Dispose();
        this.adMediatorCore = (IAdMediatorCore) null;
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~CoreManager() => this.Dispose(false);
  }
}
