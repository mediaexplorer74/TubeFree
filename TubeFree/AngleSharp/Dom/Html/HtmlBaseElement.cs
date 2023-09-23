// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlBaseElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlBaseElement : 
    HtmlElement,
    IHtmlBaseElement,
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
    public HtmlBaseElement(Document owner, string prefix = null)
      : base(owner, TagNames.Base, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    public string Href
    {
      get => this.GetOwnAttribute(AttributeNames.Href);
      set => this.SetOwnAttribute(AttributeNames.Href, value);
    }

    public string Target
    {
      get => this.GetOwnAttribute(AttributeNames.Target);
      set => this.SetOwnAttribute(AttributeNames.Target, value);
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      string ownAttribute = this.GetOwnAttribute(AttributeNames.Href);
      if (ownAttribute == null)
        return;
      this.UpdateUrl(ownAttribute);
    }

    internal void UpdateUrl(string url) => this.Owner.BaseUrl = new Url(this.Owner.DocumentUrl, url ?? string.Empty);
  }
}
