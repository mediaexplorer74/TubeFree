// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.PlayerResponseParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YoutubeExplode.Internal.Parsers
{
  internal class PlayerResponseParser
  {
    private readonly JToken _root;

    public PlayerResponseParser(JToken root) => this._root = root;

    public bool ParseIsAvailable() => this._root.SelectToken("videoDetails") != null;

    public bool ParseIsPlayable()
    {
      JToken jtoken = this._root.SelectToken("playabilityStatus.status");
      return string.Equals(jtoken != null ? jtoken.Value<string>() : (string) null, "OK", StringComparison.OrdinalIgnoreCase);
    }

    public string ParseErrorReason()
    {
      JToken jtoken = this._root.SelectToken("playabilityStatus.reason");
      return jtoken == null ? (string) null : jtoken.Value<string>();
    }

    public string ParseAuthor() => this._root.SelectToken("videoDetails.author").Value<string>();

    public string ParseChannelId() => this._root.SelectToken("videoDetails.channelId").Value<string>();

    public string ParseTitle() => this._root.SelectToken("videoDetails.title").Value<string>();

    public TimeSpan ParseDuration() => TimeSpan.FromSeconds(this._root.SelectToken("videoDetails.lengthSeconds").Value<double>());

    public IReadOnlyList<string> ParseKeywords() => (IReadOnlyList<string>) this._root.SelectToken("videoDetails.keywords").EmptyIfNull<JToken>().Values<string>().ToArray<string>();

    public bool ParseIsLiveStream()
    {
      JToken jtoken = this._root.SelectToken("videoDetails.isLive");
      return jtoken != null && jtoken.Value<bool>();
    }

    public string ParseDashManifestUrl()
    {
      if (this.ParseIsLiveStream())
        return (string) null;
      JToken jtoken = this._root.SelectToken("streamingData.dashManifestUrl");
      return jtoken == null ? (string) null : jtoken.Value<string>();
    }

    public string ParseHlsManifestUrl()
    {
      JToken jtoken = this._root.SelectToken("streamingData.hlsManifestUrl");
      return jtoken == null ? (string) null : jtoken.Value<string>();
    }

    public TimeSpan ParseStreamInfoSetExpiresIn() => TimeSpan.FromSeconds(this._root.SelectToken("streamingData.expiresInSeconds").Value<double>());

    public IEnumerable<PlayerResponseParser.StreamInfoParser> GetMuxedStreamInfos() => this.ParseIsLiveStream() ? Enumerable.Empty<PlayerResponseParser.StreamInfoParser>() : this._root.SelectToken("streamingData.formats").EmptyIfNull<JToken>().Select<JToken, PlayerResponseParser.StreamInfoParser>((Func<JToken, PlayerResponseParser.StreamInfoParser>) (j => new PlayerResponseParser.StreamInfoParser(j)));

    public IEnumerable<PlayerResponseParser.StreamInfoParser> GetAdaptiveStreamInfos() => this.ParseIsLiveStream() ? Enumerable.Empty<PlayerResponseParser.StreamInfoParser>() : this._root.SelectToken("streamingData.adaptiveFormats").EmptyIfNull<JToken>().Select<JToken, PlayerResponseParser.StreamInfoParser>((Func<JToken, PlayerResponseParser.StreamInfoParser>) (j => new PlayerResponseParser.StreamInfoParser(j)));

    public IEnumerable<PlayerResponseParser.ClosedCaptionTrackInfoParser> GetClosedCaptionTrackInfos() => this._root.SelectToken("captions.playerCaptionsTracklistRenderer.captionTracks").EmptyIfNull<JToken>().Select<JToken, PlayerResponseParser.ClosedCaptionTrackInfoParser>((Func<JToken, PlayerResponseParser.ClosedCaptionTrackInfoParser>) (t => new PlayerResponseParser.ClosedCaptionTrackInfoParser(t)));

    public class StreamInfoParser
    {
      private readonly JToken _root;

      public StreamInfoParser(JToken root) => this._root = root;

      public int ParseItag() => this._root.SelectToken("itag").Value<int>();

      public string ParseUrl() => this._root.SelectToken("url").Value<string>();

      public long ParseContentLength()
      {
        JToken jtoken = this._root.SelectToken("contentLength");
        return jtoken == null ? -1L : jtoken.Value<long>();
      }

      public long ParseBitrate() => this._root.SelectToken("bitrate").Value<long>();

      public string ParseMimeType() => this._root.SelectToken("mimeType").Value<string>();

      public string ParseContainer() => this.ParseMimeType().SubstringUntil(";").SubstringAfter("/");

      public string ParseAudioEncoding() => ((IEnumerable<string>) this.ParseMimeType().SubstringAfter("codecs=\"").SubstringUntil("\"").Split(", ")).LastOrDefault<string>();

      public string ParseVideoEncoding() => ((IEnumerable<string>) this.ParseMimeType().SubstringAfter("codecs=\"").SubstringUntil("\"").Split(", ")).FirstOrDefault<string>();

      public bool ParseIsAudioOnly() => this.ParseMimeType().StartsWith("audio/", StringComparison.OrdinalIgnoreCase);

      public int ParseWidth() => this._root.SelectToken("width").Value<int>();

      public int ParseHeight() => this._root.SelectToken("height").Value<int>();

      public int ParseFramerate() => this._root.SelectToken("fps").Value<int>();

      public string ParseVideoQualityLabel() => this._root.SelectToken("qualityLabel").Value<string>();
    }

    public class ClosedCaptionTrackInfoParser
    {
      private readonly JToken _root;

      public ClosedCaptionTrackInfoParser(JToken root) => this._root = root;

      public string ParseUrl() => this._root.SelectToken("baseUrl").Value<string>();

      public string ParseLanguageCode() => this._root.SelectToken("languageCode").Value<string>();

      public string ParseLanguageName() => this._root.SelectToken("name.simpleText").Value<string>();

      public bool ParseIsAutoGenerated() => this._root.SelectToken("vssId").Value<string>().StartsWith("a.", StringComparison.OrdinalIgnoreCase);
    }
  }
}
