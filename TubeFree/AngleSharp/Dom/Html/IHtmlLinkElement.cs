// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlLinkElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLLinkElement")]
  public interface IHtmlLinkElement : 
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
    ILinkStyle,
    ILinkImport,
    ILoadableElement
  {
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    [DomName("href")]
    string Href { get; set; }

    [DomName("rel")]
    string Relation { get; set; }

    [DomName("relList")]
    ITokenList RelationList { get; }

    [DomName("media")]
    string Media { get; set; }

    [DomName("hreflang")]
    string TargetLanguage { get; set; }

    [DomName("type")]
    string Type { get; set; }

    [DomName("sizes")]
    ISettableTokenList Sizes { get; }

    [DomName("integrity")]
    string Integrity { get; set; }

    [DomName("crossOrigin")]
    string CrossOrigin { get; set; }
  }
}
