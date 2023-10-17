// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlParamElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlParamElement : 
    HtmlElement,
    IHtmlParamElement,
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
    public HtmlParamElement(Document owner, string prefix = null)
      : base(owner, TagNames.Param, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    public string Value
    {
      get => this.GetOwnAttribute(AttributeNames.Value);
      set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }
  }
}
