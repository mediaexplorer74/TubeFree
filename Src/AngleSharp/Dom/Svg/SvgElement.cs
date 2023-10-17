// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Svg.SvgElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Services;

namespace AngleSharp.Dom.Svg
{
  internal class SvgElement : 
    Element,
    ISvgElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle
  {
    public SvgElement(Document owner, string name, string prefix = null, NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, NamespaceNames.SvgUri, flags | NodeFlags.SvgMember)
    {
    }

    public override INode Clone(bool deep = true)
    {
      SvgElement svgElement = this.Owner.Options.GetFactory<IElementFactory<SvgElement>>().Create(this.Owner, this.LocalName, this.Prefix);
      this.CloneElement((Element) svgElement, deep);
      return (INode) svgElement;
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      string ownAttribute = this.GetOwnAttribute(AttributeNames.Style);
      if (ownAttribute == null)
        return;
      this.UpdateStyle(ownAttribute);
    }
  }
}
