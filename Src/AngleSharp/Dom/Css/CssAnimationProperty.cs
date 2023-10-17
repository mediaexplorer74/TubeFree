// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssAnimationProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssAnimationProperty : CssShorthandProperty
  {
    private static readonly IValueConverter ListConverter = Converters.WithAny(Converters.TimeConverter.Option().For(PropertyNames.AnimationDuration), Converters.TransitionConverter.Option().For(PropertyNames.AnimationTimingFunction), Converters.TimeConverter.Option().For(PropertyNames.AnimationDelay), Converters.PositiveOrInfiniteNumberConverter.Option().For(PropertyNames.AnimationIterationCount), Converters.AnimationDirectionConverter.Option().For(PropertyNames.AnimationDirection), Converters.AnimationFillStyleConverter.Option().For(PropertyNames.AnimationFillMode), Converters.PlayStateConverter.Option().For(PropertyNames.AnimationPlayState), Converters.IdentifierConverter.Option().For(PropertyNames.AnimationName)).FromList().OrDefault();

    internal CssAnimationProperty()
      : base(PropertyNames.Animation)
    {
    }

    internal override IValueConverter Converter => CssAnimationProperty.ListConverter;
  }
}
