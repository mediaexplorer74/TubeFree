// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlTrackElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLTrackElement")]
  public interface IHtmlTrackElement : 
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers
  {
    [DomName("kind")]
    string Kind { get; set; }

    [DomName("src")]
    string Source { get; set; }

    [DomName("srclang")]
    string SourceLanguage { get; set; }

    [DomName("label")]
    string Label { get; set; }

    [DomName("default")]
    bool IsDefault { get; set; }

    [DomName("readyState")]
    TrackReadyState ReadyState { get; }

    [DomName("track")]
    ITextTrack Track { get; }
  }
}
