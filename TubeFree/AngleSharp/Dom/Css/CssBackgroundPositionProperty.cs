// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBackgroundPositionProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBackgroundPositionProperty : CssProperty
  {
    private static readonly IValueConverter ListConverter = Converters.PointConverter.FromList().OrDefault<Point>(Point.Center);

    internal CssBackgroundPositionProperty()
      : base(PropertyNames.BackgroundPosition, PropertyFlags.Animatable)
    {
    }

    internal override IValueConverter Converter => CssBackgroundPositionProperty.ListConverter;
  }
}
