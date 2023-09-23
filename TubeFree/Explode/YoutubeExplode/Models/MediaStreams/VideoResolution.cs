// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.VideoResolution
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models.MediaStreams
{
  public struct VideoResolution : IEquatable<VideoResolution>
  {
    public int Width { get; }

    public int Height { get; }

    public VideoResolution(int width, int height)
    {
      this.Width = width.GuardNotNegative(nameof (width));
      this.Height = height.GuardNotNegative(nameof (height));
    }

    public override bool Equals(object obj) => false;

    public bool Equals(VideoResolution other) => this.Width == other.Width && this.Height == other.Height;

    public override int GetHashCode() => this.Width * 397 ^ this.Height;

    public override string ToString() => string.Format("{0}x{1}", new object[2]
    {
      (object) this.Width,
      (object) this.Height
    });

    public static bool operator ==(VideoResolution r1, VideoResolution r2) => r1.Equals(r2);

    public static bool operator !=(VideoResolution r1, VideoResolution r2) => !(r1 == r2);
  }
}
