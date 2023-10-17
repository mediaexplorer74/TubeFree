// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.ICharacterData
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("CharacterData")]
  public interface ICharacterData : 
    INode,
    IEventTarget,
    IMarkupFormattable,
    IChildNode,
    INonDocumentTypeChildNode
  {
    [DomName("data")]
    string Data { get; set; }

    [DomName("length")]
    int Length { get; }

    [DomName("substringData")]
    string Substring(int offset, int count);

    [DomName("appendData")]
    void Append(string value);

    [DomName("insertData")]
    void Insert(int offset, string value);

    [DomName("deleteData")]
    void Delete(int offset, int count);

    [DomName("replaceData")]
    void Replace(int offset, int count, string value);
  }
}
