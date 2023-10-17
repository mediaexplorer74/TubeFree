// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IStringMap
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  [DomName("DOMStringMap")]
  public interface IStringMap : IEnumerable<KeyValuePair<string, string>>, IEnumerable
  {
    [DomAccessor(Accessors.Getter | Accessors.Setter)]
    string this[string name] { get; set; }

    [DomAccessor(Accessors.Deleter)]
    void Remove(string name);
  }
}
