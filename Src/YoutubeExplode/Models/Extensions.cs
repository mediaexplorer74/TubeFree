// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.Extensions
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System.Linq;
using YoutubeExplode.Internal;

namespace YoutubeExplode.Models
{
  public static class Extensions
  {
    public static string GetUrl(this Video video)
    {
      video.GuardNotNull<Video>(nameof (video));
      return string.Format("https://www.youtube.com/watch?v={0}", new object[1]
      {
        (object) video.Id
      });
    }

    public static string GetShortUrl(this Video video)
    {
      video.GuardNotNull<Video>(nameof (video));
      return string.Format("https://youtu.be/{0}", new object[1]
      {
        (object) video.Id
      });
    }

    public static string GetEmbedUrl(this Video video)
    {
      video.GuardNotNull<Video>(nameof (video));
      return string.Format("https://www.youtube.com/embed/{0}", new object[1]
      {
        (object) video.Id
      });
    }

    public static string GetUrl(this Playlist playlist)
    {
      playlist.GuardNotNull<Playlist>(nameof (playlist));
      return string.Format("https://www.youtube.com/playlist?list={0}", new object[1]
      {
        (object) playlist.Id
      });
    }

    public static string GetWatchUrl(this Playlist playlist)
    {
      playlist.GuardNotNull<Playlist>(nameof (playlist));
      return string.Format("https://www.youtube.com/watch?v={0}&list={1}", new object[2]
      {
        (object) playlist.Videos.First<Video>().Id,
        (object) playlist.Id
      });
    }

    public static string GetShortUrl(this Playlist playlist)
    {
      playlist.GuardNotNull<Playlist>(nameof (playlist));
      return string.Format("https://www.youtu.be/{0}/?list={1}", new object[2]
      {
        (object) playlist.Videos.First<Video>().Id,
        (object) playlist.Id
      });
    }

    public static string GetEmbedUrl(this Playlist playlist)
    {
      playlist.GuardNotNull<Playlist>(nameof (playlist));
      return string.Format("https://www.youtube.com/embed/{0}/?list={1}", new object[2]
      {
        (object) playlist.Videos.First<Video>().Id,
        (object) playlist.Id
      });
    }

    public static string GetUrl(this Channel channel)
    {
      channel.GuardNotNull<Channel>(nameof (channel));
      return string.Format("https://www.youtube.com/channel/{0}", new object[1]
      {
        (object) channel.Id
      });
    }

    public static string GetVideoMixPlaylistId(this Video video)
    {
      video.GuardNotNull<Video>(nameof (video));
      return "RD" + video.Id;
    }

    public static string GetChannelVideoMixPlaylistId(this Video video)
    {
      video.GuardNotNull<Video>(nameof (video));
      return "UL" + video.Id;
    }

    public static string GetChannelVideosPlaylistId(this Channel channel)
    {
      channel.GuardNotNull<Channel>(nameof (channel));
      return "UU" + channel.Id.SubstringAfter("UC");
    }

    public static string GetPopularChannelVideosPlaylistId(this Channel channel)
    {
      channel.GuardNotNull<Channel>(nameof (channel));
      return "PU" + channel.Id.SubstringAfter("UC");
    }

    public static string GetLikedVideosPlaylistId(this Channel channel)
    {
      channel.GuardNotNull<Channel>(nameof (channel));
      return "LL" + channel.Id.SubstringAfter("UC");
    }

    public static string GetFavoritesPlaylistId(this Channel channel)
    {
      channel.GuardNotNull<Channel>(nameof (channel));
      return "FL" + channel.Id.SubstringAfter("UC");
    }
  }
}
