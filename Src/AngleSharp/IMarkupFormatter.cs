// Decompiled with JetBrains decompiler
// Type: AngleSharp.IMarkupFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;

namespace AngleSharp
{
  public interface IMarkupFormatter
  {
    string Text(string text);

    string Comment(IComment comment);

    string Processing(IProcessingInstruction processing);

    string Doctype(IDocumentType doctype);

    string OpenTag(IElement element, bool selfClosing);

    string CloseTag(IElement element, bool selfClosing);

    string Attribute(IAttr attribute);
  }
}
