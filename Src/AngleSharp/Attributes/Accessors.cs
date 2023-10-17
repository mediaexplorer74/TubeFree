// Decompiled with JetBrains decompiler
// Type: AngleSharp.Attributes.Accessors
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Attributes
{
  [Flags]
  public enum Accessors : byte
  {
    None = 0,
    Getter = 1,
    Setter = 2,
    Deleter = 4,
  }
}
