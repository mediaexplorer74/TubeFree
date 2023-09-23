// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.FunctionValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class FunctionValueConverter : IValueConverter
  {
    private readonly string _name;
    private readonly IValueConverter _arguments;

    public FunctionValueConverter(string name, IValueConverter arguments)
    {
      this._name = name;
      this._arguments = arguments;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      CssFunctionToken function = value.OnlyOrDefault() as CssFunctionToken;
      if (!this.Check(function))
        return (IPropertyValue) null;
      IPropertyValue arguments = this._arguments.Convert(function.ArgumentTokens);
      return arguments == null ? (IPropertyValue) null : (IPropertyValue) new FunctionValueConverter.FunctionValue(this._name, arguments, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<FunctionValueConverter.FunctionValue>();

    private bool Check(CssFunctionToken function) => function != null && function.Data.Equals(this._name, StringComparison.OrdinalIgnoreCase);

    private sealed class FunctionValue : IPropertyValue
    {
      private readonly string _name;
      private readonly IPropertyValue _arguments;
      private readonly CssValue _value;

      public FunctionValue(string name, IPropertyValue arguments, IEnumerable<CssToken> tokens)
      {
        this._name = name;
        this._arguments = arguments;
        this._value = new CssValue(tokens);
      }

      public string CssText => this._name.CssFunction(this._arguments.CssText);

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name) => this._value;
    }
  }
}
