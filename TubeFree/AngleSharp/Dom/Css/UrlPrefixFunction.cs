// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.UrlPrefixFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using System;

namespace AngleSharp.Dom.Css
{
  internal sealed class UrlPrefixFunction : DocumentFunction
  {
    public UrlPrefixFunction(string url)
      : base(FunctionNames.UrlPrefix, url)
    {
    }

    public override bool Matches(Url url) => url.Href.StartsWith(this.Data, StringComparison.OrdinalIgnoreCase);
  }
}
