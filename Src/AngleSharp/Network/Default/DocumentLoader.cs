// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Default.DocumentLoader
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Collections.Generic;

namespace AngleSharp.Network.Default
{
  public class DocumentLoader : BaseLoader, IDocumentLoader, ILoader
  {
    public DocumentLoader(IBrowsingContext context, Predicate<IRequest> filter = null)
      : base(context, filter)
    {
    }

    public virtual IDownload DownloadAsync(DocumentRequest request)
    {
      Request request1 = new Request()
      {
        Address = request.Target,
        Content = request.Body,
        Method = request.Method
      };
      foreach (KeyValuePair<string, string> header in request.Headers)
        request1.Headers[header.Key] = header.Value;
      return this.DownloadAsync(request1, request.Source);
    }
  }
}
