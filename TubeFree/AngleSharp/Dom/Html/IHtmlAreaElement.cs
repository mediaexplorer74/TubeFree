// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlAreaElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLAreaElement")]
  public interface IHtmlAreaElement : 
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
    IUrlUtilities
  {
    [DomName("alt")]
    string AlternativeText { get; set; }

    [DomName("coords")]
    string Coordinates { get; set; }

    [DomName("shape")]
    string Shape { get; set; }

    [DomName("target")]
    string Target { get; set; }

    [DomName("download")]
    string Download { get; set; }

    [DomName("ping")]
    ISettableTokenList Ping { get; }

    [DomName("rel")]
    string Relation { get; set; }

    [DomName("relList")]
    ITokenList RelationList { get; }

    [DomName("hreflang")]
    string TargetLanguage { get; set; }

    [DomName("type")]
    string Type { get; set; }
  }
}
