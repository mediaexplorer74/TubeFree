// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFormControlElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Linq;

namespace AngleSharp.Dom.Html
{
  internal abstract class HtmlFormControlElement : HtmlElement, ILabelabelElement, IValidation
  {
    private readonly NodeList _labels;
    private readonly ValidityState _vstate;
    private string _error;

    public HtmlFormControlElement(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, flags | NodeFlags.Special)
    {
      this._vstate = new ValidityState();
      this._labels = new NodeList();
    }

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public IHtmlFormElement Form => this.GetAssignedForm();

    public bool IsDisabled
    {
      get => this.GetBoolAttribute(AttributeNames.Disabled) || this.IsFieldsetDisabled();
      set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public bool Autofocus
    {
      get => this.GetBoolAttribute(AttributeNames.AutoFocus);
      set => this.SetBoolAttribute(AttributeNames.AutoFocus, value);
    }

    public INodeList Labels => (INodeList) this._labels;

    public string ValidationMessage => !this._vstate.IsCustomError ? string.Empty : this._error;

    public bool WillValidate => !this.IsDisabled && this.CanBeValidated();

    public IValidityState Validity
    {
      get
      {
        this.Check(this._vstate);
        return (IValidityState) this._vstate;
      }
    }

    public override INode Clone(bool deep = true)
    {
      HtmlFormControlElement formControlElement = (HtmlFormControlElement) base.Clone(deep);
      formControlElement.SetCustomValidity(this._error);
      return (INode) formControlElement;
    }

    public bool CheckValidity() => this.WillValidate && this.Validity.IsValid;

    public void SetCustomValidity(string error)
    {
      this._vstate.IsCustomError = !string.IsNullOrEmpty(error);
      this._error = error;
    }

    protected virtual bool IsFieldsetDisabled()
    {
      foreach (IHtmlFieldSetElement htmlFieldSetElement in this.GetAncestors().OfType<IHtmlFieldSetElement>())
      {
        if (htmlFieldSetElement.IsDisabled)
          return !this.IsDescendantOf(htmlFieldSetElement.ChildNodes.FirstOrDefault<INode>((Func<INode, bool>) (m => m is IHtmlLegendElement)));
      }
      return false;
    }

    internal virtual void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    {
    }

    internal virtual void Reset()
    {
    }

    protected virtual void Check(ValidityState state)
    {
    }

    protected abstract bool CanBeValidated();
  }
}
