// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssStringToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssStringToken : CssToken
  {
    private readonly bool _bad;
    private readonly char _quote;

    public CssStringToken(string data, bool bad, char quote, TextPosition position)
      : base(CssTokenType.String, data, position)
    {
      this._bad = bad;
      this._quote = quote;
    }

    public bool IsBad => this._bad;

    public char Quote => this._quote;

    public override string ToValue() => this.Data.CssString();
  }
}
