// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Time
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Css.Values
{
  public struct Time : IEquatable<Time>, IComparable<Time>, IFormattable
  {
    public static readonly Time Zero = new Time(0.0f, Time.Unit.Ms);
    private readonly float _value;
    private readonly Time.Unit _unit;

    public Time(float value, Time.Unit unit)
    {
      this._value = value;
      this._unit = unit;
    }

    public float Value => this._value;

    public Time.Unit Type => this._unit;

    public string UnitString
    {
      get
      {
        switch (this._unit)
        {
          case Time.Unit.Ms:
            return UnitNames.Ms;
          case Time.Unit.S:
            return UnitNames.S;
          default:
            return string.Empty;
        }
      }
    }

    public static bool operator >=(Time a, Time b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == 1;
    }

    public static bool operator >(Time a, Time b) => a.CompareTo(b) == 1;

    public static bool operator <=(Time a, Time b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == -1;
    }

    public static bool operator <(Time a, Time b) => a.CompareTo(b) == -1;

    public int CompareTo(Time other) => this.ToMilliseconds().CompareTo(other.ToMilliseconds());

    public static bool TryParse(string s, out Time result)
    {
      float result1 = 0.0f;
      Time.Unit unit = Time.GetUnit(s.CssUnit(out result1));
      if (unit != Time.Unit.None)
      {
        result = new Time(result1, unit);
        return true;
      }
      result = new Time();
      return false;
    }

    public static Time.Unit GetUnit(string s)
    {
      switch (s)
      {
        case nameof (s):
          return Time.Unit.S;
        case "ms":
          return Time.Unit.Ms;
        default:
          return Time.Unit.None;
      }
    }

    public float ToMilliseconds() => this._unit != Time.Unit.S ? this._value : this._value * 1000f;

    public bool Equals(Time other) => (double) this.ToMilliseconds() == (double) other.ToMilliseconds();

    public static bool operator ==(Time a, Time b) => a.Equals(b);

    public static bool operator !=(Time a, Time b) => !a.Equals(b);

    public override bool Equals(object obj)
    {
      Time? nullable = obj as Time?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public override string ToString() => this._value.ToString() + this.UnitString;

    public string ToString(string format, IFormatProvider formatProvider) => this._value.ToString(format, formatProvider) + this.UnitString;

    public enum Unit : byte
    {
      None,
      Ms,
      S,
    }
  }
}
