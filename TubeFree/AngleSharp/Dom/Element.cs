// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Element
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Parser.Css;
using AngleSharp.Services.Styling;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AngleSharp.Dom
{
  internal class Element : 
    Node,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle
  {
    private static readonly AttachedProperty<Element, IShadowRoot> ShadowRootProperty = new AttachedProperty<Element, IShadowRoot>();
    private readonly NamedNodeMap _attributes;
    private readonly string _namespace;
    private readonly string _prefix;
    private readonly string _localName;
    private HtmlCollection<IElement> _elements;
    private ICssStyleDeclaration _style;
    private TokenList _classList;

    public Element(
      Document owner,
      string localName,
      string prefix,
      string namespaceUri,
      NodeFlags flags = NodeFlags.None)
      : this(owner, prefix != null ? prefix + ":" + localName : localName, localName, prefix, namespaceUri, flags)
    {
    }

    public Element(
      Document owner,
      string name,
      string localName,
      string prefix,
      string namespaceUri,
      NodeFlags flags = NodeFlags.None)
      : base(owner, name, flags: flags)
    {
      this._localName = localName;
      this._prefix = prefix;
      this._namespace = namespaceUri;
      this._attributes = new NamedNodeMap(this);
    }

    internal NamedNodeMap Attributes => this._attributes;

    public ICssStyleDeclaration Style => this._style ?? (this._style = this.CreateStyle());

    public IElement AssignedSlot
    {
      get
      {
        IElement parentElement = this.ParentElement;
        if (parentElement == null)
          return (IElement) null;
        IShadowRoot shadowRoot = parentElement.ShadowRoot;
        return shadowRoot == null ? (IElement) null : shadowRoot.GetAssignedSlot(this.Slot);
      }
    }

    public string Slot
    {
      get => this.GetOwnAttribute(AttributeNames.Slot);
      set => this.SetOwnAttribute(AttributeNames.Slot, value);
    }

    public IShadowRoot ShadowRoot => Element.ShadowRootProperty.Get(this);

    public string Prefix => this._prefix;

    public string LocalName => this._localName;

    public string NamespaceUri => this._namespace;

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

    public ITokenList ClassList
    {
      get
      {
        if (this._classList == null)
        {
          this._classList = new TokenList(this.GetOwnAttribute(AttributeNames.Class));
          this._classList.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.Class, value));
        }
        return (ITokenList) this._classList;
      }
    }

    public string ClassName
    {
      get => this.GetOwnAttribute(AttributeNames.Class);
      set => this.SetOwnAttribute(AttributeNames.Class, value);
    }

    public string Id
    {
      get => this.GetOwnAttribute(AttributeNames.Id);
      set => this.SetOwnAttribute(AttributeNames.Id, value);
    }

    public string TagName => this.NodeName;

    public IElement PreviousElementSibling
    {
      get
      {
        Node parent = this.Parent;
        if (parent != null)
        {
          bool flag = false;
          for (int index = parent.ChildNodes.Length - 1; index >= 0; --index)
          {
            if (parent.ChildNodes[index] == this)
              flag = true;
            else if (flag && parent.ChildNodes[index] is IElement)
              return (IElement) parent.ChildNodes[index];
          }
        }
        return (IElement) null;
      }
    }

    public IElement NextElementSibling
    {
      get
      {
        Node parent = this.Parent;
        if (parent != null)
        {
          int length = parent.ChildNodes.Length;
          bool flag = false;
          for (int index = 0; index < length; ++index)
          {
            if (parent.ChildNodes[index] == this)
              flag = true;
            else if (flag && parent.ChildNodes[index] is IElement)
              return (IElement) parent.ChildNodes[index];
          }
        }
        return (IElement) null;
      }
    }

    public int ChildElementCount
    {
      get
      {
        NodeList childNodes = this.ChildNodes;
        int length = childNodes.Length;
        int childElementCount = 0;
        for (int index = 0; index < length; ++index)
        {
          if (childNodes[index].NodeType == NodeType.Element)
            ++childElementCount;
        }
        return childElementCount;
      }
    }

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

    public string InnerHtml
    {
      get => this.ChildNodes.ToHtml();
      set => this.ReplaceAll((Node) new DocumentFragment(this, value), false);
    }

    public string OuterHtml
    {
      get => this.ToHtml();
      set
      {
        Node parent = this.Parent;
        if (parent == null)
          throw new DomException(DomError.NotSupported);
        Document owner = this.Owner;
        if (owner != null && owner.DocumentElement == this)
          throw new DomException(DomError.NoModificationAllowed);
        parent.InsertChild(parent.IndexOf((INode) this), (INode) new DocumentFragment(this, value));
        parent.RemoveChild((INode) this);
      }
    }

    INamedNodeMap IElement.Attributes => (INamedNodeMap) this._attributes;

    public bool IsFocused
    {
      get => this.Owner?.FocusElement == this;
      protected set
      {
        Document owner = this.Owner;
        if (owner == null)
          return;
        if (value)
        {
          owner.SetFocus((IElement) this);
          this.Fire<FocusEvent>((Action<FocusEvent>) (m => m.Init(EventNames.Focus, false, false)));
        }
        else
        {
          owner.SetFocus((IElement) null);
          this.Fire<FocusEvent>((Action<FocusEvent>) (m => m.Init(EventNames.Blur, false, false)));
        }
      }
    }

    public IShadowRoot AttachShadow(ShadowRootMode mode = ShadowRootMode.Open)
    {
      if (TagNames.AllNoShadowRoot.Contains(this._localName))
        throw new DomException(DomError.NotSupported);
      if (this.ShadowRoot != null)
        throw new DomException(DomError.InvalidState);
      AngleSharp.Dom.ShadowRoot shadowRoot = new AngleSharp.Dom.ShadowRoot(this, mode);
      Element.ShadowRootProperty.Set(this, (IShadowRoot) shadowRoot);
      return (IShadowRoot) shadowRoot;
    }

    public IElement QuerySelector(string selectors) => this.ChildNodes.QuerySelector(selectors);

    public IHtmlCollection<IElement> QuerySelectorAll(string selectors) => (IHtmlCollection<IElement>) this.ChildNodes.QuerySelectorAll(selectors);

    public IHtmlCollection<IElement> GetElementsByClassName(string classNames) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByClassName(classNames);

    public IHtmlCollection<IElement> GetElementsByTagName(string tagName) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByTagName(tagName);

    public IHtmlCollection<IElement> GetElementsByTagNameNS(string namespaceURI, string tagName) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByTagName(namespaceURI, tagName);

    public bool Matches(string selectors) => CssParser.Default.ParseSelector(selectors).Match((IElement) this);

    public override INode Clone(bool deep = true)
    {
      Element element = new Element(this.Owner, this.LocalName, this._prefix, this._namespace, this.Flags);
      this.CloneElement(element, deep);
      return (INode) element;
    }

    public IPseudoElement Pseudo(string pseudoElement) => (IPseudoElement) PseudoElement.Create((IElement) this, pseudoElement);

    public bool HasAttribute(string name)
    {
      if (this._namespace.Is(NamespaceNames.HtmlUri))
        name = name.HtmlLower();
      return this._attributes.GetNamedItem(name) != null;
    }

    public bool HasAttribute(string namespaceUri, string localName)
    {
      if (string.IsNullOrEmpty(namespaceUri))
        namespaceUri = (string) null;
      return this._attributes.GetNamedItem(namespaceUri, localName) != null;
    }

    public string GetAttribute(string name)
    {
      if (this._namespace.Is(NamespaceNames.HtmlUri))
        name = name.HtmlLower();
      return this._attributes.GetNamedItem(name)?.Value;
    }

    public string GetAttribute(string namespaceUri, string localName)
    {
      if (string.IsNullOrEmpty(namespaceUri))
        namespaceUri = (string) null;
      return this._attributes.GetNamedItem(namespaceUri, localName)?.Value;
    }

    public void SetAttribute(string name, string value)
    {
      if (value != null)
      {
        if (!name.IsXmlName())
          throw new DomException(DomError.InvalidCharacter);
        if (this._namespace.Is(NamespaceNames.HtmlUri))
          name = name.HtmlLower();
        this.SetOwnAttribute(name, value);
      }
      else
        this.RemoveAttribute(name);
    }

    public void SetAttribute(string namespaceUri, string name, string value)
    {
      if (value != null)
      {
        string prefix = (string) null;
        string localName = (string) null;
        Node.GetPrefixAndLocalName(name, ref namespaceUri, out prefix, out localName);
        this._attributes.SetNamedItem((IAttr) new Attr(prefix, localName, value, namespaceUri));
      }
      else
        this.RemoveAttribute(namespaceUri, name);
    }

    public bool RemoveAttribute(string name)
    {
      if (this._namespace.Is(NamespaceNames.HtmlUri))
        name = name.HtmlLower();
      return this._attributes.RemoveNamedItemOrDefault(name) != null;
    }

    public bool RemoveAttribute(string namespaceUri, string localName)
    {
      if (string.IsNullOrEmpty(namespaceUri))
        namespaceUri = (string) null;
      return this._attributes.RemoveNamedItemOrDefault(namespaceUri, localName) != null;
    }

    public void Prepend(params INode[] nodes) => this.PrependNodes(nodes);

    public void Append(params INode[] nodes) => this.AppendNodes(nodes);

    public override bool Equals(INode otherNode) => otherNode is IElement element && this.NamespaceUri.Is(element.NamespaceUri) && this._attributes.AreEqual(element.Attributes) && base.Equals(otherNode);

    public void Before(params INode[] nodes) => this.InsertBefore(nodes);

    public void After(params INode[] nodes) => this.InsertAfter(nodes);

    public void Replace(params INode[] nodes) => this.ReplaceWith(nodes);

    public void Remove() => this.RemoveFromParent();

    public void Insert(AdjacentPosition position, string html)
    {
      DocumentFragment documentFragment = new DocumentFragment((position == AdjacentPosition.BeforeBegin ? 1 : (position == AdjacentPosition.AfterEnd ? 1 : 0)) != 0 ? this : this.Parent as Element, html);
      switch (position)
      {
        case AdjacentPosition.BeforeBegin:
          this.Parent.InsertBefore((INode) documentFragment, (INode) this);
          break;
        case AdjacentPosition.AfterBegin:
          this.InsertChild(0, (INode) documentFragment);
          break;
        case AdjacentPosition.BeforeEnd:
          this.AppendChild((INode) documentFragment);
          break;
        case AdjacentPosition.AfterEnd:
          this.Parent.InsertChild(this.Parent.IndexOf((INode) this) + 1, (INode) documentFragment);
          break;
      }
    }

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter)
    {
      bool selfClosing = (this.Flags & NodeFlags.SelfClosing) == NodeFlags.SelfClosing;
      writer.Write(formatter.OpenTag((IElement) this, selfClosing));
      if (!selfClosing)
      {
        if ((this.Flags & NodeFlags.LineTolerance) == NodeFlags.LineTolerance && this.FirstChild is IText && ((ICharacterData) this.FirstChild).Data.Has('\n'))
          writer.Write('\n');
        foreach (IMarkupFormattable childNode in this.ChildNodes)
          childNode.ToHtml(writer, formatter);
      }
      writer.Write(formatter.CloseTag((IElement) this, selfClosing));
    }

    internal virtual void SetupElement()
    {
    }

    internal void AttributeChanged(
      string localName,
      string namespaceUri,
      string oldValue,
      string newValue)
    {
      if (namespaceUri == null)
      {
        foreach (IAttributeObserver service in this.Owner.Options.GetServices<IAttributeObserver>())
          service.NotifyChange((IElement) this, localName, newValue);
      }
      this.Owner.QueueMutation(MutationRecord.Attributes((INode) this, localName, namespaceUri, oldValue));
    }

    internal void UpdateClassList(string value) => this._classList?.Update(value);

    internal void UpdateStyle(string value)
    {
      IBindable style = this._style as IBindable;
      if (string.IsNullOrEmpty(value))
        this._attributes.RemoveNamedItemOrDefault(AttributeNames.Style, true);
      style?.Update(value);
    }

    protected ICssStyleDeclaration CreateStyle()
    {
      if ((this.Flags & (NodeFlags.HtmlMember | NodeFlags.SvgMember)) != NodeFlags.None)
      {
        Document owner = this.Owner;
        IConfiguration options1 = owner.Options;
        IBrowsingContext context = owner.Context;
        ICssStyleEngine cssStyleEngine = options1.GetCssStyleEngine();
        if (cssStyleEngine != null)
        {
          string ownAttribute = this.GetOwnAttribute(AttributeNames.Style);
          StyleOptions options2 = new StyleOptions(context)
          {
            Element = (IElement) this
          };
          ICssStyleDeclaration declaration = cssStyleEngine.ParseDeclaration(ownAttribute, options2);
          if (!(declaration is IBindable bindable))
            return declaration;
          bindable.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.Style, value));
          return declaration;
        }
      }
      return (ICssStyleDeclaration) null;
    }

    protected void UpdateAttribute(string name, string value) => this.SetOwnAttribute(name, value, true);

    protected override sealed string LocateNamespace(string prefix) => this.LocateNamespaceFor(prefix);

    protected override sealed string LocatePrefix(string namespaceUri) => this.LocatePrefixFor(namespaceUri);

    protected void CloneElement(Element element, bool deep)
    {
      this.CloneNode((Node) element, deep);
      foreach (IAttr attribute in this._attributes)
      {
        Attr attr = new Attr(attribute.Prefix, attribute.LocalName, attribute.Value, attribute.NamespaceUri);
        element._attributes.FastAddItem(attr);
      }
      element.SetupElement();
    }
  }
}
