// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.DocumentFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Dom.Svg;
using AngleSharp.Dom.Xml;
using AngleSharp.Network;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Services.Default
{
  public class DocumentFactory : IDocumentFactory
  {
    private readonly Dictionary<string, DocumentFactory.Creator> _creators = new Dictionary<string, DocumentFactory.Creator>()
    {
      {
        MimeTypeNames.Xml,
        new DocumentFactory.Creator(XmlDocument.LoadAsync)
      },
      {
        MimeTypeNames.ApplicationXml,
        new DocumentFactory.Creator(XmlDocument.LoadAsync)
      },
      {
        MimeTypeNames.Svg,
        new DocumentFactory.Creator(SvgDocument.LoadAsync)
      },
      {
        MimeTypeNames.Html,
        new DocumentFactory.Creator(HtmlDocument.LoadAsync)
      },
      {
        MimeTypeNames.ApplicationXHtml,
        new DocumentFactory.Creator(HtmlDocument.LoadAsync)
      },
      {
        MimeTypeNames.Plain,
        new DocumentFactory.Creator(HtmlDocument.LoadTextAsync)
      },
      {
        MimeTypeNames.ApplicationJson,
        new DocumentFactory.Creator(HtmlDocument.LoadTextAsync)
      },
      {
        MimeTypeNames.DefaultJavaScript,
        new DocumentFactory.Creator(HtmlDocument.LoadTextAsync)
      },
      {
        MimeTypeNames.Css,
        new DocumentFactory.Creator(HtmlDocument.LoadTextAsync)
      }
    };

    public void Register(string contentType, DocumentFactory.Creator creator) => this._creators.Add(contentType, creator);

    public DocumentFactory.Creator Unregister(string contentType)
    {
      DocumentFactory.Creator creator = (DocumentFactory.Creator) null;
      if (this._creators.TryGetValue(contentType, out creator))
        this._creators.Remove(contentType);
      return creator;
    }

    protected virtual Task<IDocument> CreateDefaultAsync(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancellationToken)
    {
      return HtmlDocument.LoadAsync(context, options, cancellationToken);
    }

    public Task<IDocument> CreateAsync(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancellationToken)
    {
      MimeType contentType = options.ContentType;
      foreach (KeyValuePair<string, DocumentFactory.Creator> creator in this._creators)
      {
        if (contentType.Represents(creator.Key))
          return creator.Value(context, options, cancellationToken);
      }
      return this.CreateDefaultAsync(context, options, cancellationToken);
    }

    public delegate Task<IDocument> Creator(
      IBrowsingContext context,
      CreateDocumentOptions options,
      CancellationToken cancellationToken);
  }
}
