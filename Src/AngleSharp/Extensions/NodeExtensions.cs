﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.NodeExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  internal static class NodeExtensions
  {
    public static INode GetRoot(this INode node) => node.Parent == null ? node : node.Parent.GetRoot();

    public static NodeList CreateChildren(this INode node) => !node.IsEndPoint() ? new NodeList() : NodeList.Empty;

    public static bool IsEndPoint(this INode node)
    {
      NodeType nodeType = node.NodeType;
      switch (nodeType)
      {
        case NodeType.Document:
        case NodeType.DocumentFragment:
          return false;
        default:
          return nodeType != NodeType.Element;
      }
    }

    public static bool IsInsertable(this INode node)
    {
      NodeType nodeType = node.NodeType;
      switch (nodeType)
      {
        case NodeType.Element:
        case NodeType.Text:
        case NodeType.ProcessingInstruction:
        case NodeType.Comment:
        case NodeType.DocumentFragment:
          return true;
        default:
          return nodeType == NodeType.DocumentType;
      }
    }

    public static Url HyperReference(this INode node, string url) => url == null ? (Url) null : new Url(node.BaseUrl, url);

    public static bool IsDescendantOf(this INode node, INode parent)
    {
      if (node.Parent == null)
        return false;
      return node.Parent == parent || node.Parent.IsDescendantOf(parent);
    }

    public static IEnumerable<INode> GetDescendants(this INode parent) => parent.GetDescendantsAndSelf().Skip<INode>(1);

    public static IEnumerable<INode> GetDescendantsAndSelf(this INode parent)
    {
      Stack<INode> stack = new Stack<INode>();
      stack.Push(parent);
      while (stack.Count > 0)
      {
        INode next = stack.Pop();
        yield return next;
        int length = next.ChildNodes.Length;
        while (length > 0)
          stack.Push(next.ChildNodes[--length]);
        next = (INode) null;
      }
    }

    public static bool IsInclusiveDescendantOf(this INode node, INode parent) => node == parent || node.IsDescendantOf(parent);

    public static bool IsAncestorOf(this INode parent, INode node) => node.IsDescendantOf(parent);

    public static IEnumerable<INode> GetAncestors(this INode node)
    {
      while ((node = node.Parent) != null)
        yield return node;
    }

    public static IEnumerable<INode> GetInclusiveAncestors(this INode node)
    {
      do
      {
        yield return node;
      }
      while ((node = node.Parent) != null);
    }

    public static bool IsInclusiveAncestorOf(this INode parent, INode node) => node == parent || node.IsDescendantOf(parent);

    public static T GetAncestor<T>(this INode node) where T : INode
    {
      while ((node = node.Parent) != null)
      {
        if (node is T ancestor)
          return ancestor;
      }
      return default (T);
    }

    public static bool HasDataListAncestor(this INode child) => child.Ancestors<IHtmlDataListElement>().Any<IHtmlDataListElement>();

    public static bool IsSiblingOf(this INode node, INode element) => node?.Parent == element.Parent;

    public static int Index(this INode node) => node.Parent.IndexOf(node);

    public static int IndexOf(this INode parent, INode node)
    {
      int num = 0;
      if (parent != null)
      {
        foreach (INode childNode in (IEnumerable<INode>) parent.ChildNodes)
        {
          if (childNode == node)
            return num;
          ++num;
        }
      }
      return -1;
    }

    public static bool IsPreceding(this INode before, INode after)
    {
      Queue<INode> before1 = new Queue<INode>(before.GetInclusiveAncestors());
      Queue<INode> after1 = new Queue<INode>(after.GetInclusiveAncestors());
      int num = after1.Count - before1.Count;
      if (num != 0)
      {
        while (before1.Count > after1.Count)
          before1.Dequeue();
        while (after1.Count > before1.Count)
          after1.Dequeue();
        if (NodeExtensions.IsCurrentlySame(after1, before1))
          return num > 0;
      }
      while (before1.Count > 0)
      {
        before = before1.Dequeue();
        after = after1.Dequeue();
        if (NodeExtensions.IsCurrentlySame(after1, before1))
          return before.Index() < after.Index();
      }
      return false;
    }

    public static bool IsFollowing(this INode after, INode before) => before.IsPreceding(after);

    public static INode GetAssociatedHost(this INode node)
    {
      if (!(node is IDocumentFragment))
        return (INode) null;
      IDocument owner = node.Owner;
      return owner == null ? (INode) null : (INode) owner.All.OfType<IHtmlTemplateElement>().FirstOrDefault<IHtmlTemplateElement>((Func<IHtmlTemplateElement, bool>) (m => m.Content == node));
    }

    public static bool IsHostIncludingInclusiveAncestor(this INode parent, INode node)
    {
      if (parent.IsInclusiveAncestorOf(node))
        return true;
      INode associatedHost = node.GetRoot().GetAssociatedHost();
      return associatedHost != null && parent.IsInclusiveAncestorOf(associatedHost);
    }

    public static void EnsurePreInsertionValidity(this INode parent, INode node, INode child)
    {
      if (parent.IsEndPoint() || node.IsHostIncludingInclusiveAncestor(parent))
        throw new DomException(DomError.HierarchyRequest);
      if (child != null && child.Parent != parent)
        throw new DomException(DomError.NotFound);
      switch (node)
      {
        case IElement _:
        case ICharacterData _:
        case IDocumentType _:
        case IDocumentFragment _:
          if (parent is IDocument document)
          {
            bool flag = false;
            switch (node.NodeType)
            {
              case NodeType.Element:
                flag = document.DocumentElement != null || child is IDocumentType || child.IsFollowedByDoctype();
                break;
              case NodeType.Text:
                flag = true;
                break;
              case NodeType.DocumentType:
                flag = document.Doctype != null || child != null && child.IsPrecededByElement() || child == null && document.DocumentElement != null;
                break;
              case NodeType.DocumentFragment:
                int elementCount = node.GetElementCount();
                flag = elementCount > 1 || node.HasTextNodes() || elementCount == 1 && document.DocumentElement != null || child is IDocumentType || child.IsFollowedByDoctype();
                break;
            }
            if (!flag)
              break;
            throw new DomException(DomError.HierarchyRequest);
          }
          if (!(node is IDocumentType))
            break;
          throw new DomException(DomError.HierarchyRequest);
        default:
          throw new DomException(DomError.HierarchyRequest);
      }
    }

    public static INode PreInsert(this INode parent, INode node, INode child)
    {
      Node node1 = parent as Node;
      Node newElement = node as Node;
      if (node1 == null)
        throw new DomException(DomError.NotSupported);
      parent.EnsurePreInsertionValidity(node, child);
      Node referenceElement = child as Node;
      if (referenceElement == node)
        referenceElement = newElement.NextSibling;
      (parent.Owner ?? parent as IDocument).AdoptNode(node);
      node1.InsertBefore(newElement, referenceElement, false);
      return node;
    }

    public static INode PreRemove(this INode parent, INode child)
    {
      if (!(parent is Node node))
        throw new DomException(DomError.NotSupported);
      if (child == null || child.Parent != parent)
        throw new DomException(DomError.NotFound);
      node.RemoveChild(child as Node, false);
      return child;
    }

    public static bool HasTextNodes(this INode node) => node.ChildNodes.OfType<IText>().Any<IText>();

    public static bool IsFollowedByDoctype(this INode child)
    {
      if (child != null)
      {
        bool flag = true;
        foreach (INode childNode in (IEnumerable<INode>) child.Parent.ChildNodes)
        {
          if (flag)
            flag = childNode != child;
          else if (childNode.NodeType == NodeType.DocumentType)
            return true;
        }
      }
      return false;
    }

    public static bool IsPrecededByElement(this INode child)
    {
      foreach (INode childNode in (IEnumerable<INode>) child.Parent.ChildNodes)
      {
        if (childNode != child)
        {
          if (childNode.NodeType == NodeType.Element)
            return true;
        }
        else
          break;
      }
      return false;
    }

    public static int GetElementCount(this INode parent)
    {
      int elementCount = 0;
      foreach (INode childNode in (IEnumerable<INode>) parent.ChildNodes)
      {
        if (childNode.NodeType == NodeType.Element)
          ++elementCount;
      }
      return elementCount;
    }

    public static TNode FindChild<TNode>(this INode parent) where TNode : class, INode
    {
      if (parent != null)
      {
        for (int index = 0; index < parent.ChildNodes.Length; ++index)
        {
          if (parent.ChildNodes[index] is TNode childNode)
            return childNode;
        }
      }
      return default (TNode);
    }

    public static TNode FindDescendant<TNode>(this INode parent) where TNode : class, INode
    {
      if (parent != null)
      {
        for (int index = 0; index < parent.ChildNodes.Length; ++index)
        {
          INode childNode = parent.ChildNodes[index];
          if (!(childNode is TNode node))
            node = childNode.FindDescendant<TNode>();
          TNode descendant = node;
          if ((object) descendant != null)
            return descendant;
        }
      }
      return default (TNode);
    }

    public static IElement GetAssignedSlot(this IShadowRoot root, string name) => (IElement) root.GetDescendants().OfType<IHtmlSlotElement>().FirstOrDefault<IHtmlSlotElement>((Func<IHtmlSlotElement, bool>) (m => m.Name.Is(name)));

    private static bool IsCurrentlySame(Queue<INode> after, Queue<INode> before) => after.Count > 0 && before.Count > 0 && after.Peek() == before.Peek();
  }
}
