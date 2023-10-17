// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.CustomEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("CustomEvent")]
  public class CustomEvent : Event
  {
    public CustomEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public CustomEvent(string type, bool bubbles = false, bool cancelable = false, object details = null) => this.Init(type, bubbles, cancelable, details);

    [DomName("detail")]
    public object Details { get; private set; }

    [DomName("initCustomEvent")]
    public void Init(string type, bool bubbles, bool cancelable, object details)
    {
      this.Init(type, bubbles, cancelable);
      this.Details = details;
    }
  }
}
