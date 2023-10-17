// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.TrackEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("TrackEvent")]
  public class TrackEvent : Event
  {
    public TrackEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public TrackEvent(string type, bool bubbles = false, bool cancelable = false, object track = null) => this.Init(type, bubbles, cancelable, track);

    [DomName("track")]
    public object Track { get; private set; }

    [DomName("initTrackEvent")]
    public void Init(string type, bool bubbles, bool cancelable, object track)
    {
      this.Init(type, bubbles, cancelable);
      this.Track = track;
    }
  }
}
