﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBorderLeftStyleProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBorderLeftStyleProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault<LineStyle>(LineStyle.None);

    internal CssBorderLeftStyleProperty()
      : base(PropertyNames.BorderLeftStyle)
    {
    }

    internal override IValueConverter Converter => CssBorderLeftStyleProperty.StyleConverter;
  }
}
