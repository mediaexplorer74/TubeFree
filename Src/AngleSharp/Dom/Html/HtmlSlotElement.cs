// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlSlotElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlSlotElement : 
    HtmlElement,
    IHtmlSlotElement,
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
    public HtmlSlotElement(Document owner, string prefix = null)
      : base(owner, TagNames.Slot, prefix)
    {
    }

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public IEnumerable<INode> GetDistributedNodes()
    {
      IElement host = this.GetAncestor<IShadowRoot>()?.Host;
      if (host == null)
        return Enumerable.Empty<INode>();
      List<INode> distributedNodes = new List<INode>();
      foreach (INode childNode in (IEnumerable<INode>) host.ChildNodes)
      {
        if (HtmlSlotElement.GetAssignedSlot(childNode) == this)
        {
          if (childNode is HtmlSlotElement htmlSlotElement)
            distributedNodes.AddRange(htmlSlotElement.GetDistributedNodes());
          else
            distributedNodes.Add(childNode);
        }
      }
      return (IEnumerable<INode>) distributedNodes;
    }

    private static IElement GetAssignedSlot(INode node)
    {
      switch (node.NodeType)
      {
        case NodeType.Element:
          return ((IElement) node).AssignedSlot;
        case NodeType.Text:
          return ((IText) node).AssignedSlot;
        default:
          return (IElement) null;
      }
    }
  }
}
