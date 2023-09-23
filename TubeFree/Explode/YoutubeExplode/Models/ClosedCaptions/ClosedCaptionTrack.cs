// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.ClosedCaptions.ClosedCaptionTrack
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System.Collections.Generic;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.ClosedCaptions
{
  public class ClosedCaptionTrack
  {
    [NotNull]
    public ClosedCaptionTrackInfo Info { get; }

    [NotNull]
    [ItemNotNull]
    public IReadOnlyList<ClosedCaption> Captions { get; }

    public ClosedCaptionTrack(ClosedCaptionTrackInfo info, IReadOnlyList<ClosedCaption> captions)
    {
      this.Info = info.GuardNotNull<ClosedCaptionTrackInfo>(nameof (info));
      this.Captions = captions.GuardNotNull<IReadOnlyList<ClosedCaption>>(nameof (captions));
    }
  }
}
