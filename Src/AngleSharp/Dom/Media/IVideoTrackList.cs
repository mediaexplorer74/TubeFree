// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.IVideoTrackList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Media
{
  [DomName("VideoTrackList")]
  public interface IVideoTrackList : IEventTarget, IEnumerable<IVideoTrack>, IEnumerable
  {
    [DomName("length")]
    int Length { get; }

    [DomName("selectedIndex")]
    int SelectedIndex { get; }

    [DomAccessor(Accessors.Getter)]
    IVideoTrack this[int index] { get; }

    [DomName("getTrackById")]
    IVideoTrack GetTrackById(string id);

    [DomName("onchange")]
    event DomEventHandler Changed;

    [DomName("onaddtrack")]
    event DomEventHandler TrackAdded;

    [DomName("onremovetrack")]
    event DomEventHandler TrackRemoved;
  }
}
