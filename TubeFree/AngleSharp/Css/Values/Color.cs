// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Color
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Runtime.InteropServices;

namespace AngleSharp.Css.Values
{
  [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
  public struct Color : IEquatable<Color>, IComparable<Color>, IFormattable
  {
    public static readonly Color Black = new Color((byte) 0, (byte) 0, (byte) 0);
    public static readonly Color White = new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
    public static readonly Color Red = new Color(byte.MaxValue, (byte) 0, (byte) 0);
    public static readonly Color Magenta = new Color(byte.MaxValue, (byte) 0, byte.MaxValue);
    public static readonly Color Green = new Color((byte) 0, (byte) 128, (byte) 0);
    public static readonly Color PureGreen = new Color((byte) 0, byte.MaxValue, (byte) 0);
    public static readonly Color Blue = new Color((byte) 0, (byte) 0, byte.MaxValue);
    public static readonly Color Transparent = new Color((byte) 0, (byte) 0, (byte) 0, (byte) 0);
    [FieldOffset(0)]
    private readonly byte _alpha;
    [FieldOffset(1)]
    private readonly byte _red;
    [FieldOffset(2)]
    private readonly byte _green;
    [FieldOffset(3)]
    private readonly byte _blue;
    [FieldOffset(0)]
    private readonly int _hashcode;

    public Color(byte r, byte g, byte b)
    {
      this._hashcode = 0;
      this._alpha = byte.MaxValue;
      this._red = r;
      this._blue = b;
      this._green = g;
    }

    public Color(byte r, byte g, byte b, byte a)
    {
      this._hashcode = 0;
      this._alpha = a;
      this._red = r;
      this._blue = b;
      this._green = g;
    }

    public static Color FromRgba(byte r, byte g, byte b, float a) => new Color(r, g, b, Color.Normalize(a));

    public static Color FromRgba(float r, float g, float b, float a) => new Color(Color.Normalize(r), Color.Normalize(g), Color.Normalize(b), Color.Normalize(a));

    public static Color FromGray(byte number, float alpha = 1f) => new Color(number, number, number, Color.Normalize(alpha));

    public static Color FromGray(float value, float alpha = 1f) => Color.FromGray(Color.Normalize(value), alpha);

    public static Color? FromName(string name) => Colors.GetColor(name);

    public static Color FromRgb(byte r, byte g, byte b) => new Color(r, g, b);

    public static Color FromHex(string color)
    {
      int r = 0;
      int g = 0;
      int b = 0;
      int a = (int) byte.MaxValue;
      switch (color.Length)
      {
        case 3:
          r = 17 * color[0].FromHex();
          g = 17 * color[1].FromHex();
          b = 17 * color[2].FromHex();
          break;
        case 4:
          a = 17 * color[3].FromHex();
          goto case 3;
        case 6:
          r = 16 * color[0].FromHex() + color[1].FromHex();
          g = 16 * color[2].FromHex() + color[3].FromHex();
          b = 16 * color[4].FromHex() + color[5].FromHex();
          break;
        case 8:
          a = 16 * color[6].FromHex() + color[7].FromHex();
          goto case 6;
      }
      return new Color((byte) r, (byte) g, (byte) b, (byte) a);
    }

    public static bool TryFromHex(string color, out Color value)
    {
      if (color.Length == 6 || color.Length == 3 || color.Length == 8 || color.Length == 4)
      {
        for (int index = 0; index < color.Length; ++index)
        {
          if (!color[index].IsHex())
            goto label_6;
        }
        value = Color.FromHex(color);
        return true;
      }
label_6:
      value = new Color();
      return false;
    }

    public static Color FromFlexHex(string color)
    {
      int length1 = Math.Max(color.Length, 3);
      int num1 = length1 % 3;
      if (num1 != 0)
        length1 += 3 - num1;
      int val2 = length1 / 3;
      int num2 = Math.Min(2, val2);
      int index1 = Math.Max(val2 - 8, 0);
      char[] chArray = new char[length1];
      for (int index2 = 0; index2 < color.Length; ++index2)
        chArray[index2] = color[index2].IsHex() ? color[index2] : '0';
      for (int length2 = color.Length; length2 < length1; ++length2)
        chArray[length2] = '0';
      return num2 == 1 ? new Color((byte) chArray[index1].FromHex(), (byte) chArray[val2 + index1].FromHex(), (byte) chArray[2 * val2 + index1].FromHex()) : new Color((byte) (16 * chArray[index1].FromHex() + chArray[index1 + 1].FromHex()), (byte) (16 * chArray[val2 + index1].FromHex() + chArray[val2 + index1 + 1].FromHex()), (byte) (16 * chArray[2 * val2 + index1].FromHex() + chArray[2 * val2 + index1 + 1].FromHex()));
    }

    public static Color FromHsl(float h, float s, float l) => Color.FromHsla(h, s, l, 1f);

    public static Color FromHsla(float h, float s, float l, float alpha)
    {
      float m2 = (double) l <= 0.5 ? l * (s + 1f) : (float) ((double) l + (double) s - (double) l * (double) s);
      double m1 = 2.0 * (double) l - (double) m2;
      return new Color(Color.Convert(Color.HueToRgb((float) m1, m2, h + 0.333333343f)), Color.Convert(Color.HueToRgb((float) m1, m2, h)), Color.Convert(Color.HueToRgb((float) m1, m2, h - 0.333333343f)), Color.Normalize(alpha));
    }

    public static Color FromHwb(float h, float w, float b) => Color.FromHwba(h, w, b, 1f);

    public static Color FromHwba(float h, float w, float b, float alpha)
    {
      float num1 = (float) (1.0 / ((double) w + (double) b));
      if ((double) num1 < 1.0)
      {
        w *= num1;
        b *= num1;
      }
      int num2 = (int) (6.0 * (double) h);
      float num3 = 6f * h - (float) num2;
      if ((num2 & 1) != 0)
        num3 = 1f - num3;
      float num4 = 1f - b;
      float num5 = w + num3 * (num4 - w);
      float r;
      float g;
      float b1;
      switch (num2)
      {
        case 1:
          r = num5;
          g = num4;
          b1 = w;
          break;
        case 2:
          r = w;
          g = num4;
          b1 = num5;
          break;
        case 3:
          r = w;
          g = num5;
          b1 = num4;
          break;
        case 4:
          r = num5;
          g = w;
          b1 = num4;
          break;
        case 5:
          r = num4;
          g = w;
          b1 = num5;
          break;
        default:
          r = num4;
          g = num5;
          b1 = w;
          break;
      }
      return Color.FromRgba(r, g, b1, alpha);
    }

    public int Value => this._hashcode;

    public byte A => this._alpha;

    public double Alpha => (double) this._alpha / (double) byte.MaxValue;

    public byte R => this._red;

    public byte G => this._green;

    public byte B => this._blue;

    public static bool operator ==(Color a, Color b) => a._hashcode == b._hashcode;

    public static bool operator !=(Color a, Color b) => a._hashcode != b._hashcode;

    public bool Equals(Color other) => this._hashcode == other._hashcode;

    public override bool Equals(object obj)
    {
      Color? nullable = obj as Color?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    int IComparable<Color>.CompareTo(Color other) => this._hashcode - other._hashcode;

    public override int GetHashCode() => this._hashcode;

    public static Color Mix(Color above, Color below) => Color.Mix(above.Alpha, above, below);

    public static Color Mix(double alpha, Color above, Color below)
    {
      double num = 1.0 - alpha;
      return new Color((byte) (num * (double) below.R + alpha * (double) above.R), (byte) (num * (double) below.G + alpha * (double) above.G), (byte) (num * (double) below.B + alpha * (double) above.B));
    }

    private static byte Normalize(float value) => (byte) Math.Max(Math.Min(Math.Round((double) byte.MaxValue * (double) value), (double) byte.MaxValue), 0.0);

    private static byte Convert(float value) => (byte) Math.Round((double) byte.MaxValue * (double) value);

    private static float HueToRgb(float m1, float m2, float h)
    {
      if ((double) h < 0.0)
        ++h;
      else if ((double) h > 1.0)
        --h;
      if ((double) h < 0.1666666716337204)
        return m1 + (float) (((double) m2 - (double) m1) * (double) h * 6.0);
      if ((double) h < 0.5)
        return m2;
      return (double) h < 0.66666668653488159 ? m1 + (float) (((double) m2 - (double) m1) * (0.66666668653488159 - (double) h) * 6.0) : m1;
    }

    public override string ToString()
    {
      if (this._alpha == byte.MaxValue)
      {
        string str = string.Join(", ", new string[3]
        {
          this.R.ToString(),
          this.G.ToString(),
          this.B.ToString()
        });
        return FunctionNames.Rgb.CssFunction(str);
      }
      string str1 = string.Join(", ", new string[4]
      {
        this.R.ToString(),
        this.G.ToString(),
        this.B.ToString(),
        this.Alpha.ToString()
      });
      return FunctionNames.Rgba.CssFunction(str1);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
      if (this._alpha == byte.MaxValue)
      {
        string str = string.Join(", ", new string[3]
        {
          this.R.ToString(format, formatProvider),
          this.G.ToString(format, formatProvider),
          this.B.ToString(format, formatProvider)
        });
        return FunctionNames.Rgb.CssFunction(str);
      }
      string str1 = string.Join(", ", new string[4]
      {
        this.R.ToString(format, formatProvider),
        this.G.ToString(format, formatProvider),
        this.B.ToString(format, formatProvider),
        this.Alpha.ToString(format, formatProvider)
      });
      return FunctionNames.Rgba.CssFunction(str1);
    }
  }
}
