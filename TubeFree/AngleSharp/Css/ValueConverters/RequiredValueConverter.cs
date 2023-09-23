// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.RequiredValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class RequiredValueConverter : IValueConverter
  {
    private readonly IValueConverter _converter;

    public RequiredValueConverter(IValueConverter converter) => this._converter = converter;

    public IPropertyValue Convert(IEnumerable<CssToken> value) => !value.Any<CssToken>() ? (IPropertyValue) null : this._converter.Convert(value);

    public IPropertyValue Construct(CssProperty[] properties) => this._converter.Construct(properties);
  }
}
