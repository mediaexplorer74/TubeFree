// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.INodeIterator
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("NodeIterator")]
  public interface INodeIterator
  {
    [DomName("root")]
    INode Root { get; }

    [DomName("referenceNode")]
    INode Reference { get; }

    [DomName("pointerBeforeReferenceNode")]
    bool IsBeforeReference { get; }

    [DomName("whatToShow")]
    FilterSettings Settings { get; }

    [DomName("filter")]
    NodeFilter Filter { get; }

    [DomName("nextNode")]
    INode Next();

    [DomName("previousNode")]
    INode Previous();
  }
}
