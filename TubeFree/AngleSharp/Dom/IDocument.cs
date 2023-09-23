// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IDocument
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Html;
using System;
using System.Net;

namespace AngleSharp.Dom
{
  [DomName("Document")]
  public interface IDocument : 
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IGlobalEventHandlers,
    IDocumentStyle,
    INonElementParentNode,
    IDisposable
  {
    [DomName("all")]
    IHtmlAllCollection All { get; }

    [DomName("anchors")]
    IHtmlCollection<IHtmlAnchorElement> Anchors { get; }

    [DomName("implementation")]
    IImplementation Implementation { get; }

    [DomName("designMode")]
    string DesignMode { get; set; }

    [DomName("dir")]
    string Direction { get; set; }

    [DomName("documentURI")]
    string DocumentUri { get; }

    [DomName("characterSet")]
    string CharacterSet { get; }

    [DomName("compatMode")]
    string CompatMode { get; }

    [DomName("URL")]
    string Url { get; }

    [DomName("contentType")]
    string ContentType { get; }

    [DomName("open")]
    IDocument Open(string type = "text/html", string replace = null);

    [DomName("close")]
    void Close();

    [DomName("write")]
    void Write(string content);

    [DomName("writeln")]
    void WriteLine(string content);

    [DomName("load")]
    void Load(string url);

    [DomName("doctype")]
    IDocumentType Doctype { get; }

    [DomName("documentElement")]
    IElement DocumentElement { get; }

    [DomName("getElementsByName")]
    IHtmlCollection<IElement> GetElementsByName(string name);

    [DomName("getElementsByClassName")]
    IHtmlCollection<IElement> GetElementsByClassName(string classNames);

    [DomName("getElementsByTagName")]
    IHtmlCollection<IElement> GetElementsByTagName(string tagName);

    [DomName("getElementsByTagNameNS")]
    IHtmlCollection<IElement> GetElementsByTagName(string namespaceUri, string tagName);

    [DomName("createEvent")]
    Event CreateEvent(string type);

    [DomName("createRange")]
    IRange CreateRange();

    [DomName("createComment")]
    IComment CreateComment(string data);

    [DomName("createDocumentFragment")]
    IDocumentFragment CreateDocumentFragment();

    [DomName("createElement")]
    IElement CreateElement(string name);

    [DomName("createElementNS")]
    IElement CreateElement(string namespaceUri, string name);

    [DomName("createAttribute")]
    IAttr CreateAttribute(string name);

    [DomName("createAttributeNS")]
    IAttr CreateAttribute(string namespaceUri, string name);

    [DomName("createProcessingInstruction")]
    IProcessingInstruction CreateProcessingInstruction(string target, string data);

    [DomName("createTextNode")]
    IText CreateTextNode(string data);

    [DomName("createNodeIterator")]
    INodeIterator CreateNodeIterator(INode root, FilterSettings settings = FilterSettings.All, NodeFilter filter = null);

    [DomName("createTreeWalker")]
    ITreeWalker CreateTreeWalker(INode root, FilterSettings settings = FilterSettings.All, NodeFilter filter = null);

    [DomName("importNode")]
    INode Import(INode externalNode, bool deep = true);

    [DomName("adoptNode")]
    INode Adopt(INode externalNode);

    [DomName("lastModified")]
    string LastModified { get; }

    [DomLenientThis]
    [DomName("readyState")]
    DocumentReadyState ReadyState { get; }

    [DomName("location")]
    [DomPutForwards("href")]
    ILocation Location { get; }

    [DomName("forms")]
    IHtmlCollection<IHtmlFormElement> Forms { get; }

    [DomName("images")]
    IHtmlCollection<IHtmlImageElement> Images { get; }

    [DomName("scripts")]
    IHtmlCollection<IHtmlScriptElement> Scripts { get; }

    [DomName("embeds")]
    [DomName("plugins")]
    IHtmlCollection<IHtmlEmbedElement> Plugins { get; }

    [DomName("commands")]
    IHtmlCollection<IElement> Commands { get; }

    [DomName("links")]
    IHtmlCollection<IElement> Links { get; }

    [DomName("title")]
    string Title { get; set; }

    [DomName("head")]
    IHtmlHeadElement Head { get; }

    [DomName("body")]
    IHtmlElement Body { get; set; }

    [DomName("cookie")]
    string Cookie { get; set; }

    [DomName("origin")]
    string Origin { get; }

    [DomName("domain")]
    string Domain { get; set; }

    [DomName("referrer")]
    string Referrer { get; }

    [DomName("onreadystatechange")]
    event DomEventHandler ReadyStateChanged;

    [DomName("activeElement")]
    IElement ActiveElement { get; }

    [DomName("currentScript")]
    IHtmlScriptElement CurrentScript { get; }

    [DomName("defaultView")]
    IWindow DefaultView { get; }

    [DomName("hasFocus")]
    bool HasFocus();

    [DomName("execCommand")]
    bool ExecuteCommand(string commandId, bool showUserInterface = false, string value = "");

    [DomName("queryCommandEnabled")]
    bool IsCommandEnabled(string commandId);

    [DomName("queryCommandIndeterm")]
    bool IsCommandIndeterminate(string commandId);

    [DomName("queryCommandState")]
    bool IsCommandExecuted(string commandId);

    [DomName("queryCommandSupported")]
    bool IsCommandSupported(string commandId);

    [DomName("queryCommandValue")]
    string GetCommandValue(string commandId);

    IBrowsingContext Context { get; }

    IDocument ImportAncestor { get; }

    TextSource Source { get; }

    HttpStatusCode StatusCode { get; }
  }
}
