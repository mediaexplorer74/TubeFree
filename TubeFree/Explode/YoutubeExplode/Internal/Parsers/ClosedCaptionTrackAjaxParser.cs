// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Parsers.ClosedCaptionTrackAjaxParser
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace YoutubeExplode.Internal.Parsers
{
  internal class ClosedCaptionTrackAjaxParser
  {
    private readonly XElement _root;

    public ClosedCaptionTrackAjaxParser(XElement root) => this._root = root;

    public IEnumerable<ClosedCaptionTrackAjaxParser.ClosedCaptionParser> GetClosedCaptions() => this._root.Descendants((XName) "p").Select<XElement, ClosedCaptionTrackAjaxParser.ClosedCaptionParser>((Func<XElement, ClosedCaptionTrackAjaxParser.ClosedCaptionParser>) (x => new ClosedCaptionTrackAjaxParser.ClosedCaptionParser(x)));

    public static ClosedCaptionTrackAjaxParser Initialize(string raw) => new ClosedCaptionTrackAjaxParser(XElement.Parse(raw).StripNamespaces());

    public class ClosedCaptionParser
    {
      private readonly XElement _root;

      public ClosedCaptionParser(XElement root) => this._root = root;

      public string ParseText() => (string) this._root;

      public TimeSpan ParseOffset() => TimeSpan.FromMilliseconds((double) this._root.Attribute((XName) "t"));

      public TimeSpan ParseDuration() => TimeSpan.FromMilliseconds((double) this._root.Attribute((XName) "d"));
    }
  }
}
