// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssMarginLeftProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssMarginLeftProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.AutoLengthOrPercentConverter.OrDefault<Length>(Length.Zero);

    internal CssMarginLeftProperty()
      : base(PropertyNames.MarginLeft, PropertyFlags.Unitless | PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssMarginLeftProperty.StyleConverter;
  }
}
