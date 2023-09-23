// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTableSectionElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlTableSectionElement : 
    HtmlElement,
    IHtmlTableSectionElement,
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
    private HtmlCollection<IHtmlTableRowElement> _rows;

    public HtmlTableSectionElement(Document owner, string name = null, string prefix = null)
      : base(owner, name ?? TagNames.Tbody, prefix, NodeFlags.Special | NodeFlags.ImplicitelyClosed | NodeFlags.HtmlTableSectionScoped)
    {
    }

    public HorizontalAlignment Align
    {
      get => this.GetOwnAttribute(AttributeNames.Align).ToEnum<HorizontalAlignment>(HorizontalAlignment.Center);
      set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public IHtmlCollection<IHtmlTableRowElement> Rows => (IHtmlCollection<IHtmlTableRowElement>) this._rows ?? (IHtmlCollection<IHtmlTableRowElement>) (this._rows = new HtmlCollection<IHtmlTableRowElement>((INode) this, false));

    public VerticalAlignment VAlign
    {
      get => this.GetOwnAttribute(AttributeNames.Valign).ToEnum<VerticalAlignment>(VerticalAlignment.Middle);
      set => this.SetOwnAttribute(AttributeNames.Valign, value.ToString());
    }

    public IHtmlTableRowElement InsertRowAt(int index = -1)
    {
      IHtmlCollection<IHtmlTableRowElement> rows = this.Rows;
      IHtmlTableRowElement element = this.Owner.CreateElement(TagNames.Tr) as IHtmlTableRowElement;
      if (index >= 0 && index < rows.Length)
        this.InsertBefore((INode) element, (INode) rows[index]);
      else
        this.AppendChild((INode) element);
      return element;
    }

    public void RemoveRowAt(int index)
    {
      IHtmlCollection<IHtmlTableRowElement> rows = this.Rows;
      if (index < 0 || index >= rows.Length)
        return;
      rows[index].Remove();
    }
  }
}
