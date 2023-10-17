// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ParentNodeExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  internal static class ParentNodeExtensions
  {
    public static INode MutationMacro(this INode parent, INode[] nodes)
    {
      if (nodes.Length <= 1)
        return nodes[0];
      IDocumentFragment documentFragment = parent.Owner.CreateDocumentFragment();
      for (int index = 0; index < nodes.Length; ++index)
        documentFragment.AppendChild(nodes[index]);
      return (INode) documentFragment;
    }

    public static void PrependNodes(this INode parent, params INode[] nodes)
    {
      if (nodes.Length == 0)
        return;
      INode node = parent.MutationMacro(nodes);
      parent.PreInsert(node, parent.FirstChild);
    }

    public static void AppendNodes(this INode parent, params INode[] nodes)
    {
      if (nodes.Length == 0)
        return;
      INode node = parent.MutationMacro(nodes);
      parent.PreInsert(node, (INode) null);
    }

    public static void InsertBefore(this INode child, params INode[] nodes)
    {
      INode parent = child.Parent;
      if (parent == null || nodes.Length == 0)
        return;
      INode node = parent.MutationMacro(nodes);
      parent.PreInsert(node, child);
    }

    public static void InsertAfter(this INode child, params INode[] nodes)
    {
      INode parent = child.Parent;
      if (parent == null || nodes.Length == 0)
        return;
      INode node = parent.MutationMacro(nodes);
      parent.PreInsert(node, child.NextSibling);
    }

    public static void ReplaceWith(this INode child, params INode[] nodes)
    {
      INode parent = child.Parent;
      if (parent == null)
        return;
      if (nodes.Length != 0)
      {
        INode newChild = parent.MutationMacro(nodes);
        parent.ReplaceChild(newChild, child);
      }
      else
        parent.RemoveChild(child);
    }

    public static void RemoveFromParent(this INode child)
    {
      INode parent = child.Parent;
      if (parent == null)
        return;
      parent.PreRemove(child);
    }

    public static IEnumerable<TNode> DescendentsAndSelf<TNode>(this INode parent) => parent.DescendentsAndSelf().OfType<TNode>();

    public static IEnumerable<INode> DescendentsAndSelf(this INode parent) => parent != null ? parent.GetDescendantsAndSelf() : throw new ArgumentNullException(nameof (parent));
  }
}
