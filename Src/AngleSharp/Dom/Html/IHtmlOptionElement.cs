// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlOptionElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLOptionElement")]
  public interface IHtmlOptionElement : 
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
    [DomName("disabled")]
    bool IsDisabled { get; set; }

    [DomName("form")]
    IHtmlFormElement Form { get; }

    [DomName("label")]
    string Label { get; set; }

    [DomName("defaultSelected")]
    bool IsDefaultSelected { get; set; }

    [DomName("selected")]
    bool IsSelected { get; set; }

    [DomName("value")]
    string Value { get; set; }

    [DomName("text")]
    string Text { get; set; }

    [DomName("index")]
    int Index { get; }
  }
}
