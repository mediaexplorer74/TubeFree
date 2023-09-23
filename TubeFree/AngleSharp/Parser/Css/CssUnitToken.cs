// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssUnitToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Globalization;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssUnitToken : CssToken
  {
    private readonly string _unit;

    public CssUnitToken(CssTokenType type, string value, string dimension, TextPosition position)
      : base(type, value, position)
    {
      this._unit = dimension;
    }

    public float Value => float.Parse(this.Data, (IFormatProvider) CultureInfo.InvariantCulture);

    public string Unit => this._unit;

    public override string ToValue() => this.Data + this._unit;
  }
}
