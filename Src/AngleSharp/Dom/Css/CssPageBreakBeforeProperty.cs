// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssPageBreakBeforeProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssPageBreakBeforeProperty : CssProperty
  {
    private static readonly IValueConverter StyleConverter = Converters.PageBreakModeConverter.OrDefault<BreakMode>(BreakMode.Auto);

    internal CssPageBreakBeforeProperty()
      : base(PropertyNames.PageBreakBefore)
    {
    }

    internal override IValueConverter Converter => CssPageBreakBeforeProperty.StyleConverter;
  }
}
