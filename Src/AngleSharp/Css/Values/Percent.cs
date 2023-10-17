// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Percent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css.Values
{
  public struct Percent : IEquatable<Percent>, IComparable<Percent>, IFormattable
  {
    public static readonly Percent Zero = new Percent(0.0f);
    public static readonly Percent Fifty = new Percent(50f);
    public static readonly Percent Hundred = new Percent(100f);
    private readonly float _value;

    public Percent(float value) => this._value = value;

    public float NormalizedValue => this._value * 0.01f;

    public float Value => this._value;

    public static bool operator >=(Percent a, Percent b) => (double) a._value >= (double) b._value;

    public static bool operator >(Percent a, Percent b) => (double) a._value > (double) b._value;

    public static bool operator <=(Percent a, Percent b) => (double) a._value <= (double) b._value;

    public static bool operator <(Percent a, Percent b) => (double) a._value < (double) b._value;

    public int CompareTo(Percent other) => this._value.CompareTo(other._value);

    public bool Equals(Percent other) => (double) this._value == (double) other._value;

    public static bool operator ==(Percent a, Percent b) => a.Equals(b);

    public static bool operator !=(Percent a, Percent b) => !a.Equals(b);

    public override bool Equals(object obj)
    {
      Percent? nullable = obj as Percent?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public override string ToString() => this._value.ToString() + "%";

    public string ToString(string format, IFormatProvider formatProvider) => this._value.ToString(format, formatProvider) + "%";
  }
}
