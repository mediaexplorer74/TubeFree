// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlFormElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Network;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLFormElement")]
  public interface IHtmlFormElement : 
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
    [DomName("acceptCharset")]
    string AcceptCharset { get; set; }

    [DomName("action")]
    string Action { get; set; }

    [DomName("autocomplete")]
    string Autocomplete { get; set; }

    [DomName("enctype")]
    string Enctype { get; set; }

    [DomName("encoding")]
    string Encoding { get; set; }

    [DomName("method")]
    string Method { get; set; }

    [DomName("name")]
    string Name { get; set; }

    [DomName("noValidate")]
    bool NoValidate { get; set; }

    [DomName("target")]
    string Target { get; set; }

    [DomName("length")]
    int Length { get; }

    [DomName("elements")]
    IHtmlFormControlsCollection Elements { get; }

    [DomName("submit")]
    Task<IDocument> SubmitAsync();

    Task<IDocument> SubmitAsync(IHtmlElement sourceElement);

    DocumentRequest GetSubmission();

    DocumentRequest GetSubmission(IHtmlElement sourceElement);

    [DomName("reset")]
    void Reset();

    [DomName("checkValidity")]
    bool CheckValidity();

    [DomName("reportValidity")]
    bool ReportValidity();

    [DomAccessor(Accessors.Getter)]
    IElement this[int index] { get; }

    [DomAccessor(Accessors.Getter)]
    IElement this[string name] { get; }

    [DomName("requestAutocomplete")]
    void RequestAutocomplete();
  }
}
