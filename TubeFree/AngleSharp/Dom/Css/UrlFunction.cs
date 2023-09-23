// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.UrlFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;

namespace AngleSharp.Dom.Css
{
  internal sealed class UrlFunction : DocumentFunction
  {
    private readonly Url _expected;

    public UrlFunction(string url)
      : base(FunctionNames.Url, url)
    {
      this._expected = Url.Create(this.Data);
    }

    public override bool Matches(Url actual) => !this._expected.IsInvalid && this._expected.Equals(actual);
  }
}
