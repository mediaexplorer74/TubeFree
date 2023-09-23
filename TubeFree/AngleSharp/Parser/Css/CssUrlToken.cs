// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssUrlToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssUrlToken : CssToken
  {
    private readonly bool _bad;
    private readonly string _functionName;

    public CssUrlToken(string functionName, string data, bool bad, TextPosition position)
      : base(CssTokenType.Url, data, position)
    {
      this._bad = bad;
      this._functionName = functionName;
    }

    public bool IsBad => this._bad;

    public string FunctionName => this._functionName;

    public override string ToValue() => this._functionName.CssFunction(this.Data.CssString());
  }
}
