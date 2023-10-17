// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlSourceElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLSourceElement")]
  public interface IHtmlSourceElement : 
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
    [DomName("src")]
    string Source { get; set; }

    [DomName("srcset")]
    string SourceSet { get; set; }

    [DomName("sizes")]
    string Sizes { get; set; }

    [DomName("type")]
    string Type { get; set; }

    [DomName("media")]
    string Media { get; set; }
  }
}
