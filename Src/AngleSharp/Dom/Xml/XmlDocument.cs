// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Xml.XmlDocument
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Network;
using AngleSharp.Parser.Xml;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Xml
{
  internal sealed class XmlDocument : 
    Document,
    IXmlDocument,
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
    internal XmlDocument(IBrowsingContext context, TextSource source)
      : base(context ?? BrowsingContext.New(), source)
    {
      this.ContentType = MimeTypeNames.Xml;
    }

    internal XmlDocument(IBrowsingContext context = null)
      : this(context, new TextSource(string.Empty))
    {
    }

    public override IElement DocumentElement => this.FindChild<IElement>();

    public override INode Clone(bool deep = true)
    {
      XmlDocument xmlDocument = new XmlDocument(this.Context, new TextSource(this.Source.Text));
      this.CloneDocument((Document) xmlDocument, deep);
      return (INode) xmlDocument;
    }

    internal static async Task<IDocument> LoadAsync(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancelToken)
    {
      XmlParserOptions xmlParserOptions = new XmlParserOptions();
      XmlDocument document = new XmlDocument(context, options.Source);
      XmlDomBuilder xmlDomBuilder = new XmlDomBuilder((Document) document);
      document.Setup(options);
      context.NavigateTo((IDocument) document);
      context.Fire((Event) new HtmlParseEvent((IDocument) document, false));
      XmlParserOptions options1 = new XmlParserOptions();
      CancellationToken cancelToken1 = cancelToken;
      Document document1 = await xmlDomBuilder.ParseAsync(options1, cancelToken1).ConfigureAwait(false);
      context.Fire((Event) new HtmlParseEvent((IDocument) document, true));
      return (IDocument) document;
    }

    protected override void SetTitle(string value)
    {
    }
  }
}
