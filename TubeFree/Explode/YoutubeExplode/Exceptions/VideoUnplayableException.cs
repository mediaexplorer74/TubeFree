// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Exceptions.VideoUnplayableException
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Exceptions
{
  public class VideoUnplayableException : Exception
  {
    public string VideoId { get; }

    public VideoUnplayableException(string videoId, string message)
      : base(message)
    {
      this.VideoId = videoId.GuardNotNull<string>(nameof (videoId));
    }
  }
}
