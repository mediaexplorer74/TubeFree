// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Document
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Commands;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Html;
using AngleSharp.Dom.Mathml;
using AngleSharp.Dom.Svg;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Dom
{
  internal abstract class Document : 
    Node,
    IDocument,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IGlobalEventHandlers,
    IDocumentStyle,
    INonElementParentNode,
    IDisposable
  {
    private readonly List<WeakReference> _attachedReferences;
    private readonly Queue<HtmlScriptElement> _loadingScripts;
    private readonly MutationHost _mutations;
    private readonly IBrowsingContext _context;
    private readonly IEventLoop _loop;
    private readonly Window _view;
    private readonly IResourceLoader _loader;
    private readonly AngleSharp.Dom.Location _location;
    private readonly TextSource _source;
    private QuirksMode _quirksMode;
    private Sandboxes _sandbox;
    private bool _async;
    private bool _designMode;
    private bool _shown;
    private bool _salvageable;
    private bool _firedUnload;
    private DocumentReadyState _ready;
    private IElement _focus;
    private HtmlAllCollection _all;
    private HtmlCollection<IHtmlAnchorElement> _anchors;
    private HtmlCollection<IElement> _children;
    private DomImplementation _implementation;
    private IStringList _styleSheetSets;
    private HtmlCollection<IHtmlImageElement> _images;
    private HtmlCollection<IHtmlScriptElement> _scripts;
    private HtmlCollection<IHtmlEmbedElement> _plugins;
    private HtmlCollection<IElement> _commands;
    private HtmlCollection<IElement> _links;
    private IStyleSheetList _styleSheets;
    private HttpStatusCode _statusCode;

    public event DomEventHandler ReadyStateChanged
    {
      add => this.AddEventListener(EventNames.ReadyStateChanged, value, false);
      remove => this.RemoveEventListener(EventNames.ReadyStateChanged, value, false);
    }

    public event DomEventHandler Aborted
    {
      add => this.AddEventListener(EventNames.Abort, value, false);
      remove => this.RemoveEventListener(EventNames.Abort, value, false);
    }

    public event DomEventHandler Blurred
    {
      add => this.AddEventListener(EventNames.Blur, value, false);
      remove => this.RemoveEventListener(EventNames.Blur, value, false);
    }

    public event DomEventHandler Cancelled
    {
      add => this.AddEventListener(EventNames.Cancel, value, false);
      remove => this.RemoveEventListener(EventNames.Cancel, value, false);
    }

    public event DomEventHandler CanPlay
    {
      add => this.AddEventListener(EventNames.CanPlay, value, false);
      remove => this.RemoveEventListener(EventNames.CanPlay, value, false);
    }

    public event DomEventHandler CanPlayThrough
    {
      add => this.AddEventListener(EventNames.CanPlayThrough, value, false);
      remove => this.RemoveEventListener(EventNames.CanPlayThrough, value, false);
    }

    public event DomEventHandler Changed
    {
      add => this.AddEventListener(EventNames.Change, value, false);
      remove => this.RemoveEventListener(EventNames.Change, value, false);
    }

    public event DomEventHandler Clicked
    {
      add => this.AddEventListener(EventNames.Click, value, false);
      remove => this.RemoveEventListener(EventNames.Click, value, false);
    }

    public event DomEventHandler CueChanged
    {
      add => this.AddEventListener(EventNames.CueChange, value, false);
      remove => this.RemoveEventListener(EventNames.CueChange, value, false);
    }

    public event DomEventHandler DoubleClick
    {
      add => this.AddEventListener(EventNames.DblClick, value, false);
      remove => this.RemoveEventListener(EventNames.DblClick, value, false);
    }

    public event DomEventHandler Drag
    {
      add => this.AddEventListener(EventNames.Drag, value, false);
      remove => this.RemoveEventListener(EventNames.Drag, value, false);
    }

    public event DomEventHandler DragEnd
    {
      add => this.AddEventListener(EventNames.DragEnd, value, false);
      remove => this.RemoveEventListener(EventNames.DragEnd, value, false);
    }

    public event DomEventHandler DragEnter
    {
      add => this.AddEventListener(EventNames.DragEnter, value, false);
      remove => this.RemoveEventListener(EventNames.DragEnter, value, false);
    }

    public event DomEventHandler DragExit
    {
      add => this.AddEventListener(EventNames.DragExit, value, false);
      remove => this.RemoveEventListener(EventNames.DragExit, value, false);
    }

    public event DomEventHandler DragLeave
    {
      add => this.AddEventListener(EventNames.DragLeave, value, false);
      remove => this.RemoveEventListener(EventNames.DragLeave, value, false);
    }

    public event DomEventHandler DragOver
    {
      add => this.AddEventListener(EventNames.DragOver, value, false);
      remove => this.RemoveEventListener(EventNames.DragOver, value, false);
    }

    public event DomEventHandler DragStart
    {
      add => this.AddEventListener(EventNames.DragStart, value, false);
      remove => this.RemoveEventListener(EventNames.DragStart, value, false);
    }

    public event DomEventHandler Dropped
    {
      add => this.AddEventListener(EventNames.Drop, value, false);
      remove => this.RemoveEventListener(EventNames.Drop, value, false);
    }

    public event DomEventHandler DurationChanged
    {
      add => this.AddEventListener(EventNames.DurationChange, value, false);
      remove => this.RemoveEventListener(EventNames.DurationChange, value, false);
    }

    public event DomEventHandler Emptied
    {
      add => this.AddEventListener(EventNames.Emptied, value, false);
      remove => this.RemoveEventListener(EventNames.Emptied, value, false);
    }

    public event DomEventHandler Ended
    {
      add => this.AddEventListener(EventNames.Ended, value, false);
      remove => this.RemoveEventListener(EventNames.Ended, value, false);
    }

    public event DomEventHandler Error
    {
      add => this.AddEventListener(EventNames.Error, value, false);
      remove => this.RemoveEventListener(EventNames.Error, value, false);
    }

    public event DomEventHandler Focused
    {
      add => this.AddEventListener(EventNames.Focus, value, false);
      remove => this.RemoveEventListener(EventNames.Focus, value, false);
    }

    public event DomEventHandler Input
    {
      add => this.AddEventListener(EventNames.Input, value, false);
      remove => this.RemoveEventListener(EventNames.Input, value, false);
    }

    public event DomEventHandler Invalid
    {
      add => this.AddEventListener(EventNames.Invalid, value, false);
      remove => this.RemoveEventListener(EventNames.Invalid, value, false);
    }

    public event DomEventHandler KeyDown
    {
      add => this.AddEventListener(EventNames.Keydown, value, false);
      remove => this.RemoveEventListener(EventNames.Keydown, value, false);
    }

    public event DomEventHandler KeyPress
    {
      add => this.AddEventListener(EventNames.Keypress, value, false);
      remove => this.RemoveEventListener(EventNames.Keypress, value, false);
    }

    public event DomEventHandler KeyUp
    {
      add => this.AddEventListener(EventNames.Keyup, value, false);
      remove => this.RemoveEventListener(EventNames.Keyup, value, false);
    }

    public event DomEventHandler Loaded
    {
      add => this.AddEventListener(EventNames.Load, value, false);
      remove => this.RemoveEventListener(EventNames.Load, value, false);
    }

    public event DomEventHandler LoadedData
    {
      add => this.AddEventListener(EventNames.LoadedData, value, false);
      remove => this.RemoveEventListener(EventNames.LoadedData, value, false);
    }

    public event DomEventHandler LoadedMetadata
    {
      add => this.AddEventListener(EventNames.LoadedMetaData, value, false);
      remove => this.RemoveEventListener(EventNames.LoadedMetaData, value, false);
    }

    public event DomEventHandler Loading
    {
      add => this.AddEventListener(EventNames.LoadStart, value, false);
      remove => this.RemoveEventListener(EventNames.LoadStart, value, false);
    }

    public event DomEventHandler MouseDown
    {
      add => this.AddEventListener(EventNames.Mousedown, value, false);
      remove => this.RemoveEventListener(EventNames.Mousedown, value, false);
    }

    public event DomEventHandler MouseEnter
    {
      add => this.AddEventListener(EventNames.Mouseenter, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseenter, value, false);
    }

    public event DomEventHandler MouseLeave
    {
      add => this.AddEventListener(EventNames.Mouseleave, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseleave, value, false);
    }

    public event DomEventHandler MouseMove
    {
      add => this.AddEventListener(EventNames.Mousemove, value, false);
      remove => this.RemoveEventListener(EventNames.Mousemove, value, false);
    }

    public event DomEventHandler MouseOut
    {
      add => this.AddEventListener(EventNames.Mouseout, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseout, value, false);
    }

    public event DomEventHandler MouseOver
    {
      add => this.AddEventListener(EventNames.Mouseover, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseover, value, false);
    }

    public event DomEventHandler MouseUp
    {
      add => this.AddEventListener(EventNames.Mouseup, value, false);
      remove => this.RemoveEventListener(EventNames.Mouseup, value, false);
    }

    public event DomEventHandler MouseWheel
    {
      add => this.AddEventListener(EventNames.Wheel, value, false);
      remove => this.RemoveEventListener(EventNames.Wheel, value, false);
    }

    public event DomEventHandler Paused
    {
      add => this.AddEventListener(EventNames.Pause, value, false);
      remove => this.RemoveEventListener(EventNames.Pause, value, false);
    }

    public event DomEventHandler Played
    {
      add => this.AddEventListener(EventNames.Play, value, false);
      remove => this.RemoveEventListener(EventNames.Play, value, false);
    }

    public event DomEventHandler Playing
    {
      add => this.AddEventListener(EventNames.Playing, value, false);
      remove => this.RemoveEventListener(EventNames.Playing, value, false);
    }

    public event DomEventHandler Progress
    {
      add => this.AddEventListener(EventNames.Progress, value, false);
      remove => this.RemoveEventListener(EventNames.Progress, value, false);
    }

    public event DomEventHandler RateChanged
    {
      add => this.AddEventListener(EventNames.RateChange, value, false);
      remove => this.RemoveEventListener(EventNames.RateChange, value, false);
    }

    public event DomEventHandler Resetted
    {
      add => this.AddEventListener(EventNames.Reset, value, false);
      remove => this.RemoveEventListener(EventNames.Reset, value, false);
    }

    public event DomEventHandler Resized
    {
      add => this.AddEventListener(EventNames.Resize, value, false);
      remove => this.RemoveEventListener(EventNames.Resize, value, false);
    }

    public event DomEventHandler Scrolled
    {
      add => this.AddEventListener(EventNames.Scroll, value, false);
      remove => this.RemoveEventListener(EventNames.Scroll, value, false);
    }

    public event DomEventHandler Seeked
    {
      add => this.AddEventListener(EventNames.Seeked, value, false);
      remove => this.RemoveEventListener(EventNames.Seeked, value, false);
    }

    public event DomEventHandler Seeking
    {
      add => this.AddEventListener(EventNames.Seeking, value, false);
      remove => this.RemoveEventListener(EventNames.Seeking, value, false);
    }

    public event DomEventHandler Selected
    {
      add => this.AddEventListener(EventNames.Select, value, false);
      remove => this.RemoveEventListener(EventNames.Select, value, false);
    }

    public event DomEventHandler Shown
    {
      add => this.AddEventListener(EventNames.Show, value, false);
      remove => this.RemoveEventListener(EventNames.Show, value, false);
    }

    public event DomEventHandler Stalled
    {
      add => this.AddEventListener(EventNames.Stalled, value, false);
      remove => this.RemoveEventListener(EventNames.Stalled, value, false);
    }

    public event DomEventHandler Submitted
    {
      add => this.AddEventListener(EventNames.Submit, value, false);
      remove => this.RemoveEventListener(EventNames.Submit, value, false);
    }

    public event DomEventHandler Suspended
    {
      add => this.AddEventListener(EventNames.Suspend, value, false);
      remove => this.RemoveEventListener(EventNames.Suspend, value, false);
    }

    public event DomEventHandler TimeUpdated
    {
      add => this.AddEventListener(EventNames.TimeUpdate, value, false);
      remove => this.RemoveEventListener(EventNames.TimeUpdate, value, false);
    }

    public event DomEventHandler Toggled
    {
      add => this.AddEventListener(EventNames.Toggle, value, false);
      remove => this.RemoveEventListener(EventNames.Toggle, value, false);
    }

    public event DomEventHandler VolumeChanged
    {
      add => this.AddEventListener(EventNames.VolumeChange, value, false);
      remove => this.RemoveEventListener(EventNames.VolumeChange, value, false);
    }

    public event DomEventHandler Waiting
    {
      add => this.AddEventListener(EventNames.Waiting, value, false);
      remove => this.RemoveEventListener(EventNames.Waiting, value, false);
    }

    internal Document(IBrowsingContext context, TextSource source)
      : base((Document) null, "#document", NodeType.Document)
    {
      this.Referrer = string.Empty;
      this.ContentType = MimeTypeNames.ApplicationXml;
      this._attachedReferences = new List<WeakReference>();
      this._async = true;
      this._designMode = false;
      this._firedUnload = false;
      this._salvageable = true;
      this._shown = false;
      this._context = context;
      this._source = source;
      this._ready = DocumentReadyState.Loading;
      this._sandbox = Sandboxes.None;
      this._quirksMode = QuirksMode.Off;
      this._loadingScripts = new Queue<HtmlScriptElement>();
      this._location = new AngleSharp.Dom.Location("about:blank");
      this._location.Changed += new EventHandler<AngleSharp.Dom.Location.LocationChangedEventArgs>(this.LocationChanged);
      this._view = new Window(this);
      this._loader = context.CreateService<IResourceLoader>();
      this._loop = context.CreateService<IEventLoop>();
      this._mutations = new MutationHost(this._loop);
      this._statusCode = HttpStatusCode.OK;
    }

    public TextSource Source => this._source;

    public IDocument ImportAncestor { get; private set; }

    public IEventLoop Loop => this._loop;

    public string DesignMode
    {
      get => !this._designMode ? Keywords.Off : Keywords.On;
      set => this._designMode = value.Isi(Keywords.On);
    }

    public IHtmlAllCollection All => (IHtmlAllCollection) this._all ?? (IHtmlAllCollection) (this._all = new HtmlAllCollection((IDocument) this));

    public IHtmlCollection<IHtmlAnchorElement> Anchors => (IHtmlCollection<IHtmlAnchorElement>) this._anchors ?? (IHtmlCollection<IHtmlAnchorElement>) (this._anchors = new HtmlCollection<IHtmlAnchorElement>((INode) this, predicate: new Predicate<IHtmlAnchorElement>(Document.IsAnchor)));

    public int ChildElementCount => this.ChildNodes.OfType<Element>().Count<Element>();

    public IHtmlCollection<IElement> Children => (IHtmlCollection<IElement>) this._children ?? (IHtmlCollection<IElement>) (this._children = new HtmlCollection<IElement>((IEnumerable<IElement>) this.ChildNodes.OfType<Element>()));

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

    public bool IsAsync => this._async;

    public IHtmlScriptElement CurrentScript => this._loadingScripts.Count <= 0 ? (IHtmlScriptElement) null : (IHtmlScriptElement) this._loadingScripts.Peek();

    public IImplementation Implementation => (IImplementation) this._implementation ?? (IImplementation) (this._implementation = new DomImplementation(this));

    public string LastModified { get; protected set; }

    public IDocumentType Doctype => (IDocumentType) this.FindChild<DocumentType>();

    public string ContentType { get; protected set; }

    public DocumentReadyState ReadyState
    {
      get => this._ready;
      protected set
      {
        this._ready = value;
        this.FireSimpleEvent(EventNames.ReadyStateChanged);
      }
    }

    public IStyleSheetList StyleSheets => this._styleSheets ?? (this._styleSheets = this.CreateStyleSheets());

    public IStringList StyleSheetSets => this._styleSheetSets ?? (this._styleSheetSets = this.CreateStyleSheetSets());

    public string Referrer { get; protected set; }

    public ILocation Location => (ILocation) this._location;

    public string DocumentUri
    {
      get => this._location.Href;
      protected set
      {
        this._location.Changed -= new EventHandler<AngleSharp.Dom.Location.LocationChangedEventArgs>(this.LocationChanged);
        this._location.Href = value;
        this._location.Changed += new EventHandler<AngleSharp.Dom.Location.LocationChangedEventArgs>(this.LocationChanged);
      }
    }

    public AngleSharp.Url DocumentUrl => this._location.Original;

    public IWindow DefaultView => (IWindow) this._view;

    public string Direction
    {
      get
      {
        if (!(this.DocumentElement is IHtmlElement htmlElement))
          htmlElement = (IHtmlElement) new HtmlHtmlElement(this);
        return htmlElement.Direction;
      }
      set
      {
        if (!(this.DocumentElement is IHtmlElement htmlElement))
          htmlElement = (IHtmlElement) new HtmlHtmlElement(this);
        htmlElement.Direction = value;
      }
    }

    public string CharacterSet => this._source.CurrentEncoding.WebName;

    public abstract IElement DocumentElement { get; }

    public IElement ActiveElement => this.All.Where<IElement>((Func<IElement, bool>) (m => m.IsFocused)).FirstOrDefault<IElement>();

    public string CompatMode => this._quirksMode.GetCompatiblity();

    public string Url => this._location.Href;

    public IHtmlCollection<IHtmlFormElement> Forms => (IHtmlCollection<IHtmlFormElement>) new HtmlCollection<IHtmlFormElement>((INode) this);

    public IHtmlCollection<IHtmlImageElement> Images => (IHtmlCollection<IHtmlImageElement>) this._images ?? (IHtmlCollection<IHtmlImageElement>) (this._images = new HtmlCollection<IHtmlImageElement>((INode) this));

    public IHtmlCollection<IHtmlScriptElement> Scripts => (IHtmlCollection<IHtmlScriptElement>) this._scripts ?? (IHtmlCollection<IHtmlScriptElement>) (this._scripts = new HtmlCollection<IHtmlScriptElement>((INode) this));

    public IHtmlCollection<IHtmlEmbedElement> Plugins => (IHtmlCollection<IHtmlEmbedElement>) this._plugins ?? (IHtmlCollection<IHtmlEmbedElement>) (this._plugins = new HtmlCollection<IHtmlEmbedElement>((INode) this));

    public IHtmlCollection<IElement> Commands => (IHtmlCollection<IElement>) this._commands ?? (IHtmlCollection<IElement>) (this._commands = new HtmlCollection<IElement>((INode) this, predicate: new Predicate<IElement>(Document.IsCommand)));

    public IHtmlCollection<IElement> Links => (IHtmlCollection<IElement>) this._links ?? (IHtmlCollection<IElement>) (this._links = new HtmlCollection<IElement>((INode) this, predicate: new Predicate<IElement>(Document.IsLink)));

    public string Title
    {
      get => this.GetTitle();
      set => this.SetTitle(value);
    }

    public IHtmlHeadElement Head => this.DocumentElement.FindChild<IHtmlHeadElement>();

    public IHtmlElement Body
    {
      get
      {
        IElement documentElement = this.DocumentElement;
        if (documentElement != null)
        {
          foreach (INode childNode in (IEnumerable<INode>) documentElement.ChildNodes)
          {
            if (childNode is HtmlBodyElement body1)
              return (IHtmlElement) body1;
            if (childNode is HtmlFrameSetElement body2)
              return (IHtmlElement) body2;
          }
        }
        return (IHtmlElement) null;
      }
      set
      {
        switch (value)
        {
          case IHtmlBodyElement _:
          case HtmlFrameSetElement _:
            IHtmlElement body = this.Body;
            if (body == value)
              break;
            if (body == null)
            {
              (this.DocumentElement ?? throw new DomException(DomError.HierarchyRequest)).AppendChild((INode) value);
              break;
            }
            this.ReplaceChild((INode) value, (INode) body);
            break;
          default:
            throw new DomException(DomError.HierarchyRequest);
        }
      }
    }

    public IBrowsingContext Context => this._context;

    public HttpStatusCode StatusCode
    {
      get => this._statusCode;
      private set => this._statusCode = value;
    }

    public string Cookie
    {
      get => this.Options.GetCookie(this._location.Origin);
      set => this.Options.SetCookie(this._location.Origin, value);
    }

    public string Domain
    {
      get => !string.IsNullOrEmpty(this.DocumentUri) ? new Uri(this.DocumentUri).Host : string.Empty;
      set
      {
        if (this._location == null)
          return;
        this._location.Host = value;
      }
    }

    public string Origin => this._location.Origin;

    public string SelectedStyleSheetSet
    {
      get
      {
        IEnumerable<string> enabledStyleSheetSets = this.StyleSheets.GetEnabledStyleSheetSets();
        string enabledName = enabledStyleSheetSets.FirstOrDefault<string>();
        IEnumerable<IStyleSheet> source = this.StyleSheets.Where<IStyleSheet>((Func<IStyleSheet, bool>) (m => !string.IsNullOrEmpty(m.Title) && !m.IsDisabled));
        if (enabledStyleSheetSets.Count<string>() == 1 && !source.Any<IStyleSheet>((Func<IStyleSheet, bool>) (m => !m.Title.Is(enabledName))))
          return enabledName;
        return source.Any<IStyleSheet>() ? (string) null : string.Empty;
      }
      set
      {
        if (value == null)
          return;
        this.StyleSheets.EnableStyleSheetSet(value);
        this.LastStyleSheetSet = value;
      }
    }

    public string LastStyleSheetSet { get; private set; }

    public string PreferredStyleSheetSet => this.All.OfType<IHtmlLinkElement>().Where<IHtmlLinkElement>((Func<IHtmlLinkElement, bool>) (m => m.IsPreferred())).Select<IHtmlLinkElement, string>((Func<IHtmlLinkElement, string>) (m => m.Title)).FirstOrDefault<string>();

    public bool IsReady => this.ReadyState == DocumentReadyState.Complete;

    public bool IsLoading => this.ReadyState == DocumentReadyState.Loading;

    internal MutationHost Mutations => this._mutations;

    internal IConfiguration Options => this._context.Configuration;

    internal QuirksMode QuirksMode
    {
      get => this._quirksMode;
      set => this._quirksMode = value;
    }

    internal Sandboxes ActiveSandboxing
    {
      get => this._sandbox;
      set => this._sandbox = value;
    }

    internal void AddScript(HtmlScriptElement script) => this._loadingScripts.Enqueue(script);

    internal bool IsInBrowsingContext => this._context.Active != null;

    internal bool IsToBePrinted => false;

    internal IElement FocusElement => this._focus;

    internal IResourceLoader Loader => this._loader;

    public void Dispose()
    {
      this.ReplaceAll((Node) null, true);
      this._loop.CancelAll();
      this._loadingScripts.Clear();
      this._source.Dispose();
    }

    public void EnableStyleSheetsForSet(string name)
    {
      if (name == null)
        return;
      this.StyleSheets.EnableStyleSheetSet(name);
    }

    public IDocument Open(string type = "text/html", string replace = null)
    {
      if (!this.ContentType.Is(MimeTypeNames.Html))
        throw new DomException(DomError.InvalidState);
      if (this.IsInBrowsingContext && this._context.Active != this)
        return (IDocument) null;
      IDocument active = this._context?.Parent.Active;
      if (active != null && !active.Origin.Is(this.Origin))
        throw new DomException(DomError.Security);
      if (!this._firedUnload && this._loadingScripts.Count == 0)
      {
        int num1 = replace.Isi(Keywords.Replace) ? 1 : 0;
        IHistory sessionHistory = this._context.SessionHistory;
        int length = type != null ? type.IndexOf(';') : -1;
        if (num1 == 0 && sessionHistory != null)
        {
          int num2 = sessionHistory.Length != 1 ? 0 : (sessionHistory[0].Url.Is("about:blank") ? 1 : 0);
        }
        this._salvageable = false;
        if (!this.PromptToUnloadAsync().Result)
          return (IDocument) this;
        this.Unload(true);
        this.Abort();
        this.RemoveEventListeners();
        foreach (EventTarget descendent in this.Descendents<Element>())
          descendent.RemoveEventListeners();
        this._loop.CancelAll();
        this.ReplaceAll((Node) null, true);
        this._source.CurrentEncoding = TextEncoding.Utf8;
        this._salvageable = true;
        this._ready = DocumentReadyState.Loading;
        if (type.Isi(Keywords.Replace))
          type = MimeTypeNames.Html;
        else if (length >= 0)
          type = type.Substring(0, length);
        type = type.StripLeadingTrailingSpaces();
        type.Isi(MimeTypeNames.Html);
        this.ContentType = type;
        this._firedUnload = false;
        this._source.Index = this._source.Length;
      }
      return (IDocument) this;
    }

    public void Load(string url) => this.Location.Href = url;

    void IDocument.Close()
    {
      if (!this.IsLoading)
        return;
      this.FinishLoadingAsync().Wait();
    }

    public void Write(string content)
    {
      if (this.IsReady)
      {
        string content1 = content ?? string.Empty;
        this.Open("text/html", (string) null).Write(content1);
      }
      else
        this._source.InsertText(content);
    }

    public void WriteLine(string content) => this.Write(content + "\n");

    public IHtmlCollection<IElement> GetElementsByName(string name)
    {
      List<IElement> result = new List<IElement>();
      this.ChildNodes.GetElementsByName(name, result);
      return (IHtmlCollection<IElement>) new HtmlCollection<IElement>((IEnumerable<IElement>) result);
    }

    public INode Import(INode externalNode, bool deep = true) => externalNode.NodeType != NodeType.Document ? externalNode.Clone(deep) : throw new DomException(DomError.NotSupported);

    public INode Adopt(INode externalNode)
    {
      if (externalNode.NodeType == NodeType.Document)
        throw new DomException(DomError.NotSupported);
      this.AdoptNode(externalNode);
      return externalNode;
    }

    public Event CreateEvent(string type) => this.Options.GetFactory<IEventFactory>().Create(type) ?? throw new DomException(DomError.NotSupported);

    public INodeIterator CreateNodeIterator(INode root, FilterSettings settings = FilterSettings.All, NodeFilter filter = null) => (INodeIterator) new NodeIterator(root, settings, filter);

    public ITreeWalker CreateTreeWalker(INode root, FilterSettings settings = FilterSettings.All, NodeFilter filter = null) => (ITreeWalker) new TreeWalker(root, settings, filter);

    public IRange CreateRange()
    {
      Range range = new Range((IDocument) this);
      this.AttachReference((object) range);
      return (IRange) range;
    }

    public void Prepend(params INode[] nodes) => this.PrependNodes(nodes);

    public void Append(params INode[] nodes) => this.AppendNodes(nodes);

    public IElement CreateElement(string localName)
    {
      HtmlElement element = localName.IsXmlName() ? this.Options.GetFactory<IElementFactory<HtmlElement>>().Create(this, localName) : throw new DomException(DomError.InvalidCharacter);
      element.SetupElement();
      return (IElement) element;
    }

    public IElement CreateElement(string namespaceUri, string qualifiedName)
    {
      string localName = (string) null;
      string prefix = (string) null;
      Node.GetPrefixAndLocalName(qualifiedName, ref namespaceUri, out prefix, out localName);
      if (namespaceUri.Is(NamespaceNames.HtmlUri))
      {
        HtmlElement element = this.Options.GetFactory<IElementFactory<HtmlElement>>().Create(this, localName, prefix);
        element.SetupElement();
        return (IElement) element;
      }
      if (namespaceUri.Is(NamespaceNames.SvgUri))
      {
        SvgElement element = this.Options.GetFactory<IElementFactory<SvgElement>>().Create(this, localName, prefix);
        element.SetupElement();
        return (IElement) element;
      }
      if (namespaceUri.Is(NamespaceNames.MathMlUri))
      {
        MathElement element = this.Options.GetFactory<IElementFactory<MathElement>>().Create(this, localName, prefix);
        element.SetupElement();
        return (IElement) element;
      }
      Element element1 = new Element(this, localName, prefix, namespaceUri);
      element1.SetupElement();
      return (IElement) element1;
    }

    public IComment CreateComment(string data) => (IComment) new Comment(this, data);

    public IDocumentFragment CreateDocumentFragment() => (IDocumentFragment) new DocumentFragment(this);

    public IProcessingInstruction CreateProcessingInstruction(string target, string data)
    {
      ProcessingInstruction processingInstruction = target.IsXmlName() && !data.Contains("?>") ? new ProcessingInstruction(this, target) : throw new DomException(DomError.InvalidCharacter);
      processingInstruction.Data = data;
      return (IProcessingInstruction) processingInstruction;
    }

    public IText CreateTextNode(string data) => (IText) new TextNode(this, data);

    public IElement GetElementById(string elementId) => this.ChildNodes.GetElementById(elementId);

    public IElement QuerySelector(string selectors) => this.ChildNodes.QuerySelector(selectors);

    public IHtmlCollection<IElement> QuerySelectorAll(string selectors) => (IHtmlCollection<IElement>) this.ChildNodes.QuerySelectorAll(selectors);

    public IHtmlCollection<IElement> GetElementsByClassName(string classNames) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByClassName(classNames);

    public IHtmlCollection<IElement> GetElementsByTagName(string tagName) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByTagName(tagName);

    public IHtmlCollection<IElement> GetElementsByTagName(string namespaceURI, string tagName) => (IHtmlCollection<IElement>) this.ChildNodes.GetElementsByTagName(namespaceURI, tagName);

    public abstract override INode Clone(bool deep = true);

    public override void ToHtml(TextWriter writer, IMarkupFormatter formatter) => this.ChildNodes.ToHtml(writer, formatter);

    public bool HasFocus() => this._context.Active == this;

    public IAttr CreateAttribute(string localName) => localName.IsXmlName() ? (IAttr) new Attr(localName) : throw new DomException(DomError.InvalidCharacter);

    public IAttr CreateAttribute(string namespaceUri, string qualifiedName)
    {
      string localName = (string) null;
      string prefix = (string) null;
      Node.GetPrefixAndLocalName(qualifiedName, ref namespaceUri, out prefix, out localName);
      return (IAttr) new Attr(prefix, localName, string.Empty, namespaceUri);
    }

    internal IEnumerable<T> GetAttachedReferences<T>() where T : class => this._attachedReferences.Select<WeakReference, T>((Func<WeakReference, T>) (entry => !entry.IsAlive ? default (T) : entry.Target as T)).Where<T>((Func<T, bool>) (m => (object) m != null));

    internal void AttachReference(object value) => this._attachedReferences.Add(new WeakReference(value));

    internal void DelayLoad(Task task)
    {
      if (this.IsReady || task == null || task.IsCompleted)
        return;
      this.AttachReference((object) task);
    }

    internal void SetFocus(IElement element) => this._focus = element;

    internal async Task FinishLoadingAsync()
    {
      Task[] tasks = this.GetAttachedReferences<Task>().ToArray<Task>();
      this.ReadyState = DocumentReadyState.Interactive;
      while (this._loadingScripts.Count > 0)
      {
        await this.WaitForReadyAsync().ConfigureAwait(false);
        await this._loadingScripts.Dequeue().RunAsync(CancellationToken.None).ConfigureAwait(false);
      }
      this.QueueTask(new Action(this.RaiseDomContentLoaded));
      await TaskEx.WhenAll(tasks).ConfigureAwait(false);
      this.QueueTask(new Action(this.RaiseLoadedEvent));
      if (this.IsInBrowsingContext)
        this.QueueTask(new Action(this.ShowPage));
      this.QueueTask(new Action(this.EmptyAppCache));
      if (!this.IsToBePrinted)
        return;
      await this.PrintAsync().ConfigureAwait(false);
    }

    internal async Task<bool> PromptToUnloadAsync()
    {
      IEnumerable<IBrowsingContext> descendants = this.GetAttachedReferences<IBrowsingContext>();
      if (this._view.HasEventListener(EventNames.BeforeUnload))
      {
        int num = this._view.Fire(new Event(EventNames.BeforeUnload, cancelable: true)) ? 1 : 0;
        this._salvageable = false;
        if (num != 0)
        {
          var data = new
          {
            Document = this,
            IsCancelled = true
          };
          await this._context.FireAsync(EventNames.ConfirmUnload, data).ConfigureAwait(false);
          if (data.IsCancelled)
            return false;
          data = null;
        }
      }
      foreach (IBrowsingContext browsingContext in descendants)
      {
        if (browsingContext.Active is Document active)
        {
          if (!await active.PromptToUnloadAsync().ConfigureAwait(false))
            return false;
          this._salvageable = this._salvageable && active._salvageable;
        }
        active = (Document) null;
      }
      return true;
    }

    internal void Unload(bool recycle)
    {
      IEnumerable<IBrowsingContext> attachedReferences = this.GetAttachedReferences<IBrowsingContext>();
      if (this._shown)
      {
        this._shown = false;
        this.Fire<PageTransitionEvent>((Action<PageTransitionEvent>) (ev => ev.Init(EventNames.PageHide, false, false, this._salvageable)), (IEventTarget) this._view);
      }
      if (this._view.HasEventListener(EventNames.Unload))
      {
        if (!this._firedUnload)
        {
          this._view.FireSimpleEvent(EventNames.Unload);
          this._firedUnload = true;
        }
        this._salvageable = false;
      }
      this.CancelTasks();
      foreach (IBrowsingContext browsingContext in attachedReferences)
      {
        if (browsingContext.Active is Document active)
        {
          active.Unload(false);
          this._salvageable = this._salvageable && active._salvageable;
        }
      }
      if (recycle || this._salvageable || this._context.Active != this)
        return;
      this._context.Active = (IDocument) null;
    }

    bool IDocument.ExecuteCommand(string commandId, bool showUserInterface, string value)
    {
      ICommand command = this.Options.GetCommand(commandId);
      return command != null && command.Execute((IDocument) this, showUserInterface, value);
    }

    bool IDocument.IsCommandEnabled(string commandId)
    {
      ICommand command = this.Options.GetCommand(commandId);
      return command != null && command.IsEnabled((IDocument) this);
    }

    bool IDocument.IsCommandIndeterminate(string commandId)
    {
      ICommand command = this.Options.GetCommand(commandId);
      return command != null && command.IsIndeterminate((IDocument) this);
    }

    bool IDocument.IsCommandExecuted(string commandId)
    {
      ICommand command = this.Options.GetCommand(commandId);
      return command != null && command.IsExecuted((IDocument) this);
    }

    bool IDocument.IsCommandSupported(string commandId)
    {
      ICommand command = this.Options.GetCommand(commandId);
      return command != null && command.IsSupported((IDocument) this);
    }

    string IDocument.GetCommandValue(string commandId) => this.Options.GetCommand(commandId)?.GetValue((IDocument) this);

    private void Abort(bool fromUser = false)
    {
      if (fromUser && this._context.Active == this)
        this.QueueTask((Action) (() => this._view.FireSimpleEvent(EventNames.Abort)));
      foreach (IBrowsingContext attachedReference in this.GetAttachedReferences<IBrowsingContext>())
      {
        if (attachedReference.Active is Document active)
        {
          active.Abort();
          this._salvageable = this._salvageable && active._salvageable;
        }
      }
      foreach (ICancellable cancellable in this._loader.GetDownloads().Where<IDownload>((Func<IDownload, bool>) (m => !m.IsCompleted)))
      {
        cancellable.Cancel();
        this._salvageable = false;
      }
    }

    private void CancelTasks()
    {
      foreach (CancellationTokenSource attachedReference in this.GetAttachedReferences<CancellationTokenSource>())
      {
        if (!attachedReference.IsCancellationRequested)
          attachedReference.Cancel();
      }
    }

    private static bool IsCommand(IElement element)
    {
      switch (element)
      {
        case IHtmlMenuItemElement _:
        case IHtmlButtonElement _:
          return true;
        default:
          return element is IHtmlAnchorElement;
      }
    }

    private static bool IsLink(IElement element) => (element is IHtmlAnchorElement ? 1 : (element is IHtmlAreaElement ? 1 : 0)) != 0 && element.Attributes.Any<IAttr>((Func<IAttr, bool>) (m => m.Name.Is(AttributeNames.Href)));

    private static bool IsAnchor(IHtmlAnchorElement element) => element.Attributes.Any<IAttr>((Func<IAttr, bool>) (m => m.Name.Is(AttributeNames.Name)));

    private void RaiseDomContentLoaded() => this.FireSimpleEvent(EventNames.DomContentLoaded);

    private void RaiseLoadedEvent()
    {
      this.ReadyState = DocumentReadyState.Complete;
      this.FireSimpleEvent(EventNames.Load);
    }

    private void EmptyAppCache()
    {
    }

    private async Task PrintAsync()
    {
      var data = new{ Document = this };
      this.FireSimpleEvent(EventNames.BeforePrint);
      await this._context.FireAsync(EventNames.Print, data).ConfigureAwait(false);
      this.FireSimpleEvent(EventNames.AfterPrint);
    }

    private void ShowPage()
    {
      if (this._shown)
        return;
      this._shown = true;
      this.Fire<PageTransitionEvent>((Action<PageTransitionEvent>) (ev => ev.Init(EventNames.PageShow, false, false, false)), (IEventTarget) this._view);
    }

    private async void LocationChanged(object sender, AngleSharp.Dom.Location.LocationChangedEventArgs e)
    {
      if (e.IsHashChanged)
      {
        HashChangedEvent hashChangedEvent = new HashChangedEvent();
        hashChangedEvent.Init(EventNames.HashChange, false, false, e.PreviousLocation, e.CurrentLocation);
        hashChangedEvent.IsTrusted = true;
        hashChangedEvent.Dispatch((IEventTarget) this);
      }
      else
      {
        IDocument document = await this._context.OpenAsync(DocumentRequest.Get(new AngleSharp.Url(e.CurrentLocation), (INode) this, this.DocumentUri), CancellationToken.None);
      }
    }

    protected void Setup(CreateDocumentOptions options)
    {
      this.ContentType = options.ContentType.Content;
      this.StatusCode = options.Response.StatusCode;
      this.Referrer = options.Response.Headers.GetOrDefault<string, string>(HeaderNames.Referer, string.Empty);
      this.DocumentUri = options.Response.Address.Href;
      this.Cookie = options.Response.Headers.GetOrDefault<string, string>(HeaderNames.SetCookie, string.Empty);
      this.ImportAncestor = options.ImportAncestor;
      this.ReadyState = DocumentReadyState.Loading;
    }

    protected override sealed string LocateNamespace(string prefix)
    {
      IElement documentElement = this.DocumentElement;
      return documentElement == null ? (string) null : documentElement.LocateNamespaceFor(prefix);
    }

    protected override sealed string LocatePrefix(string namespaceUri)
    {
      IElement documentElement = this.DocumentElement;
      return documentElement == null ? (string) null : documentElement.LocatePrefixFor(namespaceUri);
    }

    protected void CloneDocument(Document document, bool deep)
    {
      this.CloneNode((Node) document, deep);
      document._ready = this._ready;
      document.Referrer = this.Referrer;
      document._location.Href = this._location.Href;
      document._quirksMode = this._quirksMode;
      document._sandbox = this._sandbox;
      document._async = this._async;
      document.ContentType = this.ContentType;
    }

    protected virtual string GetTitle() => string.Empty;

    protected abstract void SetTitle(string value);
  }
}
