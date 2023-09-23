// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.YoutubeClient
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode.Exceptions;
using YoutubeExplode.Internal;
using YoutubeExplode.Internal.Helpers;
using YoutubeExplode.Internal.Parsers;
using YoutubeExplode.Models;
using YoutubeExplode.Models.ClosedCaptions;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeExplode
{
  public class YoutubeClient : IYoutubeClient
  {
    private readonly HttpClient _httpClient;

    public async Task<string> GetChannelIdAsync(string username)
    {
      username.GuardNotNull<string>(nameof (username));
      if (!YoutubeClient.ValidateUsername(username))
        throw new ArgumentException(string.Format("Invalid YouTube username [{0}].", new object[1]
        {
          (object) username
        }));
      return (await this.GetChannelPageParserByUsernameAsync(username).ConfigureAwait(false)).ParseChannelId();
    }

    public async Task<Channel> GetChannelAsync(string channelId)
    {
      channelId.GuardNotNull<string>(nameof (channelId));
      Video video = YoutubeClient.ValidateChannelId(channelId) ? (await this.GetChannelUploadsAsync(channelId, 1).ConfigureAwait(false)).FirstOrDefault<Video>() : throw new ArgumentException(string.Format("Invalid YouTube channel ID [{0}].", new object[1]
      {
        (object) channelId
      }), nameof (channelId));
      if (video == null)
        throw new InvalidOperationException("Channel contains no videos.");
      return await this.GetVideoAuthorChannelAsync(video.Id).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<Video>> GetChannelUploadsAsync(string channelId, int maxPages)
    {
      channelId.GuardNotNull<string>(nameof (channelId));
      maxPages.GuardPositive(nameof (maxPages));
      if (!YoutubeClient.ValidateChannelId(channelId))
        throw new ArgumentException(string.Format("Invalid YouTube channel ID [{0}].", new object[1]
        {
          (object) channelId
        }), nameof (channelId));
      return (await this.GetPlaylistAsync("UU" + channelId.SubstringAfter("UC"), maxPages).ConfigureAwait(false)).Videos;
    }

    public Task<IReadOnlyList<Video>> GetChannelUploadsAsync(string channelId) => this.GetChannelUploadsAsync(channelId, int.MaxValue);

    public async Task<ClosedCaptionTrack> GetClosedCaptionTrackAsync(ClosedCaptionTrackInfo info)
    {
      info.GuardNotNull<ClosedCaptionTrackInfo>(nameof (info));
      ClosedCaptionTrackAjaxParser captionTrackAjaxParser = await this.GetClosedCaptionTrackAjaxParserAsync(info.Url).ConfigureAwait(false);
      List<ClosedCaption> captions = new List<ClosedCaption>();
      foreach (ClosedCaptionTrackAjaxParser.ClosedCaptionParser closedCaption1 in captionTrackAjaxParser.GetClosedCaptions())
      {
        string text = closedCaption1.ParseText();
        if (!text.IsBlank())
        {
          TimeSpan offset = closedCaption1.ParseOffset();
          TimeSpan duration = closedCaption1.ParseDuration();
          ClosedCaption closedCaption2 = new ClosedCaption(text, offset, duration);
          captions.Add(closedCaption2);
        }
      }
      return new ClosedCaptionTrack(info, (IReadOnlyList<ClosedCaption>) captions);
    }

    public async Task DownloadClosedCaptionTrackAsync(
      ClosedCaptionTrackInfo info,
      Stream output,
      IProgress<double> progress = null,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      info.GuardNotNull<ClosedCaptionTrackInfo>(nameof (info));
      output.GuardNotNull<Stream>(nameof (output));
      ClosedCaptionTrack track = await this.GetClosedCaptionTrackAsync(info).ConfigureAwait(false);
      using (StreamWriter writer = new StreamWriter(output, Encoding.UTF8, 1024, true))
      {
        for (int i = 0; i < track.Captions.Count; ++i)
        {
          cancellationToken.ThrowIfCancellationRequested();
          ClosedCaption caption = track.Captions[i];
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.AppendLine((i + 1).ToString());
          stringBuilder.Append(caption.Offset.ToString("hh\\:mm\\:ss\\,fff"));
          stringBuilder.Append(" --> ");
          stringBuilder.Append((caption.Offset + caption.Duration).ToString("hh\\:mm\\:ss\\,fff"));
          stringBuilder.AppendLine();
          stringBuilder.AppendLine(caption.Text);
          await writer.WriteLineAsync(stringBuilder.ToString()).ConfigureAwait(false);
          progress?.Report(((double) i + 1.0) / (double) track.Captions.Count);
        }
      }
    }

    public YoutubeClient(HttpClient httpClient) => this._httpClient = httpClient.GuardNotNull<HttpClient>(nameof (httpClient));

    public YoutubeClient()
      : this(HttpClientEx.GetSingleton())
    {
    }

    private async Task<VideoWatchPageParser> GetVideoWatchPageParserAsync(string videoId) => VideoWatchPageParser.Initialize(await this._httpClient.GetStringAsync(string.Format("https://www.youtube.com/watch?v={0}&disable_polymer=true&bpctr=9999999999&hl=en", new object[1]
    {
      (object) videoId
    })).ConfigureAwait(false));

    private async Task<VideoInfoParser> GetVideoInfoParserAsync(string videoId, string el = "embedded")
    {
      string str = string.Format("https://youtube.googleapis.com/v/{0}", new object[1]
      {
        (object) videoId
      }).UrlEncode();
      string requestUri = string.Format("https://www.youtube.com/get_video_info?video_id={0}&el={1}&eurl={2}&hl=en", new object[3]
      {
        (object) videoId,
        (object) el,
        (object) str
      });
      this._httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0");
      return VideoInfoParser.Initialize(await this._httpClient.GetStringAsync(requestUri).ConfigureAwait(false));
    }

    private async Task<PlayerResponseParser> GetPlayerResponseParserAsync(
      string videoId,
      bool ensureIsPlayable = false)
    {
      PlayerResponseParser playerResponse = (await this.GetVideoInfoParserAsync(videoId).ConfigureAwait(false)).GetPlayerResponse();
      if (!playerResponse.ParseIsAvailable())
      {
        string errorReason = playerResponse.ParseErrorReason();
        throw new VideoUnavailableException(videoId, string.Format("Video [{0}] is unavailable. (Reason: {1})", new object[2]
        {
          (object) videoId,
          (object) errorReason
        }));
      }
      if (ensureIsPlayable && !playerResponse.ParseIsPlayable())
      {
        VideoWatchPageParser.ConfigParser config = (await this.GetVideoWatchPageParserAsync(videoId).ConfigureAwait(false)).GetConfig();
        playerResponse = config.GetPlayerResponse();
        if (!playerResponse.ParseIsPlayable())
        {
          string errorReason = playerResponse.ParseErrorReason();
          string previewVideoId = config.ParsePreviewVideoId();
          if (previewVideoId.IsNotBlank())
            throw new VideoRequiresPurchaseException(previewVideoId, videoId, string.Format("Video [{0}] is unplayable because it requires purchase. (Reason: {1})", new object[2]
            {
              (object) videoId,
              (object) errorReason
            }));
          throw new VideoUnplayableException(videoId, string.Format("Video [{0}] is unplayable. (Reason: {1})", new object[2]
          {
            (object) videoId,
            (object) errorReason
          }));
        }
      }
      return playerResponse;
    }

    private async Task<DashManifestParser> GetDashManifestParserAsync(string dashManifestUrl) => DashManifestParser.Initialize(await this._httpClient.GetStringAsync(dashManifestUrl).ConfigureAwait(false));

    private async Task<ClosedCaptionTrackAjaxParser> GetClosedCaptionTrackAjaxParserAsync(string url) => ClosedCaptionTrackAjaxParser.Initialize(await this._httpClient.GetStringAsync(url).ConfigureAwait(false));

    private async Task<ChannelPageParser> GetChannelPageParserAsync(string channelId)
    {
      string url = string.Format("https://www.youtube.com/channel/{0}?hl=en", new object[1]
      {
        (object) channelId
      });
      for (int retry = 0; retry < 5; ++retry)
      {
        ChannelPageParser channelPageParserAsync = ChannelPageParser.Initialize(await this._httpClient.GetStringAsync(url).ConfigureAwait(false));
        if (channelPageParserAsync.ParseIsAvailable())
          return channelPageParserAsync;
        await Task.Delay(150).ConfigureAwait(false);
      }
      throw new InvalidDataException("Could not get channel page.");
    }

    private async Task<ChannelPageParser> GetChannelPageParserByUsernameAsync(string username)
    {
      username = username.UrlEncode();
      string url = string.Format("https://www.youtube.com/user/{0}?hl=en", new object[1]
      {
        (object) username
      });
      for (int retry = 0; retry < 5; ++retry)
      {
        ChannelPageParser parserByUsernameAsync = ChannelPageParser.Initialize(await this._httpClient.GetStringAsync(url).ConfigureAwait(false));
        if (parserByUsernameAsync.ParseIsAvailable())
          return parserByUsernameAsync;
        await Task.Delay(150).ConfigureAwait(false);
      }
      throw new InvalidDataException("Could not get channel page.");
    }

    private async Task<PlaylistAjaxParser> GetPlaylistAjaxParserAsync(string playlistId, int index) => PlaylistAjaxParser.Initialize(await this._httpClient.GetStringAsync(string.Format("https://www.youtube.com/list_ajax?style=json&action_get_list=1&list={0}&index={1}&hl=en", new object[2]
    {
      (object) playlistId,
      (object) index
    })).ConfigureAwait(false));

    private async Task<PlaylistAjaxParser> GetPlaylistAjaxParserForSearchAsync(
      string query,
      int page)
    {
      query = query.UrlEncode();
      return PlaylistAjaxParser.Initialize(await this._httpClient.GetStringAsync(string.Format("https://www.youtube.com/search_ajax?style=json&search_query={0}&page={1}&hl=en", new object[2]
      {
        (object) query,
        (object) page
      }), false).ConfigureAwait(false));
    }

    public Task<MediaStream> GetMediaStreamAsync(MediaStreamInfo info)
    {
      info.GuardNotNull<MediaStreamInfo>(nameof (info));
      int num = !Regex.IsMatch(info.Url, "ratebypass[=/]yes") ? 1 : 0;
      SegmentedHttpStream segmentedStream = this._httpClient.CreateSegmentedStream(info.Url, info.Size, long.MaxValue);
      return Task.FromResult<MediaStream>(new MediaStream(info, (Stream) segmentedStream));
    }

    public async Task DownloadMediaStreamAsync(
      MediaStreamInfo info,
      Stream output,
      IProgress<double> progress = null,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      info.GuardNotNull<MediaStreamInfo>(nameof (info));
      output.GuardNotNull<Stream>(nameof (output));
      using (MediaStream input = await this.GetMediaStreamAsync(info).ConfigureAwait(false))
        await input.CopyToAsync(output, progress, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Playlist> GetPlaylistAsync(string playlistId, int maxPages)
    {
      playlistId.GuardNotNull<string>(nameof (playlistId));
      maxPages.GuardPositive(nameof (maxPages));
      if (!YoutubeClient.ValidatePlaylistId(playlistId))
        throw new ArgumentException(string.Format("Invalid YouTube playlist ID [{0}].", new object[1]
        {
          (object) playlistId
        }), nameof (playlistId));
      PlaylistAjaxParser playlistAjaxParser = await this.GetPlaylistAjaxParserAsync(playlistId, 0).ConfigureAwait(false);
      string author = playlistAjaxParser.ParseAuthor();
      string title = playlistAjaxParser.ParseTitle();
      string description = playlistAjaxParser.ParseDescription();
      long viewCount = playlistAjaxParser.ParseViewCount();
      long likeCount = playlistAjaxParser.ParseLikeCount();
      long dislikeCount = playlistAjaxParser.ParseDislikeCount();
      int page = 0;
      int index = 0;
      HashSet<string> videoIds = new HashSet<string>();
      List<Video> videos = new List<Video>();
      do
      {
        int num1 = 0;
        int num2 = 0;
        foreach (PlaylistAjaxParser.VideoParser video1 in playlistAjaxParser.GetVideos())
        {
          string id = video1.ParseId();
          string author1 = video1.ParseAuthor();
          DateTimeOffset uploadDate = video1.ParseUploadDate();
          string title1 = video1.ParseTitle();
          string description1 = video1.ParseDescription();
          TimeSpan duration = video1.ParseDuration();
          IReadOnlyList<string> keywords = video1.ParseKeywords();
          Statistics statistics = new Statistics(video1.ParseViewCount(), video1.ParseLikeCount(), video1.ParseDislikeCount());
          ThumbnailSet thumbnails = new ThumbnailSet(id);
          Video video2 = new Video(id, author1, uploadDate, title1, description1, thumbnails, duration, keywords, statistics);
          if (videoIds.Add(video2.Id))
          {
            videos.Add(video2);
            ++num2;
          }
          ++num1;
        }
        if (num2 > 0)
        {
          ++page;
          index += num1;
          playlistAjaxParser = await this.GetPlaylistAjaxParserAsync(playlistId, index).ConfigureAwait(false);
        }
        else
          break;
      }
      while (page < maxPages);
      return new Playlist(playlistId, author, title, description, new Statistics(viewCount, likeCount, dislikeCount), (IReadOnlyList<Video>) videos);
    }

    public Task<Playlist> GetPlaylistAsync(string playlistId) => this.GetPlaylistAsync(playlistId, int.MaxValue);

    public async Task<IReadOnlyList<Video>> SearchVideosAsync(string query, int maxPages)
    {
      query.GuardNotNull<string>(nameof (query));
      maxPages.GuardPositive(nameof (maxPages));
      List<Video> videos = new List<Video>();
      for (int page = 1; page <= maxPages; ++page)
      {
        PlaylistAjaxParser playlistAjaxParser = await this.GetPlaylistAjaxParserForSearchAsync(query, page).ConfigureAwait(false);
        int num = 0;
        foreach (PlaylistAjaxParser.VideoParser video in playlistAjaxParser.GetVideos())
        {
          string id = video.ParseId();
          string author = video.ParseAuthor();
          DateTimeOffset uploadDate = video.ParseUploadDate();
          string title = video.ParseTitle();
          string description = video.ParseDescription();
          TimeSpan duration = video.ParseDuration();
          IReadOnlyList<string> keywords = video.ParseKeywords();
          Statistics statistics = new Statistics(video.ParseViewCount(), video.ParseLikeCount(), video.ParseDislikeCount());
          ThumbnailSet thumbnails = new ThumbnailSet(id);
          videos.Add(new Video(id, author, uploadDate, title, description, thumbnails, duration, keywords, statistics));
          ++num;
        }
        if (num <= 0)
          break;
      }
      return (IReadOnlyList<Video>) videos;
    }

    public Task<IReadOnlyList<Video>> SearchVideosAsync(string query) => this.SearchVideosAsync(query, int.MaxValue);

    public static bool ValidateVideoId(string videoId) => !videoId.IsBlank() && videoId.Length == 11 && !Regex.IsMatch(videoId, "[^0-9a-zA-Z_\\-]");

    public static bool TryParseVideoId(string videoUrl, out string videoId)
    {
      videoId = (string) null;
      if (videoUrl.IsBlank())
        return false;
      string str1 = Regex.Match(videoUrl, "youtube\\..+?/watch.*?v=(.*?)(?:&|/|$)").Groups[1].Value;
      if (str1.IsNotBlank() && YoutubeClient.ValidateVideoId(str1))
      {
        videoId = str1;
        return true;
      }
      string str2 = Regex.Match(videoUrl, "youtu\\.be/(.*?)(?:\\?|&|/|$)").Groups[1].Value;
      if (str2.IsNotBlank() && YoutubeClient.ValidateVideoId(str2))
      {
        videoId = str2;
        return true;
      }
      string str3 = Regex.Match(videoUrl, "youtube\\..+?/embed/(.*?)(?:\\?|&|/|$)").Groups[1].Value;
      if (!str3.IsNotBlank() || !YoutubeClient.ValidateVideoId(str3))
        return false;
      videoId = str3;
      return true;
    }

    public static string ParseVideoId(string videoUrl)
    {
      videoUrl.GuardNotNull<string>(nameof (videoUrl));
      string videoId;
      if (YoutubeClient.TryParseVideoId(videoUrl, out videoId))
        return videoId;
      throw new FormatException(string.Format("Could not parse video ID from given string [{0}].", new object[1]
      {
        (object) videoUrl
      }));
    }

    public static bool ValidatePlaylistId(string playlistId)
    {
      if (playlistId.IsBlank())
        return false;
      if (playlistId == "WL")
        return true;
      return (playlistId.StartsWith("PL", StringComparison.Ordinal) || playlistId.StartsWith("RD", StringComparison.Ordinal) || playlistId.StartsWith("UL", StringComparison.Ordinal) || playlistId.StartsWith("UU", StringComparison.Ordinal) || playlistId.StartsWith("PU", StringComparison.Ordinal) || playlistId.StartsWith("OL", StringComparison.Ordinal) || playlistId.StartsWith("LL", StringComparison.Ordinal) || playlistId.StartsWith("FL", StringComparison.Ordinal)) && playlistId.Length >= 13 && playlistId.Length <= 42 && !Regex.IsMatch(playlistId, "[^0-9a-zA-Z_\\-]");
    }

    public static bool TryParsePlaylistId(string playlistUrl, out string playlistId)
    {
      playlistId = (string) null;
      if (playlistUrl.IsBlank())
        return false;
      string str1 = Regex.Match(playlistUrl, "youtube\\..+?/playlist.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
      if (str1.IsNotBlank() && YoutubeClient.ValidatePlaylistId(str1))
      {
        playlistId = str1;
        return true;
      }
      string str2 = Regex.Match(playlistUrl, "youtube\\..+?/watch.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
      if (str2.IsNotBlank() && YoutubeClient.ValidatePlaylistId(str2))
      {
        playlistId = str2;
        return true;
      }
      string str3 = Regex.Match(playlistUrl, "youtu\\.be/.*?/.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
      if (str3.IsNotBlank() && YoutubeClient.ValidatePlaylistId(str3))
      {
        playlistId = str3;
        return true;
      }
      string str4 = Regex.Match(playlistUrl, "youtube\\..+?/embed/.*?/.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
      if (!str4.IsNotBlank() || !YoutubeClient.ValidatePlaylistId(str4))
        return false;
      playlistId = str4;
      return true;
    }

    public static string ParsePlaylistId(string playlistUrl)
    {
      playlistUrl.GuardNotNull<string>(nameof (playlistUrl));
      string playlistId = (string) null;
      if (YoutubeClient.TryParsePlaylistId(playlistUrl, out playlistId))
        return playlistId;
      throw new FormatException(string.Format("Could not parse playlist ID from given string [{0}].", new object[1]
      {
        (object) playlistUrl
      }));
    }

    public static bool ValidateUsername(string username) => !username.IsBlank() && username.Length <= 20 && !Regex.IsMatch(username, "[^0-9a-zA-Z]");

    public static bool TryParseUsername(string userUrl, out string username)
    {
      username = (string) null;
      if (userUrl.IsBlank())
        return false;
      string str = Regex.Match(userUrl, "youtube\\..+?/user/(.*?)(?:&|/|$)").Groups[1].Value;
      if (!str.IsNotBlank() || !YoutubeClient.ValidateUsername(str))
        return false;
      username = str;
      return true;
    }

    public static string ParseUsername(string userUrl)
    {
      userUrl.GuardNotNull<string>(nameof (userUrl));
      string username;
      if (YoutubeClient.TryParseUsername(userUrl, out username))
        return username;
      throw new FormatException(string.Format("Could not parse username from given string [{0}].", new object[1]
      {
        (object) userUrl
      }));
    }

    public static bool ValidateChannelId(string channelId) => !channelId.IsBlank() && channelId.StartsWith("UC", StringComparison.Ordinal) && channelId.Length == 24 && !Regex.IsMatch(channelId, "[^0-9a-zA-Z_\\-]");

    public static bool TryParseChannelId(string channelUrl, out string channelId)
    {
      channelId = (string) null;
      if (channelUrl.IsBlank())
        return false;
      string str = Regex.Match(channelUrl, "youtube\\..+?/channel/(.*?)(?:&|/|$)").Groups[1].Value;
      if (!str.IsNotBlank() || !YoutubeClient.ValidateChannelId(str))
        return false;
      channelId = str;
      return true;
    }

    public static string ParseChannelId(string channelUrl)
    {
      channelUrl.GuardNotNull<string>(nameof (channelUrl));
      string channelId;
      if (YoutubeClient.TryParseChannelId(channelUrl, out channelId))
        return channelId;
      throw new FormatException(string.Format("Could not parse channel ID from given string [{0}].", new object[1]
      {
        (object) channelUrl
      }));
    }

    public async Task<Video> GetVideoAsync(string videoId)
    {
      videoId.GuardNotNull<string>(nameof (videoId));
      if (!YoutubeClient.ValidateVideoId(videoId))
        throw new ArgumentException(string.Format("Invalid YouTube video ID [{0}].", new object[1]
        {
          (object) videoId
        }), nameof (videoId));
      PlayerResponseParser playerResponseParser = await this.GetPlayerResponseParserAsync(videoId).ConfigureAwait(false);
      string author = playerResponseParser.ParseAuthor();
      string title = playerResponseParser.ParseTitle();
      TimeSpan duration = playerResponseParser.ParseDuration();
      IReadOnlyList<string> keywords = playerResponseParser.ParseKeywords();
      VideoWatchPageParser videoWatchPageParser = await this.GetVideoWatchPageParserAsync(videoId).ConfigureAwait(false);
      DateTimeOffset uploadDate = videoWatchPageParser.ParseUploadDate();
      string description = videoWatchPageParser.ParseDescription();
      Statistics statistics = new Statistics(videoWatchPageParser.ParseViewCount(), videoWatchPageParser.ParseLikeCount(), videoWatchPageParser.ParseDislikeCount());
      ThumbnailSet thumbnails = new ThumbnailSet(videoId);
      return new Video(videoId, author, uploadDate, title, description, thumbnails, duration, keywords, statistics);
    }

    public async Task<Channel> GetVideoAuthorChannelAsync(string videoId)
    {
      videoId.GuardNotNull<string>(nameof (videoId));
      if (!YoutubeClient.ValidateVideoId(videoId))
        throw new ArgumentException(string.Format("Invalid YouTube video ID [{0}].", new object[1]
        {
          (object) videoId
        }), nameof (videoId));
      string id = (await this.GetPlayerResponseParserAsync(videoId).ConfigureAwait(false)).ParseChannelId();
      ChannelPageParser channelPageParser = await this.GetChannelPageParserAsync(id).ConfigureAwait(false);
      return new Channel(id, channelPageParser.ParseChannelTitle(), channelPageParser.ParseChannelLogoUrl());
    }

    public async Task<MediaStreamInfoSet> GetVideoMediaStreamInfosAsync(string videoId)
    {
      videoId.GuardNotNull<string>(nameof (videoId));
      if (!YoutubeClient.ValidateVideoId(videoId))
        throw new ArgumentException(string.Format("Invalid YouTube video ID [{0}].", new object[1]
        {
          (object) videoId
        }), nameof (videoId));
      DateTimeOffset requestedAt = DateTimeOffset.Now;
      PlayerResponseParser parser = await this.GetPlayerResponseParserAsync(videoId, true).ConfigureAwait(false);
      Dictionary<int, MuxedStreamInfo> muxedStreamInfoMap = new Dictionary<int, MuxedStreamInfo>();
      Dictionary<int, AudioStreamInfo> audioStreamInfoMap = new Dictionary<int, AudioStreamInfo>();
      Dictionary<int, VideoStreamInfo> videoStreamInfoMap = new Dictionary<int, VideoStreamInfo>();
      foreach (PlayerResponseParser.StreamInfoParser streamInfoParser in parser.GetMuxedStreamInfos())
      {
        int itag = streamInfoParser.ParseItag();
        string url = streamInfoParser.ParseUrl();
        long size = streamInfoParser.ParseContentLength();
        if (size <= 0L)
        {
          size = await this._httpClient.GetContentLengthAsync(url, false).ConfigureAwait(false) ?? -1L;
          if (size <= 0L)
            continue;
        }
        Container container = ContainerHelper.ContainerFromString(streamInfoParser.ParseContainer());
        AudioEncoding audioEncoding = AudioEncodingHelper.AudioEncodingFromString(streamInfoParser.ParseAudioEncoding());
        VideoEncoding videoEncoding = VideoEncodingHelper.VideoEncodingFromString(streamInfoParser.ParseVideoEncoding());
        string videoQualityLabel = streamInfoParser.ParseVideoQualityLabel();
        VideoQuality videoQuality = VideoQualityHelper.VideoQualityFromLabel(videoQualityLabel);
        VideoResolution resolution = new VideoResolution(streamInfoParser.ParseWidth(), streamInfoParser.ParseHeight());
        muxedStreamInfoMap[itag] = new MuxedStreamInfo(itag, url, container, size, audioEncoding, videoEncoding, videoQualityLabel, videoQuality, resolution);
        url = (string) null;
      }
      foreach (PlayerResponseParser.StreamInfoParser streamInfoParser in parser.GetAdaptiveStreamInfos())
      {
        int itag = streamInfoParser.ParseItag();
        string url = streamInfoParser.ParseUrl();
        long bitrate = streamInfoParser.ParseBitrate();
        long size = streamInfoParser.ParseContentLength();
        if (size <= 0L)
        {
          size = await this._httpClient.GetContentLengthAsync(url, false).ConfigureAwait(false) ?? -1L;
          if (size <= 0L)
            continue;
        }
        Container container = ContainerHelper.ContainerFromString(streamInfoParser.ParseContainer());
        if (streamInfoParser.ParseIsAudioOnly())
        {
          AudioEncoding audioEncoding = AudioEncodingHelper.AudioEncodingFromString(streamInfoParser.ParseAudioEncoding());
          audioStreamInfoMap[itag] = new AudioStreamInfo(itag, url, container, size, bitrate, audioEncoding);
        }
        else
        {
          VideoEncoding videoEncoding = VideoEncodingHelper.VideoEncodingFromString(streamInfoParser.ParseVideoEncoding());
          string videoQualityLabel = streamInfoParser.ParseVideoQualityLabel();
          VideoQuality videoQuality = VideoQualityHelper.VideoQualityFromLabel(videoQualityLabel);
          VideoResolution resolution = new VideoResolution(streamInfoParser.ParseWidth(), streamInfoParser.ParseHeight());
          int framerate = streamInfoParser.ParseFramerate();
          videoStreamInfoMap[itag] = new VideoStreamInfo(itag, url, container, size, bitrate, videoEncoding, videoQualityLabel, videoQuality, resolution, framerate);
        }
        url = (string) null;
      }
      string dashManifestUrl = parser.ParseDashManifestUrl();
      if (dashManifestUrl.IsNotBlank())
      {
        foreach (DashManifestParser.StreamInfoParser streamInfo in (await this.GetDashManifestParserAsync(dashManifestUrl).ConfigureAwait(false)).GetStreamInfos())
        {
          int itag = streamInfo.ParseItag();
          string url = streamInfo.ParseUrl();
          long contentLength = streamInfo.ParseContentLength();
          long bitrate = streamInfo.ParseBitrate();
          Container container = ContainerHelper.ContainerFromString(streamInfo.ParseContainer());
          if (streamInfo.ParseIsAudioOnly())
          {
            AudioEncoding audioEncoding = AudioEncodingHelper.AudioEncodingFromString(streamInfo.ParseEncoding());
            AudioStreamInfo audioStreamInfo = new AudioStreamInfo(itag, url, container, contentLength, bitrate, audioEncoding);
            audioStreamInfoMap[itag] = audioStreamInfo;
          }
          else
          {
            VideoEncoding videoEncoding = VideoEncodingHelper.VideoEncodingFromString(streamInfo.ParseEncoding());
            int width = streamInfo.ParseWidth();
            int height = streamInfo.ParseHeight();
            VideoResolution resolution = new VideoResolution(width, height);
            int framerate = streamInfo.ParseFramerate();
            VideoQuality videoQuality = VideoQualityHelper.VideoQualityFromHeight(height);
            string label = VideoQualityHelper.VideoQualityToLabel(videoQuality, framerate);
            VideoStreamInfo videoStreamInfo = new VideoStreamInfo(itag, url, container, contentLength, bitrate, videoEncoding, label, videoQuality, resolution, framerate);
            videoStreamInfoMap[itag] = videoStreamInfo;
          }
        }
      }
      MuxedStreamInfo[] array1 = muxedStreamInfoMap.Values.OrderByDescending<MuxedStreamInfo, VideoQuality>((Func<MuxedStreamInfo, VideoQuality>) (s => s.VideoQuality)).ToArray<MuxedStreamInfo>();
      AudioStreamInfo[] array2 = audioStreamInfoMap.Values.OrderByDescending<AudioStreamInfo, long>((Func<AudioStreamInfo, long>) (s => s.Bitrate)).ToArray<AudioStreamInfo>();
      VideoStreamInfo[] array3 = videoStreamInfoMap.Values.OrderByDescending<VideoStreamInfo, VideoQuality>((Func<VideoStreamInfo, VideoQuality>) (s => s.VideoQuality)).ToArray<VideoStreamInfo>();
      string hlsManifestUrl = parser.ParseHlsManifestUrl();
      DateTimeOffset dateTimeOffset = requestedAt.Add(parser.ParseStreamInfoSetExpiresIn());
      AudioStreamInfo[] audio = array2;
      VideoStreamInfo[] video = array3;
      string hlsLiveStreamUrl = hlsManifestUrl;
      DateTimeOffset validUntil = dateTimeOffset;
      return new MediaStreamInfoSet((IReadOnlyList<MuxedStreamInfo>) array1, (IReadOnlyList<AudioStreamInfo>) audio, (IReadOnlyList<VideoStreamInfo>) video, hlsLiveStreamUrl, validUntil);
    }

    public async Task<IReadOnlyList<ClosedCaptionTrackInfo>> GetVideoClosedCaptionTrackInfosAsync(
      string videoId)
    {
      videoId.GuardNotNull<string>(nameof (videoId));
      if (!YoutubeClient.ValidateVideoId(videoId))
        throw new ArgumentException(string.Format("Invalid YouTube video ID [{0}].", new object[1]
        {
          (object) videoId
        }), nameof (videoId));
      PlayerResponseParser playerResponseParser = await this.GetPlayerResponseParserAsync(videoId).ConfigureAwait(false);
      List<ClosedCaptionTrackInfo> captionTrackInfosAsync = new List<ClosedCaptionTrackInfo>();
      foreach (PlayerResponseParser.ClosedCaptionTrackInfoParser captionTrackInfo1 in playerResponseParser.GetClosedCaptionTrackInfos())
      {
        string url = captionTrackInfo1.ParseUrl();
        bool isAutoGenerated = captionTrackInfo1.ParseIsAutoGenerated();
        Language language = new Language(captionTrackInfo1.ParseLanguageCode(), captionTrackInfo1.ParseLanguageName());
        ClosedCaptionTrackInfo captionTrackInfo2 = new ClosedCaptionTrackInfo(UrlEx.SetQueryParameter(url, "format", "3"), language, isAutoGenerated);
        captionTrackInfosAsync.Add(captionTrackInfo2);
      }
      return (IReadOnlyList<ClosedCaptionTrackInfo>) captionTrackInfosAsync;
    }
  }
}
