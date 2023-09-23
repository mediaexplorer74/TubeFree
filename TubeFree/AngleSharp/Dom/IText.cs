// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IText
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("Text")]
  public interface IText : 
    ICharacterData,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IChildNode,
    INonDocumentTypeChildNode
  {
    [DomName("splitText")]
    IText Split(int offset);

    [DomName("wholeText")]
    string Text { get; }

    [DomName("assignedSlot")]
    IElement AssignedSlot { get; }
  }
}
