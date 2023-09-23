// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.AdRefreshTimer
// Assembly: Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E5DA0355-9146-4692-8FC1-7265B05C19F2
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising.dll

using System;
using System.Threading;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal sealed class AdRefreshTimer : IDisposable
  {
    private readonly TimeSpan minimumRefreshTimeSpan;
    private readonly TimeSpan refreshTimeSpan;
    private readonly Timer timer;
    private readonly Action timerAction;
    private DateTime lastRefreshed = DateTime.MinValue;

    public AdRefreshTimer(
      TimeSpan refreshTimeSpan,
      TimeSpan minimumRefreshTimeSpan,
      Action timerAction)
    {
      this.refreshTimeSpan = refreshTimeSpan;
      this.minimumRefreshTimeSpan = minimumRefreshTimeSpan;
      this.timerAction = timerAction;
      this.timer = new Timer(new System.Threading.TimerCallback(this.TimerCallback), (object) null, TimeSpan.FromMilliseconds(-1.0), refreshTimeSpan);
    }

    public void Dispose()
    {
      if (this.timer == null)
        return;
      this.timer.Dispose();
    }

    public void Start() => this.timer.Change(TimeSpan.Zero, this.refreshTimeSpan);

    public void Pause() => this.timer.Change(TimeSpan.FromMilliseconds(-1.0), this.refreshTimeSpan);

    public void Reset()
    {
      this.lastRefreshed = DateTime.Now;
      this.timer.Change(this.refreshTimeSpan, this.refreshTimeSpan);
    }

    public void Resume()
    {
      TimeSpan timeSpan = this.GetRemainingTimeSpan();
      if (timeSpan < TimeSpan.Zero)
        timeSpan = TimeSpan.Zero;
      this.timer.Change(timeSpan, this.refreshTimeSpan);
    }

    private TimeSpan GetRemainingTimeSpan() => this.minimumRefreshTimeSpan - (DateTime.Now - this.lastRefreshed);

    private void TimerCallback(object state)
    {
      TimeSpan remainingTimeSpan = this.GetRemainingTimeSpan();
      if (remainingTimeSpan > TimeSpan.Zero)
      {
        this.timer.Change(remainingTimeSpan, this.refreshTimeSpan);
      }
      else
      {
        this.timerAction();
        this.lastRefreshed = DateTime.Now;
      }
    }
  }
}
