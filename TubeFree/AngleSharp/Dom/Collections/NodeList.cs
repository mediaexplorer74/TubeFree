// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.NodeList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Collections
{
  internal sealed class NodeList : INodeList, IEnumerable<INode>, IEnumerable, IMarkupFormattable
  {
    private readonly List<Node> _entries;
    internal static readonly NodeList Empty = new NodeList();

    internal NodeList() => this._entries = new List<Node>();

    public Node this[int index]
    {
      get => this._entries[index];
      set => this._entries[index] = value;
    }

    INode INodeList.this[int index] => (INode) this[index];

    public int Length => this._entries.Count;

    internal void Add(Node node) => this._entries.Add(node);

    internal void AddRange(NodeList nodeList) => this._entries.AddRange((IEnumerable<Node>) nodeList._entries);

    internal void Insert(int index, Node node) => this._entries.Insert(index, node);

    internal void Remove(Node node) => this._entries.Remove(node);

    internal void RemoveAt(int index) => this._entries.RemoveAt(index);

    internal bool Contains(Node node) => this._entries.Contains(node);

    public void ToHtml(TextWriter writer, IMarkupFormatter formatter)
    {
      for (int index = 0; index < this._entries.Count; ++index)
        this._entries[index].ToHtml(writer, formatter);
    }

    public IEnumerator<INode> GetEnumerator() => (IEnumerator<INode>) this._entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._entries.GetEnumerator();
  }
}
