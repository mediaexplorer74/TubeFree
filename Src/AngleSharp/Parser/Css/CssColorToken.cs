// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssColorToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Css
{
  internal sealed class CssColorToken : CssToken
  {
    public CssColorToken(string data, TextPosition position)
      : base(CssTokenType.Color, data, position)
    {
    }

    public bool IsBad => this.Data.Length != 3 && this.Data.Length != 6;

    public override string ToValue() => "#" + this.Data;
  }
}
