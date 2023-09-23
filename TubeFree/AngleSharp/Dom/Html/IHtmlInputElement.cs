// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlInputElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Io;
using System;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLInputElement")]
  public interface IHtmlInputElement : 
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

    [DomName("accept")]
    string Accept { get; set; }

    [DomName("autocomplete")]
    string Autocomplete { get; set; }

    [DomName("disabled")]
    bool IsDisabled { get; set; }

    [DomName("form")]
    IHtmlFormElement Form { get; }

    [DomName("labels")]
    INodeList Labels { get; }

    [DomName("files")]
    IFileList Files { get; }

    [DomName("name")]
    string Name { get; set; }

    [DomName("type")]
    string Type { get; set; }

    [DomName("required")]
    bool IsRequired { get; set; }

    [DomName("readOnly")]
    bool IsReadOnly { get; set; }

    [DomName("alt")]
    string AlternativeText { get; set; }

    [DomName("src")]
    string Source { get; set; }

    [DomName("max")]
    string Maximum { get; set; }

    [DomName("min")]
    string Minimum { get; set; }

    [DomName("pattern")]
    string Pattern { get; set; }

    [DomName("step")]
    string Step { get; set; }

    [DomName("stepUp")]
    void StepUp(int n = 1);

    [DomName("stepDown")]
    void StepDown(int n = 1);

    [DomName("list")]
    IHtmlDataListElement List { get; }

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

    [DomName("defaultValue")]
    string DefaultValue { get; set; }

    [DomName("value")]
    string Value { get; set; }

    bool HasValue { get; }

    [DomName("valueAsNumber")]
    double ValueAsNumber { get; set; }

    [DomName("valueAsDate")]
    DateTime? ValueAsDate { get; set; }

    [DomName("indeterminate")]
    bool IsIndeterminate { get; set; }

    [DomName("defaultChecked")]
    bool IsDefaultChecked { get; set; }

    [DomName("checked")]
    bool IsChecked { get; set; }

    [DomName("size")]
    int Size { get; set; }

    [DomName("multiple")]
    bool IsMultiple { get; set; }

    [DomName("maxLength")]
    int MaxLength { get; set; }

    [DomName("placeholder")]
    string Placeholder { get; set; }

    [DomName("width")]
    int DisplayWidth { get; set; }

    [DomName("height")]
    int DisplayHeight { get; set; }

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
