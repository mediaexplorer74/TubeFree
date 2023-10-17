// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IImplementation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Xml;

namespace AngleSharp.Dom
{
  [DomName("DOMImplementation")]
  public interface IImplementation
  {
    [DomName("createDocument")]
    IXmlDocument CreateDocument(string namespaceUri, string qualifiedName, IDocumentType doctype);

    [DomName("createHTMLDocument")]
    IDocument CreateHtmlDocument(string title);

    [DomName("createDocumentType")]
    IDocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId);

    [DomName("hasFeature")]
    bool HasFeature(string feature, string version = null);
  }
}
