// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.EntityReference
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Dom
{
  internal sealed class EntityReference : Node
  {
    internal EntityReference(Document owner)
      : this(owner, string.Empty)
    {
    }

    internal EntityReference(Document owner, string name)
      : base(owner, name, NodeType.EntityReference)
    {
    }

    public override INode Clone(bool deep = true)
    {
      EntityReference target = new EntityReference(this.Owner, this.NodeName);
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }
  }
}
