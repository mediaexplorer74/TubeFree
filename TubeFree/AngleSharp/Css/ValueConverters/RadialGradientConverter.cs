// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.RadialGradientConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css.Values;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class RadialGradientConverter : GradientConverter
  {
    private readonly IValueConverter _converter;

    public RadialGradientConverter(bool repeating)
      : base(repeating)
    {
      IValueConverter valueConverter = Converters.PointConverter.StartsWithKeyword(Keywords.At).Option<Point>(Point.Center);
      this._converter = Converters.WithOrder(Converters.WithAny(Converters.Assign<bool>(Keywords.Circle, true).Option<bool>(true), Converters.LengthConverter.Option()), valueConverter).Or(Converters.WithOrder(Converters.WithAny(Converters.Assign<bool>(Keywords.Ellipse, false).Option<bool>(false), Converters.LengthOrPercentConverter.Many(2, 2).Option()), valueConverter).Or(Converters.WithOrder(Converters.WithAny(Converters.Toggle(Keywords.Circle, Keywords.Ellipse).Option<bool>(false), Map.RadialGradientSizeModes.ToConverter<RadialGradient.SizeMode>()), valueConverter)));
    }

    protected override IPropertyValue ConvertFirstArgument(IEnumerable<CssToken> value) => this._converter.Convert(value);
  }
}
