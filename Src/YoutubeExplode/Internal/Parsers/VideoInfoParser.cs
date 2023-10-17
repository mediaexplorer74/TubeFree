// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.VideoInfoParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace YoutubeExplode.Internal.Parsers
{
  internal class VideoInfoParser
  {
    private readonly IReadOnlyDictionary<string, string> _root;

    public VideoInfoParser(IReadOnlyDictionary<string, string> root) => this._root = root;

    public PlayerResponseParser GetPlayerResponse() => new PlayerResponseParser(JToken.Parse(this._root["player_response"]));

    public static VideoInfoParser Initialize(string raw) => new VideoInfoParser((IReadOnlyDictionary<string, string>) UrlEx.SplitQuery(raw));
  }
}
