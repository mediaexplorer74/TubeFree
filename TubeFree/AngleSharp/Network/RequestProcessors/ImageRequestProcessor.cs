// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.ImageRequestProcessor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Services;
using AngleSharp.Services.Media;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal sealed class ImageRequestProcessor : ResourceRequestProcessor<IImageInfo>
  {
    private ImageRequestProcessor(IConfiguration options, IResourceLoader loader)
      : base(options, loader)
    {
    }

    internal static ImageRequestProcessor Create(Element element)
    {
      Document owner = element.Owner;
      IConfiguration options = owner.Options;
      IResourceLoader loader = owner.Loader;
      return options == null || loader == null ? (ImageRequestProcessor) null : new ImageRequestProcessor(options, loader);
    }

    public int Width => !this.IsReady ? 0 : this.Resource.Width;

    public int Height => !this.IsReady ? 0 : this.Resource.Height;

    protected override async Task ProcessResponseAsync(IResponse response)
    {
      IResourceService<IImageInfo> service = this.GetService(response);
      if (service == null)
        return;
      CancellationToken none = CancellationToken.None;
      this.Resource = await service.CreateAsync(response, none).ConfigureAwait(false);
    }
  }
}
