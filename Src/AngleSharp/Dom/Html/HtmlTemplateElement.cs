// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTemplateElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Html;
using System.IO;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlTemplateElement : 
    HtmlElement,
    IHtmlTemplateElement,
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers
  {
    private readonly DocumentFragment _content;

    public HtmlTemplateElement(Document owner, string prefix = null)
      : base(owner, TagNames.Template, prefix, NodeFlags.Special | NodeFlags.Scoped | NodeFlags.HtmlTableSectionScoped | NodeFlags.HtmlTableScoped)
    {
      this._content = new DocumentFragment(owner);
    }

    public IDocumentFragment Content => (IDocumentFragment) this._content;

    public void PopulateFragment()
    {
      while (this.HasChildNodes)
      {
        Node childNode = this.ChildNodes[0];
        this.RemoveNode(0, childNode);
        this._content.AddNode(childNode);
      }
    }

    public override INode Clone(bool deep = true)
    {
      HtmlTemplateElement htmlTemplateElement = new HtmlTemplateElement(this.Owner);
      this.CloneElement((Element) htmlTemplateElement, deep);
      for (int index = 0; index < this._content.ChildNodes.Length; ++index)
      {
        if (this._content.ChildNodes[index].Clone(deep) is Node node)
          htmlTemplateElement._content.AddNode(node);
      }
      return (INode) htmlTemplateElement;
    }

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter)
    {
      writer.Write(formatter.OpenTag((IElement) this, false));
      this._content.ChildNodes.ToHtml(writer, formatter);
      writer.Write(formatter.CloseTag((IElement) this, false));
    }

    internal override void NodeIsAdopted(Document oldDocument) => this._content.Owner = oldDocument;
  }
}
