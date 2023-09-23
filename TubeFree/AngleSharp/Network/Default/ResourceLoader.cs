// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Default.ResourceLoader
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Network.Default
{
  public class ResourceLoader : BaseLoader, IResourceLoader, ILoader
  {
    public ResourceLoader(IBrowsingContext context, Predicate<IRequest> filter = null)
      : base(context, filter)
    {
    }

    public virtual IDownload DownloadAsync(ResourceRequest request)
    {
      Request request1 = new Request()
      {
        Address = request.Target,
        Content = Stream.Null,
        Method = HttpMethod.Get,
        Headers = (IDictionary<string, string>) new Dictionary<string, string>()
        {
          {
            HeaderNames.Referer,
            request.Source.Owner.DocumentUri
          }
        }
      };
      string cookie = this.GetCookie(request.Target);
      if (cookie != null)
        request1.Headers[HeaderNames.Cookie] = cookie;
      return this.DownloadAsync(request1, (INode) request.Source);
    }
  }
}
