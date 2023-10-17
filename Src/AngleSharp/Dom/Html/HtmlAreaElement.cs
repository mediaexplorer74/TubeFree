// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlAreaElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlAreaElement : 
    HtmlUrlBaseElement,
    IHtmlAreaElement,
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
    public HtmlAreaElement(Document owner, string prefix = null)
      : base(owner, TagNames.Area, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    public string AlternativeText
    {
      get => this.GetOwnAttribute(AttributeNames.Alt);
      set => this.SetOwnAttribute(AttributeNames.Alt, value);
    }

    public string Coordinates
    {
      get => this.GetOwnAttribute(AttributeNames.Coords);
      set => this.SetOwnAttribute(AttributeNames.Coords, value);
    }

    public string Shape
    {
      get => this.GetOwnAttribute(AttributeNames.Shape);
      set => this.SetOwnAttribute(AttributeNames.Shape, value);
    }
  }
}
