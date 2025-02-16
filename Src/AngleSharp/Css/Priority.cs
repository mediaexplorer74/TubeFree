﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Priority
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Runtime.InteropServices;

namespace AngleSharp.Css
{
  [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
  public struct Priority : IEquatable<Priority>, IComparable<Priority>
  {
    [FieldOffset(0)]
    private readonly byte _tags;
    [FieldOffset(1)]
    private readonly byte _classes;
    [FieldOffset(2)]
    private readonly byte _ids;
    [FieldOffset(3)]
    private readonly byte _inlines;
    [FieldOffset(0)]
    private readonly uint _priority;
    public static readonly Priority Zero = new Priority(0U);
    public static readonly Priority OneTag = new Priority((byte) 0, (byte) 0, (byte) 0, (byte) 1);
    public static readonly Priority OneClass = new Priority((byte) 0, (byte) 0, (byte) 1, (byte) 0);
    public static readonly Priority OneId = new Priority((byte) 0, (byte) 1, (byte) 0, (byte) 0);
    public static readonly Priority Inline = new Priority((byte) 1, (byte) 0, (byte) 0, (byte) 0);

    public Priority(uint priority)
    {
      this._inlines = this._ids = this._classes = this._tags = (byte) 0;
      this._priority = priority;
    }

    public Priority(byte inlines, byte ids, byte classes, byte tags)
    {
      this._priority = 0U;
      this._inlines = inlines;
      this._ids = ids;
      this._classes = classes;
      this._tags = tags;
    }

    public byte Tags => this._tags;

    public byte Classes => this._classes;

    public byte Ids => this._ids;

    public byte Inlines => this._inlines;

    public static Priority operator +(Priority a, Priority b) => new Priority(a._priority + b._priority);

    public static bool operator ==(Priority a, Priority b) => (int) a._priority == (int) b._priority;

    public static bool operator >(Priority a, Priority b) => a._priority > b._priority;

    public static bool operator >=(Priority a, Priority b) => a._priority >= b._priority;

    public static bool operator <(Priority a, Priority b) => a._priority < b._priority;

    public static bool operator <=(Priority a, Priority b) => a._priority <= b._priority;

    public static bool operator !=(Priority a, Priority b) => (int) a._priority != (int) b._priority;

    public bool Equals(Priority other) => (int) this._priority == (int) other._priority;

    public override bool Equals(object obj) => obj is Priority other && this.Equals(other);

    public override int GetHashCode() => (int) this._priority;

    public int CompareTo(Priority other)
    {
      if (this == other)
        return 0;
      return !(this > other) ? -1 : 1;
    }

    public override string ToString() => string.Format("({0}, {1}, {2}, {3})", (object) this._inlines, (object) this._ids, (object) this._classes, (object) this._tags);
  }
}
