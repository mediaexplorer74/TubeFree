// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlInlineFrameElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLIFrameElement")]
  public interface IHtmlInlineFrameElement : 
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
    [DomName("src")]
    string Source { get; set; }

    [DomName("srcdoc")]
    string ContentHtml { get; set; }

    [DomName("name")]
    string Name { get; set; }

    [DomName("sandbox")]
    ISettableTokenList Sandbox { get; }

    [DomName("seamless")]
    bool IsSeamless { get; set; }

    [DomName("allowFullscreen")]
    bool IsFullscreenAllowed { get; set; }

    [DomName("width")]
    int DisplayWidth { get; set; }

    [DomName("height")]
    int DisplayHeight { get; set; }

    [DomName("contentDocument")]
    IDocument ContentDocument { get; }

    [DomName("contentWindow")]
    IWindow ContentWindow { get; }
  }
}
