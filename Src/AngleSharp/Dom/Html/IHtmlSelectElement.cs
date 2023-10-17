// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlSelectElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLSelectElement")]
  public interface IHtmlSelectElement : 
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

    [DomName("value")]
    string Value { get; set; }

    [DomName("type")]
    string Type { get; }

    [DomName("required")]
    bool IsRequired { get; set; }

    [DomName("selectedOptions")]
    IHtmlCollection<IHtmlOptionElement> SelectedOptions { get; }

    [DomName("size")]
    int Size { get; set; }

    [DomName("options")]
    IHtmlOptionsCollection Options { get; }

    [DomName("length")]
    int Length { get; }

    [DomName("multiple")]
    bool IsMultiple { get; set; }

    [DomName("selectedIndex")]
    int SelectedIndex { get; }

    [DomAccessor(Accessors.Getter | Accessors.Setter)]
    IHtmlOptionElement this[int index] { get; set; }

    [DomName("add")]
    void AddOption(IHtmlOptionElement element, IHtmlElement before = null);

    [DomName("add")]
    void AddOption(IHtmlOptionsGroupElement element, IHtmlElement before = null);

    [DomName("remove")]
    void RemoveOptionAt(int index);
  }
}
