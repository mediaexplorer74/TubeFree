// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTableRowElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System.Collections.Generic;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlTableRowElement : 
    HtmlElement,
    IHtmlTableRowElement,
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
    private HtmlCollection<IHtmlTableCellElement> _cells;

    public HtmlTableRowElement(Document owner, string prefix = null)
      : base(owner, TagNames.Tr, prefix, NodeFlags.Special | NodeFlags.ImplicitelyClosed)
    {
    }

    public HorizontalAlignment Align
    {
      get => this.GetOwnAttribute(AttributeNames.Align).ToEnum<HorizontalAlignment>(HorizontalAlignment.Left);
      set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public VerticalAlignment VAlign
    {
      get => this.GetOwnAttribute(AttributeNames.Valign).ToEnum<VerticalAlignment>(VerticalAlignment.Middle);
      set => this.SetOwnAttribute(AttributeNames.Valign, value.ToString());
    }

    public string BgColor
    {
      get => this.GetOwnAttribute(AttributeNames.BgColor);
      set => this.SetOwnAttribute(AttributeNames.BgColor, value);
    }

    public IHtmlCollection<IHtmlTableCellElement> Cells => (IHtmlCollection<IHtmlTableCellElement>) this._cells ?? (IHtmlCollection<IHtmlTableCellElement>) (this._cells = new HtmlCollection<IHtmlTableCellElement>((INode) this, false));

    public int Index
    {
      get
      {
        IHtmlTableElement ancestor = this.GetAncestor<IHtmlTableElement>();
        return ancestor == null ? -1 : ((IEnumerable<INode>) ancestor.Rows).Index((INode) this);
      }
    }

    public int IndexInSection => !(this.ParentElement is IHtmlTableSectionElement parentElement) ? this.Index : ((IEnumerable<INode>) parentElement.Rows).Index((INode) this);

    public IHtmlTableCellElement InsertCellAt(int index = -1)
    {
      IHtmlCollection<IHtmlTableCellElement> cells = this.Cells;
      IHtmlTableCellElement element = this.Owner.CreateElement(TagNames.Td) as IHtmlTableCellElement;
      if (index >= 0 && index < cells.Length)
        this.InsertBefore((INode) element, (INode) cells[index]);
      else
        this.AppendChild((INode) element);
      return element;
    }

    public void RemoveCellAt(int index)
    {
      IHtmlCollection<IHtmlTableCellElement> cells = this.Cells;
      if (index < 0)
        index = cells.Length + index;
      if (index < 0 || index >= cells.Length)
        return;
      cells[index].Remove();
    }
  }
}
