// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlSourceElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlSourceElement : 
    HtmlElement,
    IHtmlSourceElement,
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
    public HtmlSourceElement(Document owner, string prefix = null)
      : base(owner, TagNames.Source, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    public string Source
    {
      get => this.GetUrlAttribute(AttributeNames.Src);
      set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Media
    {
      get => this.GetOwnAttribute(AttributeNames.Media);
      set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Type
    {
      get => this.GetOwnAttribute(AttributeNames.Type);
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string SourceSet
    {
      get => this.GetOwnAttribute(AttributeNames.SrcSet);
      set => this.SetOwnAttribute(AttributeNames.SrcSet, value);
    }

    public string Sizes
    {
      get => this.GetOwnAttribute(AttributeNames.Sizes);
      set => this.SetOwnAttribute(AttributeNames.Sizes, value);
    }
  }
}
