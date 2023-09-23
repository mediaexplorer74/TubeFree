// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlImageElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLImageElement")]
  public interface IHtmlImageElement : 
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
    ILoadableElement
  {
    [DomName("alt")]
    string AlternativeText { get; set; }

    [DomName("currentSrc")]
    string ActualSource { get; }

    [DomName("src")]
    string Source { get; set; }

    [DomName("srcset")]
    string SourceSet { get; set; }

    [DomName("sizes")]
    string Sizes { get; set; }

    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }

    [DomName("useMap")]
    string UseMap { get; set; }

    [DomName("isMap")]
    bool IsMap { get; set; }

    [DomName("width")]
    int DisplayWidth { get; set; }

    [DomName("height")]
    int DisplayHeight { get; set; }

    [DomName("naturalWidth")]
    int OriginalWidth { get; }

    [DomName("naturalHeight")]
    int OriginalHeight { get; }

    [DomName("complete")]
    bool IsCompleted { get; }
  }
}
