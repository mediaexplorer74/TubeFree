// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTextFormControlElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal abstract class HtmlTextFormControlElement : HtmlFormControlElementWithState
  {
    private bool _dirty;
    private string _value;
    private HtmlTextFormControlElement.SelectionType _direction;
    private int _start;
    private int _end;

    public HtmlTextFormControlElement(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, flags)
    {
    }

    public bool IsDirty
    {
      get => this._dirty;
      set => this._dirty = value;
    }

    public string DirectionName
    {
      get => this.GetOwnAttribute(AttributeNames.DirName);
      set => this.SetOwnAttribute(AttributeNames.DirName, value);
    }

    public int MaxLength
    {
      get => this.GetOwnAttribute(AttributeNames.MaxLength).ToInteger(-1);
      set => this.SetOwnAttribute(AttributeNames.MaxLength, value.ToString());
    }

    public int MinLength
    {
      get => this.GetOwnAttribute(AttributeNames.MinLength).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.MinLength, value.ToString());
    }

    public abstract string DefaultValue { get; set; }

    public bool HasValue => this._value != null || this.HasOwnAttribute(AttributeNames.Value);

    public string Value
    {
      get => this._value ?? this.DefaultValue;
      set => this._value = value;
    }

    public string Placeholder
    {
      get => this.GetOwnAttribute(AttributeNames.Placeholder);
      set => this.SetOwnAttribute(AttributeNames.Placeholder, value);
    }

    public bool IsRequired
    {
      get => this.GetBoolAttribute(AttributeNames.Required);
      set => this.SetBoolAttribute(AttributeNames.Required, value);
    }

    public bool IsReadOnly
    {
      get => this.GetBoolAttribute(AttributeNames.Readonly);
      set => this.SetBoolAttribute(AttributeNames.Readonly, value);
    }

    public int SelectionStart
    {
      get => this._start;
      set => this.SetSelectionRange(value, this._end, this._direction);
    }

    public int SelectionEnd
    {
      get => this._end;
      set => this.SetSelectionRange(this._start, value, this._direction);
    }

    public string SelectionDirection => this._direction.ToString().ToLowerInvariant();

    public override INode Clone(bool deep = true)
    {
      HtmlTextFormControlElement formControlElement = (HtmlTextFormControlElement) base.Clone(deep);
      formControlElement._dirty = this._dirty;
      formControlElement._value = this._value;
      formControlElement._direction = this._direction;
      formControlElement._start = this._start;
      formControlElement._end = this._end;
      return (INode) formControlElement;
    }

    public void Select(int selectionStart, int selectionEnd, string selectionDirection = null) => this.SetSelectionRange(selectionStart, selectionEnd, selectionDirection.ToEnum<HtmlTextFormControlElement.SelectionType>(HtmlTextFormControlElement.SelectionType.Forward));

    public void SelectAll() => this.SetSelectionRange(0, this.Value.Length, HtmlTextFormControlElement.SelectionType.Forward);

    protected override void Check(ValidityState state)
    {
      int length = (this.Value ?? string.Empty).Length;
      int maxLength = this.MaxLength;
      int minLength = this.MinLength;
      state.IsValueMissing = this.IsRequired && length == 0;
      state.IsTooLong = this._dirty && maxLength > -1 && length > maxLength;
      state.IsTooShort = this._dirty && length > 0 && length < minLength;
    }

    protected override bool CanBeValidated() => !this.IsReadOnly && !this.HasDataListAncestor();

    protected void ConstructDataSet(FormDataSet dataSet, string type)
    {
      dataSet.Append(this.Name, this.Value, type);
      string ownAttribute = this.GetOwnAttribute(AttributeNames.DirName);
      if (string.IsNullOrEmpty(ownAttribute))
        return;
      dataSet.Append(ownAttribute, this.Direction.ToString().ToLowerInvariant(), "Direction");
    }

    private void SetSelectionRange(
      int selectionStart,
      int selectionEnd,
      HtmlTextFormControlElement.SelectionType selectionType)
    {
      int length = (this.Value ?? string.Empty).Length;
      if (selectionEnd > length)
        selectionEnd = length;
      if (selectionEnd < selectionStart)
        selectionStart = selectionEnd;
      this._start = selectionStart;
      this._end = selectionEnd;
      this._direction = selectionType;
    }

    internal override void Reset()
    {
      this.Value = (string) null;
      this.Select(int.MaxValue, int.MaxValue);
    }

    public enum SelectionType : byte
    {
      None,
      Forward,
      Backward,
    }
  }
}
