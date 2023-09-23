// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlListItemElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlListItemElement : 
    HtmlElement,
    IHtmlListItemElement,
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
    public HtmlListItemElement(Document owner, string name = null, string prefix = null)
      : base(owner, name ?? TagNames.Li, prefix, NodeFlags.Special | NodeFlags.ImplicitelyClosed | NodeFlags.ImpliedEnd)
    {
    }

    public int? Value
    {
      get
      {
        int result = 0;
        return !int.TryParse(this.GetOwnAttribute(AttributeNames.Value), out result) ? new int?() : new int?(result);
      }
      set => this.SetOwnAttribute(AttributeNames.Value, value.HasValue ? value.Value.ToString() : (string) null);
    }
  }
}
