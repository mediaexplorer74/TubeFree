// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFieldSetElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlFieldSetElement : 
    HtmlFormControlElement,
    IHtmlFieldSetElement,
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
    private HtmlFormControlsCollection _elements;

    public HtmlFieldSetElement(Document owner, string prefix = null)
      : base(owner, TagNames.Fieldset, prefix)
    {
    }

    public string Type => TagNames.Fieldset;

    public IHtmlFormControlsCollection Elements => (IHtmlFormControlsCollection) this._elements ?? (IHtmlFormControlsCollection) (this._elements = new HtmlFormControlsCollection((IElement) this.Form, (IElement) this));

    protected override bool IsFieldsetDisabled() => false;

    protected override bool CanBeValidated() => true;
  }
}
