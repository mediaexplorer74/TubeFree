// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlParser
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Services;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Parser.Html
{
  public class HtmlParser
  {
    private readonly HtmlParserOptions _options;
    private readonly IBrowsingContext _context;

    public HtmlParser()
      : this(Configuration.Default)
    {
    }

    public HtmlParser(HtmlParserOptions options)
      : this(options, Configuration.Default)
    {
    }

    public HtmlParser(IConfiguration configuration)
      : this(new HtmlParserOptions()
      {
        IsScripting = configuration.IsScripting()
      }, configuration)
    {
    }

    public HtmlParser(HtmlParserOptions options, IConfiguration configuration)
      : this(options, BrowsingContext.New(configuration))
    {
    }

    public HtmlParser(HtmlParserOptions options, IBrowsingContext context)
    {
      this._options = options;
      this._context = context;
    }

    public HtmlParserOptions Options => this._options;

    public IBrowsingContext Context => this._context;

    public IHtmlDocument Parse(string source) => (IHtmlDocument) new HtmlDomBuilder(this.CreateDocument(source)).Parse(this._options);

    public INodeList ParseFragment(string source, IElement context)
    {
      HtmlDocument document = this.CreateDocument(source);
      HtmlDomBuilder htmlDomBuilder = new HtmlDomBuilder(document);
      if (context == null)
        return (INodeList) htmlDomBuilder.Parse(this._options).ChildNodes;
      if (!(context is Element context1))
        context1 = (Element) document.Options.GetFactory<IElementFactory<HtmlElement>>().Create((Document) document, context.LocalName, context.Prefix);
      return htmlDomBuilder.ParseFragment(this._options, context1).DocumentElement.ChildNodes;
    }

    public IHtmlDocument Parse(Stream source) => (IHtmlDocument) new HtmlDomBuilder(this.CreateDocument(source)).Parse(this._options);

    public Task<IHtmlDocument> ParseAsync(string source) => this.ParseAsync(source, CancellationToken.None);

    public Task<IHtmlDocument> ParseAsync(Stream source) => this.ParseAsync(source, CancellationToken.None);

    public async Task<IHtmlDocument> ParseAsync(string source, CancellationToken cancel) => (IHtmlDocument) await new HtmlDomBuilder(this.CreateDocument(source)).ParseAsync(this._options, cancel).ConfigureAwait(false);

    public async Task<IHtmlDocument> ParseAsync(Stream source, CancellationToken cancel) => (IHtmlDocument) await new HtmlDomBuilder(this.CreateDocument(source)).ParseAsync(this._options, cancel).ConfigureAwait(false);

    private HtmlDocument CreateDocument(string source) => this.CreateDocument(new TextSource(source));

    private HtmlDocument CreateDocument(Stream source) => this.CreateDocument(new TextSource(source, this._context.Configuration.DefaultEncoding()));

    private HtmlDocument CreateDocument(TextSource textSource) => new HtmlDocument(this._context, textSource);
  }
}
