// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.BaseRequestProcessor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal abstract class BaseRequestProcessor : IRequestProcessor
  {
    private readonly IResourceLoader _loader;

    public BaseRequestProcessor(IResourceLoader loader) => this._loader = loader;

    public IDownload Download { get; protected set; }

    public virtual Task ProcessAsync(ResourceRequest request)
    {
      if (!this.IsDifferentToCurrentDownloadUrl(request.Target))
        return (Task) null;
      this.CancelDownload();
      this.Download = this._loader.DownloadAsync(request);
      return this.FinishDownloadAsync();
    }

    protected abstract Task ProcessResponseAsync(IResponse response);

    protected async Task FinishDownloadAsync()
    {
      IDownload download = this.Download;
      IResponse response = await download.Task.ConfigureAwait(false);
      EventTarget eventTarget = download.Originator as EventTarget;
      string eventName = EventNames.Error;
      if (response != null)
      {
        try
        {
          await this.ProcessResponseAsync(response).ConfigureAwait(false);
          eventName = EventNames.Load;
        }
        catch (Exception ex)
        {
        }
        finally
        {
          response.Dispose();
        }
      }
      EventTarget target = eventTarget;
      if (target == null)
        return;
      target.FireSimpleEvent(eventName);
    }

    protected void CancelDownload()
    {
      IDownload download = this.Download;
      if (download == null || download.IsCompleted)
        return;
      download.Cancel();
    }

    protected bool IsDifferentToCurrentDownloadUrl(Url target)
    {
      IDownload download = this.Download;
      return download == null || !target.Equals(download.Target);
    }
  }
}
