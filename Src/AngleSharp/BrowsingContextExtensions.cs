// Decompiled with JetBrains decompiler
// Type: AngleSharp.BrowsingContextExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Network;
using AngleSharp.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp
{
  public static class BrowsingContextExtensions
  {
    public static Task<IDocument> OpenNewAsync(this IBrowsingContext context, string url = null) => context.OpenAsync((Action<VirtualResponse>) (m => m.Address(url)));

    public static Task<IDocument> OpenAsync(
      this IBrowsingContext context,
      IResponse response,
      CancellationToken cancel)
    {
      if (response == null)
        throw new ArgumentNullException(nameof (response));
      if (context == null)
        context = BrowsingContext.New();
      CreateDocumentOptions options = new CreateDocumentOptions(response, context.Configuration);
      return context.Configuration.GetFactory<IDocumentFactory>().CreateAsync(context, options, cancel);
    }

    public static async Task<IDocument> OpenAsync(
      this IBrowsingContext context,
      DocumentRequest request,
      CancellationToken cancel)
    {
      if (request == null)
        throw new ArgumentNullException(nameof (request));
      IDocumentLoader loader = context.Loader;
      if (loader != null)
      {
        IDownload download = loader.DownloadAsync(request);
        cancel.Register(new Action(((ICancellable) download).Cancel));
        using (IResponse response = await download.Task.ConfigureAwait(false))
        {
          if (response != null)
            return await context.OpenAsync(response, cancel).ConfigureAwait(false);
        }
      }
      return await context.OpenNewAsync(request.Target.Href).ConfigureAwait(false);
    }

    public static Task<IDocument> OpenAsync(
      this IBrowsingContext context,
      Url url,
      CancellationToken cancel)
    {
      DocumentRequest request = url != null ? DocumentRequest.Get(url) : throw new ArgumentNullException(nameof (url));
      if (context != null && context.Active != null)
        request.Referer = context.Active.DocumentUri;
      return context.OpenAsync(request, cancel);
    }

    public static async Task<IDocument> OpenAsync(
      this IBrowsingContext context,
      Action<VirtualResponse> request,
      CancellationToken cancel)
    {
      if (request == null)
        throw new ArgumentNullException(nameof (request));
      IDocument document;
      using (IResponse response = VirtualResponse.Create(request))
        document = await context.OpenAsync(response, cancel).ConfigureAwait(false);
      return document;
    }

    public static Task<IDocument> OpenAsync(
      this IBrowsingContext context,
      Action<VirtualResponse> request)
    {
      return context.OpenAsync(request, CancellationToken.None);
    }

    public static Task<IDocument> OpenAsync(this IBrowsingContext context, Url url) => context.OpenAsync(url, CancellationToken.None);

    public static Task<IDocument> OpenAsync(this IBrowsingContext context, string address)
    {
      if (address == null)
        throw new ArgumentNullException(nameof (address));
      return context.OpenAsync(Url.Create(address), CancellationToken.None);
    }

    public static void NavigateTo(this IBrowsingContext context, IDocument document)
    {
      context.SessionHistory?.PushState((object) document, document.Title, document.Url);
      context.Active = document;
    }
  }
}
