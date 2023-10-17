// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.DomImplementation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Dom.Xml;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Collections.Generic;

namespace AngleSharp.Dom
{
  internal sealed class DomImplementation : IImplementation
  {
    private static readonly Dictionary<string, string[]> features = new Dictionary<string, string[]>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        "XML",
        new string[2]{ "1.0", "2.0" }
      },
      {
        "HTML",
        new string[2]{ "1.0", "2.0" }
      },
      {
        "Core",
        new string[1]{ "2.0" }
      },
      {
        "Views",
        new string[1]{ "2.0" }
      },
      {
        "StyleSheets",
        new string[1]{ "2.0" }
      },
      {
        "CSS",
        new string[1]{ "2.0" }
      },
      {
        "CSS2",
        new string[1]{ "2.0" }
      },
      {
        "Traversal",
        new string[1]{ "2.0" }
      },
      {
        "Events",
        new string[1]{ "2.0" }
      },
      {
        "UIEvents",
        new string[1]{ "2.0" }
      },
      {
        "HTMLEvents",
        new string[1]{ "2.0" }
      },
      {
        "Range",
        new string[1]{ "2.0" }
      },
      {
        "MutationEvents",
        new string[1]{ "2.0" }
      }
    };
    private readonly Document _owner;

    public DomImplementation(Document owner) => this._owner = owner;

    public IDocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId)
    {
      if (qualifiedName == null)
        throw new ArgumentNullException(nameof (qualifiedName));
      if (!qualifiedName.IsXmlName())
        throw new DomException(DomError.InvalidCharacter);
      if (!qualifiedName.IsQualifiedName())
        throw new DomException(DomError.Namespace);
      return (IDocumentType) new DocumentType(this._owner, qualifiedName)
      {
        PublicIdentifier = publicId,
        SystemIdentifier = systemId
      };
    }

    public IXmlDocument CreateDocument(
      string namespaceUri = null,
      string qualifiedName = null,
      IDocumentType doctype = null)
    {
      XmlDocument document = new XmlDocument();
      if (doctype != null)
        document.AppendChild((INode) doctype);
      if (!string.IsNullOrEmpty(qualifiedName))
      {
        IElement element = document.CreateElement(namespaceUri, qualifiedName);
        if (element != null)
          document.AppendChild((INode) element);
      }
      document.BaseUrl = this._owner.BaseUrl;
      return (IXmlDocument) document;
    }

    public IDocument CreateHtmlDocument(string title)
    {
      HtmlDocument owner = new HtmlDocument();
      owner.AppendChild((INode) new DocumentType((Document) owner, TagNames.Html));
      owner.AppendChild((INode) owner.CreateElement(TagNames.Html));
      owner.DocumentElement.AppendChild((INode) owner.CreateElement(TagNames.Head));
      if (!string.IsNullOrEmpty(title))
      {
        IElement element = owner.CreateElement(TagNames.Title);
        element.AppendChild((INode) owner.CreateTextNode(title));
        owner.Head.AppendChild((INode) element);
      }
      owner.DocumentElement.AppendChild((INode) owner.CreateElement(TagNames.Body));
      owner.BaseUrl = this._owner.BaseUrl;
      return (IDocument) owner;
    }

    public bool HasFeature(string feature, string version = null)
    {
      if (feature == null)
        throw new ArgumentNullException(nameof (feature));
      string[] list = (string[]) null;
      return DomImplementation.features.TryGetValue(feature, out list) && list.Contains(version ?? string.Empty, StringComparison.OrdinalIgnoreCase);
    }
  }
}
