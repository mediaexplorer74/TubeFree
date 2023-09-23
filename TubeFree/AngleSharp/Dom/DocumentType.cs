// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.DocumentType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom
{
  internal sealed class DocumentType : 
    Node,
    IDocumentType,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IChildNode
  {
    internal DocumentType(Document owner, string name)
      : base(owner, name, NodeType.DocumentType)
    {
      this.PublicIdentifier = string.Empty;
      this.SystemIdentifier = string.Empty;
    }

    public IElement PreviousElementSibling
    {
      get
      {
        Node parent = this.Parent;
        if (parent != null)
        {
          bool flag = false;
          for (int index = parent.ChildNodes.Length - 1; index >= 0; --index)
          {
            if (parent.ChildNodes[index] == this)
              flag = true;
            else if (flag && parent.ChildNodes[index] is IElement)
              return (IElement) parent.ChildNodes[index];
          }
        }
        return (IElement) null;
      }
    }

    public IElement NextElementSibling
    {
      get
      {
        Node parent = this.Parent;
        if (parent != null)
        {
          int length = parent.ChildNodes.Length;
          bool flag = false;
          for (int index = 0; index < length; ++index)
          {
            if (parent.ChildNodes[index] == this)
              flag = true;
            else if (flag && parent.ChildNodes[index] is IElement)
              return (IElement) parent.ChildNodes[index];
          }
        }
        return (IElement) null;
      }
    }

    public IEnumerable<Entity> Entities => Enumerable.Empty<Entity>();

    public IEnumerable<Notation> Notations => Enumerable.Empty<Notation>();

    public string Name => this.NodeName;

    public string PublicIdentifier { get; set; }

    public string SystemIdentifier { get; set; }

    public string InternalSubset { get; set; }

    public override INode Clone(bool deep = true)
    {
      DocumentType target = new DocumentType(this.Owner, this.Name)
      {
        PublicIdentifier = this.PublicIdentifier,
        SystemIdentifier = this.SystemIdentifier,
        InternalSubset = this.InternalSubset
      };
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }

    public void Before(params INode[] nodes) => this.InsertBefore(nodes);

    public void After(params INode[] nodes) => this.InsertAfter(nodes);

    public void Replace(params INode[] nodes) => this.ReplaceWith(nodes);

    public void Remove() => this.RemoveFromParent();

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter) => writer.Write(formatter.Doctype((IDocumentType) this));

    protected override string LocateNamespace(string prefix) => (string) null;

    protected override string LocatePrefix(string namespaceUri) => (string) null;
  }
}
