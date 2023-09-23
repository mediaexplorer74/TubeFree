// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBorderBottomRightRadiusProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBorderBottomRightRadiusProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.BorderRadiusConverter.OrDefault<Length>(Length.Zero);

    internal CssBorderBottomRightRadiusProperty()
      : base(PropertyNames.BorderBottomRightRadius, PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssBorderBottomRightRadiusProperty.StyleConverter;
  }
}
