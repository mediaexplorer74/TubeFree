// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.MediaStreamInfo
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public abstract class MediaStreamInfo
  {
    public int Itag { get; }

    [NotNull]
    public string Url { get; }

    public Container Container { get; }

    public long Size { get; }

    protected MediaStreamInfo(int itag, string url, Container container, long size)
    {
      this.Itag = itag;
      this.Url = url.GuardNotNull<string>(nameof (url));
      this.Container = container;
      this.Size = size.GuardNotNegative(nameof (size));
    }

    public override string ToString() => string.Format("{0} ({1})", new object[2]
    {
      (object) this.Itag,
      (object) this.Container
    });
  }
}
