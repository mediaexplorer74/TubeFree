// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssBorderImageSliceProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssBorderImageSliceProperty : CssProperty
  {
    internal static readonly IValueConverter TheConverter = Converters.WithAny(Converters.BorderSliceConverter.Option<Length>(new Length(100f, Length.Unit.Percent)), Converters.BorderSliceConverter.Option(), Converters.BorderSliceConverter.Option(), Converters.BorderSliceConverter.Option(), Converters.Assign<bool>(Keywords.Fill, true).Option<bool>(false));
    private static readonly IValueConverter StyleConverter = CssBorderImageSliceProperty.TheConverter.OrDefault<Length>(Length.Full);

    internal CssBorderImageSliceProperty()
      : base(PropertyNames.BorderImageSlice)
    {
    }

    internal override IValueConverter Converter => CssBorderImageSliceProperty.StyleConverter;
  }
}
