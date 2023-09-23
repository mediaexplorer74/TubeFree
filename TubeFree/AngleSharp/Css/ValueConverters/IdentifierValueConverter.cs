// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.IdentifierValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class IdentifierValueConverter : IValueConverter
  {
    private readonly Func<IEnumerable<CssToken>, string> _converter;

    public IdentifierValueConverter(Func<IEnumerable<CssToken>, string> converter) => this._converter = converter;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      string identifier = this._converter(value);
      return identifier == null ? (IPropertyValue) null : (IPropertyValue) new IdentifierValueConverter.IdentifierValue(identifier, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<IdentifierValueConverter.IdentifierValue>();

    private sealed class IdentifierValue : IPropertyValue
    {
      private readonly string _identifier;
      private readonly CssValue _value;

      public IdentifierValue(string identifier, IEnumerable<CssToken> tokens)
      {
        this._identifier = identifier;
        this._value = new CssValue(tokens);
      }

      public string CssText => this._identifier;

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name) => this._value;
    }
  }
}
