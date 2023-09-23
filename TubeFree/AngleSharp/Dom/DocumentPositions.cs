// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.DocumentPositions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System;

namespace AngleSharp.Dom
{
  [Flags]
  [DomName("Document")]
  public enum DocumentPositions : byte
  {
    Same = 0,
    [DomName("DOCUMENT_POSITION_DISCONNECTED")] Disconnected = 1,
    [DomName("DOCUMENT_POSITION_PRECEDING")] Preceding = 2,
    [DomName("DOCUMENT_POSITION_FOLLOWING")] Following = 4,
    [DomName("DOCUMENT_POSITION_CONTAINS")] Contains = 8,
    [DomName("DOCUMENT_POSITION_CONTAINED_BY")] ContainedBy = 16, // 0x10
    [DomName("DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC")] ImplementationSpecific = 32, // 0x20
  }
}
