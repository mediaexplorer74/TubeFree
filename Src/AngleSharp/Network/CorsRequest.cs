// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.CorsRequest
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Services;

namespace AngleSharp.Network
{
  public class CorsRequest
  {
    public CorsRequest(ResourceRequest request) => this.Request = request;

    public ResourceRequest Request { get; }

    public CorsSetting Setting { get; set; }

    public OriginBehavior Behavior { get; set; }

    public IIntegrityProvider Integrity { get; set; }
  }
}
