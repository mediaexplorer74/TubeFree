// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.ValueConverters.GradientConverter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Css.ValueConverters
{
  internal abstract class GradientConverter : IValueConverter
  {
    private readonly bool _repeating;

    public GradientConverter(bool repeating) => this._repeating = repeating;

    private static IPropertyValue[] ToGradientStops(List<List<CssToken>> values, int offset)
    {
      IPropertyValue[] gradientStops = new IPropertyValue[values.Count - offset];
      int index1 = offset;
      int index2 = 0;
      while (index1 < values.Count)
      {
        gradientStops[index2] = GradientConverter.ToGradientStop(values[index1]);
        if (gradientStops[index2] == null)
          return (IPropertyValue[]) null;
        ++index1;
        ++index2;
      }
      return gradientStops;
    }

    private static IPropertyValue ToGradientStop(List<CssToken> value)
    {
      IPropertyValue color = (IPropertyValue) null;
      IPropertyValue position = (IPropertyValue) null;
      List<List<CssToken>> items = value.ToItems();
      if (items.Count != 0)
      {
        position = Converters.LengthOrPercentConverter.Convert((IEnumerable<CssToken>) items[items.Count - 1]);
        if (position != null)
          items.RemoveAt(items.Count - 1);
      }
      if (items.Count != 0)
      {
        color = Converters.ColorConverter.Convert((IEnumerable<CssToken>) items[items.Count - 1]);
        if (color != null)
          items.RemoveAt(items.Count - 1);
      }
      return items.Count != 0 ? (IPropertyValue) null : (IPropertyValue) new GradientConverter.StopValue(color, position, (IEnumerable<CssToken>) value);
    }

    public IPropertyValue Convert(IEnumerable<CssToken> value)
    {
      List<List<CssToken>> list = value.ToList();
      IPropertyValue initial = list.Count != 0 ? this.ConvertFirstArgument((IEnumerable<CssToken>) list[0]) : (IPropertyValue) null;
      int offset = initial != null ? 1 : 0;
      IPropertyValue[] gradientStops = GradientConverter.ToGradientStops(list, offset);
      return gradientStops == null ? (IPropertyValue) null : (IPropertyValue) new GradientConverter.GradientValue(this._repeating, initial, gradientStops, value);
    }

    public IPropertyValue Construct(CssProperty[] properties) => properties.Guard<GradientConverter.GradientValue>();

    protected abstract IPropertyValue ConvertFirstArgument(IEnumerable<CssToken> value);

    private sealed class StopValue : IPropertyValue
    {
      private readonly IPropertyValue _color;
      private readonly IPropertyValue _position;
      private readonly CssValue _original;

      public StopValue(IPropertyValue color, IPropertyValue position, IEnumerable<CssToken> tokens)
      {
        this._color = color;
        this._position = position;
        this._original = new CssValue(tokens);
      }

      public string CssText
      {
        get
        {
          if (this._color == null && this._position != null)
            return this._position.CssText;
          return this._color != null && this._position == null ? this._color.CssText : this._color.CssText + " " + this._position.CssText;
        }
      }

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._original;
    }

    private sealed class GradientValue : IPropertyValue
    {
      private readonly bool _repeating;
      private readonly IPropertyValue _initial;
      private readonly IPropertyValue[] _stops;
      private readonly CssValue _original;

      public GradientValue(
        bool repeating,
        IPropertyValue initial,
        IPropertyValue[] stops,
        IEnumerable<CssToken> tokens)
      {
        this._repeating = repeating;
        this._initial = initial;
        this._stops = stops;
        this._original = new CssValue(tokens);
      }

      public string CssText
      {
        get
        {
          int length = this._stops.Length;
          if (this._initial != null)
            ++length;
          string[] strArray = new string[length];
          int num = 0;
          if (this._initial != null)
            strArray[num++] = this._initial.CssText;
          for (int index = 0; index < this._stops.Length; ++index)
            strArray[num++] = this._stops[index].CssText;
          return string.Join(", ", strArray);
        }
      }

      public CssValue Original => this._original;

      public CssValue ExtractFor(string name) => this._original;
    }
  }
}
