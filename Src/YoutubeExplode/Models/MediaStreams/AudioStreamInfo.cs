// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.AudioStreamInfo
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public class AudioStreamInfo : MediaStreamInfo
  {
    public long Bitrate { get; }

    public AudioEncoding AudioEncoding { get; }

    public AudioStreamInfo(
      int itag,
      string url,
      Container container,
      long size,
      long bitrate,
      AudioEncoding audioEncoding)
      : base(itag, url, container, size)
    {
      this.Bitrate = bitrate.GuardNotNegative(nameof (bitrate));
      this.AudioEncoding = audioEncoding;
    }

    public override string ToString() => string.Format("{0} ({1}) [audio]", new object[2]
    {
      (object) this.Itag,
      (object) this.Container
    });
  }
}
