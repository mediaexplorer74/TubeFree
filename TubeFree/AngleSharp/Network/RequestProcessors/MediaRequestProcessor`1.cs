// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.MediaRequestProcessor`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Media;
using AngleSharp.Services;
using AngleSharp.Services.Media;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal sealed class MediaRequestProcessor<TMediaInfo> : ResourceRequestProcessor<TMediaInfo> where TMediaInfo : IMediaInfo
  {
    private MediaRequestProcessor(IConfiguration options, IResourceLoader loader)
      : base(options, loader)
    {
    }

    internal static MediaRequestProcessor<TMediaInfo> Create(Element element)
    {
      Document owner = element.Owner;
      IConfiguration options = owner.Options;
      IResourceLoader loader = owner.Loader;
      return options == null || loader == null ? (MediaRequestProcessor<TMediaInfo>) null : new MediaRequestProcessor<TMediaInfo>(options, loader);
    }

    public TMediaInfo Media { get; private set; }

    public MediaNetworkState NetworkState
    {
      get
      {
        IDownload download = this.Download;
        if (download != null)
        {
          if (download.IsRunning)
            return MediaNetworkState.Loading;
          if ((object) this.Resource == null)
            return MediaNetworkState.NoSource;
        }
        return MediaNetworkState.Idle;
      }
    }

    protected override async Task ProcessResponseAsync(IResponse response)
    {
      IResourceService<TMediaInfo> service = this.GetService(response);
      if (service == null)
        return;
      CancellationToken none = CancellationToken.None;
      this.Media = await service.CreateAsync(response, none).ConfigureAwait(false);
    }
  }
}
