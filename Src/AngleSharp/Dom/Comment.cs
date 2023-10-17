// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Comment
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.IO;

namespace AngleSharp.Dom
{
  internal sealed class Comment : 
    CharacterData,
    IComment,
    ICharacterData,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IChildNode,
    INonDocumentTypeChildNode
  {
    internal Comment(Document owner)
      : this(owner, string.Empty)
    {
    }

    internal Comment(Document owner, string data)
      : base(owner, "#comment", NodeType.Comment, data)
    {
    }

    public override INode Clone(bool deep = true)
    {
      Comment target = new Comment(this.Owner, this.Data);
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter) => writer.Write(formatter.Comment((IComment) this));
  }
}
