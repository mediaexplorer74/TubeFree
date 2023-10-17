// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.UnorderedOptionsConverter
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
  internal sealed class UnorderedOptionsConverter : IValueConverter
  {
    private readonly IValueConverter[] _converters;

    public UnorderedOptionsConverter(params IValueConverter[] converters) => this._converters = converters;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<CssToken> list = new List<CssToken>(value);
      IPropertyValue[] options = new IPropertyValue[this._converters.Length];
      for (int index = 0; index < this._converters.Length; ++index)
      {
        options[index] = this._converters[index].VaryAll(list);
        if (options[index] == null)
          return (IPropertyValue) null;
      }
      return list.Count != 0 ? (IPropertyValue) null : (IPropertyValue) new UnorderedOptionsConverter.OptionsValue(options, value);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      IPropertyValue propertyValue1 = properties.Guard<UnorderedOptionsConverter.OptionsValue>();
      if (propertyValue1 == null)
      {
        IPropertyValue[] options = new IPropertyValue[this._converters.Length];
        for (int index = 0; index < this._converters.Length; ++index)
        {
          IPropertyValue propertyValue2 = this._converters[index].Construct(properties);
          if (propertyValue2 == null)
            return (IPropertyValue) null;
          options[index] = propertyValue2;
        }
        propertyValue1 = (IPropertyValue) new UnorderedOptionsConverter.OptionsValue(options, Enumerable.Empty<CssToken>());
      }
      return propertyValue1;
    }

    private sealed class OptionsValue : IPropertyValue
    {
      private readonly IPropertyValue[] _options;
      private readonly CssValue _original;

      public OptionsValue(IPropertyValue[] options, IEnumerable<CssToken> tokens)
      {
        this._options = options;
        this._original = new CssValue(tokens);
      }

      public string CssText => string.Join(" ", ((IEnumerable<IPropertyValue>) this._options).Where<IPropertyValue>((Func<IPropertyValue, bool>) (m => !string.IsNullOrEmpty(m.CssText))).Select<IPropertyValue, string>((Func<IPropertyValue, string>) (m => m.CssText)));

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name)
      {
        List<CssToken> tokens = new List<CssToken>();
        foreach (IPropertyValue option in this._options)
        {
          CssValue collection = option.ExtractFor(name);
          if (collection != null && collection.Count > 0)
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
