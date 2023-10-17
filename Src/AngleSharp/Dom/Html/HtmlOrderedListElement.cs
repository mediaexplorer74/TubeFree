// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlOrderedListElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlOrderedListElement : 
    HtmlElement,
    IHtmlOrderedListElement,
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
    public HtmlOrderedListElement(Document owner, string prefix = null)
      : base(owner, TagNames.Ol, prefix, NodeFlags.Special | NodeFlags.HtmlListScoped)
    {
    }

    public bool IsReversed
    {
      get => this.GetBoolAttribute(AttributeNames.Reversed);
      set => this.SetBoolAttribute(AttributeNames.Reversed, value);
    }

    public int Start
    {
      get => this.GetOwnAttribute(AttributeNames.Start).ToInteger(1);
      set => this.SetOwnAttribute(AttributeNames.Start, value.ToString());
    }

    public string Type
    {
      get => this.GetOwnAttribute(AttributeNames.Type);
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }
  }
}
