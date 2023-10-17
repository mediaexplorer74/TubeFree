// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.ClosedCaptions.Extensions
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System;
using System.Linq;

namespace YoutubeExplode.Models.ClosedCaptions
{
  public static class Extensions
  {
    [CanBeNull]
    public static ClosedCaption GetByTime(this ClosedCaptionTrack track, TimeSpan time) => track.Captions.FirstOrDefault<ClosedCaption>((Func<ClosedCaption, bool>) (c => time >= c.Offset && time <= c.Offset + c.Duration));
  }
}
