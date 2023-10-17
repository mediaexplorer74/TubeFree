// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Helpers.AudioEncodingHelper
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeExplode.Internal.Helpers
{
  internal static class AudioEncodingHelper
  {
    public static AudioEncoding AudioEncodingFromString(string str)
    {
      if (str.StartsWith("mp4a", StringComparison.OrdinalIgnoreCase))
        return AudioEncoding.Aac;
      if (str.StartsWith("vorbis", StringComparison.OrdinalIgnoreCase))
        return AudioEncoding.Vorbis;
      if (str.StartsWith("opus", StringComparison.OrdinalIgnoreCase))
        return AudioEncoding.Opus;
      throw new ArgumentOutOfRangeException(nameof (str), string.Format("Unknown encoding [{0}].", new object[1]
      {
        (object) str
      }));
    }
  }
}
