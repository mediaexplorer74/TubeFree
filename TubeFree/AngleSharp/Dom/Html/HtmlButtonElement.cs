// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlButtonElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlButtonElement : 
    HtmlFormControlElement,
    IHtmlButtonElement,
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
    public HtmlButtonElement(Document owner, string prefix = null)
      : base(owner, TagNames.Button, prefix)
    {
    }

    public string Type
    {
      get => (this.GetOwnAttribute(AttributeNames.Type) ?? InputTypeNames.Submit).ToLowerInvariant();
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string FormAction
    {
      get
      {
        IHtmlFormElement form = this.Form;
        return form == null ? string.Empty : form.Action;
      }
      set
      {
        IHtmlFormElement form = this.Form;
        if (form == null)
          return;
        form.Action = value;
      }
    }

    public string FormEncType
    {
      get
      {
        IHtmlFormElement form = this.Form;
        return form == null ? string.Empty : form.Enctype;
      }
      set
      {
        IHtmlFormElement form = this.Form;
        if (form == null)
          return;
        form.Enctype = value;
      }
    }

    public string FormMethod
    {
      get
      {
        IHtmlFormElement form = this.Form;
        return form == null ? string.Empty : form.Method;
      }
      set
      {
        IHtmlFormElement form = this.Form;
        if (form == null)
          return;
        form.Method = value;
      }
    }

    public bool FormNoValidate
    {
      get
      {
        IHtmlFormElement form = this.Form;
        return form != null && form.NoValidate;
      }
      set
      {
        IHtmlFormElement form = this.Form;
        if (form == null)
          return;
        form.NoValidate = value;
      }
    }

    public string FormTarget
    {
      get
      {
        IHtmlFormElement form = this.Form;
        return form == null ? string.Empty : form.Target;
      }
      set
      {
        IHtmlFormElement form = this.Form;
        if (form == null)
          return;
        form.Target = value;
      }
    }

    public string Value
    {
      get => this.GetOwnAttribute(AttributeNames.Value) ?? string.Empty;
      set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    internal bool IsVisited { get; set; }

    internal bool IsActive { get; set; }

    public override void DoClick()
    {
      IHtmlFormElement form = this.Form;
      if (this.IsClickedCancelled() || form == null)
        return;
      string type = this.Type;
      if (type.Is(InputTypeNames.Submit))
      {
        form.SubmitAsync((IHtmlElement) this);
      }
      else
      {
        if (!type.Is(InputTypeNames.Reset))
          return;
        form.Reset();
      }
    }

    protected override bool CanBeValidated() => this.Type.Is(InputTypeNames.Submit) && !this.HasDataListAncestor();

    internal override void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    {
      string type = this.Type;
      if (this != submitter || !type.IsOneOf(InputTypeNames.Submit, InputTypeNames.Reset))
        return;
      dataSet.Append(this.Name, this.Value, type);
    }
  }
}
