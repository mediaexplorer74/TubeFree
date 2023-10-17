// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.EndListValueConverter
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
  internal sealed class EndListValueConverter : IValueConverter
  {
    private readonly IValueConverter _listConverter;
    private readonly IValueConverter _endConverter;

    public EndListValueConverter(IValueConverter listConverter, IValueConverter endConverter)
    {
      this._listConverter = listConverter;
      this._endConverter = endConverter;
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<List<CssToken>> list = value.ToList();
      int index1 = list.Count - 1;
      IPropertyValue[] values = new IPropertyValue[index1 + 1];
      for (int index2 = 0; index2 < index1; ++index2)
      {
        values[index2] = this._listConverter.Convert((IEnumerable<CssToken>) list[index2]);
        if (values[index2] == null)
          return (IPropertyValue) null;
      }
      values[index1] = this._endConverter.Convert((IEnumerable<CssToken>) list[index1]);
      return values[index1] == null ? (IPropertyValue) null : (IPropertyValue) new EndListValueConverter.ListValue(values, value);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      List<List<CssToken>>[] cssTokenListListArray = new List<List<CssToken>>[properties.Length];
      CssProperty[] properties1 = new CssProperty[properties.Length];
      int val1 = 0;
      for (int index = 0; index < properties.Length; ++index)
      {
        IPropertyValue declaredValue = properties[index].DeclaredValue;
        cssTokenListListArray[index] = declaredValue != null ? declaredValue.Original.ToList() : new List<List<CssToken>>();
        properties1[index] = Factory.Properties.CreateLonghand(properties[index].Name);
        val1 = Math.Max(val1, cssTokenListListArray[index].Count);
      }
      IPropertyValue[] values = new IPropertyValue[val1];
      for (int index1 = 0; index1 < val1; ++index1)
      {
        for (int index2 = 0; index2 < properties1.Length; ++index2)
        {
          List<List<CssToken>> cssTokenListList = cssTokenListListArray[index2];
          IEnumerable<CssToken> tokens = cssTokenListList.Count > index1 ? (IEnumerable<CssToken>) cssTokenListList[index1] : Enumerable.Empty<CssToken>();
          properties1[index2].TrySetValue(new CssValue(tokens));
        }
        IValueConverter valueConverter = index1 < val1 - 1 ? this._listConverter : this._endConverter;
        values[index1] = valueConverter.Construct(properties1);
      }
      return (IPropertyValue) new EndListValueConverter.ListValue(values, Enumerable.Empty<CssToken>());
    }

    private sealed class ListValue : IPropertyValue
    {
      private readonly IPropertyValue[] _values;
      private readonly CssValue _value;

      public ListValue(IPropertyValue[] values, IEnumerable<CssToken> tokens)
      {
        this._values = values;
        this._value = new CssValue(tokens);
      }

      public string CssText => string.Join(", ", ((IEnumerable<IPropertyValue>) this._values).Select<IPropertyValue, string>((Func<IPropertyValue, string>) (m => m.CssText)));

      public CssValue Original => this._value;

      public CssValue ExtractFor(string name)
      {
        List<CssToken> tokens = new List<CssToken>();
        foreach (IPropertyValue propertyValue in this._values)
        {
          CssValue collection = propertyValue.ExtractFor(name);
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
