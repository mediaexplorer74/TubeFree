// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.ContinuousValueConverter
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
  internal sealed class ContinuousValueConverter : IValueConverter
  {
    private readonly IValueConverter _converter;

    public ContinuousValueConverter(IValueConverter converter) => this._converter = converter;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<CssToken> list = new List<CssToken>(value);
      List<IPropertyValue> propertyValueList = new List<IPropertyValue>();
      if (list.Count <= 0)
        return (IPropertyValue) null;
      while (list.Count != 0)
      {
        IPropertyValue propertyValue = this._converter.VaryStart(list);
        if (propertyValue == null)
          return (IPropertyValue) null;
        propertyValueList.Add(propertyValue);
      }
      return (IPropertyValue) new ContinuousValueConverter.OptionsValue(propertyValueList.ToArray(), value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<ContinuousValueConverter.OptionsValue>();

    private sealed class OptionsValue : IPropertyValue
    {
      private readonly IPropertyValue[] _options;
      private readonly CssValue _value;

      public OptionsValue(IPropertyValue[] options, IEnumerable<CssToken> tokens)
      {
        this._options = options;
        this._value = new CssValue(tokens);
      }

      public string CssText => string.Join(" ", ((IEnumerable<IPropertyValue>) this._options).Where<IPropertyValue>((Func<IPropertyValue, bool>) (m => !string.IsNullOrEmpty(m.CssText))).Select<IPropertyValue, string>((Func<IPropertyValue, string>) (m => m.CssText)));

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name)
      {
        List<CssToken> tokens = new List<CssToken>();
        foreach (IPropertyValue option in this._options)
        {
          CssValue collection = option.ExtractFor(name);
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
