// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.ResourceRequest
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;

namespace AngleSharp.Network
{
  public class ResourceRequest
  {
    public ResourceRequest(IElement source, Url target)
    {
      this.Source = source;
      this.Target = target;
      this.Origin = source.Owner.Origin;
      this.IsManualRedirectDesired = false;
      this.IsSameOriginForced = false;
      this.IsCookieBlocked = false;
      this.IsCredentialOmitted = false;
    }

    public IElement Source { get; }

    public Url Target { get; }

    public string Origin { get; set; }

    public bool IsManualRedirectDesired { get; set; }

    public bool IsSameOriginForced { get; set; }

    public bool IsCredentialOmitted { get; set; }

    public bool IsCookieBlocked { get; set; }
  }
}
