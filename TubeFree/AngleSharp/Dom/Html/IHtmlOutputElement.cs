// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlOutputElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLOutputElement")]
  public interface IHtmlOutputElement : 
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
    IValidation
  {
    [DomName("htmlFor")]
    ISettableTokenList HtmlFor { get; }

    [DomName("defaultValue")]
    string DefaultValue { get; set; }

    [DomName("value")]
    string Value { get; set; }

    [DomName("labels")]
    INodeList Labels { get; }

    [DomName("type")]
    string Type { get; }

    [DomName("form")]
    IHtmlFormElement Form { get; }

    [DomName("name")]
    string Name { get; set; }
  }
}
