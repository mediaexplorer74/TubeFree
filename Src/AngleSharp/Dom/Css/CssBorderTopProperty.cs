// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBorderTopProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBorderTopProperty : CssShorthandProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.WithAny(Converters.LineWidthConverter.Option().For(PropertyNames.BorderTopWidth), Converters.LineStyleConverter.Option().For(PropertyNames.BorderTopStyle), Converters.CurrentColorConverter.Option().For(PropertyNames.BorderTopColor)).OrDefault();

    internal CssBorderTopProperty()
      : base(PropertyNames.BorderTop, PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssBorderTopProperty.StyleConverter;
  }
}
