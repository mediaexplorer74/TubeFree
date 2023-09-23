// Decompiled with JetBrains decompiler
// Type: AngleSharp.TextPosition
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp
{
  public struct TextPosition : IEquatable<TextPosition>, IComparable<TextPosition>
  {
    public static readonly TextPosition Empty;
    private readonly ushort _line;
    private readonly ushort _column;
    private readonly int _position;

    public TextPosition(ushort line, ushort column, int position)
    {
      this._line = line;
      this._column = column;
      this._position = position;
    }

    public int Line => (int) this._line;

    public int Column => (int) this._column;

    public int Position => this._position;

    public TextPosition Shift(int columns) => new TextPosition(this._line, (ushort) ((uint) this._column + (uint) columns), this._position + columns);

    public TextPosition After(char chr)
    {
      ushort line = this._line;
      ushort num1 = this._column;
      if (chr == '\n')
      {
        ++line;
        num1 = (ushort) 0;
      }
      ushort num2;
      return new TextPosition(line, num2 = (ushort) ((uint) num1 + 1U), this._position + 1);
    }

    public TextPosition After(string str)
    {
      ushort line = this._line;
      ushort column = this._column;
      foreach (char ch in str)
      {
        if (ch == '\n')
        {
          ++line;
          column = (ushort) 0;
        }
        ++column;
      }
      return new TextPosition(line, column, this._position + str.Length);
    }

    public override string ToString() => string.Format("Ln {0}, Col {1}, Pos {2}", (object) this._line, (object) this._column, (object) this._position);

    public override int GetHashCode() => this._position ^ ((int) this._line | (int) this._column) + (int) this._line;

    public override bool Equals(object obj)
    {
      TextPosition? nullable = obj as TextPosition?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public bool Equals(TextPosition other) => this._position == other._position && (int) this._column == (int) other._column && (int) this._line == (int) other._line;

    public static bool operator >(TextPosition a, TextPosition b) => a._position > b._position;

    public static bool operator <(TextPosition a, TextPosition b) => a._position < b._position;

    public int CompareTo(TextPosition other)
    {
      if (this.Equals(other))
        return 0;
      return !(this > other) ? -1 : 1;
    }
  }
}
