// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IAttr
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System;

namespace AngleSharp.Dom
{
  [DomName("Attr")]
  public interface IAttr : IEquatable<IAttr>
  {
    [DomName("localName")]
    string LocalName { get; }

    [DomName("name")]
    string Name { get; }

    [DomName("value")]
    string Value { get; set; }

    [DomName("namespaceURI")]
    string NamespaceUri { get; }

    [DomName("prefix")]
    string Prefix { get; }
  }
}
