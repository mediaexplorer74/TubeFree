// Decompiled with JetBrains decompiler
// Type: AngleSharp.TextRange
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Diagnostics;

namespace AngleSharp
{
  [DebuggerStepThrough]
  public struct TextRange : IEquatable<TextRange>, IComparable<TextRange>
  {
    private readonly TextPosition _start;
    private readonly TextPosition _end;

    public TextRange(TextPosition start, TextPosition end)
    {
      this._start = start;
      this._end = end;
    }

    public TextPosition Start => this._start;

    public TextPosition End => this._end;

    public override string ToString() => string.Format("({0}) -- ({1})", (object) this._start, (object) this._end);

    public override int GetHashCode()
    {
      TextPosition textPosition = this._end;
      int hashCode1 = textPosition.GetHashCode();
      textPosition = this._start;
      int hashCode2 = textPosition.GetHashCode();
      return hashCode1 ^ hashCode2;
    }

    public override bool Equals(object obj)
    {
      TextRange? nullable = obj as TextRange?;
      return nullable.HasValue && this.Equals(nullable.Value);
    }

    public bool Equals(TextRange other) => this._start.Equals(other._start) && this._end.Equals(other._end);

    public static bool operator >(TextRange a, TextRange b) => a._start > b._end;

    public static bool operator <(TextRange a, TextRange b) => a._end < b._start;

    public int CompareTo(TextRange other)
    {
      if (this > other)
        return 1;
      return other > this ? -1 : 0;
    }
  }
}
