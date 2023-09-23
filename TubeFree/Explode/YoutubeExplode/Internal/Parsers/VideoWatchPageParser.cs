// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.VideoWatchPageParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Parser.Html;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace YoutubeExplode.Internal.Parsers
{
  internal class VideoWatchPageParser
  {
    private readonly IHtmlDocument _root;

    public VideoWatchPageParser(IHtmlDocument root) => this._root = root;

    public DateTimeOffset ParseUploadDate() => this._root.QuerySelector("meta[itemprop=\"datePublished\"]").GetAttribute("content").ParseDateTimeOffset("yyyy-MM-dd");

    public string ParseDescription() => "";

    public long ParseViewCount()
    {
      IElement element = this._root.QuerySelector("meta[itemprop=\"interactionCount\"]");
      return element == null ? 0L : element.GetAttribute("content").ParseLongOrDefault();
    }

    public long ParseLikeCount()
    {
      IElement node = this._root.QuerySelector("button.like-button-renderer-like-button");
      return node == null ? 0L : node.Text().StripNonDigit().ParseLongOrDefault();
    }

    public long ParseDislikeCount()
    {
      IElement node = this._root.QuerySelector("button.like-button-renderer-dislike-button");
      return node == null ? 0L : node.Text().StripNonDigit().ParseLongOrDefault();
    }

    public VideoWatchPageParser.ConfigParser GetConfig() => new VideoWatchPageParser.ConfigParser(JToken.Parse(Regex.Match(this._root.Source.Text, "ytplayer\\.config = (?<Json>\\{[^\\{\\}]*(((?<Open>\\{)[^\\{\\}]*)+((?<Close-Open>\\})[^\\{\\}]*)+)*(?(Open)(?!))\\})").Groups["Json"].Value));

    public static VideoWatchPageParser Initialize(string raw) => new VideoWatchPageParser(new HtmlParser().Parse(raw));

    public class ConfigParser
    {
      private readonly JToken _root;

      public ConfigParser(JToken root) => this._root = root;

      public string ParsePreviewVideoId()
      {
        JToken jtoken = this._root.SelectToken("args.ypc_vid");
        return jtoken == null ? (string) null : jtoken.Value<string>();
      }

      public PlayerResponseParser GetPlayerResponse() => new PlayerResponseParser(JToken.Parse(this._root.SelectToken("args.player_response").Value<string>()));
    }
  }
}
