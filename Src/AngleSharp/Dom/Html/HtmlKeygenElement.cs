// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlKeygenElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlKeygenElement : 
    HtmlFormControlElementWithState,
    IHtmlKeygenElement,
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
    public HtmlKeygenElement(Document owner, string prefix = null)
      : base(owner, TagNames.Keygen, prefix, NodeFlags.SelfClosing)
    {
    }

    public string Challenge
    {
      get => this.GetOwnAttribute(AttributeNames.Challenge);
      set => this.SetOwnAttribute(AttributeNames.Challenge, value);
    }

    public string KeyEncryption
    {
      get => this.GetOwnAttribute(AttributeNames.Keytype);
      set => this.SetOwnAttribute(AttributeNames.Keytype, value);
    }

    public string Type => TagNames.Keygen;

    internal override FormControlState SaveControlState() => new FormControlState(this.Name, this.Type, this.Challenge);

    internal override void RestoreFormControlState(FormControlState state)
    {
      if (!state.Type.Is(this.Type) || !state.Name.Is(this.Name))
        return;
      this.Challenge = state.Value;
    }

    protected override bool CanBeValidated() => false;
  }
}
