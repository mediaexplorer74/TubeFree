// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssPageBreakInsideProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssPageBreakInsideProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.Assign<BreakMode>(Keywords.Auto, BreakMode.Auto).Or<BreakMode>(Keywords.Avoid, BreakMode.Avoid).OrDefault<BreakMode>(BreakMode.Auto);

    internal CssPageBreakInsideProperty()
      : base(PropertyNames.PageBreakInside)
    {
    }

    internal override IValueConverter Converter => CssPageBreakInsideProperty.StyleConverter;
  }
}
