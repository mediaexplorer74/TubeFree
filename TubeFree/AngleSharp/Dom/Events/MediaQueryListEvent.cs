// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.MediaQueryListEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("MediaQueryListEvent")]
  public class MediaQueryListEvent : Event
  {
    public MediaQueryListEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public MediaQueryListEvent(
      string type,
      bool bubbles = false,
      bool cancelable = false,
      string media = null,
      bool matches = false)
    {
      this.Init(type, bubbles, cancelable, media, matches);
    }

    [DomName("matches")]
    public bool IsMatch { get; private set; }

    [DomName("media")]
    public string Media { get; private set; }

    [DomName("initMediaQueryListEvent")]
    public void Init(string type, bool bubbles, bool cancelable, string media, bool matches)
    {
      this.Init(type, bubbles, cancelable);
      this.Media = media;
      this.IsMatch = matches;
    }
  }
}
