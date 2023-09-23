// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.Channel
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models
{
  public class Channel
  {
    [NotNull]
    public string Id { get; }

    [NotNull]
    public string Title { get; }

    [NotNull]
    public string LogoUrl { get; }

    public Channel(string id, string title, string logoUrl)
    {
      this.Id = id.GuardNotNull<string>(nameof (id));
      this.Title = title.GuardNotNull<string>(nameof (title));
      this.LogoUrl = logoUrl.GuardNotNull<string>(nameof (logoUrl));
    }

    public override string ToString() => this.Title;
  }
}
