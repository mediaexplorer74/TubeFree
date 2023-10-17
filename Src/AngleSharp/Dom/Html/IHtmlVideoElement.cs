// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlVideoElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLVideoElement")]
  public interface IHtmlVideoElement : 
    IHtmlMediaElement,
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
    [DomName("width")]
    int DisplayWidth { get; set; }

    [DomName("height")]
    int DisplayHeight { get; set; }

    [DomName("videoWidth")]
    int OriginalWidth { get; }

    [DomName("videoHeight")]
    int OriginalHeight { get; }

    [DomName("poster")]
    string Poster { get; set; }
  }
}
