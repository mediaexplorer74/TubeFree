// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.ResourceRequestProcessor`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Services;
using AngleSharp.Services.Media;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal abstract class ResourceRequestProcessor<TResource> : BaseRequestProcessor where TResource : IResourceInfo
  {
    private readonly IConfiguration _options;

    public ResourceRequestProcessor(IConfiguration options, IResourceLoader loader)
      : base(loader)
    {
      this._options = options;
    }

    public string Source
    {
      get
      {
        TResource resource1 = this.Resource;
        ref TResource local1 = ref resource1;
        string str;
        if ((object) default (TResource) == null)
        {
          TResource resource2 = local1;
          ref TResource local2 = ref resource2;
          if ((object) resource2 == null)
          {
            str = (string) null;
            goto label_4;
          }
          else
            local1 = ref local2;
        }
        str = local1.Source.Href;
label_4:
        return str ?? string.Empty;
      }
    }

    public bool IsReady => (object) this.Resource != null;

    public TResource Resource { get; protected set; }

    public override Task ProcessAsync(ResourceRequest request) => this.IsDifferentToCurrentResourceUrl(request.Target) ? base.ProcessAsync(request) : (Task) null;

    protected IResourceService<TResource> GetService(IResponse response) => this._options.GetResourceService<TResource>(response.GetContentType().Content);

    private bool IsDifferentToCurrentResourceUrl(Url target)
    {
      TResource resource = this.Resource;
      return (object) resource == null || !target.Equals(resource.Source);
    }
  }
}
