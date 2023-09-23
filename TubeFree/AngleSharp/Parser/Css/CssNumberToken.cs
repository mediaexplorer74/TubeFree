// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssNumberToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Globalization;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssNumberToken : CssToken
  {
    private static readonly char[] floatIndicators = new char[3]
    {
      '.',
      'e',
      'E'
    };

    public CssNumberToken(string number, TextPosition position)
      : base(CssTokenType.Number, number, position)
    {
    }

    public bool IsInteger => this.Data.IndexOfAny(CssNumberToken.floatIndicators) == -1;

    public int IntegerValue => int.Parse(this.Data, (IFormatProvider) CultureInfo.InvariantCulture);

    public float Value => float.Parse(this.Data, (IFormatProvider) CultureInfo.InvariantCulture);
  }
}
