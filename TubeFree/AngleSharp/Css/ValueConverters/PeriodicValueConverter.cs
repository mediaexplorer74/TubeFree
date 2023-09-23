// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.PeriodicValueConverter
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
  internal sealed class PeriodicValueConverter : IValueConverter
  {
    private readonly IValueConverter _converter;
    private readonly string[] _labels;

    public PeriodicValueConverter(IValueConverter converter, string[] labels)
    {
      this._converter = converter;
      this._labels = labels.Length == 4 ? labels : Enumerable.Repeat<string>(string.Empty, 4).ToArray<string>();
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<CssToken> list = new List<CssToken>(value);
      IPropertyValue[] options = new IPropertyValue[4];
      if (list.Count == 0)
        return (IPropertyValue) null;
      for (int index = 0; index < options.Length && list.Count != 0; ++index)
      {
        options[index] = this._converter.VaryStart(list);
        if (options[index] == null)
          return (IPropertyValue) null;
      }
      return list.Count != 0 ? (IPropertyValue) null : (IPropertyValue) new PeriodicValueConverter.PeriodicValue(options, value, this._labels);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      if (properties.Length != 4)
        return (IPropertyValue) null;
      IPropertyValue[] options = new IPropertyValue[4]
      {
        this._converter.Construct(((IEnumerable<CssProperty>) properties).Where<CssProperty>((Func<CssProperty, bool>) (m => m.Name == this._labels[0])).ToArray<CssProperty>()),
        this._converter.Construct(((IEnumerable<CssProperty>) properties).Where<CssProperty>((Func<CssProperty, bool>) (m => m.Name == this._labels[1])).ToArray<CssProperty>()),
        this._converter.Construct(((IEnumerable<CssProperty>) properties).Where<CssProperty>((Func<CssProperty, bool>) (m => m.Name == this._labels[2])).ToArray<CssProperty>()),
        this._converter.Construct(((IEnumerable<CssProperty>) properties).Where<CssProperty>((Func<CssProperty, bool>) (m => m.Name == this._labels[3])).ToArray<CssProperty>())
      };
      return options[0] == null || options[1] == null || options[2] == null || options[3] == null ? (IPropertyValue) null : (IPropertyValue) new PeriodicValueConverter.PeriodicValue(options, Enumerable.Empty<CssToken>(), this._labels);
    }

    private sealed class PeriodicValue : IPropertyValue
    {
      private readonly IPropertyValue _top;
      private readonly IPropertyValue _right;
      private readonly IPropertyValue _bottom;
      private readonly IPropertyValue _left;
      private readonly CssValue _original;
      private readonly string[] _labels;

      public PeriodicValue(IPropertyValue[] options, IEnumerable<CssToken> tokens, string[] labels)
      {
        this._top = options[0];
        this._right = options[1] ?? this._top;
        this._bottom = options[2] ?? this._top;
        this._left = options[3] ?? this._right;
        this._original = new CssValue(tokens);
        this._labels = labels;
      }

      public string[] Values
      {
        get
        {
          string cssText1 = this._top.CssText;
          string cssText2 = this._right.CssText;
          string cssText3 = this._bottom.CssText;
          string cssText4 = this._left.CssText;
          return cssText2.Is(cssText4) ? (cssText1.Is(cssText3) ? (cssText2.Is(cssText1) ? new string[1]
          {
            cssText1
          } : new string[2]{ cssText1, cssText2 }) : new string[3]
          {
            cssText1,
            cssText2,
            cssText3
          }) : new string[4]
          {
            cssText1,
            cssText2,
            cssText3,
            cssText4
          };
        }
      }

      public string CssText => string.Join(" ", this.Values);

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name)
      {
        if (name.Is(this._labels[0]))
          return this._top.Original;
        if (name.Is(this._labels[1]))
          return this._right.Original;
        if (name.Is(this._labels[2]))
          return this._bottom.Original;
        return name.Is(this._labels[3]) ? this._left.Original : (CssValue) null;
      }
    }
  }
}
