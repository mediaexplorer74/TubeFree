// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Angle
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Css.Values
{
  public struct Angle : IEquatable<Angle>, IComparable<Angle>, IFormattable
  {
    public static readonly Angle Zero = new Angle(0.0f, Angle.Unit.Rad);
    public static readonly Angle HalfQuarter = new Angle(45f, Angle.Unit.Deg);
    public static readonly Angle Quarter = new Angle(90f, Angle.Unit.Deg);
    public static readonly Angle TripleHalfQuarter = new Angle(135f, Angle.Unit.Deg);
    public static readonly Angle Half = new Angle(180f, Angle.Unit.Deg);
    private readonly float _value;
    private readonly Angle.Unit _unit;

    public Angle(float value, Angle.Unit unit)
    {
      this._value = value;
      this._unit = unit;
    }

    public float Value => this._value;

    public Angle.Unit Type => this._unit;

    public string UnitString
    {
      get
      {
        switch (this._unit)
        {
          case Angle.Unit.Deg:
            return UnitNames.Deg;
          case Angle.Unit.Rad:
            return UnitNames.Rad;
          case Angle.Unit.Grad:
            return UnitNames.Grad;
          case Angle.Unit.Turn:
            return UnitNames.Turn;
          default:
            return string.Empty;
        }
      }
    }

    public static bool operator >=(Angle a, Angle b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == 1;
    }

    public static bool operator >(Angle a, Angle b) => a.CompareTo(b) == 1;

    public static bool operator <=(Angle a, Angle b)
    {
      int num = a.CompareTo(b);
      return num == 0 || num == -1;
    }

    public static bool operator <(Angle a, Angle b) => a.CompareTo(b) == -1;

    public int CompareTo(Angle other) => this.ToRadian().CompareTo(other.ToRadian());

    public static bool TryParse(string s, out Angle result)
    {
      float result1 = 0.0f;
      Angle.Unit unit = Angle.GetUnit(s.CssUnit(out result1));
      if (unit != Angle.Unit.None)
      {
        result = new Angle(result1, unit);
        return true;
      }
      result = new Angle();
      return false;
    }

    public static Angle.Unit GetUnit(string s)
    {
      switch (s)
      {
        case "deg":
          return Angle.Unit.Deg;
        case "grad":
          return Angle.Unit.Grad;
        case "turn":
          return Angle.Unit.Turn;
        case "rad":
          return Angle.Unit.Rad;
        default:
          return Angle.Unit.None;
      }
    }

    public float ToRadian()
    {
      switch (this._unit)
      {
        case Angle.Unit.Deg:
          return 0.0174532924f * this._value;
        case Angle.Unit.Grad:
          return 0.0157079641f * this._value;
        case Angle.Unit.Turn:
          return 6.28318548f * this._value;
        default:
          return this._value;
      }
    }

    public float ToTurns()
    {
      switch (this._unit)
      {
        case Angle.Unit.Deg:
          return this._value / 360f;
        case Angle.Unit.Rad:
          return this._value / 6.28318548f;
        case Angle.Unit.Grad:
          return this._value / 400f;
        default:
          return this._value;
      }
    }

    public bool Equals(Angle other) => (double) this.ToRadian() == (double) other.ToRadian();

    public static bool operator ==(Angle a, Angle b) => a.Equals(b);

    public static bool operator !=(Angle a, Angle b) => !a.Equals(b);

    public override bool Equals(object obj)
    {
      Angle? nullable = obj as Angle?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public override int GetHashCode() => (int) this._value;

    public override string ToString() => this._value.ToString() + this.UnitString;

    public string ToString(string format, IFormatProvider formatProvider) => this._value.ToString(format, formatProvider) + this.UnitString;

    public enum Unit : byte
    {
      None,
      Deg,
      Rad,
      Grad,
      Turn,
    }
  }
}
