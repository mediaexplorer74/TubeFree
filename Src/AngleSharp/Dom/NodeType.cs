// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.NodeType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("Document")]
  public enum NodeType : byte
  {
    [DomName("ELEMENT_NODE")] Element = 1,
    [DomName("ATTRIBUTE_NODE"), DomHistorical] Attribute = 2,
    [DomName("TEXT_NODE")] Text = 3,
    [DomName("CDATA_SECTION_NODE"), DomHistorical] CharacterData = 4,
    [DomName("ENTITY_REFERENCE_NODE"), DomHistorical] EntityReference = 5,
    [DomName("ENTITY_NODE"), DomHistorical] Entity = 6,
    [DomName("PROCESSING_INSTRUCTION_NODE"), DomHistorical] ProcessingInstruction = 7,
    [DomName("COMMENT_NODE")] Comment = 8,
    [DomName("DOCUMENT_NODE")] Document = 9,
    [DomName("DOCUMENT_TYPE_NODE")] DocumentType = 10, // 0x0A
    [DomName("DOCUMENT_FRAGMENT_NODE")] DocumentFragment = 11, // 0x0B
    [DomName("NOTATION_NODE"), DomHistorical] Notation = 12, // 0x0C
  }
}
