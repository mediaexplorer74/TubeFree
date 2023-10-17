// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.ITextTrackCueList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Media
{
  [DomName("TextTrackCueList")]
  public interface ITextTrackCueList : IEnumerable<ITextTrackCue>, IEnumerable
  {
    [DomName("length")]
    int Length { get; }

    ITextTrackCue this[int index] { get; }

    [DomName("getCueById")]
    IVideoTrack GetCueById(string id);
  }
}
