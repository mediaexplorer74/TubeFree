// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.PseudoElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom
{
  internal abstract class PseudoElement : 
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IPseudoElement,
    IStyleUtilities
  {
    private static readonly Dictionary<string, Func<IElement, PseudoElement>> creators = new Dictionary<string, Func<IElement, PseudoElement>>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        ":" + PseudoElementNames.Before,
        (Func<IElement, PseudoElement>) (element => (PseudoElement) new PseudoElement.BeforePseudoElement(element))
      },
      {
        "::" + PseudoElementNames.Before,
        (Func<IElement, PseudoElement>) (element => (PseudoElement) new PseudoElement.BeforePseudoElement(element))
      },
      {
        ":" + PseudoElementNames.After,
        (Func<IElement, PseudoElement>) (element => (PseudoElement) new PseudoElement.AfterPseudoElement(element))
      },
      {
        "::" + PseudoElementNames.After,
        (Func<IElement, PseudoElement>) (element => (PseudoElement) new PseudoElement.AfterPseudoElement(element))
      }
    };
    private readonly IElement _host;

    public static PseudoElement Create(IElement host, string pseudoSelector)
    {
      Func<IElement, PseudoElement> func;
      return !string.IsNullOrEmpty(pseudoSelector) && PseudoElement.creators.TryGetValue(pseudoSelector, out func) ? func(host) : (PseudoElement) null;
    }

    public PseudoElement(IElement host) => this._host = host;

    public ICssStyleDeclaration Style => this._host.Style;

    public IElement AssignedSlot => this._host.AssignedSlot;

    public string Slot
    {
      get => this._host.Slot;
      set
      {
      }
    }

    public IShadowRoot ShadowRoot => this._host.ShadowRoot;

    public ICssStyleDeclaration CascadedStyle => (ICssStyleDeclaration) this.Owner.DefaultView.GetStyleCollection().ComputeCascadedStyle((IElement) this);

    public ICssStyleDeclaration DefaultStyle => (ICssStyleDeclaration) this.Owner.DefaultView.ComputeDefaultStyle((IElement) this);

    public ICssStyleDeclaration RawComputedStyle => (ICssStyleDeclaration) this.Owner.DefaultView.ComputeRawStyle((IElement) this);

    public ICssStyleDeclaration UsedStyle => (ICssStyleDeclaration) this.Owner.DefaultView.ComputeUsedStyle((IElement) this);

    public string Prefix => this._host.Prefix;

    public abstract string PseudoName { get; }

    public string LocalName => this._host.LocalName;

    public string NamespaceUri => this._host.NamespaceUri;

    public INamedNodeMap Attributes => this._host.Attributes;

    public ITokenList ClassList => this._host.ClassList;

    public string ClassName
    {
      get => this._host.ClassName;
      set
      {
      }
    }

    public string Id
    {
      get => this._host.Id;
      set
      {
      }
    }

    public string InnerHtml
    {
      get => string.Empty;
      set
      {
      }
    }

    public string OuterHtml
    {
      get => string.Empty;
      set
      {
      }
    }

    public string TagName => this._host.TagName;

    public bool IsFocused => this._host.IsFocused;

    public string BaseUri => this._host.BaseUri;

    public Url BaseUrl => this._host.BaseUrl;

    public string NodeName => this._host.NodeName;

    public INodeList ChildNodes => this._host.ChildNodes;

    public IDocument Owner => this._host.Owner;

    public IElement ParentElement => this._host.ParentElement;

    public INode Parent => this._host.Parent;

    public INode FirstChild => this._host.FirstChild;

    public INode LastChild => this._host.LastChild;

    public INode NextSibling => this._host.NextSibling;

    public INode PreviousSibling => this._host.PreviousSibling;

    public NodeType NodeType => NodeType.Element;

    public string NodeValue
    {
      get => this._host.NodeValue;
      set
      {
      }
    }

    public string TextContent
    {
      get => string.Empty;
      set
      {
      }
    }

    public bool HasChildNodes => this._host.HasChildNodes;

    public IHtmlCollection<IElement> Children => this._host.Children;

    public IElement FirstElementChild => this._host.FirstElementChild;

    public IElement LastElementChild => this._host.LastElementChild;

    public int ChildElementCount => this._host.ChildElementCount;

    public IElement NextElementSibling => this._host.NextElementSibling;

    public IElement PreviousElementSibling => this._host.PreviousElementSibling;

    public IShadowRoot AttachShadow(ShadowRootMode mode = ShadowRootMode.Open) => this._host.AttachShadow(mode);

    public void Insert(AdjacentPosition position, string html)
    {
    }

    public bool HasAttribute(string name) => this._host.HasAttribute(name);

    public bool HasAttribute(string namespaceUri, string localName) => this._host.HasAttribute(namespaceUri, localName);

    public string GetAttribute(string name) => this._host.GetAttribute(name);

    public string GetAttribute(string namespaceUri, string localName) => this._host.GetAttribute(namespaceUri, localName);

    public void SetAttribute(string name, string value) => this._host.SetAttribute(name, value);

    public void SetAttribute(string namespaceUri, string name, string value) => this._host.SetAttribute(namespaceUri, name, value);

    public bool RemoveAttribute(string name) => this._host.RemoveAttribute(name);

    public bool RemoveAttribute(string namespaceUri, string localName) => this._host.RemoveAttribute(namespaceUri, localName);

    public IHtmlCollection<IElement> GetElementsByClassName(string classNames) => this._host.GetElementsByClassName(classNames);

    public IHtmlCollection<IElement> GetElementsByTagName(string tagName) => this._host.GetElementsByTagName(tagName);

    public IHtmlCollection<IElement> GetElementsByTagNameNS(string namespaceUri, string tagName) => this._host.GetElementsByTagNameNS(namespaceUri, tagName);

    public bool Matches(string selectors) => this._host.Matches(selectors);

    public INode Clone(bool deep = true) => this._host.Clone(deep);

    public IPseudoElement Pseudo(string pseudoElement) => (IPseudoElement) null;

    public bool Equals(INode otherNode) => this._host.Equals(otherNode);

    public DocumentPositions CompareDocumentPosition(INode otherNode) => this._host.CompareDocumentPosition(otherNode);

    public void Normalize() => this._host.Normalize();

    public bool Contains(INode otherNode) => this._host.Contains(otherNode);

    public bool IsDefaultNamespace(string namespaceUri) => this._host.IsDefaultNamespace(namespaceUri);

    public string LookupNamespaceUri(string prefix) => this._host.LookupNamespaceUri(prefix);

    public string LookupPrefix(string namespaceUri) => this._host.LookupPrefix(namespaceUri);

    public INode AppendChild(INode child) => this._host.AppendChild(child);

    public INode InsertBefore(INode newElement, INode referenceElement) => this._host.InsertBefore(newElement, referenceElement);

    public INode RemoveChild(INode child) => this._host.RemoveChild(child);

    public INode ReplaceChild(INode newChild, INode oldChild) => this._host.ReplaceChild(newChild, oldChild);

    public void AddEventListener(string type, DomEventHandler callback = null, bool capture = false) => this._host.AddEventListener(type, callback, capture);

    public void RemoveEventListener(string type, DomEventHandler callback = null, bool capture = false) => this._host.RemoveEventListener(type, callback, capture);

    public void InvokeEventListener(Event ev) => this._host.InvokeEventListener(ev);

    public bool Dispatch(Event ev) => this._host.Dispatch(ev);

    public void Append(params INode[] nodes) => this._host.Append(nodes);

    public void Prepend(params INode[] nodes) => this._host.Prepend(nodes);

    public IElement QuerySelector(string selectors) => this._host.QuerySelector(selectors);

    public IHtmlCollection<IElement> QuerySelectorAll(string selectors) => this._host.QuerySelectorAll(selectors);

    public void Before(params INode[] nodes) => this._host.Before(nodes);

    public void After(params INode[] nodes) => this._host.After(nodes);

    public void Replace(params INode[] nodes) => this._host.Replace(nodes);

    public void Remove() => this._host.Remove();

    public void ToHtml(TextWriter writer, IMarkupFormatter formatter) => this._host.ToHtml(writer, formatter);

    private sealed class BeforePseudoElement : PseudoElement
    {
      public BeforePseudoElement(IElement host)
        : base(host)
      {
      }

      public override string PseudoName => "::" + PseudoElementNames.Before;
    }

    private sealed class AfterPseudoElement : PseudoElement
    {
      public AfterPseudoElement(IElement host)
        : base(host)
      {
      }

      public override string PseudoName => "::" + PseudoElementNames.After;
    }
  }
}
