// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.NodeFlags
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Html
{
  [Flags]
  internal enum NodeFlags : uint
  {
    None = 0,
    SelfClosing = 1,
    Special = 2,
    LiteralText = 4,
    LineTolerance = 8,
    ImplicitelyClosed = 16, // 0x00000010
    ImpliedEnd = 32, // 0x00000020
    Scoped = 64, // 0x00000040
    HtmlMember = 256, // 0x00000100
    HtmlTip = 512, // 0x00000200
    HtmlFormatting = 2048, // 0x00000800
    HtmlListScoped = 4096, // 0x00001000
    HtmlSelectScoped = 8192, // 0x00002000
    HtmlTableSectionScoped = 16384, // 0x00004000
    HtmlTableScoped = 32768, // 0x00008000
    MathMember = 65536, // 0x00010000
    MathTip = 131072, // 0x00020000
    SvgMember = 16777216, // 0x01000000
    SvgTip = 33554432, // 0x02000000
  }
}
