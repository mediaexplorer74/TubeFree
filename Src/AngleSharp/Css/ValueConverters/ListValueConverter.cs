// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.ListValueConverter
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
  internal sealed class ListValueConverter : IValueConverter
  {
    private readonly IValueConverter _converter;

    public ListValueConverter(IValueConverter converter) => this._converter = converter;

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<List<CssToken>> list = value.ToList();
      IPropertyValue[] values = new IPropertyValue[list.Count];
      for (int index = 0; index < list.Count; ++index)
      {
        values[index] = this._converter.Convert((IEnumerable<CssToken>) list[index]);
        if (values[index] == null)
          return (IPropertyValue) null;
      }
      return values.Length == 1 ? values[0] : (IPropertyValue) new ListValueConverter.ListValue(values, value);
    }

    public IPropertyValue Construct(CssProperty[] properties)
    {
      IPropertyValue propertyValue = properties.Guard<ListValueConverter.ListValue>();
      if (propertyValue == null)
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
          values[index1] = this._converter.Construct(properties1);
        }
        propertyValue = (IPropertyValue) new ListValueConverter.ListValue(values, Enumerable.Empty<CssToken>());
      }
      return propertyValue;
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
              tokens.Add(CssToken.Comma);
            tokens.AddRange((IEnumerable<CssToken>) collection);
          }
        }
        return new CssValue((IEnumerable<CssToken>) tokens);
      }
    }
  }
}
