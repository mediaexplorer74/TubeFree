// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Svg.SvgForeignObjectElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Html;

namespace AngleSharp.Dom.Svg
{
  internal sealed class SvgForeignObjectElement : 
    SvgElement,
    ISvgForeignObjectElement,
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
    public SvgForeignObjectElement(Document owner, string prefix = null)
      : base(owner, TagNames.ForeignObject, prefix, NodeFlags.Special | NodeFlags.Scoped | NodeFlags.HtmlTip)
    {
    }
  }
}
