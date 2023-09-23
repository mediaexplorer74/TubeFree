// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.EventTargetExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Events;
using System;
using System.Threading.Tasks;

namespace AngleSharp.Extensions
{
  internal static class EventTargetExtensions
  {
    public static bool FireSimpleEvent(
      this IEventTarget target,
      string eventName,
      bool bubble = false,
      bool cancelable = false)
    {
      Event @event = new Event();
      @event.IsTrusted = true;
      @event.Init(eventName, bubble, cancelable);
      return @event.Dispatch(target);
    }

    public static bool Fire(this IEventTarget target, Event eventData)
    {
      eventData.IsTrusted = true;
      return eventData.Dispatch(target);
    }

    public static Task FireAsync<T>(this IBrowsingContext target, string eventName, T data)
    {
      InteractivityEvent<T> eventData = new InteractivityEvent<T>(eventName, data);
      target.Fire((Event) eventData);
      return eventData.Result ?? (Task) TaskEx.FromResult<bool>(false);
    }

    public static bool Fire<T>(
      this IEventTarget target,
      Action<T> initializer,
      IEventTarget targetOverride = null)
      where T : Event, new()
    {
      T obj1 = new T();
      obj1.IsTrusted = true;
      T obj2 = obj1;
      initializer(obj2);
      return obj2.Dispatch(targetOverride ?? target);
    }
  }
}
