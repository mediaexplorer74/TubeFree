// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Notation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Dom
{
  internal sealed class Notation : Node
  {
    internal Notation(Document owner)
      : base(owner, "#notation", NodeType.Notation)
    {
    }

    public string PublicId { get; set; }

    public string SystemId { get; set; }

    public override INode Clone(bool deep = true)
    {
      Notation target = new Notation(this.Owner)
      {
        PublicId = this.PublicId,
        SystemId = this.SystemId
      };
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }
  }
}
