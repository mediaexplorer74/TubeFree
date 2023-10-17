// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IMutationRecord
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("MutationRecord")]
  public interface IMutationRecord
  {
    [DomName("type")]
    string Type { get; }

    [DomName("target")]
    INode Target { get; }

    [DomName("addedNodes")]
    INodeList Added { get; }

    [DomName("removedNodes")]
    INodeList Removed { get; }

    [DomName("previousSibling")]
    INode PreviousSibling { get; }

    [DomName("nextSibling")]
    INode NextSibling { get; }

    [DomName("attributeName")]
    string AttributeName { get; }

    [DomName("attributeNamespace")]
    string AttributeNamespace { get; }

    [DomName("oldValue")]
    string PreviousValue { get; }
  }
}
