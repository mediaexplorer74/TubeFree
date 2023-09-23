// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.LinearGradientConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class LinearGradientConverter : GradientConverter
  {
    private readonly IValueConverter _converter;

    public LinearGradientConverter(bool repeating)
      : base(repeating)
    {
      this._converter = Converters.AngleConverter.Or(Converters.SideOrCornerConverter.StartsWithKeyword(Keywords.To));
    }

    protected override IPropertyValue ConvertFirstArgument(IEnumerable<CssToken> value) => this._converter.Convert(value);
  }
}
