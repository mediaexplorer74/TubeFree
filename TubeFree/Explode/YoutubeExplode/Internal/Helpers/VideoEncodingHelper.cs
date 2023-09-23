// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Helpers.VideoEncodingHelper
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeExplode.Internal.Helpers
{
  internal static class VideoEncodingHelper
  {
    public static VideoEncoding VideoEncodingFromString(string str)
    {
      if (str.StartsWith("mp4v", StringComparison.OrdinalIgnoreCase))
        return VideoEncoding.Mp4V;
      if (str.StartsWith("avc1", StringComparison.OrdinalIgnoreCase))
        return VideoEncoding.H264;
      if (str.StartsWith("vp8", StringComparison.OrdinalIgnoreCase))
        return VideoEncoding.Vp8;
      if (str.StartsWith("vp9", StringComparison.OrdinalIgnoreCase))
        return VideoEncoding.Vp9;
      if (str.StartsWith("av01", StringComparison.OrdinalIgnoreCase))
        return VideoEncoding.Av1;
      throw new ArgumentOutOfRangeException(nameof (str), string.Format("Unknown encoding [{0}].", new object[1]
      {
        (object) str
      }));
    }
  }
}
