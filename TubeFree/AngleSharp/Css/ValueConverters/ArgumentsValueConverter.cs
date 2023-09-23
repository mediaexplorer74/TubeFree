// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.ArgumentsValueConverter
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
  internal sealed class ArgumentsValueConverter : IValueConverter
  {
    private readonly IValueConverter[] _converters;

    public ArgumentsValueConverter(params IValueConverter[] converters) => this._converters = converters;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<List<CssToken>> list = value.ToList();
      int length = this._converters.Length;
      if (list.Count > length)
        return (IPropertyValue) null;
      IPropertyValue[] arguments = new IPropertyValue[length];
      for (int index = 0; index < length; ++index)
      {
        IEnumerable<CssToken> cssTokens = index < list.Count ? (IEnumerable<CssToken>) list[index] : Enumerable.Empty<CssToken>();
        arguments[index] = this._converters[index].Convert(cssTokens);
        if (arguments[index] == null)
          return (IPropertyValue) null;
      }
      return (IPropertyValue) new ArgumentsValueConverter.ArgumentsValue(arguments, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<ArgumentsValueConverter.ArgumentsValue>();

    private sealed class ArgumentsValue : IPropertyValue
    {
      private readonly IPropertyValue[] _arguments;
      private readonly CssValue _value;

      public ArgumentsValue(IPropertyValue[] arguments, IEnumerable<CssToken> tokens)
      {
        this._arguments = arguments;
        this._value = new CssValue(tokens);
      }

      public string CssText => string.Join(", ", ((IEnumerable<IPropertyValue>) this._arguments).Where<IPropertyValue>((Func<IPropertyValue, bool>) (m => !string.IsNullOrEmpty(m.CssText))).Select<IPropertyValue, string>((Func<IPropertyValue, string>) (m => m.CssText)));

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name) => this._value;
    }
  }
}
