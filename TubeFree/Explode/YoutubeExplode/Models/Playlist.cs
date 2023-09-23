// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.Playlist
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models
{
  public class Playlist
  {
    [NotNull]
    public string Id { get; }

    public PlaylistType Type { get; }

    [NotNull]
    public string Author { get; }

    [NotNull]
    public string Title { get; }

    [NotNull]
    public string Description { get; }

    [NotNull]
    public Statistics Statistics { get; }

    [NotNull]
    [ItemNotNull]
    public IReadOnlyList<Video> Videos { get; }

    public Playlist(
      string id,
      string author,
      string title,
      string description,
      Statistics statistics,
      IReadOnlyList<Video> videos)
    {
      this.Id = id.GuardNotNull<string>(nameof (id));
      this.Type = Playlist.GetPlaylistType(id);
      this.Author = author.GuardNotNull<string>(nameof (author));
      this.Title = title.GuardNotNull<string>(nameof (title));
      this.Description = description.GuardNotNull<string>(nameof (description));
      this.Statistics = statistics.GuardNotNull<Statistics>(nameof (statistics));
      this.Videos = videos.GuardNotNull<IReadOnlyList<Video>>(nameof (videos));
    }

    public override string ToString() => this.Title;

    protected static PlaylistType GetPlaylistType(string id)
    {
      id.GuardNotNull<string>(nameof (id));
      if (id.StartsWith("PL", StringComparison.Ordinal))
        return PlaylistType.Normal;
      if (id.StartsWith("RD", StringComparison.Ordinal))
        return PlaylistType.VideoMix;
      if (id.StartsWith("UL", StringComparison.Ordinal))
        return PlaylistType.ChannelVideoMix;
      if (id.StartsWith("UU", StringComparison.Ordinal))
        return PlaylistType.ChannelVideos;
      if (id.StartsWith("PU", StringComparison.Ordinal))
        return PlaylistType.PopularChannelVideos;
      if (id.StartsWith("OL", StringComparison.Ordinal))
        return PlaylistType.MusicAlbum;
      if (id.StartsWith("LL", StringComparison.Ordinal))
        return PlaylistType.LikedVideos;
      if (id.StartsWith("FL", StringComparison.Ordinal))
        return PlaylistType.Favorites;
      if (id.StartsWith("WL", StringComparison.Ordinal))
        return PlaylistType.WatchLater;
      throw new ArgumentOutOfRangeException(nameof (id), string.Format("Unexpected playlist ID [{0}].", new object[1]
      {
        (object) id
      }));
    }
  }
}
