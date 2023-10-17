// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.IYoutubeClient
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode.Models;
using YoutubeExplode.Models.ClosedCaptions;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeExplode
{
  public interface IYoutubeClient
  {
    Task<Video> GetVideoAsync(string videoId);

    Task<Channel> GetVideoAuthorChannelAsync(string videoId);

    Task<MediaStreamInfoSet> GetVideoMediaStreamInfosAsync(string videoId);

    Task<IReadOnlyList<ClosedCaptionTrackInfo>> GetVideoClosedCaptionTrackInfosAsync(string videoId);

    Task<Playlist> GetPlaylistAsync(string playlistId, int maxPages);

    Task<Playlist> GetPlaylistAsync(string playlistId);

    Task<IReadOnlyList<Video>> SearchVideosAsync(string query, int maxPages);

    Task<IReadOnlyList<Video>> SearchVideosAsync(string query);

    Task<string> GetChannelIdAsync(string username);

    Task<Channel> GetChannelAsync(string channelId);

    Task<IReadOnlyList<Video>> GetChannelUploadsAsync(string channelId, int maxPages);

    Task<IReadOnlyList<Video>> GetChannelUploadsAsync(string channelId);

    Task<MediaStream> GetMediaStreamAsync(MediaStreamInfo info);

    Task DownloadMediaStreamAsync(
      MediaStreamInfo info,
      Stream output,
      IProgress<double> progress = null,
      CancellationToken cancellationToken = default (CancellationToken));

    Task<ClosedCaptionTrack> GetClosedCaptionTrackAsync(ClosedCaptionTrackInfo info);

    Task DownloadClosedCaptionTrackAsync(
      ClosedCaptionTrackInfo info,
      Stream output,
      IProgress<double> progress = null,
      CancellationToken cancellationToken = default (CancellationToken));
  }
}
