// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBorderImageProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBorderImageProperty : CssShorthandProperty
  {
    private static readonly IValueConverter ImageConverter = Converters.WithAny(Converters.OptionalImageSourceConverter.Option().For(PropertyNames.BorderImageSource), Converters.WithOrder(CssBorderImageSliceProperty.TheConverter.Option().For(PropertyNames.BorderImageSlice), CssBorderImageWidthProperty.TheConverter.StartsWithDelimiter().Option().For(PropertyNames.BorderImageWidth), CssBorderImageOutsetProperty.TheConverter.StartsWithDelimiter().Option().For(PropertyNames.BorderImageOutset)), CssBorderImageRepeatProperty.TheConverter.Option().For(PropertyNames.BorderImageRepeat)).OrDefault();

    internal CssBorderImageProperty()
      : base(PropertyNames.BorderImage)
    {
    }

    internal override IValueConverter Converter => CssBorderImageProperty.ImageConverter;
  }
}
