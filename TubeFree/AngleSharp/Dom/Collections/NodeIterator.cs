// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.NodeIterator
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class NodeIterator : INodeIterator
  {
    private readonly INode _root;
    private readonly FilterSettings _settings;
    private readonly NodeFilter _filter;
    private readonly IEnumerable<INode> _iterator;
    private INode _reference;
    private bool _beforeNode;

    public NodeIterator(INode root, FilterSettings settings, NodeFilter filter)
    {
      this._root = root;
      this._settings = settings;
      this._filter = filter ?? (NodeFilter) (m => FilterResult.Accept);
      this._beforeNode = true;
      this._iterator = this._root.GetElements<INode>(settings);
      this._reference = this._iterator.First<INode>();
    }

    public INode Root => this._root;

    public FilterSettings Settings => this._settings;

    public NodeFilter Filter => this._filter;

    public INode Reference => this._reference;

    public bool IsBeforeReference => this._beforeNode;

    public INode Next()
    {
      INode node = this._reference;
      bool flag = this._beforeNode;
      do
      {
        if (!flag)
          node = this._iterator.SkipWhile<INode>((Func<INode, bool>) (m => m != node)).Skip<INode>(1).FirstOrDefault<INode>();
        if (node == null)
          return (INode) null;
        flag = false;
      }
      while (this._filter(node) != FilterResult.Accept);
      this._beforeNode = false;
      this._reference = node;
      return node;
    }

    public INode Previous()
    {
      INode node = this._reference;
      bool flag = this._beforeNode;
      do
      {
        if (flag)
          node = this._iterator.TakeWhile<INode>((Func<INode, bool>) (m => m != node)).LastOrDefault<INode>();
        if (node == null)
          return (INode) null;
        flag = true;
      }
      while (this._filter(node) != FilterResult.Accept);
      this._beforeNode = true;
      this._reference = node;
      return node;
    }
  }
}
