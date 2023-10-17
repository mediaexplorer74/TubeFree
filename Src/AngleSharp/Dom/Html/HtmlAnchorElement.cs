// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlAnchorElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlAnchorElement : 
    HtmlUrlBaseElement,
    IHtmlAnchorElement,
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
    IUrlUtilities
  {
    public HtmlAnchorElement(Document owner, string prefix = null)
      : base(owner, TagNames.A, prefix, NodeFlags.HtmlFormatting)
    {
    }

    public string Charset
    {
      get => this.GetOwnAttribute(AttributeNames.Charset);
      set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public string Text
    {
      get => this.TextContent;
      set => this.TextContent = value;
    }

    public override void DoFocus()
    {
      if (!this.HasOwnAttribute(AttributeNames.Href))
        return;
      this.IsFocused = true;
    }
  }
}
