// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Sandboxes
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Dom
{
  [Flags]
  public enum Sandboxes : ushort
  {
    None = 0,
    Navigation = 1,
    AuxiliaryNavigation = 2,
    TopLevelNavigation = 4,
    Plugins = 8,
    Origin = 16, // 0x0010
    Forms = 32, // 0x0020
    PointerLock = 64, // 0x0040
    Scripts = 128, // 0x0080
    AutomaticFeatures = 256, // 0x0100
    Fullscreen = 512, // 0x0200
    DocumentDomain = 1024, // 0x0400
  }
}
