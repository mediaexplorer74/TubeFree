// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Length
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Css.Values
{
  public struct Length : IEquatable<Length>, IComparable<Length>, IFormattable
  {
    public static readonly Length Zero = new Length(0.0f, Length.Unit.Px);
    public static readonly Length Half = new Length(50f, Length.Unit.Percent);
    public static readonly Length Full = new Length(100f, Length.Unit.Percent);
    public static readonly Length Thin = new Length(1f, Length.Unit.Px);
    public static readonly Length Medium = new Length(3f, Length.Unit.Px);
    public static readonly Length Thick = new Length(5f, Length.Unit.Px);
    public static readonly Length Missing = new Length(-1f, Length.Unit.Ch);
    private readonly float _value;
    private readonly Length.Unit _unit;

    public Length(float value, Length.Unit unit)
    {
      this._value = value;
      this._unit = unit;
    }

    public bool IsAbsolute => this._unit == Length.Unit.In || this._unit == Length.Unit.Mm || this._unit == Length.Unit.Pc || this._unit == Length.Unit.Px || this._unit == Length.Unit.Pt || this._unit == Length.Unit.Cm;

    public bool IsRelative => !this.IsAbsolute;

    public Length.Unit Type => this._unit;

    public float Value => this._value;

    public string UnitString
    {
      get
      {
        switch (this._unit)
        {
          case Length.Unit.Px:
            return UnitNames.Px;
          case Length.Unit.Em:
            return UnitNames.Em;
          case Length.Unit.Ex:
            return UnitNames.Ex;
          case Length.Unit.Cm:
            return UnitNames.Cm;
          case Length.Unit.Mm:
            return UnitNames.Mm;
          case Length.Unit.In:
            return UnitNames.In;
          case Length.Unit.Pt:
            return UnitNames.Pt;
          case Length.Unit.Pc:
            return UnitNames.Pc;
          case Length.Unit.Ch:
            return UnitNames.Ch;
          case Length.Unit.Rem:
            return UnitNames.Rem;
          case Length.Unit.Vw:
            return UnitNames.Vw;
          case Length.Unit.Vh:
            return UnitNames.Vh;
          case Length.Unit.Vmin:
            return UnitNames.Vmin;
          case Length.Unit.Vmax:
            return UnitNames.Vmax;
          case Length.Unit.Percent:
            return UnitNames.Percent;
          default:
            return string.Empty;
        }
      }
    }

    public static bool operator >=(Length a, Length b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == 1;
    }

    public static bool operator >(Length a, Length b) => a.CompareTo(b) == 1;

    public static bool operator <=(Length a, Length b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == -1;
    }

    public static bool operator <(Length a, Length b) => a.CompareTo(b) == -1;

    public int CompareTo(Length other)
    {
      if (this._unit == other._unit)
        return this._value.CompareTo(other._value);
      return this.IsAbsolute && other.IsAbsolute ? this.ToPixel().CompareTo(other.ToPixel()) : 0;
    }

    public static bool TryParse(string s, out Length result)
    {
      float result1 = 0.0f;
      Length.Unit unit = Length.GetUnit(s.CssUnit(out result1));
      if (unit != Length.Unit.None)
      {
        result = new Length(result1, unit);
        return true;
      }
      if ((double) result1 == 0.0)
      {
        result = Length.Zero;
        return true;
      }
      result = new Length();
      return false;
    }

    public static Length.Unit GetUnit(string s)
    {
      switch (s)
      {
        case "%":
          return Length.Unit.Percent;
        case "ch":
          return Length.Unit.Ch;
        case "cm":
          return Length.Unit.Cm;
        case "em":
          return Length.Unit.Em;
        case "ex":
          return Length.Unit.Ex;
        case "in":
          return Length.Unit.In;
        case "mm":
          return Length.Unit.Mm;
        case "pc":
          return Length.Unit.Pc;
        case "pt":
          return Length.Unit.Pt;
        case "px":
          return Length.Unit.Px;
        case "rem":
          return Length.Unit.Rem;
        case "vh":
          return Length.Unit.Vh;
        case "vmax":
          return Length.Unit.Vmax;
        case "vmin":
          return Length.Unit.Vmin;
        case "vw":
          return Length.Unit.Vw;
        default:
          return Length.Unit.None;
      }
    }

    public float ToPixel()
    {
      switch (this._unit)
      {
        case Length.Unit.Px:
          return this._value;
        case Length.Unit.Cm:
          return (float) ((double) this._value * 50.0 * 96.0 / (double) sbyte.MaxValue);
        case Length.Unit.Mm:
          return (float) ((double) this._value * 5.0 * 96.0 / (double) sbyte.MaxValue);
        case Length.Unit.In:
          return this._value * 96f;
        case Length.Unit.Pt:
          return (float) ((double) this._value * 96.0 / 72.0);
        case Length.Unit.Pc:
          return (float) ((double) this._value * 12.0 * 96.0 / 72.0);
        default:
          throw new InvalidOperationException("A relative unit cannot be converted.");
      }
    }

    public float To(Length.Unit unit)
    {
      float pixel = this.ToPixel();
      switch (unit)
      {
        case Length.Unit.Px:
          return pixel;
        case Length.Unit.Cm:
          return (float) ((double) pixel * (double) sbyte.MaxValue / 4800.0);
        case Length.Unit.Mm:
          return (float) ((double) pixel * (double) sbyte.MaxValue / 480.0);
        case Length.Unit.In:
          return pixel / 96f;
        case Length.Unit.Pt:
          return (float) ((double) pixel * 72.0 / 96.0);
        case Length.Unit.Pc:
          return (float) ((double) pixel * 72.0 / 1152.0);
        default:
          throw new InvalidOperationException("An absolute unit cannot be converted to a relative one.");
      }
    }

    public bool Equals(Length other) => (double) this._value == (double) other._value && this._unit == other._unit;

    public static bool operator ==(Length a, Length b) => a.Equals(b);

    public static bool operator !=(Length a, Length b) => !a.Equals(b);

    public override bool Equals(object obj)
    {
      Length? nullable = obj as Length?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public override string ToString()
    {
      string str = (double) this._value == 0.0 ? string.Empty : this.UnitString;
      return this._value.ToString() + str;
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
      string str = (double) this._value == 0.0 ? string.Empty : this.UnitString;
      return this._value.ToString(format, formatProvider) + str;
    }

    public enum Unit : byte
    {
      None,
      Px,
      Em,
      Ex,
      Cm,
      Mm,
      In,
      Pt,
      Pc,
      Ch,
      Rem,
      Vw,
      Vh,
      Vmin,
      Vmax,
      Percent,
    }
  }
}
