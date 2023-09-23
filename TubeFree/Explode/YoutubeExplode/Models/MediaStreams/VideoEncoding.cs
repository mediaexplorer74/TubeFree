// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.VideoEncoding
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace YoutubeExplode.Models.MediaStreams
{
  public enum VideoEncoding
  {
    Mp4V,
    [Obsolete("Not available anymore.")] H263,
    H264,
    Vp8,
    Vp9,
    Av1,
  }
}
