// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.PlaylistAjaxParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YoutubeExplode.Internal.Parsers
{
  internal class PlaylistAjaxParser
  {
    private readonly JToken _root;

    public PlaylistAjaxParser(JToken root) => this._root = root;

    public string ParseAuthor()
    {
      JToken jtoken = this._root.SelectToken("author");
      return (jtoken != null ? jtoken.Value<string>() : (string) null) ?? "";
    }

    public string ParseTitle() => this._root.SelectToken("title").Value<string>();

    public string ParseDescription()
    {
      JToken jtoken = this._root.SelectToken("description");
      return (jtoken != null ? jtoken.Value<string>() : (string) null) ?? "";
    }

    public long ParseViewCount()
    {
      JToken jtoken = this._root.SelectToken("views");
      return jtoken == null ? 0L : jtoken.Value<long>();
    }

    public long ParseLikeCount()
    {
      JToken jtoken = this._root.SelectToken("likes");
      return jtoken == null ? 0L : jtoken.Value<long>();
    }

    public long ParseDislikeCount()
    {
      JToken jtoken = this._root.SelectToken("dislikes");
      return jtoken == null ? 0L : jtoken.Value<long>();
    }

    public IEnumerable<PlaylistAjaxParser.VideoParser> GetVideos() => this._root.SelectToken("video").EmptyIfNull<JToken>().Select<JToken, PlaylistAjaxParser.VideoParser>((Func<JToken, PlaylistAjaxParser.VideoParser>) (t => new PlaylistAjaxParser.VideoParser(t)));

    public static PlaylistAjaxParser Initialize(string raw) => new PlaylistAjaxParser(JToken.Parse(raw));

    public class VideoParser
    {
      private readonly JToken _root;

      public VideoParser(JToken root) => this._root = root;

      public string ParseId() => this._root.SelectToken("encrypted_id").Value<string>();

      public string ParseAuthor() => this._root.SelectToken("author").Value<string>();

      public DateTimeOffset ParseUploadDate() => this._root.SelectToken("added").Value<string>().ParseDateTimeOffset("M/d/yy");

      public string ParseTitle() => this._root.SelectToken("title").Value<string>();

      public string ParseDescription() => this._root.SelectToken("description").Value<string>();

      public TimeSpan ParseDuration() => TimeSpan.FromSeconds(this._root.SelectToken("length_seconds").Value<double>());

      public IReadOnlyList<string> ParseKeywords() => (IReadOnlyList<string>) Regex.Matches(this._root.SelectToken("keywords").Value<string>(), "(?<=(^|\\s)(?<q>\"?))([^\"]|(\"\"))*?(?=\\<q>(?=\\s|$))").Cast<Match>().Select<Match, string>((Func<Match, string>) (m => m.Value)).Where<string>((Func<string, bool>) (s => s.IsNotBlank())).ToArray<string>();

      public long ParseViewCount() => this._root.SelectToken("views").Value<string>().StripNonDigit().ParseLong();

      public long ParseLikeCount() => this._root.SelectToken("likes").Value<long>();

      public long ParseDislikeCount() => this._root.SelectToken("dislikes").Value<long>();
    }
  }
}
