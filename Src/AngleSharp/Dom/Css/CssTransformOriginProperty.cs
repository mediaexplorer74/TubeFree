// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssTransformOriginProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssTransformOriginProperty : CssProperty
  {
    private static IValueConverter StyleConverter = Converters.WithOrder(Converters.LengthOrPercentConverter.Or<Point>(Keywords.Center, Point.Center).Or(Converters.WithAny(Converters.LengthOrPercentConverter.Or<Length>(Keywords.Left, Length.Zero).Or<Length>(Keywords.Right, Length.Full).Or<Length>(Keywords.Center, Length.Half).Option<Length>(Length.Half), Converters.LengthOrPercentConverter.Or<Length>(Keywords.Top, Length.Zero).Or<Length>(Keywords.Bottom, Length.Full).Or<Length>(Keywords.Center, Length.Half).Option<Length>(Length.Half))).Or(Converters.WithAny(Converters.LengthOrPercentConverter.Or<Length>(Keywords.Top, Length.Zero).Or<Length>(Keywords.Bottom, Length.Full).Or<Length>(Keywords.Center, Length.Half).Option<Length>(Length.Half), Converters.LengthOrPercentConverter.Or<Length>(Keywords.Left, Length.Zero).Or<Length>(Keywords.Right, Length.Full).Or<Length>(Keywords.Center, Length.Half).Option<Length>(Length.Half))).Required(), Converters.LengthConverter.Option<Length>(Length.Zero)).OrDefault<Point>(Point.Center);

    internal CssTransformOriginProperty()
      : base(PropertyNames.TransformOrigin, PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssTransformOriginProperty.StyleConverter;
  }
}
