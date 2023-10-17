// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.ShadowRoot
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AngleSharp.Dom
{
  internal sealed class ShadowRoot : 
    Node,
    IShadowRoot,
    IDocumentFragment,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    INonElementParentNode
  {
    private readonly Element _host;
    private readonly IStyleSheetList _styleSheets;
    private readonly ShadowRootMode _mode;
    private HtmlCollection<IElement> _elements;

    internal ShadowRoot(Element host, ShadowRootMode mode)
      : base(host.Owner, "#shadow-root", NodeType.DocumentFragment)
    {
      this._host = host;
      this._styleSheets = this.CreateStyleSheets();
      this._mode = mode;
    }

    public IElement ActiveElement => (IElement) this.GetDescendants().OfType<Element>().Where<Element>((Func<Element, bool>) (m => m.IsFocused)).FirstOrDefault<Element>();

    public IElement Host => (IElement) this._host;

    public string InnerHtml
    {
      get => this.ChildNodes.ToHtml(HtmlMarkupFormatter.Instance);
      set => this.ReplaceAll((Node) new DocumentFragment(this._host, value), false);
    }

    public IStyleSheetList StyleSheets => this._styleSheets;

    public int ChildElementCount => this.ChildNodes.OfType<Element>().Count<Element>();

    public IHtmlCollection<IElement> Children => (IHtmlCollection<IElement>) this._elements ?? (IHtmlCollection<IElement>) (this._elements = new HtmlCollection<IElement>((INode) this, false));

    public IElement FirstElementChild
    {
      get
      {
        NodeList childNodes = this.ChildNodes;
        int length = childNodes.Length;
        for (int index = 0; index < length; ++index)
        {
          if (childNodes[index] is IElement firstElementChild)
            return firstElementChild;
        }
        return (IElement) null;
      }
    }

    public IElement LastElementChild
    {
      get
      {
        NodeList childNodes = this.ChildNodes;
        for (int index = childNodes.Length - 1; index >= 0; --index)
        {
          if (childNodes[index] is IElement lastElementChild)
            return lastElementChild;
        }
        return (IElement) null;
      }
    }

    public override string TextContent
    {
      get
      {
        StringBuilder sb = Pool.NewStringBuilder();
        foreach (IText text in this.GetDescendants().OfType<IText>())
          sb.Append(text.Data);
        return sb.ToPool();
      }
      set => this.ReplaceAll(!string.IsNullOrEmpty(value) ? (Node) new TextNode(this.Owner, value) : (Node) null, false);
    }

    public override INode Clone(bool deep = true)
    {
      ShadowRoot target = new ShadowRoot(this._host, this._mode);
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }

    public void Prepend(params INode[] nodes) => this.PrependNodes(nodes);

    public void Append(params INode[] nodes) => this.AppendNodes(nodes);

    public IElement QuerySelector(string selectors) => this.ChildNodes.QuerySelector(selectors);

    public IHtmlCollection<IElement> QuerySelectorAll(string selectors) => (IHtmlCollection<IElement>) this.ChildNodes.QuerySelectorAll(selectors);

    public IHtmlCollection<IElement> GetElementsByClassName(string classNames) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByClassName(classNames);

    public IHtmlCollection<IElement> GetElementsByTagName(string tagName) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByTagName(tagName);

    public IHtmlCollection<IElement> GetElementsByTagNameNS(string namespaceURI, string tagName) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByTagName(namespaceURI, tagName);

    public IElement GetElementById(string elementId) => this.ChildNodes.GetElementById(elementId);

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter) => this.ChildNodes.ToHtml(writer, formatter);
  }
}
