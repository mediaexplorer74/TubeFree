// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.MuxedStreamInfo
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public class MuxedStreamInfo : MediaStreamInfo
  {
    public AudioEncoding AudioEncoding { get; }

    public VideoEncoding VideoEncoding { get; }

    [NotNull]
    public string VideoQualityLabel { get; }

    public VideoQuality VideoQuality { get; }

    public VideoResolution Resolution { get; }

    public MuxedStreamInfo(
      int itag,
      string url,
      Container container,
      long size,
      AudioEncoding audioEncoding,
      VideoEncoding videoEncoding,
      string videoQualityLabel,
      VideoQuality videoQuality,
      VideoResolution resolution)
      : base(itag, url, container, size)
    {
      this.AudioEncoding = audioEncoding;
      this.VideoEncoding = videoEncoding;
      this.VideoQualityLabel = videoQualityLabel.GuardNotNull<string>(nameof (videoQualityLabel));
      this.VideoQuality = videoQuality;
      this.Resolution = resolution;
    }

    public override string ToString() => string.Format("{0} ({1}) [muxed]", new object[2]
    {
      (object) this.Itag,
      (object) this.Container
    });
  }
}
