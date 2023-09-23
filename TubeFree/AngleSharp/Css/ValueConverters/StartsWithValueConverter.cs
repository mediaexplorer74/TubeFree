// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.StartsWithValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class StartsWithValueConverter : IValueConverter
  {
    private readonly CssTokenType _type;
    private readonly string _data;
    private readonly IValueConverter _converter;

    public StartsWithValueConverter(CssTokenType type, string data, IValueConverter converter)
    {
      this._type = type;
      this._data = data;
      this._converter = converter;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<CssToken> cssTokenList = this.Transform(value);
      return cssTokenList == null ? (IPropertyValue) null : this.CreateFrom(this._converter.Convert((IEnumerable<CssToken>) cssTokenList), value);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      IPropertyValue propertyValue = this._converter.Construct(properties);
      return propertyValue == null ? (IPropertyValue) null : this.CreateFrom(propertyValue, Enumerable.Empty<CssToken>());
    }

    private IPropertyValue CreateFrom(IPropertyValue value, IEnumerable<CssToken> tokens) => value == null ? (IPropertyValue) null : (IPropertyValue) new StartsWithValueConverter.StartValue(this._data, value, tokens);

    private List<CssToken> Transform(IEnumerable<CssToken> values)
    {
      IEnumerator<CssToken> enumerator = values.GetEnumerator();
      do
        ;
      while (enumerator.MoveNext() && enumerator.Current.Type == CssTokenType.Whitespace);
      if (enumerator.Current.Type != this._type || !enumerator.Current.Data.Isi(this._data))
        return (List<CssToken>) null;
      List<CssToken> cssTokenList = new List<CssToken>();
      while (enumerator.MoveNext())
      {
        if (enumerator.Current.Type != CssTokenType.Whitespace || cssTokenList.Count != 0)
          cssTokenList.Add(enumerator.Current);
      }
      return cssTokenList;
    }

    private sealed class StartValue : IPropertyValue
    {
      private readonly string _start;
      private readonly IPropertyValue _value;
      private readonly CssValue _original;

      public StartValue(string start, IPropertyValue value, IEnumerable<CssToken> tokens)
      {
        this._start = start;
        this._value = value;
        this._original = new CssValue(tokens);
      }

      public string CssText => this._start + " " + this._value.CssText;

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._value.ExtractFor(name);
    }
  }
}
