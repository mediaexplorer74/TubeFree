// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTextAreaElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlTextAreaElement : 
    HtmlTextFormControlElement,
    IHtmlTextAreaElement,
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
    public HtmlTextAreaElement(Document owner, string prefix = null)
      : base(owner, TagNames.Textarea, prefix, NodeFlags.LineTolerance)
    {
    }

    public string Wrap
    {
      get => this.GetOwnAttribute(AttributeNames.Wrap);
      set => this.SetOwnAttribute(AttributeNames.Wrap, value);
    }

    public override string DefaultValue
    {
      get => this.TextContent;
      set => this.TextContent = value;
    }

    public int TextLength => this.Value.Length;

    public int Rows
    {
      get => this.GetOwnAttribute(AttributeNames.Rows).ToInteger(2);
      set => this.SetOwnAttribute(AttributeNames.Rows, value.ToString());
    }

    public int Columns
    {
      get => this.GetOwnAttribute(AttributeNames.Cols).ToInteger(20);
      set => this.SetOwnAttribute(AttributeNames.Cols, value.ToString());
    }

    public string Type => TagNames.Textarea;

    internal bool IsMutable => !this.IsDisabled && !this.IsReadOnly;

    internal override void ConstructDataSet(FormDataSet dataSet, IHtmlElement submitter) => this.ConstructDataSet(dataSet, this.Type);

    internal override FormControlState SaveControlState() => new FormControlState(this.Name, this.Type, this.Value);

    internal override void RestoreFormControlState(FormControlState state)
    {
      if (!state.Type.Is(this.Type) || !state.Name.Is(this.Name))
        return;
      this.Value = state.Value;
    }
  }
}
