// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IStringList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  [DomName("DOMStringList")]
  public interface IStringList : IEnumerable<string>, IEnumerable
  {
    [DomName("item")]
    [DomAccessor(Accessors.Getter)]
    string this[int index] { get; }

    [DomName("length")]
    int Length { get; }

    [DomName("contains")]
    bool Contains(string entry);
  }
}
