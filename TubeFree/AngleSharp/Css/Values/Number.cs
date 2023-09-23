// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Number
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css.Values
{
  public struct Number : IEquatable<Number>, IComparable<Number>, IFormattable
  {
    public static readonly Number Zero = new Number(0.0f, Number.Unit.Integer);
    public static readonly Number Infinite = new Number(float.PositiveInfinity, Number.Unit.Float);
    public static readonly Number One = new Number(1f, Number.Unit.Integer);
    private readonly float _value;
    private readonly Number.Unit _unit;

    public Number(float value, Number.Unit unit)
    {
      this._value = value;
      this._unit = unit;
    }

    public float Value => this._value;

    public bool IsInteger => this._unit == Number.Unit.Integer;

    public static bool operator >=(Number a, Number b) => (double) a._value >= (double) b._value;

    public static bool operator >(Number a, Number b) => (double) a._value > (double) b._value;

    public static bool operator <=(Number a, Number b) => (double) a._value <= (double) b._value;

    public static bool operator <(Number a, Number b) => (double) a._value < (double) b._value;

    public int CompareTo(Number other) => this._value.CompareTo(other._value);

    public bool Equals(Number other) => (double) this._value == (double) other._value && this._unit == other._unit;

    public static bool operator ==(Number a, Number b) => (double) a._value == (double) b._value;

    public static bool operator !=(Number a, Number b) => (double) a._value != (double) b._value;

    public override bool Equals(object obj)
    {
      Number? nullable = obj as Number?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public override string ToString() => this._value.ToString();

    public string ToString(string format, IFormatProvider formatProvider) => this._value.ToString(format, formatProvider);

    public enum Unit : byte
    {
      Integer,
      Float,
    }
  }
}
