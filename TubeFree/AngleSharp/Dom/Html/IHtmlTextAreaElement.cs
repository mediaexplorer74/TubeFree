// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlTextAreaElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLTextAreaElement")]
  public interface IHtmlTextAreaElement : 
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
    string Type { get; }

    [DomName("required")]
    bool IsRequired { get; set; }

    [DomName("readOnly")]
    bool IsReadOnly { get; set; }

    [DomName("defaultValue")]
    string DefaultValue { get; set; }

    [DomName("value")]
    string Value { get; set; }

    [DomName("wrap")]
    string Wrap { get; set; }

    [DomName("textLength")]
    int TextLength { get; }

    [DomName("rows")]
    int Rows { get; set; }

    [DomName("cols")]
    int Columns { get; set; }

    [DomName("maxLength")]
    int MaxLength { get; set; }

    [DomName("placeholder")]
    string Placeholder { get; set; }

    [DomName("selectionDirection")]
    string SelectionDirection { get; }

    [DomName("dirName")]
    string DirectionName { get; set; }

    [DomName("selectionStart")]
    int SelectionStart { get; set; }

    [DomName("selectionEnd")]
    int SelectionEnd { get; set; }

    [DomName("select")]
    void SelectAll();

    [DomName("setSelectionRange")]
    void Select(int selectionStart, int selectionEnd, string selectionDirection = null);
  }
}
