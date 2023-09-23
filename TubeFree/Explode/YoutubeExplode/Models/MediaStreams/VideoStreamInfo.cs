// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.VideoStreamInfo
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public class VideoStreamInfo : MediaStreamInfo
  {
    public long Bitrate { get; }

    public VideoEncoding VideoEncoding { get; }

    [NotNull]
    public string VideoQualityLabel { get; }

    public VideoQuality VideoQuality { get; }

    public VideoResolution Resolution { get; }

    public int Framerate { get; }

    public VideoStreamInfo(
      int itag,
      string url,
      Container container,
      long size,
      long bitrate,
      VideoEncoding videoEncoding,
      string videoQualityLabel,
      VideoQuality videoQuality,
      VideoResolution resolution,
      int framerate)
      : base(itag, url, container, size)
    {
      this.Bitrate = bitrate.GuardNotNegative(nameof (bitrate));
      this.VideoEncoding = videoEncoding;
      this.VideoQualityLabel = videoQualityLabel.GuardNotNull<string>(nameof (videoQualityLabel));
      this.VideoQuality = videoQuality;
      this.Resolution = resolution;
      this.Framerate = framerate.GuardNotNegative(nameof (framerate));
    }

    public override string ToString() => string.Format("{0} ({1}) [video]", new object[2]
    {
      (object) this.Itag,
      (object) this.Container
    });
  }
}
