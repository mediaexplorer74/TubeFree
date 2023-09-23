// Decompiled with JetBrains decompiler
// Type: AngleSharp.BrowsingContext
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using System;

namespace AngleSharp
{
  public sealed class BrowsingContext : EventTarget, IBrowsingContext, IEventTarget, IDisposable
  {
    private readonly IConfiguration _configuration;
    private readonly Sandboxes _security;
    private readonly IBrowsingContext _parent;
    private readonly IDocument _creator;
    private readonly IDocumentLoader _loader;
    private readonly IHistory _history;

    event DomEventHandler IBrowsingContext.Parsing
    {
      add => this.AddEventListener(EventNames.ParseStart, value, false);
      remove => this.RemoveEventListener(EventNames.ParseStart, value, false);
    }

    event DomEventHandler IBrowsingContext.Parsed
    {
      add => this.AddEventListener(EventNames.ParseEnd, value, false);
      remove => this.RemoveEventListener(EventNames.ParseEnd, value, false);
    }

    event DomEventHandler IBrowsingContext.Requesting
    {
      add => this.AddEventListener(EventNames.RequestStart, value, false);
      remove => this.RemoveEventListener(EventNames.RequestStart, value, false);
    }

    event DomEventHandler IBrowsingContext.Requested
    {
      add => this.AddEventListener(EventNames.RequestEnd, value, false);
      remove => this.RemoveEventListener(EventNames.RequestEnd, value, false);
    }

    event DomEventHandler IBrowsingContext.ParseError
    {
      add => this.AddEventListener(EventNames.ParseError, value, false);
      remove => this.RemoveEventListener(EventNames.ParseError, value, false);
    }

    internal BrowsingContext(IConfiguration configuration, Sandboxes security)
    {
      this._configuration = configuration;
      this._security = security;
      this._loader = this.CreateService<IDocumentLoader>();
      this._history = this.CreateService<IHistory>();
    }

    internal BrowsingContext(IBrowsingContext parent, Sandboxes security)
      : this(parent.Configuration, security)
    {
      this._parent = parent;
      this._creator = this._parent.Active;
    }

    public IDocument Active { get; set; }

    public IDocumentLoader Loader => this._loader;

    public IConfiguration Configuration => this._configuration;

    public IDocument Creator => this._creator;

    public IWindow Current => this.Active?.DefaultView;

    public IBrowsingContext Parent => this._parent;

    public IHistory SessionHistory => this._history;

    public Sandboxes Security => this._security;

    public static IBrowsingContext New(IConfiguration configuration = null)
    {
      if (configuration == null)
        configuration = AngleSharp.Configuration.Default;
      return configuration.NewContext();
    }

    void IDisposable.Dispose()
    {
      this.Active?.Dispose();
      this.Active = (IDocument) null;
    }
  }
}
