// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlSlotElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using System.Collections.Generic;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLSlotElement")]
  public interface IHtmlSlotElement : 
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
    [DomName("name")]
    string Name { get; set; }

    [DomName("getDistributedNodes")]
    IEnumerable<INode> GetDistributedNodes();
  }
}
