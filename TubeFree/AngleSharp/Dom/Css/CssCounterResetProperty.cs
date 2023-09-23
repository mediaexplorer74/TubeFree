// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssCounterResetProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssCounterResetProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.Continuous(Converters.WithOrder(Converters.IdentifierConverter.Required(), Converters.IntegerConverter.Option<int>(0))).OrDefault();

    internal CssCounterResetProperty()
      : base(PropertyNames.CounterReset)
    {
    }

    internal override IValueConverter Converter => CssCounterResetProperty.StyleConverter;
  }
}
