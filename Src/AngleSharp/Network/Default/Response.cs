// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Default.Response
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AngleSharp.Network.Default
{
  public sealed class Response : IResponse, IDisposable
  {
    public Response()
    {
      this.Headers = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      this.StatusCode = HttpStatusCode.Accepted;
    }

    public HttpStatusCode StatusCode { get; set; }

    public Url Address { get; set; }

    public IDictionary<string, string> Headers { get; set; }

    public Stream Content { get; set; }

    void IDisposable.Dispose()
    {
      this.Content?.Dispose();
      this.Headers.Clear();
    }
  }
}
