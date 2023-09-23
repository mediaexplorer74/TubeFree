// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlParserOptions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System;

namespace AngleSharp.Parser.Xml
{
  public struct XmlParserOptions
  {
    public bool IsSuppressingErrors { get; set; }

    public Action<IElement, TextPosition> OnCreated { get; set; }
  }
}
