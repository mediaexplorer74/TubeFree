// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssTransitionProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssTransitionProperty : CssShorthandProperty
  {
    internal static readonly IValueConverter ListConverter = Converters.WithAny(Converters.AnimatableConverter.Option().For(PropertyNames.TransitionProperty), Converters.TimeConverter.Option().For(PropertyNames.TransitionDuration), Converters.TransitionConverter.Option().For(PropertyNames.TransitionTimingFunction), Converters.TimeConverter.Option().For(PropertyNames.TransitionDelay)).FromList().OrDefault();

    internal CssTransitionProperty()
      : base(PropertyNames.Transition)
    {
    }

    internal override IValueConverter Converter => CssTransitionProperty.ListConverter;
  }
}
