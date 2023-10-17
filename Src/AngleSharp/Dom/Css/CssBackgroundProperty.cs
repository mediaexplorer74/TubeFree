// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBackgroundProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBackgroundProperty : CssShorthandProperty
  {
    private static readonly IValueConverter NormalLayerConverter = Converters.WithAny(Converters.OptionalImageSourceConverter.Option().For(PropertyNames.BackgroundImage), Converters.WithOrder(Converters.PointConverter.Option().For(PropertyNames.BackgroundPosition), Converters.BackgroundSizeConverter.StartsWithDelimiter().Option().For(PropertyNames.BackgroundSize)), Converters.BackgroundRepeatsConverter.Option().For(PropertyNames.BackgroundRepeat), Converters.BackgroundAttachmentConverter.Option().For(PropertyNames.BackgroundAttachment), Converters.BoxModelConverter.Option().For(PropertyNames.BackgroundOrigin), Converters.BoxModelConverter.Option().For(PropertyNames.BackgroundClip));
    private static readonly IValueConverter FinalLayerConverter = Converters.WithAny(Converters.OptionalImageSourceConverter.Option().For(PropertyNames.BackgroundImage), Converters.WithOrder(Converters.PointConverter.Option().For(PropertyNames.BackgroundPosition), Converters.BackgroundSizeConverter.StartsWithDelimiter().Option().For(PropertyNames.BackgroundSize)), Converters.BackgroundRepeatsConverter.Option().For(PropertyNames.BackgroundRepeat), Converters.BackgroundAttachmentConverter.Option().For(PropertyNames.BackgroundAttachment), Converters.BoxModelConverter.Option().For(PropertyNames.BackgroundOrigin), Converters.BoxModelConverter.Option().For(PropertyNames.BackgroundClip), Converters.CurrentColorConverter.Option().For(PropertyNames.BackgroundColor));
    private static readonly IValueConverter StyleConverter = CssBackgroundProperty.NormalLayerConverter.RequiresEnd(CssBackgroundProperty.FinalLayerConverter).OrDefault();

    internal CssBackgroundProperty()
      : base(PropertyNames.Background, PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssBackgroundProperty.StyleConverter;
  }
}
