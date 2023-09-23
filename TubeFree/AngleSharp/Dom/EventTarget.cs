// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.EventTarget
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  public abstract class EventTarget : IEventTarget
  {
    private List<EventTarget.RegisteredEventListener> _listeners;

    private List<EventTarget.RegisteredEventListener> Listeners => this._listeners ?? (this._listeners = new List<EventTarget.RegisteredEventListener>());

    public void AddEventListener(string type, DomEventHandler callback = null, bool capture = false)
    {
      if (callback == null)
        return;
      this.Listeners.Add(new EventTarget.RegisteredEventListener()
      {
        Type = type,
        Callback = callback,
        IsCaptured = capture
      });
    }

    public void RemoveEventListener(string type, DomEventHandler callback = null, bool capture = false)
    {
      if (callback == null)
        return;
      List<EventTarget.RegisteredEventListener> listeners = this._listeners;
      if (listeners == null)
        return;
      // ISSUE: explicit non-virtual call
      __nonvirtual (listeners.Remove(new EventTarget.RegisteredEventListener()
      {
        Type = type,
        Callback = callback,
        IsCaptured = capture
      }));
    }

    public void RemoveEventListeners()
    {
      if (this._listeners == null)
        return;
      this._listeners.Clear();
    }

    public void InvokeEventListener(Event ev)
    {
      if (this._listeners == null)
        return;
      string type = ev.Type;
      EventTarget.RegisteredEventListener[] array = this._listeners.ToArray();
      IEventTarget currentTarget = ev.CurrentTarget;
      EventPhase phase = ev.Phase;
      foreach (EventTarget.RegisteredEventListener registeredEventListener in array)
      {
        if (this._listeners.Contains(registeredEventListener) && registeredEventListener.Type.Is(type))
        {
          if ((ev.Flags & EventFlags.StopImmediatePropagation) == EventFlags.StopImmediatePropagation)
            break;
          if ((!registeredEventListener.IsCaptured || phase != EventPhase.Bubbling) && (registeredEventListener.IsCaptured || phase != EventPhase.Capturing))
            registeredEventListener.Callback((object) currentTarget, ev);
        }
      }
    }

    public bool HasEventListener(string type)
    {
      if (this._listeners != null)
      {
        foreach (EventTarget.RegisteredEventListener listener in this._listeners)
        {
          if (listener.Type.Is(type))
            return true;
        }
      }
      return false;
    }

    public bool Dispatch(Event ev)
    {
      if (ev == null || (ev.Flags & EventFlags.Dispatch) == EventFlags.Dispatch || (ev.Flags & EventFlags.Initialized) != EventFlags.Initialized)
        throw new DomException(DomError.InvalidState);
      ev.IsTrusted = false;
      return ev.Dispatch((IEventTarget) this);
    }

    private struct RegisteredEventListener
    {
      public string Type;
      public DomEventHandler Callback;
      public bool IsCaptured;
    }
  }
}
