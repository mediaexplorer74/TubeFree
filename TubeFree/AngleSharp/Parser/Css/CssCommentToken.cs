// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssCommentToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Css
{
  internal sealed class CssCommentToken : CssToken
  {
    private readonly bool _bad;

    public CssCommentToken(string data, bool bad, TextPosition position)
      : base(CssTokenType.Comment, data, position)
    {
      this._bad = bad;
    }

    public bool IsBad => this._bad;

    public override string ToValue() => "/*" + this.Data + (this._bad ? string.Empty : "*/");
  }
}
