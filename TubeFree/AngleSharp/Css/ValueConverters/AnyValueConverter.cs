// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.AnyValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class AnyValueConverter : IValueConverter
  {
    public IPropertyValue Convert(IEnumerable<CssToken> value) => (IPropertyValue) new AnyValueConverter.AnyValue(value);

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<AnyValueConverter.AnyValue>();

    private sealed class AnyValue : IPropertyValue
    {
      private readonly CssValue _value;

      public AnyValue(IEnumerable<CssToken> tokens) => this._value = new CssValue(tokens);

      public string CssText => this._value.ToText();

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name) => this._value;
    }
  }
}
