// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.ObjectRequestProcessor
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
  internal sealed class ObjectRequestProcessor : ResourceRequestProcessor<IObjectInfo>
  {
    private ObjectRequestProcessor(IConfiguration options, IResourceLoader loader)
      : base(options, loader)
    {
    }

    internal static ObjectRequestProcessor Create(Element element)
    {
      Document owner = element.Owner;
      IConfiguration options = owner.Options;
      IResourceLoader loader = owner.Loader;
      return options == null || loader == null ? (ObjectRequestProcessor) null : new ObjectRequestProcessor(options, loader);
    }

    public int Width
    {
      get
      {
        IObjectInfo resource = this.Resource;
        return resource == null ? 0 : resource.Width;
      }
    }

    public int Height
    {
      get
      {
        IObjectInfo resource = this.Resource;
        return resource == null ? 0 : resource.Height;
      }
    }

    protected override async Task ProcessResponseAsync(IResponse response)
    {
      IResourceService<IObjectInfo> service = this.GetService(response);
      if (service == null)
        return;
      CancellationToken none = CancellationToken.None;
      this.Resource = await service.CreateAsync(response, none).ConfigureAwait(false);
    }
  }
}
