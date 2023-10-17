// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.DictionaryValueConverter`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class DictionaryValueConverter<T> : IValueConverter
  {
    private readonly Dictionary<string, T> _values;

    public DictionaryValueConverter(Dictionary<string, T> values) => this._values = values;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      string identifier = value.ToIdentifier();
      T obj = default (T);
      return identifier == null || !this._values.TryGetValue(identifier, out obj) ? (IPropertyValue) null : (IPropertyValue) new DictionaryValueConverter<T>.EnumeratedValue(identifier, obj, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<DictionaryValueConverter<T>.EnumeratedValue>();

    private sealed class EnumeratedValue : IPropertyValue
    {
      private readonly string _identifier;
      private readonly T _value;
      private readonly CssValue _original;

      public EnumeratedValue(string identifier, T value, IEnumerable<CssToken> tokens)
      {
        this._identifier = identifier;
        this._value = value;
        this._original = new CssValue(tokens);
      }

      public string CssText => this._identifier;

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._original;
    }
  }
}
