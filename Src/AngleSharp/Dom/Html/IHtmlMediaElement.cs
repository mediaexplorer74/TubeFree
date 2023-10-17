// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlMediaElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;
using System;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLMediaElement")]
  public interface IHtmlMediaElement : 
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers,
    IMediaController,
    ILoadableElement
  {
    [DomName("src")]
    string Source { get; set; }

    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }

    [DomName("preload")]
    string Preload { get; set; }

    [DomName("mediaGroup")]
    string MediaGroup { get; set; }

    [DomName("networkState")]
    MediaNetworkState NetworkState { get; }

    [DomName("seeking")]
    bool IsSeeking { get; }

    [DomName("currentSrc")]
    string CurrentSource { get; }

    [DomName("error")]
    IMediaError MediaError { get; }

    [DomName("controller")]
    IMediaController Controller { get; }

    [DomName("ended")]
    bool IsEnded { get; }

    [DomName("autoplay")]
    bool IsAutoplay { get; set; }

    [DomName("loop")]
    bool IsLoop { get; set; }

    [DomName("controls")]
    bool IsShowingControls { get; set; }

    [DomName("defaultMuted")]
    bool IsDefaultMuted { get; set; }

    [DomName("load")]
    void Load();

    [DomName("canPlayType")]
    string CanPlayType(string type);

    [DomName("startDate")]
    DateTime StartDate { get; }

    [DomName("audioTracks")]
    IAudioTrackList AudioTracks { get; }

    [DomName("videoTracks")]
    IVideoTrackList VideoTracks { get; }

    [DomName("textTracks")]
    ITextTrackList TextTracks { get; }

    [DomName("addTextTrack")]
    ITextTrack AddTextTrack(string kind, string label = null, string language = null);
  }
}
