// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.DocumentRequestProcessor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Extensions;
using AngleSharp.Services;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal sealed class DocumentRequestProcessor : BaseRequestProcessor
  {
    private readonly IDocument _parentDocument;
    private readonly IConfiguration _configuration;

    private DocumentRequestProcessor(
      IDocument document,
      IConfiguration configuration,
      IResourceLoader loader)
      : base(loader)
    {
      this._parentDocument = document;
      this._configuration = configuration;
    }

    internal static DocumentRequestProcessor Create(Element element)
    {
      Document owner = element.Owner;
      IConfiguration options = owner.Options;
      IResourceLoader loader = owner.Loader;
      return options == null || loader == null ? (DocumentRequestProcessor) null : new DocumentRequestProcessor((IDocument) owner, options, loader);
    }

    public IDocument ChildDocument { get; private set; }

    protected override async Task ProcessResponseAsync(IResponse response)
    {
      BrowsingContext context = new BrowsingContext(this._parentDocument.Context, Sandboxes.None);
      CreateDocumentOptions options = new CreateDocumentOptions(response, this._configuration, this._parentDocument);
      this.ChildDocument = 
                await this._configuration.GetFactory<IDocumentFactory>()
                .CreateAsync((IBrowsingContext) context, options, CancellationToken.None).ConfigureAwait(false);
    }
  }
}
