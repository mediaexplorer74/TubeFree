// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlTableElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLTableElement")]
  public interface IHtmlTableElement : 
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
    [DomName("caption")]
    IHtmlTableCaptionElement Caption { get; set; }

    [DomName("createCaption")]
    IHtmlTableCaptionElement CreateCaption();

    [DomName("deleteCaption")]
    void DeleteCaption();

    [DomName("tHead")]
    IHtmlTableSectionElement Head { get; set; }

    [DomName("createTHead")]
    IHtmlTableSectionElement CreateHead();

    [DomName("deleteTHead")]
    void DeleteHead();

    [DomName("tFoot")]
    IHtmlTableSectionElement Foot { get; set; }

    [DomName("createTFoot")]
    IHtmlTableSectionElement CreateFoot();

    [DomName("deleteTFoot")]
    void DeleteFoot();

    [DomName("tBodies")]
    IHtmlCollection<IHtmlTableSectionElement> Bodies { get; }

    [DomName("createTBody")]
    IHtmlTableSectionElement CreateBody();

    [DomName("rows")]
    IHtmlCollection<IHtmlTableRowElement> Rows { get; }

    [DomName("insertRow")]
    IHtmlTableRowElement InsertRowAt(int index = -1);

    [DomName("deleteRow")]
    void RemoveRowAt(int index);

    [DomName("border")]
    uint Border { get; set; }
  }
}
