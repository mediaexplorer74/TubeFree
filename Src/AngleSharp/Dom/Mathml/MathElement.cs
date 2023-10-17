// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Mathml.MathElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;
using AngleSharp.Services;

namespace AngleSharp.Dom.Mathml
{
  internal class MathElement : Element
  {
    public MathElement(Document owner, string name, string prefix = null, NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, NamespaceNames.MathMlUri, flags | NodeFlags.MathMember)
    {
    }

    public override INode Clone(bool deep = true)
    {
      MathElement mathElement = this.Owner.Options.GetFactory<IElementFactory<MathElement>>().Create(this.Owner, this.LocalName, this.Prefix);
      this.CloneElement((Element) mathElement, deep);
      return (INode) mathElement;
    }
  }
}
