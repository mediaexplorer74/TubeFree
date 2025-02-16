﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IRange
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("Range")]
  public interface IRange
  {
    [DomName("startContainer")]
    INode Head { get; }

    [DomName("startOffset")]
    int Start { get; }

    [DomName("endContainer")]
    INode Tail { get; }

    [DomName("endOffset")]
    int End { get; }

    [DomName("collapsed")]
    bool IsCollapsed { get; }

    [DomName("commonAncestorContainer")]
    INode CommonAncestor { get; }

    [DomName("setStart")]
    void StartWith(INode refNode, int offset);

    [DomName("setEnd")]
    void EndWith(INode refNode, int offset);

    [DomName("setStartBefore")]
    void StartBefore(INode refNode);

    [DomName("setEndBefore")]
    void EndBefore(INode refNode);

    [DomName("setStartAfter")]
    void StartAfter(INode refNode);

    [DomName("setEndAfter")]
    void EndAfter(INode refNode);

    [DomName("collapse")]
    void Collapse(bool toStart);

    [DomName("selectNode")]
    void Select(INode refNode);

    [DomName("selectNodeContents")]
    void SelectContent(INode refNode);

    [DomName("deleteContents")]
    void ClearContent();

    [DomName("extractContents")]
    IDocumentFragment ExtractContent();

    [DomName("cloneContents")]
    IDocumentFragment CopyContent();

    [DomName("insertNode")]
    void Insert(INode node);

    [DomName("surroundContents")]
    void Surround(INode newParent);

    [DomName("cloneRange")]
    IRange Clone();

    [DomName("detach")]
    void Detach();

    [DomName("isPointInRange")]
    bool Contains(INode node, int offset);

    [DomName("compareBoundaryPoints")]
    RangePosition CompareBoundaryTo(RangeType how, IRange sourceRange);

    [DomName("comparePoint")]
    RangePosition CompareTo(INode node, int offset);

    [DomName("intersectsNode")]
    bool Intersects(INode node);
  }
}
