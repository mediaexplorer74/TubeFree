// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Frequency
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Css.Values
{
  public struct Frequency : IEquatable<Frequency>, IComparable<Frequency>, IFormattable
  {
    private readonly float _value;
    private readonly Frequency.Unit _unit;

    public Frequency(float value, Frequency.Unit unit)
    {
      this._value = value;
      this._unit = unit;
    }

    public float Value => this._value;

    public Frequency.Unit Type => this._unit;

    public string UnitString
    {
      get
      {
        switch (this._unit)
        {
          case Frequency.Unit.Hz:
            return UnitNames.Hz;
          case Frequency.Unit.Khz:
            return UnitNames.Khz;
          default:
            return string.Empty;
        }
      }
    }

    public static bool operator >=(Frequency a, Frequency b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == 1;
    }

    public static bool operator >(Frequency a, Frequency b) => a.CompareTo(b) == 1;

    public static bool operator <=(Frequency a, Frequency b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == -1;
    }

    public static bool operator <(Frequency a, Frequency b) => a.CompareTo(b) == -1;

    public int CompareTo(Frequency other) => this.ToHertz().CompareTo(other.ToHertz());

    public static bool TryParse(string s, out Frequency result)
    {
      float result1 = 0.0f;
      Frequency.Unit unit = Frequency.GetUnit(s.CssUnit(out result1));
      if (unit != Frequency.Unit.None)
      {
        result = new Frequency(result1, unit);
        return true;
      }
      result = new Frequency();
      return false;
    }

    public static Frequency.Unit GetUnit(string s)
    {
      switch (s)
      {
        case "hz":
          return Frequency.Unit.Hz;
        case "khz":
          return Frequency.Unit.Khz;
        default:
          return Frequency.Unit.None;
      }
    }

    public float ToHertz() => this._unit != Frequency.Unit.Khz ? this._value : this._value * 1000f;

    public bool Equals(Frequency other) => (double) this._value == (double) other._value && this._unit == other._unit;

    public static bool operator ==(Frequency a, Frequency b) => a.Equals(b);

    public static bool operator !=(Frequency a, Frequency b) => !a.Equals(b);

    public override bool Equals(object obj)
    {
      Frequency? nullable = obj as Frequency?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public override string ToString() => this._value.ToString() + this.UnitString;

    public string ToString(string format, IFormatProvider formatProvider) => this._value.ToString(format, formatProvider) + this.UnitString;

    public enum Unit : byte
    {
      None,
      Hz,
      Khz,
    }
  }
}
