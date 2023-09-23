// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.MessageEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("MessageEvent")]
  public class MessageEvent : Event
  {
    public MessageEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public MessageEvent(
      string type,
      bool bubbles = false,
      bool cancelable = false,
      object data = null,
      string origin = null,
      string lastEventId = null,
      IWindow source = null,
      params IMessagePort[] ports)
    {
      this.Init(type, bubbles, cancelable, data, origin ?? string.Empty, lastEventId ?? string.Empty, source, ports);
    }

    [DomName("data")]
    public object Data { get; private set; }

    [DomName("origin")]
    public string Origin { get; private set; }

    [DomName("lastEventId")]
    public string LastEventId { get; private set; }

    [DomName("source")]
    public IWindow Source { get; private set; }

    [DomName("ports")]
    public IMessagePort[] Ports { get; private set; }

    [DomName("initMessageEvent")]
    public void Init(
      string type,
      bool bubbles,
      bool cancelable,
      object data,
      string origin,
      string lastEventId,
      IWindow source,
      params IMessagePort[] ports)
    {
      this.Init(type, bubbles, cancelable);
      this.Data = data;
      this.Origin = origin;
      this.LastEventId = lastEventId;
      this.Source = source;
      this.Ports = ports;
    }
  }
}
