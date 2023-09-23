// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.PropertyFlags
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css
{
  [Flags]
  internal enum PropertyFlags : byte
  {
    None = 0,
    Inherited = 1,
    Hashless = 2,
    Unitless = 4,
    Animatable = 8,
    Shorthand = 16, // 0x10
  }
}
