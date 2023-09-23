// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssPerspectiveOriginProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssPerspectiveOriginProperty : CssProperty
  {
    private static readonly IValueConverter PerspectiveConverter = Converters.LengthOrPercentConverter.Or<Point>(Keywords.Left, new Point(Length.Zero, Length.Half)).Or<Point>(Keywords.Center, new Point(Length.Half, Length.Half)).Or<Point>(Keywords.Right, new Point(Length.Full, Length.Half)).Or<Point>(Keywords.Top, new Point(Length.Half, Length.Zero)).Or<Point>(Keywords.Bottom, new Point(Length.Half, Length.Full)).Or(Converters.WithAny(Converters.LengthOrPercentConverter.Or<Length>(Keywords.Left, Length.Zero).Or<Length>(Keywords.Right, Length.Full).Or<Length>(Keywords.Center, Length.Half).Option<Length>(Length.Half), Converters.LengthOrPercentConverter.Or<Length>(Keywords.Top, Length.Zero).Or<Length>(Keywords.Bottom, Length.Full).Or<Length>(Keywords.Center, Length.Half).Option<Length>(Length.Half))).OrDefault<Point>(Point.Center);

    internal CssPerspectiveOriginProperty()
      : base(PropertyNames.PerspectiveOrigin, PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssPerspectiveOriginProperty.PerspectiveConverter;
  }
}
