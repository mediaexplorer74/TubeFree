// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.HashChangedEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("HashChangeEvent")]
  public class HashChangedEvent : Event
  {
    public HashChangedEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public HashChangedEvent(
      string type,
      bool bubbles = false,
      bool cancelable = false,
      string oldURL = null,
      string newURL = null)
    {
      this.Init(type, bubbles, cancelable, oldURL ?? string.Empty, newURL ?? string.Empty);
    }

    [DomName("oldURL")]
    public string PreviousUrl { get; private set; }

    [DomName("newURL")]
    public string CurrentUrl { get; private set; }

    [DomName("initHashChangedEvent")]
    public void Init(
      string type,
      bool bubbles,
      bool cancelable,
      string previousUrl,
      string currentUrl)
    {
      this.Init(type, bubbles, cancelable);
      this.Stop();
      this.PreviousUrl = previousUrl;
      this.CurrentUrl = currentUrl;
    }
  }
}
