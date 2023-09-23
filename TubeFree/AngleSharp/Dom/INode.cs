// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.INode
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("Node")]
  public interface INode : IEventTarget, IMarkupFormattable
  {
    [DomName("baseURI")]
    string BaseUri { get; }

    Url BaseUrl { get; }

    [DomName("nodeName")]
    string NodeName { get; }

    [DomName("childNodes")]
    INodeList ChildNodes { get; }

    [DomName("cloneNode")]
    INode Clone(bool deep = true);

    [DomName("isEqualNode")]
    bool Equals(INode otherNode);

    [DomName("compareDocumentPosition")]
    DocumentPositions CompareDocumentPosition(INode otherNode);

    [DomName("normalize")]
    void Normalize();

    [DomName("ownerDocument")]
    IDocument Owner { get; }

    [DomName("parentElement")]
    IElement ParentElement { get; }

    [DomName("parentNode")]
    INode Parent { get; }

    [DomName("contains")]
    bool Contains(INode otherNode);

    [DomName("firstChild")]
    INode FirstChild { get; }

    [DomName("lastChild")]
    INode LastChild { get; }

    [DomName("nextSibling")]
    INode NextSibling { get; }

    [DomName("previousSibling")]
    INode PreviousSibling { get; }

    [DomName("isDefaultNamespace")]
    bool IsDefaultNamespace(string namespaceUri);

    [DomName("lookupNamespaceURI")]
    string LookupNamespaceUri(string prefix);

    [DomName("lookupPrefix")]
    string LookupPrefix(string namespaceUri);

    [DomName("nodeType")]
    NodeType NodeType { get; }

    [DomName("nodeValue")]
    string NodeValue { get; set; }

    [DomName("textContent")]
    string TextContent { get; set; }

    [DomName("hasChildNodes")]
    bool HasChildNodes { get; }

    [DomName("appendChild")]
    INode AppendChild(INode child);

    [DomName("insertBefore")]
    INode InsertBefore(INode newElement, INode referenceElement);

    [DomName("removeChild")]
    INode RemoveChild(INode child);

    [DomName("replaceChild")]
    INode ReplaceChild(INode newChild, INode oldChild);
  }
}
