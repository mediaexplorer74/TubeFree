// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlMapElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlMapElement : 
    HtmlElement,
    IHtmlMapElement,
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
    private HtmlCollection<IHtmlAreaElement> _areas;
    private HtmlCollection<IHtmlImageElement> _images;

    public HtmlMapElement(Document owner, string prefix = null)
      : base(owner, TagNames.Map, prefix)
    {
    }

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public IHtmlCollection<IHtmlAreaElement> Areas => (IHtmlCollection<IHtmlAreaElement>) this._areas ?? (IHtmlCollection<IHtmlAreaElement>) (this._areas = new HtmlCollection<IHtmlAreaElement>((INode) this, false));

    public IHtmlCollection<IHtmlImageElement> Images => (IHtmlCollection<IHtmlImageElement>) this._images ?? (IHtmlCollection<IHtmlImageElement>) (this._images = new HtmlCollection<IHtmlImageElement>((INode) this.Owner.DocumentElement, predicate: new Predicate<IHtmlImageElement>(this.IsAssociatedImage)));

    private bool IsAssociatedImage(IHtmlImageElement image)
    {
      string useMap = image.UseMap;
      if (string.IsNullOrEmpty(useMap))
        return false;
      string other = useMap.Has('#') ? "#" + this.Name : this.Name;
      return useMap.Is(other);
    }
  }
}
