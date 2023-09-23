// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlMenuItemElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlMenuItemElement : 
    HtmlElement,
    IHtmlMenuItemElement,
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
    public HtmlMenuItemElement(Document owner, string prefix = null)
      : base(owner, TagNames.MenuItem, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    internal bool IsVisited { get; set; }

    internal bool IsActive { get; set; }

    public IHtmlElement Command
    {
      get
      {
        string ownAttribute = this.GetOwnAttribute(AttributeNames.Command);
        return !string.IsNullOrEmpty(ownAttribute) ? this.Owner?.GetElementById(ownAttribute) as IHtmlElement : (IHtmlElement) null;
      }
    }

    public string Type
    {
      get => this.GetOwnAttribute(AttributeNames.Type);
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string Label
    {
      get => this.GetOwnAttribute(AttributeNames.Label);
      set => this.SetOwnAttribute(AttributeNames.Label, value);
    }

    public string Icon
    {
      get => this.GetOwnAttribute(AttributeNames.Icon);
      set => this.SetOwnAttribute(AttributeNames.Icon, value);
    }

    public bool IsDisabled
    {
      get => this.GetBoolAttribute(AttributeNames.Disabled);
      set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public bool IsChecked
    {
      get => this.GetBoolAttribute(AttributeNames.Checked);
      set => this.SetBoolAttribute(AttributeNames.Checked, value);
    }

    public bool IsDefault
    {
      get => this.GetBoolAttribute(AttributeNames.Default);
      set => this.SetBoolAttribute(AttributeNames.Default, value);
    }

    public string RadioGroup
    {
      get => this.GetOwnAttribute(AttributeNames.Radiogroup);
      set => this.SetOwnAttribute(AttributeNames.Radiogroup, value);
    }
  }
}
