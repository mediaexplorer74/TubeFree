// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.DomainFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System;

namespace AngleSharp.Dom.Css
{
  internal sealed class DomainFunction : DocumentFunction
  {
    private readonly string _subdomain;

    public DomainFunction(string url)
      : base(FunctionNames.Domain, url)
    {
      this._subdomain = "." + url;
    }

    public override bool Matches(Url url)
    {
      string hostName = url.HostName;
      return hostName.Isi(this.Data) || hostName.EndsWith(this._subdomain, StringComparison.OrdinalIgnoreCase);
    }
  }
}
