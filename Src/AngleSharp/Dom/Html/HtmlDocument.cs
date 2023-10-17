// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlDocument
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Parser.Html;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlDocument : 
    Document,
    IHtmlDocument,
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
    internal HtmlDocument(IBrowsingContext context, TextSource source)
      : base(context ?? BrowsingContext.New(), source)
    {
      this.ContentType = MimeTypeNames.Html;
    }

    internal HtmlDocument(IBrowsingContext context = null)
      : this(context, new TextSource(string.Empty))
    {
    }

    public override IElement DocumentElement => (IElement) this.FindChild<HtmlHtmlElement>();

    public override INode Clone(bool deep = true)
    {
      HtmlDocument htmlDocument = new HtmlDocument(this.Context, new TextSource(this.Source.Text));
      this.CloneDocument((Document) htmlDocument, deep);
      return (INode) htmlDocument;
    }

    internal static async Task<IDocument> LoadAsync(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancelToken)
    {
      bool flag = context.Configuration.IsScripting();
      HtmlParserOptions htmlParserOptions = new HtmlParserOptions()
      {
        IsScripting = flag
      };
      HtmlDocument document = new HtmlDocument(context, options.Source);
      HtmlDomBuilder htmlDomBuilder = new HtmlDomBuilder(document);
      document.Setup(options);
      context.NavigateTo((IDocument) document);
      context.Fire((Event) new HtmlParseEvent((IDocument) document, false));
      HtmlParserOptions options1 = htmlParserOptions;
      CancellationToken cancelToken1 = cancelToken;
      HtmlDocument htmlDocument = await htmlDomBuilder.ParseAsync(options1, cancelToken1).ConfigureAwait(false);
      context.Fire((Event) new HtmlParseEvent((IDocument) document, true));
      return (IDocument) document;
    }

    internal static async Task<IDocument> LoadTextAsync(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancelToken)
    {
      new HtmlParserOptions().IsScripting = context.Configuration.IsScripting();
      HtmlDocument document = new HtmlDocument(context, options.Source);
      document.Setup(options);
      context.NavigateTo((IDocument) document);
      IElement element1 = document.CreateElement(TagNames.Html);
      IElement element2 = document.CreateElement(TagNames.Head);
      IElement element3 = document.CreateElement(TagNames.Body);
      IElement pre = document.CreateElement(TagNames.Pre);
      document.AppendChild((INode) element1);
      element1.AppendChild((INode) element2);
      element1.AppendChild((INode) element3);
      element3.AppendChild((INode) pre);
      pre.SetAttribute(AttributeNames.Style, "word-wrap: break-word; white-space: pre-wrap;");
      await options.Source.PrefetchAllAsync(cancelToken).ConfigureAwait(false);
      pre.TextContent = options.Source.Text;
      return (IDocument) document;
    }

    protected override string GetTitle()
    {
      IHtmlTitleElement descendant = this.DocumentElement.FindDescendant<IHtmlTitleElement>();
      return (descendant != null ? descendant.TextContent.CollapseAndStrip() : (string) null) ?? base.GetTitle();
    }

    protected override void SetTitle(string value)
    {
      IHtmlTitleElement child = this.DocumentElement.FindDescendant<IHtmlTitleElement>();
      if (child == null)
      {
        IHtmlHeadElement head = this.Head;
        if (head == null)
          return;
        child = (IHtmlTitleElement) new HtmlTitleElement((Document) this);
        head.AppendChild((INode) child);
      }
      child.TextContent = value;
    }
  }
}
