// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.StringValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class StringValueConverter : IValueConverter
  {
    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      string cssString = value.ToCssString();
      return cssString == null ? (IPropertyValue) null : (IPropertyValue) new StringValueConverter.StringValue(cssString, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<StringValueConverter.StringValue>();

    private sealed class StringValue : IPropertyValue
    {
      private readonly string _value;
      private readonly CssValue _original;

      public StringValue(string value, IEnumerable<CssToken> tokens)
      {
        this._value = value;
        this._original = new CssValue(tokens);
      }

      public string CssText => this._value.CssString();

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._original;
    }
  }
}
