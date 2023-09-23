// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssFloatProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssFloatProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.FloatingConverter.OrDefault<Floating>(Floating.None);

    internal CssFloatProperty()
      : base(PropertyNames.Float)
    {
    }

    internal override IValueConverter Converter => CssFloatProperty.StyleConverter;
  }
}
