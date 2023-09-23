// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Resolution
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Css.Values
{
  public struct Resolution : IEquatable<Resolution>, IComparable<Resolution>, IFormattable
  {
    private readonly float _value;
    private readonly Resolution.Unit _unit;

    public Resolution(float value, Resolution.Unit unit)
    {
      this._value = value;
      this._unit = unit;
    }

    public float Value => this._value;

    public Resolution.Unit Type => this._unit;

    public string UnitString
    {
      get
      {
        switch (this._unit)
        {
          case Resolution.Unit.Dpi:
            return UnitNames.Dpi;
          case Resolution.Unit.Dpcm:
            return UnitNames.Dpcm;
          case Resolution.Unit.Dppx:
            return UnitNames.Dppx;
          default:
            return string.Empty;
        }
      }
    }

    public static bool TryParse(string s, out Resolution result)
    {
      float result1 = 0.0f;
      Resolution.Unit unit = Resolution.GetUnit(s.CssUnit(out result1));
      if (unit != Resolution.Unit.None)
      {
        result = new Resolution(result1, unit);
        return true;
      }
      result = new Resolution();
      return false;
    }

    public static Resolution.Unit GetUnit(string s)
    {
      switch (s)
      {
        case "dpcm":
          return Resolution.Unit.Dpcm;
        case "dpi":
          return Resolution.Unit.Dpi;
        case "dppx":
          return Resolution.Unit.Dppx;
        default:
          return Resolution.Unit.None;
      }
    }

    public float ToDotsPerPixel()
    {
      if (this._unit == Resolution.Unit.Dpi)
        return this._value / 96f;
      return this._unit == Resolution.Unit.Dpcm ? (float) ((double) this._value * (double) sbyte.MaxValue / 4800.0) : this._value;
    }

    public float To(Resolution.Unit unit)
    {
      float dotsPerPixel = this.ToDotsPerPixel();
      if (unit == Resolution.Unit.Dpi)
        return dotsPerPixel * 96f;
      return unit == Resolution.Unit.Dpcm ? (float) ((double) dotsPerPixel * 50.0 * 96.0 / (double) sbyte.MaxValue) : dotsPerPixel;
    }

    public bool Equals(Resolution other) => (double) this._value == (double) other._value && this._unit == other._unit;

    public int CompareTo(Resolution other) => this.ToDotsPerPixel().CompareTo(other.ToDotsPerPixel());

    public override bool Equals(object obj)
    {
      Resolution? nullable = obj as Resolution?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public override string ToString() => this._value.ToString() + this.UnitString;

    public string ToString(string format, IFormatProvider formatProvider) => this._value.ToString(format, formatProvider) + this.UnitString;

    public enum Unit : byte
    {
      None,
      Dpi,
      Dpcm,
      Dppx,
    }
  }
}
