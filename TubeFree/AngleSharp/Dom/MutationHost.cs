// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.MutationHost
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  internal sealed class MutationHost
  {
    private readonly List<MutationObserver> _observers;
    private readonly IEventLoop _loop;
    private bool _queued;

    public MutationHost(IEventLoop loop)
    {
      this._observers = new List<MutationObserver>();
      this._queued = false;
      this._loop = loop;
    }

    public IEnumerable<MutationObserver> Observers => (IEnumerable<MutationObserver>) this._observers;

    public void Register(MutationObserver observer)
    {
      if (this._observers.Contains(observer))
        return;
      this._observers.Add(observer);
    }

    public void Unregister(MutationObserver observer)
    {
      if (!this._observers.Contains(observer))
        return;
      this._observers.Remove(observer);
    }

    public void ScheduleCallback()
    {
      if (this._queued)
        return;
      this._queued = true;
      this._loop.Enqueue(new Action(this.DispatchCallback));
    }

    private void DispatchCallback()
    {
      MutationObserver[] array = this._observers.ToArray();
      this._queued = false;
      foreach (MutationObserver mutationObserver in array)
        this._loop.Enqueue(new Action(mutationObserver.Trigger), TaskPriority.Microtask);
    }
  }
}
