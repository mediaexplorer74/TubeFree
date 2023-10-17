// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlParser
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Xml;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Parser.Xml
{
  public class XmlParser
  {
    private readonly XmlParserOptions _options;
    private readonly IBrowsingContext _context;

    public XmlParser()
      : this(Configuration.Default)
    {
    }

    public XmlParser(XmlParserOptions options)
      : this(options, Configuration.Default)
    {
    }

    public XmlParser(IConfiguration configuration)
      : this(new XmlParserOptions(), configuration)
    {
    }

    public XmlParser(XmlParserOptions options, IConfiguration configuration)
      : this(options, BrowsingContext.New(configuration))
    {
    }

    public XmlParser(XmlParserOptions options, IBrowsingContext context)
    {
      this._options = options;
      this._context = context;
    }

    public XmlParserOptions Options => this._options;

    public IBrowsingContext Context => this._context;

    public IXmlDocument Parse(string source)
    {
      XmlDocument document = this.CreateDocument(source);
      new XmlDomBuilder((Document) document).Parse(this._options);
      return (IXmlDocument) document;
    }

    public IXmlDocument Parse(Stream source)
    {
      XmlDocument document = this.CreateDocument(source);
      new XmlDomBuilder((Document) document).Parse(this._options);
      return (IXmlDocument) document;
    }

    public Task<IXmlDocument> ParseAsync(string source) => this.ParseAsync(source, CancellationToken.None);

    public Task<IXmlDocument> ParseAsync(Stream source) => this.ParseAsync(source, CancellationToken.None);

    public async Task<IXmlDocument> ParseAsync(string source, CancellationToken cancel)
    {
      XmlDocument document = this.CreateDocument(source);
      Document document1 = await new XmlDomBuilder((Document) document).ParseAsync(this._options, cancel).ConfigureAwait(false);
      return (IXmlDocument) document;
    }

    public async Task<IXmlDocument> ParseAsync(Stream source, CancellationToken cancel)
    {
      XmlDocument document = this.CreateDocument(source);
      Document document1 = await new XmlDomBuilder((Document) document).ParseAsync(this._options, cancel).ConfigureAwait(false);
      return (IXmlDocument) document;
    }

    private XmlDocument CreateDocument(string source) => this.CreateDocument(new TextSource(source));

    private XmlDocument CreateDocument(Stream source) => this.CreateDocument(new TextSource(source, this._context.Configuration.DefaultEncoding()));

    private XmlDocument CreateDocument(TextSource textSource) => new XmlDocument(this._context, textSource);
  }
}
