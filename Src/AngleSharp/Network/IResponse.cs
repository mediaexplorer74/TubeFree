// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.IResponse
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AngleSharp.Network
{
  public interface IResponse : IDisposable
  {
    HttpStatusCode StatusCode { get; }

    Url Address { get; }

    IDictionary<string, string> Headers { get; }

    Stream Content { get; }
  }
}
