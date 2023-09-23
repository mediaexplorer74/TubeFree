// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.OptionValueConverter`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class OptionValueConverter<T> : IValueConverter
  {
    private readonly IValueConverter _converter;
    private readonly T _defaultValue;

    public OptionValueConverter(IValueConverter converter, T defaultValue)
    {
      this._converter = converter;
      this._defaultValue = defaultValue;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value) => !value.Any<CssToken>() ? (IPropertyValue) new OptionValueConverter<T>.OptionValue(this._defaultValue, value) : this._converter.Convert(value);

    public IPropertyValue Construct(CssProperty[] properties) => this._converter.Construct(properties) ?? (IPropertyValue) new OptionValueConverter<T>.OptionValue(this._defaultValue, Enumerable.Empty<CssToken>());

    private sealed class OptionValue : IPropertyValue
    {
      private readonly T _value;
      private readonly CssValue _original;

      public OptionValue(T value, IEnumerable<CssToken> tokens)
      {
        this._value = value;
        this._original = new CssValue(tokens);
      }

      public string CssText => string.Empty;

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => (CssValue) null;
    }
  }
}
