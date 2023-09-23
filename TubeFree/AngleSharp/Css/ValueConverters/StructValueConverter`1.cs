// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.StructValueConverter`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class StructValueConverter<T> : IValueConverter where T : struct, IFormattable
  {
    private readonly Func<IEnumerable<CssToken>, T?> _converter;

    public StructValueConverter(Func<IEnumerable<CssToken>, T?> converter) => this._converter = converter;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      T? nullable = this._converter(value);
      return !nullable.HasValue ? (IPropertyValue) null : (IPropertyValue) new StructValueConverter<T>.StructValue(nullable.Value, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<StructValueConverter<T>.StructValue>();

    private sealed class StructValue : IPropertyValue
    {
      private readonly T _value;
      private readonly CssValue _original;

      public StructValue(T value, IEnumerable<CssToken> tokens)
      {
        this._value = value;
        this._original = new CssValue(tokens);
      }

      public string CssText => this._value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._original;
    }
  }
}
