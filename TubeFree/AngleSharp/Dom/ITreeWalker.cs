// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.ITreeWalker
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("TreeWalker")]
  public interface ITreeWalker
  {
    [DomName("root")]
    INode Root { get; }

    [DomName("currentNode")]
    INode Current { get; set; }

    [DomName("whatToShow")]
    FilterSettings Settings { get; }

    [DomName("filter")]
    NodeFilter Filter { get; }

    [DomName("nextNode")]
    INode ToNext();

    [DomName("previousNode")]
    INode ToPrevious();

    [DomName("parentNode")]
    INode ToParent();

    [DomName("firstChild")]
    INode ToFirst();

    [DomName("lastChild")]
    INode ToLast();

    [DomName("previousSibling")]
    INode ToPreviousSibling();

    [DomName("nextSibling")]
    INode ToNextSibling();
  }
}
