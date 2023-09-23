// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlInputElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Io;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Html.InputTypes;
using AngleSharp.Services;
using System;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlInputElement : 
    HtmlTextFormControlElement,
    IHtmlInputElement,
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
    private BaseInputType _type;
    private bool? _checked;

    public HtmlInputElement(Document owner, string prefix = null)
      : base(owner, TagNames.Input, prefix, NodeFlags.SelfClosing)
    {
    }

    public override string DefaultValue
    {
      get => this.GetOwnAttribute(AttributeNames.Value) ?? string.Empty;
      set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    public bool IsDefaultChecked
    {
      get => this.GetBoolAttribute(AttributeNames.Checked);
      set => this.SetBoolAttribute(AttributeNames.Checked, value);
    }

    public bool IsChecked
    {
      get => !this._checked.HasValue ? this.IsDefaultChecked : this._checked.Value;
      set => this._checked = new bool?(value);
    }

    public string Type
    {
      get => this._type.Name;
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public bool IsIndeterminate { get; set; }

    public bool IsMultiple
    {
      get => this.GetBoolAttribute(AttributeNames.Multiple);
      set => this.SetBoolAttribute(AttributeNames.Multiple, value);
    }

    public DateTime? ValueAsDate
    {
      get => this._type.ConvertToDate(this.Value);
      set
      {
        if (!value.HasValue)
          this.Value = string.Empty;
        else
          this.Value = this._type.ConvertFromDate(value.Value);
      }
    }

    public double ValueAsNumber
    {
      get => this._type.ConvertToNumber(this.Value) ?? double.NaN;
      set
      {
        if (double.IsInfinity(value))
          throw new DomException(DomError.TypeMismatch);
        if (double.IsNaN(value))
          this.Value = string.Empty;
        else
          this.Value = this._type.ConvertFromNumber(value);
      }
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

    public string Accept
    {
      get => this.GetOwnAttribute(AttributeNames.Accept);
      set => this.SetOwnAttribute(AttributeNames.Accept, value);
    }

    public Alignment Align
    {
      get => this.GetOwnAttribute(AttributeNames.Align).ToEnum<Alignment>(Alignment.Left);
      set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public string AlternativeText
    {
      get => this.GetOwnAttribute(AttributeNames.Alt);
      set => this.SetOwnAttribute(AttributeNames.Alt, value);
    }

    public string Autocomplete
    {
      get => this.GetOwnAttribute(AttributeNames.AutoComplete);
      set => this.SetOwnAttribute(AttributeNames.AutoComplete, value);
    }

    public IFileList Files => !(this._type is FileInputType type) ? (IFileList) null : (IFileList) type.Files;

    public IHtmlDataListElement List => this.Owner?.GetElementById(this.GetOwnAttribute(AttributeNames.List)) as IHtmlDataListElement;

    public string Maximum
    {
      get => this.GetOwnAttribute(AttributeNames.Max);
      set => this.SetOwnAttribute(AttributeNames.Max, value);
    }

    public string Minimum
    {
      get => this.GetOwnAttribute(AttributeNames.Min);
      set => this.SetOwnAttribute(AttributeNames.Min, value);
    }

    public string Pattern
    {
      get => this.GetOwnAttribute(AttributeNames.Pattern);
      set => this.SetOwnAttribute(AttributeNames.Pattern, value);
    }

    public int Size
    {
      get => this.GetOwnAttribute(AttributeNames.Size).ToInteger(20);
      set => this.SetOwnAttribute(AttributeNames.Size, value.ToString());
    }

    public string Source
    {
      get => this.GetOwnAttribute(AttributeNames.Src);
      set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Step
    {
      get => this.GetOwnAttribute(AttributeNames.Step);
      set => this.SetOwnAttribute(AttributeNames.Step, value);
    }

    public string UseMap
    {
      get => this.GetOwnAttribute(AttributeNames.UseMap);
      set => this.SetOwnAttribute(AttributeNames.UseMap, value);
    }

    public int DisplayWidth
    {
      get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(this.OriginalWidth);
      set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int DisplayHeight
    {
      get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(this.OriginalHeight);
      set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public int OriginalWidth => !(this._type is ImageInputType type) ? 0 : type.Width;

    public int OriginalHeight => !(this._type is ImageInputType type) ? 0 : type.Height;

    internal bool IsVisited { get; set; }

    internal bool IsActive { get; set; }

    public override void DoClick()
    {
      if (this.IsClickedCancelled())
        return;
      string type = this.Type;
      if (type.Is(InputTypeNames.Submit))
      {
        this.Form?.SubmitAsync();
      }
      else
      {
        if (!type.Is(InputTypeNames.Reset))
          return;
        this.Form?.Reset();
      }
    }

    public override sealed INode Clone(bool deep = true)
    {
      HtmlInputElement htmlInputElement = (HtmlInputElement) base.Clone(deep);
      htmlInputElement._checked = this._checked;
      htmlInputElement.UpdateType(this._type.Name);
      return (INode) htmlInputElement;
    }

    internal override FormControlState SaveControlState() => new FormControlState(this.Name, this.Type, this.Value);

    internal override void RestoreFormControlState(FormControlState state)
    {
      if (!state.Type.Is(this.Type) || !state.Name.Is(this.Name))
        return;
      this.Value = state.Value;
    }

    public void StepUp(int n = 1) => this._type.DoStep(n);

    public void StepDown(int n = 1) => this._type.DoStep(-n);

    internal bool IsMutable => !this.IsDisabled && !this.IsReadOnly;

    internal override void SetupElement()
    {
      base.SetupElement();
      this.UpdateType(this.GetOwnAttribute(AttributeNames.Type));
    }

    internal void UpdateType(string value) => this._type = this.Owner.Options.GetFactory<IInputTypeFactory>().Create((IHtmlInputElement) this, value);

    internal override void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter)
    {
      if (!this._type.IsAppendingData(submitter))
        return;
      this._type.ConstructDataSet(dataSet);
    }

    internal override void Reset()
    {
      base.Reset();
      this._checked = new bool?();
      this.UpdateType(this.Type);
    }

    protected override void Check(ValidityState state)
    {
      base.Check(state);
      this._type.Check(state);
    }

    protected override bool CanBeValidated() => this._type.CanBeValidated && base.CanBeValidated();
  }
}
