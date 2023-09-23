// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.Video
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models
{
  public class Video
  {
    [NotNull]
    public string Id { get; }

    [NotNull]
    public string Author { get; }

    public DateTimeOffset UploadDate { get; }

    [NotNull]
    public string Title { get; }

    [NotNull]
    public string Description { get; }

    [NotNull]
    public ThumbnailSet Thumbnails { get; }

    public TimeSpan Duration { get; }

    [NotNull]
    [ItemNotNull]
    public IReadOnlyList<string> Keywords { get; }

    [NotNull]
    public Statistics Statistics { get; }

    public Video(
      string id,
      string author,
      DateTimeOffset uploadDate,
      string title,
      string description,
      ThumbnailSet thumbnails,
      TimeSpan duration,
      IReadOnlyList<string> keywords,
      Statistics statistics)
    {
      this.Id = id.GuardNotNull<string>(nameof (id));
      this.Author = author.GuardNotNull<string>(nameof (author));
      this.UploadDate = uploadDate;
      this.Title = title.GuardNotNull<string>(nameof (title));
      this.Description = description.GuardNotNull<string>(nameof (description));
      this.Thumbnails = thumbnails.GuardNotNull<ThumbnailSet>(nameof (thumbnails));
      this.Duration = duration.GuardNotNegative(nameof (duration));
      this.Keywords = keywords.GuardNotNull<IReadOnlyList<string>>(nameof (keywords));
      this.Statistics = statistics.GuardNotNull<Statistics>(nameof (statistics));
    }

    public override string ToString() => this.Title;
  }
}
