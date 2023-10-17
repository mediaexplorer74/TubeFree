// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.FrameRequestProcessor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal sealed class FrameRequestProcessor : BaseRequestProcessor
  {
    private readonly HtmlFrameElementBase _element;

    private FrameRequestProcessor(HtmlFrameElementBase element, IResourceLoader loader)
      : base(loader)
    {
      this._element = element;
    }

    internal static FrameRequestProcessor Create(HtmlFrameElementBase element)
    {
      IResourceLoader loader = element.Owner.Loader;
      return loader == null ? (FrameRequestProcessor) null : new FrameRequestProcessor(element, loader);
    }

    public IDocument Document { get; private set; }

    public override Task ProcessAsync(ResourceRequest request)
    {
      string contentHtml = this._element.GetContentHtml();
      if (contentHtml == null)
        return base.ProcessAsync(request);
      string documentUri = this._element.Owner.DocumentUri;
      return this.ProcessResponse(contentHtml, documentUri);
    }

    protected override Task ProcessResponseAsync(IResponse response)
    {
      CancellationToken none = CancellationToken.None;
      return this.WaitResponse(this._element.NestedContext.OpenAsync(response, none));
    }

    private Task ProcessResponse(string response, string referer) => this.WaitResponse(this._element.NestedContext.OpenAsync((Action<VirtualResponse>) (m => m.Content(response).Address(referer)), CancellationToken.None));

    private async Task WaitResponse(Task<IDocument> task) => this.Document = await task.ConfigureAwait(false);
  }
}
