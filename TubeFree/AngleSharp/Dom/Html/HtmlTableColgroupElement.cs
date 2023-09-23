// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTableColgroupElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlTableColgroupElement : 
    HtmlElement,
    IHtmlTableColumnElement,
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
    public HtmlTableColgroupElement(Document owner, string prefix = null)
      : base(owner, TagNames.Colgroup, prefix, NodeFlags.Special)
    {
    }

    public HorizontalAlignment Align
    {
      get => this.GetOwnAttribute(AttributeNames.Align).ToEnum<HorizontalAlignment>(HorizontalAlignment.Center);
      set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public int Span
    {
      get => this.GetOwnAttribute(AttributeNames.Span).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.Span, value.ToString());
    }

    public VerticalAlignment VAlign
    {
      get => this.GetOwnAttribute(AttributeNames.Valign).ToEnum<VerticalAlignment>(VerticalAlignment.Middle);
      set => this.SetOwnAttribute(AttributeNames.Valign, value.ToString());
    }

    public string Width
    {
      get => this.GetOwnAttribute(AttributeNames.Width);
      set => this.SetOwnAttribute(AttributeNames.Width, value);
    }
  }
}
