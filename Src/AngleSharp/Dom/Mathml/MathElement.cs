using AngleSharp.Extensions;
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
      MathElement mathElement = this.Owner.Options.GetFactory<IElementFactory<MathElement>>
                ().Create(this.Owner, this.LocalName, this.Prefix);
      this.CloneElement((Element) mathElement, deep);
      return (INode) mathElement;
    }
  }
}
