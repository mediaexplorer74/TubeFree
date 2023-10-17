// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.ThumbnailSet
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models
{
  public class ThumbnailSet
  {
    private readonly string _videoId;

    [NotNull]
    public string LowResUrl => string.Format("https://img.youtube.com/vi/{0}/default.jpg", new object[1]
    {
      (object) this._videoId
    });

    [NotNull]
    public string MediumResUrl => string.Format("https://img.youtube.com/vi/{0}/mqdefault.jpg", new object[1]
    {
      (object) this._videoId
    });

    [NotNull]
    public string HighResUrl => string.Format("https://img.youtube.com/vi/{0}/hqdefault.jpg", new object[1]
    {
      (object) this._videoId
    });

    [NotNull]
    public string StandardResUrl => string.Format("https://img.youtube.com/vi/{0}/sddefault.jpg", new object[1]
    {
      (object) this._videoId
    });

    [NotNull]
    public string MaxResUrl => string.Format("https://img.youtube.com/vi/{0}/maxresdefault.jpg", new object[1]
    {
      (object) this._videoId
    });

    public ThumbnailSet(string videoId) => this._videoId = videoId.GuardNotNull<string>(nameof (videoId));
  }
}
