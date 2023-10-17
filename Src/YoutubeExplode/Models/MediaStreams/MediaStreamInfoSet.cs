// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.MediaStreamInfoSet
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public class MediaStreamInfoSet
  {
    [NotNull]
    [ItemNotNull]
    public IReadOnlyList<MuxedStreamInfo> Muxed { get; }

    [NotNull]
    [ItemNotNull]
    public IReadOnlyList<AudioStreamInfo> Audio { get; }

    [NotNull]
    [ItemNotNull]
    public IReadOnlyList<VideoStreamInfo> Video { get; }

    [CanBeNull]
    public string HlsLiveStreamUrl { get; }

    public DateTimeOffset ValidUntil { get; }

    public MediaStreamInfoSet(
      IReadOnlyList<MuxedStreamInfo> muxed,
      IReadOnlyList<AudioStreamInfo> audio,
      IReadOnlyList<VideoStreamInfo> video,
      string hlsLiveStreamUrl,
      DateTimeOffset validUntil)
    {
      this.Muxed = muxed.GuardNotNull<IReadOnlyList<MuxedStreamInfo>>(nameof (muxed));
      this.Audio = audio.GuardNotNull<IReadOnlyList<AudioStreamInfo>>(nameof (audio));
      this.Video = video.GuardNotNull<IReadOnlyList<VideoStreamInfo>>(nameof (video));
      this.HlsLiveStreamUrl = hlsLiveStreamUrl;
      this.ValidUntil = validUntil;
    }
  }
}
