// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.ChannelPageParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace YoutubeExplode.Internal.Parsers
{
  internal class ChannelPageParser
  {
    private readonly IHtmlDocument _root;

    public ChannelPageParser(IHtmlDocument root) => this._root = root;

    public bool ParseIsAvailable() => this._root.QuerySelector("meta[property=\"og:url\"]") != null;

    public string ParseChannelUrl() => this._root.QuerySelector("meta[property=\"og:url\"]").GetAttribute("content");

    public string ParseChannelId() => this.ParseChannelUrl().SubstringAfter("channel/");

    public string ParseChannelTitle() => this._root.QuerySelector("meta[property=\"og:title\"]").GetAttribute("content");

    public string ParseChannelLogoUrl() => this._root.QuerySelector("meta[property=\"og:image\"]").GetAttribute("content");

    public static ChannelPageParser Initialize(string raw) => new ChannelPageParser(new HtmlParser().Parse(raw));
  }
}
