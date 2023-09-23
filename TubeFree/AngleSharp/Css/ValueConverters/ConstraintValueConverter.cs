// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.ConstraintValueConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.ValueConverters
{
  internal sealed class ConstraintValueConverter : IValueConverter
  {
    private readonly IValueConverter _converter;
    private readonly string[] _labels;

    public ConstraintValueConverter(IValueConverter converter, string[] labels)
    {
      this._converter = converter;
      this._labels = labels;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      IPropertyValue propertyValue = this._converter.Convert(value);
      return propertyValue == null ? (IPropertyValue) null : (IPropertyValue) new ConstraintValueConverter.TransformationValueConverter(propertyValue, this._labels);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      IEnumerable<CssProperty> source = ((IEnumerable<CssProperty>) properties).Where<CssProperty>((Func<CssProperty, bool>) (m => ((IEnumerable<string>) this._labels).Contains<string>(m.Name)));
      string str1 = (string) null;
      foreach (CssProperty cssProperty in source)
      {
        string str2 = cssProperty.Value;
        if (str1 != null && str2 != str1)
          return (IPropertyValue) null;
        str1 = str2;
      }
      IPropertyValue propertyValue = this._converter.Construct(source.Take<CssProperty>(1).ToArray<CssProperty>());
      return propertyValue == null ? (IPropertyValue) null : (IPropertyValue) new ConstraintValueConverter.TransformationValueConverter(propertyValue, this._labels);
    }

    private sealed class TransformationValueConverter : IPropertyValue
    {
      private readonly IPropertyValue _value;
      private readonly string[] _labels;

      public TransformationValueConverter(IPropertyValue value, string[] labels)
      {
        this._value = value;
        this._labels = labels;
      }

      public string CssText => this._value.CssText;

      public CssValue Original => this._value.Original;

      public CssValue ExtractFor(string name) => !((IEnumerable<string>) this._labels).Contains<string>(name) ? (CssValue) null : this._value.ExtractFor(name);
    }
  }
}
