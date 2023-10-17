// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.TextNode
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.IO;
using System.Text;

namespace AngleSharp.Dom
{
  internal sealed class TextNode : 
    CharacterData,
    IText,
    ICharacterData,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IChildNode,
    INonDocumentTypeChildNode
  {
    internal TextNode(Document owner)
      : this(owner, string.Empty)
    {
    }

    internal TextNode(Document owner, string text)
      : base(owner, "#text", NodeType.Text, text)
    {
    }

    internal bool IsEmpty
    {
      get
      {
        for (int index = 0; index < this.Length; ++index)
        {
          if (!this[index].IsSpaceCharacter())
            return false;
        }
        return true;
      }
    }

    public string Text
    {
      get
      {
        Node previousSibling = this.PreviousSibling;
        textNode = this;
        StringBuilder sb = Pool.NewStringBuilder();
        for (; previousSibling is TextNode; previousSibling = textNode.PreviousSibling)
          textNode = (TextNode) previousSibling;
        do
        {
          sb.Append(textNode.Data);
        }
        while (textNode.NextSibling is TextNode textNode);
        return sb.ToPool();
      }
    }

    public IElement AssignedSlot
    {
      get
      {
        IElement parentElement = this.ParentElement;
        return parentElement.IsShadow() ? parentElement.ShadowRoot.GetAssignedSlot((string) null) : (IElement) null;
      }
    }

    public override INode Clone(bool deep = true)
    {
      TextNode target = new TextNode(this.Owner, this.Data);
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }

    public IText Split(int offset)
    {
      int length = this.Length;
      if (offset > length)
        throw new DomException(DomError.IndexSizeError);
      int count = length - offset;
      TextNode newNode = new TextNode(this.Owner, this.Substring(offset, count));
      Node parent = this.Parent;
      Document owner = this.Owner;
      if (parent != null)
      {
        int index = this.Index();
        parent.InsertBefore((INode) newNode, (INode) this.NextSibling);
        owner.ForEachRange((Predicate<Range>) (m => m.Head == this && m.Start > offset), (Action<Range>) (m => m.StartWith((INode) newNode, m.Start - offset)));
        owner.ForEachRange((Predicate<Range>) (m => m.Tail == this && m.End > offset), (Action<Range>) (m => m.EndWith((INode) newNode, m.End - offset)));
        owner.ForEachRange((Predicate<Range>) (m => m.Head == parent && m.Start == index + 1), (Action<Range>) (m => m.StartWith((INode) parent, m.Start + 1)));
        owner.ForEachRange((Predicate<Range>) (m => m.Tail == parent && m.End == index + 1), (Action<Range>) (m => m.StartWith((INode) parent, m.End + 1)));
      }
      this.Replace(offset, count, string.Empty);
      if (parent != null)
      {
        owner.ForEachRange((Predicate<Range>) (m => m.Head == this && m.Start > offset), (Action<Range>) (m => m.StartWith((INode) this, offset)));
        owner.ForEachRange((Predicate<Range>) (m => m.Tail == this && m.End > offset), (Action<Range>) (m => m.EndWith((INode) this, offset)));
      }
      return (IText) newNode;
    }

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter)
    {
      if (this.Parent != null && (this.Parent.Flags & NodeFlags.LiteralText) == NodeFlags.LiteralText)
        writer.Write(this.Data);
      else
        base.ToHtml(writer, formatter);
    }
  }
}
