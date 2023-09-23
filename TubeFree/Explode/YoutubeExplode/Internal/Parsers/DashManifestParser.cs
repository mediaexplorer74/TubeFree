// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.DashManifestParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace YoutubeExplode.Internal.Parsers
{
  internal class DashManifestParser
  {
    private readonly XElement _root;

    public DashManifestParser(XElement root) => this._root = root;

    public IEnumerable<DashManifestParser.StreamInfoParser> GetStreamInfos() => this._root.Descendants((XName) "Representation").Where<XElement>((Func<XElement, bool>) (s =>
    {
      XElement xelement = s.Descendants((XName) "Initialization").FirstOrDefault<XElement>();
      if (xelement == null)
        return true;
      bool? nullable = xelement.Attribute((XName) "sourceURL")?.Value.Contains("sq/");
      bool flag = true;
      return nullable.GetValueOrDefault() != flag || !nullable.HasValue;
    })).Select<XElement, DashManifestParser.StreamInfoParser>((Func<XElement, DashManifestParser.StreamInfoParser>) (x => new DashManifestParser.StreamInfoParser(x)));

    public static DashManifestParser Initialize(string raw) => new DashManifestParser(XElement.Parse(raw).StripNamespaces());

    public class StreamInfoParser
    {
      private readonly XElement _root;

      public StreamInfoParser(XElement root) => this._root = root;

      public int ParseItag() => (int) this._root.Attribute((XName) "id");

      public string ParseUrl() => (string) this._root.Element((XName) "BaseURL");

      public long ParseContentLength() => Regex.Match(this.ParseUrl(), "clen[/=](\\d+)").Groups[1].Value.ParseLong();

      public long ParseBitrate() => (long) this._root.Attribute((XName) "bandwidth");

      public string ParseContainer() => Regex.Match(this.ParseUrl(), "mime[/=]\\w*%2F([\\w\\d]*)").Groups[1].Value.UrlDecode();

      public string ParseEncoding() => (string) this._root.Attribute((XName) "codecs");

      public bool ParseIsAudioOnly() => this._root.Element((XName) "AudioChannelConfiguration") != null;

      public int ParseWidth() => (int) this._root.Attribute((XName) "width");

      public int ParseHeight() => (int) this._root.Attribute((XName) "height");

      public int ParseFramerate() => (int) this._root.Attribute((XName) "frameRate");
    }
  }
}
