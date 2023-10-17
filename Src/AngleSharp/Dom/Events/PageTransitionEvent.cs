// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.PageTransitionEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("PageTransitionEvent")]
  public class PageTransitionEvent : Event
  {
    public PageTransitionEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public PageTransitionEvent(string type, bool bubbles = false, bool cancelable = false, bool persisted = false) => this.Init(type, bubbles, cancelable, persisted);

    [DomName("persisted")]
    public bool IsPersisted { get; private set; }

    [DomName("initPageTransitionEvent")]
    public void Init(string type, bool bubbles, bool cancelable, bool persisted)
    {
      this.Init(type, bubbles, cancelable);
      this.IsPersisted = persisted;
    }
  }
}
