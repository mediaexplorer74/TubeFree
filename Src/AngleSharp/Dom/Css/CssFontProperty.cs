// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssFontProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssFontProperty : CssShorthandProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.WithOrder(Converters.WithAny(Converters.FontStyleConverter.Option().For(PropertyNames.FontStyle), Converters.FontVariantConverter.Option().For(PropertyNames.FontVariant), Converters.FontWeightConverter.Or(Converters.WeightIntegerConverter).Option().For(PropertyNames.FontWeight), Converters.FontStretchConverter.Option().For(PropertyNames.FontStretch)), Converters.WithOrder(Converters.FontSizeConverter.Required().For(PropertyNames.FontSize), Converters.LineHeightConverter.StartsWithDelimiter().Option().For(PropertyNames.LineHeight), Converters.FontFamiliesConverter.Required().For(PropertyNames.FontFamily))).Or(Converters.SystemFontConverter);

    internal CssFontProperty()
      : base(PropertyNames.Font, PropertyFlags.Inherited | PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssFontProperty.StyleConverter;

    private static void SetSystemFont(SystemFont font)
    {
      switch (font)
      {
      }
    }
  }
}
