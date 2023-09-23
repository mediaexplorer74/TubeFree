// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Exceptions.VideoRequiresPurchaseException
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using YoutubeExplode.Internal;

namespace YoutubeExplode.Exceptions
{
  public class VideoRequiresPurchaseException : VideoUnplayableException
  {
    public string PreviewVideoId { get; }

    public VideoRequiresPurchaseException(string previewVideoId, string videoId, string message)
      : base(videoId, message)
    {
      this.PreviewVideoId = previewVideoId.GuardNotNull<string>(nameof (previewVideoId));
    }
  }
}
