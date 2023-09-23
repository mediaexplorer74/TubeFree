// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ValueExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css.Values;
using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  internal static class ValueExtensions
  {
    public static CssToken OnlyOrDefault(this IEnumerable<CssToken> value)
    {
      CssToken cssToken1 = (CssToken) null;
      foreach (CssToken cssToken2 in value)
      {
        if (cssToken1 == null)
        {
          cssToken1 = cssToken2;
        }
        else
        {
          cssToken1 = (CssToken) null;
          break;
        }
      }
      return cssToken1;
    }

    public static bool Is(this IEnumerable<CssToken> value, string expected)
    {
      string identifier = value.ToIdentifier();
      return identifier != null && identifier.Isi(expected);
    }

    public static string ToUri(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      return cssToken != null && cssToken.Type == CssTokenType.Url ? cssToken.Data : (string) null;
    }

    public static Length? ToDistance(this IEnumerable<CssToken> value)
    {
      Percent? percent = value.ToPercent();
      return percent.HasValue ? new Length?(new Length(percent.Value.Value, Length.Unit.Percent)) : value.ToLength();
    }

    public static Length ToLength(this FontSize fontSize)
    {
      switch (fontSize)
      {
        case FontSize.Tiny:
          return new Length(0.6f, Length.Unit.Em);
        case FontSize.Little:
          return new Length(0.75f, Length.Unit.Em);
        case FontSize.Smaller:
          return new Length(80f, Length.Unit.Percent);
        case FontSize.Small:
          return new Length(0.8888889f, Length.Unit.Em);
        case FontSize.Large:
          return new Length(1.2f, Length.Unit.Em);
        case FontSize.Larger:
          return new Length(120f, Length.Unit.Percent);
        case FontSize.Big:
          return new Length(1.5f, Length.Unit.Em);
        case FontSize.Huge:
          return new Length(2f, Length.Unit.Em);
        default:
          return new Length(1f, Length.Unit.Em);
      }
    }

    public static Percent? ToPercent(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      return cssToken != null && cssToken.Type == CssTokenType.Percentage ? new Percent?(new Percent(((CssUnitToken) cssToken).Value)) : new Percent?();
    }

    public static string ToCssString(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      return cssToken != null && cssToken.Type == CssTokenType.String ? cssToken.Data : (string) null;
    }

    public static string ToLiterals(this IEnumerable<CssToken> value)
    {
      List<string> values = new List<string>();
      IEnumerator<CssToken> enumerator = value.GetEnumerator();
      if (!enumerator.MoveNext())
        return (string) null;
      while (enumerator.Current.Type == CssTokenType.Ident)
      {
        values.Add(enumerator.Current.Data);
        if (enumerator.MoveNext() && enumerator.Current.Type != CssTokenType.Whitespace)
          return (string) null;
        if (!enumerator.MoveNext())
          return string.Join(" ", (IEnumerable<string>) values);
      }
      return (string) null;
    }

    public static string ToIdentifier(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      return cssToken != null && cssToken.Type == CssTokenType.Ident ? cssToken.Data.ToLowerInvariant() : (string) null;
    }

    public static string ToAnimatableIdentifier(this IEnumerable<CssToken> value)
    {
      string identifier = value.ToIdentifier();
      return identifier != null && (identifier.Isi(Keywords.All) || Factory.Properties.IsAnimatable(identifier)) ? identifier : (string) null;
    }

    public static float? ToSingle(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      return cssToken != null && cssToken.Type == CssTokenType.Number ? new float?(((CssNumberToken) cssToken).Value) : new float?();
    }

    public static float? ToNaturalSingle(this IEnumerable<CssToken> value)
    {
      float? single = value.ToSingle();
      return !single.HasValue || (double) single.Value < 0.0 ? new float?() : single;
    }

    public static float? ToGreaterOrEqualOneSingle(this IEnumerable<CssToken> value)
    {
      float? single = value.ToSingle();
      return !single.HasValue || (double) single.Value < 1.0 ? new float?() : single;
    }

    public static int? ToInteger(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      return cssToken != null && cssToken.Type == CssTokenType.Number && ((CssNumberToken) cssToken).IsInteger ? new int?(((CssNumberToken) cssToken).IntegerValue) : new int?();
    }

    public static int? ToNaturalInteger(this IEnumerable<CssToken> value)
    {
      int? integer = value.ToInteger();
      return !integer.HasValue || integer.Value < 0 ? new int?() : integer;
    }

    public static int? ToPositiveInteger(this IEnumerable<CssToken> value)
    {
      int? integer = value.ToInteger();
      return !integer.HasValue || integer.Value <= 0 ? new int?() : integer;
    }

    public static int? ToWeightInteger(this IEnumerable<CssToken> value)
    {
      int? positiveInteger = value.ToPositiveInteger();
      return !positiveInteger.HasValue || !ValueExtensions.IsWeight(positiveInteger.Value) ? new int?() : positiveInteger;
    }

    public static int? ToBinary(this IEnumerable<CssToken> value)
    {
      int? integer = value.ToInteger();
      return !integer.HasValue || integer.Value != 0 && integer.Value != 1 ? new int?() : integer;
    }

    public static float? ToAlphaValue(this IEnumerable<CssToken> value)
    {
      float? naturalSingle = value.ToNaturalSingle();
      if (naturalSingle.HasValue)
        return new float?(Math.Min(naturalSingle.Value, 1f));
      Percent? percent = value.ToPercent();
      return !percent.HasValue ? new float?() : new float?(percent.Value.NormalizedValue);
    }

    public static byte? ToRgbComponent(this IEnumerable<CssToken> value)
    {
      int? naturalInteger = value.ToNaturalInteger();
      if (naturalInteger.HasValue)
        return new byte?((byte) Math.Min(naturalInteger.Value, (int) byte.MaxValue));
      Percent? percent = value.ToPercent();
      return !percent.HasValue ? new byte?() : new byte?((byte) ((double) byte.MaxValue * (double) percent.Value.NormalizedValue));
    }

    public static Angle? ToAngle(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      if (cssToken != null && cssToken.Type == CssTokenType.Dimension)
      {
        CssUnitToken cssUnitToken = (CssUnitToken) cssToken;
        Angle.Unit unit = Angle.GetUnit(cssUnitToken.Unit);
        if (unit != Angle.Unit.None)
          return new Angle?(new Angle(cssUnitToken.Value, unit));
      }
      return new Angle?();
    }

    public static Angle? ToAngleNumber(this IEnumerable<CssToken> value)
    {
      Angle? angle = value.ToAngle();
      if (angle.HasValue)
        return new Angle?(angle.Value);
      float? single = value.ToSingle();
      return !single.HasValue ? new Angle?() : new Angle?(new Angle(single.Value, Angle.Unit.Deg));
    }

    public static Frequency? ToFrequency(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      if (cssToken != null && cssToken.Type == CssTokenType.Dimension)
      {
        CssUnitToken cssUnitToken = (CssUnitToken) cssToken;
        Frequency.Unit unit = Frequency.GetUnit(cssUnitToken.Unit);
        if (unit != Frequency.Unit.None)
          return new Frequency?(new Frequency(cssUnitToken.Value, unit));
      }
      return new Frequency?();
    }

    public static Length? ToLength(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      if (cssToken != null)
      {
        if (cssToken.Type == CssTokenType.Dimension)
        {
          CssUnitToken cssUnitToken = (CssUnitToken) cssToken;
          Length.Unit unit = Length.GetUnit(cssUnitToken.Unit);
          if (unit != Length.Unit.None)
            return new Length?(new Length(cssUnitToken.Value, unit));
        }
        else if (cssToken.Type == CssTokenType.Number && (double) ((CssNumberToken) cssToken).Value == 0.0)
          return new Length?(Length.Zero);
      }
      return new Length?();
    }

    public static Resolution? ToResolution(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      if (cssToken != null && cssToken.Type == CssTokenType.Dimension)
      {
        CssUnitToken cssUnitToken = (CssUnitToken) cssToken;
        Resolution.Unit unit = Resolution.GetUnit(cssUnitToken.Unit);
        if (unit != Resolution.Unit.None)
          return new Resolution?(new Resolution(cssUnitToken.Value, unit));
      }
      return new Resolution?();
    }

    public static Time? ToTime(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      if (cssToken != null && cssToken.Type == CssTokenType.Dimension)
      {
        CssUnitToken cssUnitToken = (CssUnitToken) cssToken;
        Time.Unit unit = Time.GetUnit(cssUnitToken.Unit);
        if (unit != Time.Unit.None)
          return new Time?(new Time(cssUnitToken.Value, unit));
      }
      return new Time?();
    }

    public static Length? ToBorderWidth(this IEnumerable<CssToken> value)
    {
      Length? length = value.ToLength();
      if (length.HasValue)
        return length;
      if (value.Is(Keywords.Thin))
        return new Length?(Length.Thin);
      if (value.Is(Keywords.Medium))
        return new Length?(Length.Medium);
      return value.Is(Keywords.Thick) ? new Length?(Length.Thick) : length;
    }

    public static List<List<CssToken>> ToItems(this IEnumerable<CssToken> value)
    {
      List<List<CssToken>> items = new List<List<CssToken>>();
      List<CssToken> cssTokenList = new List<CssToken>();
      int num = 0;
      items.Add(cssTokenList);
      foreach (CssToken cssToken in value)
      {
        bool flag1 = cssToken.Type == CssTokenType.Whitespace;
        bool flag2 = cssToken.Type == CssTokenType.String || cssToken.Type == CssTokenType.Url || cssToken.Type == CssTokenType.Function;
        if (num == 0 && flag1 | flag2)
        {
          if (cssTokenList.Count != 0)
          {
            cssTokenList = new List<CssToken>();
            items.Add(cssTokenList);
          }
          if (flag1)
            continue;
        }
        else if (cssToken.Type == CssTokenType.RoundBracketOpen)
          ++num;
        else if (cssToken.Type == CssTokenType.RoundBracketClose)
          --num;
        cssTokenList.Add(cssToken);
      }
      return items;
    }

    public static void Trim(this List<CssToken> value)
    {
      int num1 = 0;
      int index = value.Count - 1;
      while (num1 < index)
      {
        if (value[num1].Type == CssTokenType.Whitespace)
          ++num1;
        else if (value[index].Type == CssTokenType.Whitespace)
          --index;
        else
          break;
      }
      int num2;
      value.RemoveRange(num2 = index + 1, value.Count - num2);
      value.RemoveRange(0, num1);
    }

    public static List<List<CssToken>> ToList(this IEnumerable<CssToken> value)
    {
      List<List<CssToken>> list = new List<List<CssToken>>();
      List<CssToken> cssTokenList = new List<CssToken>();
      int num = 0;
      list.Add(cssTokenList);
      foreach (CssToken cssToken in value)
      {
        if (num == 0 && cssToken.Type == CssTokenType.Comma)
        {
          cssTokenList = new List<CssToken>();
          list.Add(cssTokenList);
        }
        else
        {
          if (cssToken.Type == CssTokenType.RoundBracketOpen)
            ++num;
          else if (cssToken.Type == CssTokenType.RoundBracketClose)
            --num;
          else if (cssToken.Type == CssTokenType.Whitespace && cssTokenList.Count == 0)
            continue;
          cssTokenList.Add(cssToken);
        }
      }
      for (int index = 0; index < list.Count; ++index)
        list[index].Trim();
      return list;
    }

    public static string ToText(this IEnumerable<CssToken> value) => string.Join(string.Empty, value.Select<CssToken, string>((Func<CssToken, string>) (m => m.ToValue())));

    public static Color? ToColor(this IEnumerable<CssToken> value)
    {
      CssToken cssToken = value.OnlyOrDefault();
      if (cssToken != null && cssToken.Type == CssTokenType.Ident)
        return Color.FromName(cssToken.Data);
      return cssToken != null && cssToken.Type == CssTokenType.Color && !((CssColorToken) cssToken).IsBad ? new Color?(Color.FromHex(cssToken.Data)) : new Color?();
    }

    private static bool IsWeight(int value) => value == 100 || value == 200 || value == 300 || value == 400 || value == 500 || value == 600 || value == 700 || value == 800 || value == 900;
  }
}
