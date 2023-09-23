// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlMetaElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using System.Text;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlMetaElement : 
    HtmlElement,
    IHtmlMetaElement,
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
    public HtmlMetaElement(Document owner, string prefix = null)
      : base(owner, TagNames.Meta, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    public string Content
    {
      get => this.GetOwnAttribute(AttributeNames.Content);
      set => this.SetOwnAttribute(AttributeNames.Content, value);
    }

    public string Charset
    {
      get => this.GetOwnAttribute(AttributeNames.Charset);
      set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    public string HttpEquivalent
    {
      get => this.GetOwnAttribute(AttributeNames.HttpEquiv);
      set => this.SetOwnAttribute(AttributeNames.HttpEquiv, value);
    }

    public string Scheme
    {
      get => this.GetOwnAttribute(AttributeNames.Scheme);
      set => this.SetOwnAttribute(AttributeNames.Scheme, value);
    }

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public Encoding GetEncoding()
    {
      string charset1 = this.Charset;
      if (charset1 != null)
      {
        string charset2 = charset1.Trim();
        if (TextEncoding.IsSupported(charset2))
          return TextEncoding.Resolve(charset2);
      }
      string httpEquivalent = this.HttpEquivalent;
      return (httpEquivalent == null ? 0 : (httpEquivalent.Isi(HeaderNames.ContentType) ? 1 : 0)) == 0 ? (Encoding) null : TextEncoding.Parse(this.Content ?? string.Empty);
    }
  }
}
