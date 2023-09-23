// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Svg.SvgDocument
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Network;
using AngleSharp.Parser.Xml;
using AngleSharp.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Svg
{
  internal sealed class SvgDocument : 
    Document,
    ISvgDocument,
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
    internal SvgDocument(IBrowsingContext context, TextSource source)
      : base(context ?? BrowsingContext.New(), source)
    {
      this.ContentType = MimeTypeNames.Svg;
    }

    internal SvgDocument(IBrowsingContext context = null)
      : this(context, new TextSource(string.Empty))
    {
    }

    public override IElement DocumentElement => (IElement) this.RootElement;

    public ISvgSvgElement RootElement => this.FindChild<ISvgSvgElement>();

    public override INode Clone(bool deep = true)
    {
      SvgDocument svgDocument = new SvgDocument(this.Context, new TextSource(this.Source.Text));
      this.CloneDocument((Document) svgDocument, deep);
      return (INode) svgDocument;
    }

    internal static async Task<IDocument> LoadAsync(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancelToken)
    {
      XmlParserOptions xmlParserOptions = new XmlParserOptions();
      SvgDocument document = new SvgDocument(context, options.Source);
      XmlDomBuilder xmlDomBuilder = new XmlDomBuilder((Document) document, new Func<Document, string, string, Element>(context.Configuration.GetFactory<IElementFactory<SvgElement>>().Create));
      document.Setup(options);
      context.NavigateTo((IDocument) document);
      context.Fire((Event) new HtmlParseEvent((IDocument) document, false));
      XmlParserOptions options1 = xmlParserOptions;
      CancellationToken cancelToken1 = cancelToken;
      Document document1 = await xmlDomBuilder.ParseAsync(options1, cancelToken1).ConfigureAwait(false);
      context.Fire((Event) new HtmlParseEvent((IDocument) document, true));
      return (IDocument) document;
    }

    protected override string GetTitle()
    {
      ISvgTitleElement child = this.RootElement.FindChild<ISvgTitleElement>();
      return (child != null ? child.TextContent.CollapseAndStrip() : (string) null) ?? base.GetTitle();
    }

    protected override void SetTitle(string value)
    {
      ISvgTitleElement child = this.RootElement.FindChild<ISvgTitleElement>();
      if (child == null)
      {
        child = (ISvgTitleElement) new SvgTitleElement((Document) this);
        this.RootElement.AppendChild((INode) child);
      }
      child.TextContent = value;
    }
  }
}
