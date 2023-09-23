// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.StringsValueConverter
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
  internal sealed class StringsValueConverter : IValueConverter
  {
    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<List<CssToken>> items = value.ToItems();
      int count = items.Count;
      if (count % 2 != 0)
        return (IPropertyValue) null;
      string[] values = new string[items.Count];
      for (int index = 0; index < count; ++index)
      {
        values[index] = items[index].ToCssString();
        if (values[index] == null)
          return (IPropertyValue) null;
      }
      return (IPropertyValue) new StringsValueConverter.StringsValue(values, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<StringsValueConverter.StringsValue>();

    private sealed class StringsValue : IPropertyValue
    {
      private readonly string[] _values;
      private readonly CssValue _original;

      public StringsValue(string[] values, IEnumerable<CssToken> tokens)
      {
        this._values = values;
        this._original = new CssValue(tokens);
      }

      public string CssText => string.Join(" ", ((IEnumerable<string>) this._values).Select<string, string>((Func<string, string>) (m => m.CssString())));

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._original;
    }
  }
}
