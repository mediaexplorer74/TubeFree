// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.OneOrMoreValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class OneOrMoreValueConverter : IValueConverter
  {
    private readonly IValueConverter _converter;
    private readonly int _minimum;
    private readonly int _maximum;

    public OneOrMoreValueConverter(IValueConverter converter, int minimum, int maximum)
    {
      this._converter = converter;
      this._minimum = minimum;
      this._maximum = maximum;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<List<CssToken>> items = value.ToItems();
      int count = items.Count;
      if (count < this._minimum || count > this._maximum)
        return (IPropertyValue) null;
      IPropertyValue[] values = new IPropertyValue[items.Count];
      for (int index = 0; index < count; ++index)
      {
        values[index] = this._converter.Convert((IEnumerable<CssToken>) items[index]);
        if (values[index] == null)
          return (IPropertyValue) null;
      }
      return (IPropertyValue) new OneOrMoreValueConverter.MultipleValue(values, value);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      IPropertyValue propertyValue1 = properties.Guard<OneOrMoreValueConverter.MultipleValue>();
      if (propertyValue1 == null)
      {
        IPropertyValue[] values = new IPropertyValue[properties.Length];
        for (int index = 0; index < properties.Length; ++index)
        {
          IPropertyValue propertyValue2 = this._converter.Construct(new CssProperty[1]
          {
            properties[index]
          });
          if (propertyValue2 == null)
            return (IPropertyValue) null;
          values[index] = propertyValue2;
        }
        propertyValue1 = (IPropertyValue) new OneOrMoreValueConverter.MultipleValue(values, Enumerable.Empty<CssToken>());
      }
      return propertyValue1;
    }

    private sealed class MultipleValue : IPropertyValue
    {
      private readonly IPropertyValue[] _values;
      private readonly CssValue _value;

      public MultipleValue(IPropertyValue[] values, IEnumerable<CssToken> tokens)
      {
        this._values = values;
        this._value = new CssValue(tokens);
      }

      public string CssText => string.Join(" ", ((IEnumerable<IPropertyValue>) this._values).Where<IPropertyValue>((Func<IPropertyValue, bool>) (m => !string.IsNullOrEmpty(m.CssText))).Select<IPropertyValue, string>((Func<IPropertyValue, string>) (m => m.CssText)));

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name)
      {
        List<CssToken> tokens = new List<CssToken>();
        foreach (IPropertyValue propertyValue in this._values)
        {
          CssValue collection = propertyValue.ExtractFor(name);
          if (collection != null)
          {
            if (tokens.Count > 0)
              tokens.Add(CssToken.Whitespace);
            tokens.AddRange((IEnumerable<CssToken>) collection);
          }
        }
        return new CssValue((IEnumerable<CssToken>) tokens);
      }
    }
  }
}
