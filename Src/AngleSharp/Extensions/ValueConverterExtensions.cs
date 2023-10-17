// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ValueConverterExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.ValueConverters;
using AngleSharp.Css.Values;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  internal static class ValueConverterExtensions
  {
    public static IPropertyValue ConvertDefault(this IValueConverter converter) => converter.Convert(Enumerable.Empty<CssToken>());

    public static bool HasDefault(this IValueConverter converter) => converter.ConvertDefault() != null;

    public static IPropertyValue VaryStart(this IValueConverter converter, List<CssToken> list)
    {
      for (int count = list.Count; count > 0; --count)
      {
        if (list[count - 1].Type != CssTokenType.Whitespace)
        {
          IPropertyValue propertyValue = converter.Convert(list.Take<CssToken>(count));
          if (propertyValue != null)
          {
            list.RemoveRange(0, count);
            list.Trim();
            return propertyValue;
          }
        }
      }
      return converter.ConvertDefault();
    }

    public static IPropertyValue VaryAll(this IValueConverter converter, List<CssToken> list)
    {
      for (int index = 0; index < list.Count; ++index)
      {
        if (list[index].Type != CssTokenType.Whitespace)
        {
          for (int count1 = list.Count; count1 > index; --count1)
          {
            int count2 = count1 - index;
            if (list[count1 - 1].Type != CssTokenType.Whitespace)
            {
              IPropertyValue propertyValue = converter.Convert(list.Skip<CssToken>(index).Take<CssToken>(count2));
              if (propertyValue != null)
              {
                list.RemoveRange(index, count2);
                list.Trim();
                return propertyValue;
              }
            }
          }
        }
      }
      return converter.ConvertDefault();
    }

    public static IValueConverter Many(this IValueConverter converter, int min = 1, int max = 65535) => (IValueConverter) new OneOrMoreValueConverter(converter, min, max);

    public static IValueConverter FromList(this IValueConverter converter) => (IValueConverter) new ListValueConverter(converter);

    public static IValueConverter ToConverter<T>(this Dictionary<string, T> values) => (IValueConverter) new DictionaryValueConverter<T>(values);

    public static IValueConverter Periodic(this IValueConverter converter, params string[] labels) => (IValueConverter) new PeriodicValueConverter(converter, labels);

    public static IValueConverter RequiresEnd(
      this IValueConverter listConverter,
      IValueConverter endConverter)
    {
      return (IValueConverter) new EndListValueConverter(listConverter, endConverter);
    }

    public static IValueConverter Required(this IValueConverter converter) => (IValueConverter) new RequiredValueConverter(converter);

    public static IValueConverter Option(this IValueConverter converter) => (IValueConverter) new OptionValueConverter(converter);

    public static IValueConverter For(this IValueConverter converter, params string[] labels) => (IValueConverter) new ConstraintValueConverter(converter, labels);

    public static IValueConverter Option<T>(this IValueConverter converter, T defaultValue) => (IValueConverter) new OptionValueConverter<T>(converter, defaultValue);

    public static IValueConverter Or(this IValueConverter primary, IValueConverter secondary) => (IValueConverter) new OrValueConverter(primary, secondary);

    public static IValueConverter Or(this IValueConverter primary, string keyword) => primary.Or<object>(keyword, (object) null);

    public static IValueConverter Or<T>(this IValueConverter primary, string keyword, T value)
    {
      IdentifierValueConverter<T> next = new IdentifierValueConverter<T>(keyword, value);
      return (IValueConverter) new OrValueConverter(primary, (IValueConverter) next);
    }

    public static IValueConverter OrNone(this IValueConverter primary) => primary.Or(Keywords.None);

    public static IValueConverter OrDefault(this IValueConverter primary) => primary.OrInherit().Or(Keywords.Initial);

    public static IValueConverter OrDefault<T>(this IValueConverter primary, T value) => primary.OrInherit().Or<T>(Keywords.Initial, value);

    public static IValueConverter OrInherit(this IValueConverter primary) => primary.Or(Keywords.Inherit);

    public static IValueConverter OrAuto(this IValueConverter primary) => primary.Or(Keywords.Auto);

    public static IValueConverter StartsWithKeyword(this IValueConverter converter, string keyword) => (IValueConverter) new StartsWithValueConverter(CssTokenType.Ident, keyword, converter);

    public static IValueConverter StartsWithDelimiter(this IValueConverter converter) => (IValueConverter) new StartsWithValueConverter(CssTokenType.Delim, "/", converter);

    public static IValueConverter WithCurrentColor(this IValueConverter converter) => converter.Or<Color>(Keywords.CurrentColor, Color.Transparent);
  }
}
