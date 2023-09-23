// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlButtonElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLButtonElement")]
  public interface IHtmlButtonElement : 
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
    [DomName("autofocus")]
    bool Autofocus { get; set; }

    [DomName("disabled")]
    bool IsDisabled { get; set; }

    [DomName("form")]
    IHtmlFormElement Form { get; }

    [DomName("labels")]
    INodeList Labels { get; }

    [DomName("name")]
    string Name { get; set; }

    [DomName("type")]
    string Type { get; set; }

    [DomName("value")]
    string Value { get; set; }

    [DomName("formAction")]
    string FormAction { get; set; }

    [DomName("formEncType")]
    string FormEncType { get; set; }

    [DomName("formMethod")]
    string FormMethod { get; set; }

    [DomName("formNoValidate")]
    bool FormNoValidate { get; set; }

    [DomName("formTarget")]
    string FormTarget { get; set; }
  }
}
