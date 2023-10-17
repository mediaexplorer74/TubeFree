// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.INamedNodeMap
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  [DomName("NamedNodeMap")]
  public interface INamedNodeMap : IEnumerable<IAttr>, IEnumerable
  {
    [DomName("item")]
    [DomAccessor(Accessors.Getter)]
    IAttr this[int index] { get; }

    [DomAccessor(Accessors.Getter)]
    IAttr this[string name] { get; }

    [DomName("length")]
    int Length { get; }

    [DomName("getNamedItem")]
    IAttr GetNamedItem(string name);

    [DomName("setNamedItem")]
    IAttr SetNamedItem(IAttr item);

    [DomName("removeNamedItem")]
    IAttr RemoveNamedItem(string name);

    [DomName("getNamedItemNS")]
    IAttr GetNamedItem(string namespaceUri, string localName);

    [DomName("setNamedItemNS")]
    IAttr SetNamedItemWithNamespaceUri(IAttr item);

    [DomName("removeNamedItemNS")]
    IAttr RemoveNamedItem(string namespaceUri, string localName);
  }
}
