﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssUnicodeRangeProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssUnicodeRangeProperty : CssProperty
  {
    public CssUnicodeRangeProperty()
      : base(PropertyNames.UnicodeRange)
    {
    }

    internal override IValueConverter Converter => Converters.Any;
  }
}
