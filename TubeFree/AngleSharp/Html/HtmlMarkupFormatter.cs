// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.HtmlMarkupFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Extensions;
using System.Collections.Generic;
using System.Text;

namespace AngleSharp.Html
{
  public sealed class HtmlMarkupFormatter : IMarkupFormatter
  {
    public static readonly IMarkupFormatter Instance = (IMarkupFormatter) new HtmlMarkupFormatter();

    string IMarkupFormatter.Comment(IComment comment) => "<!--" + comment.Data + "-->";

    string IMarkupFormatter.Doctype(IDocumentType doctype)
    {
      string ids = HtmlMarkupFormatter.GetIds(doctype.PublicIdentifier, doctype.SystemIdentifier);
      return "<!DOCTYPE " + doctype.Name + ids + ">";
    }

    string IMarkupFormatter.Processing(IProcessingInstruction processing) => "<?" + (processing.Target + " " + processing.Data) + ">";

    string IMarkupFormatter.Text(string text)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      for (int index = 0; index < text.Length; ++index)
      {
        switch (text[index])
        {
          case '&':
            sb.Append("&amp;");
            break;
          case '<':
            sb.Append("&lt;");
            break;
          case '>':
            sb.Append("&gt;");
            break;
          case ' ':
            sb.Append("&nbsp;");
            break;
          default:
            sb.Append(text[index]);
            break;
        }
      }
      return sb.ToPool();
    }

    string IMarkupFormatter.OpenTag(IElement element, bool selfClosing)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      sb.Append('<');
      if (!string.IsNullOrEmpty(element.Prefix))
        sb.Append(element.Prefix).Append(':');
      sb.Append(element.LocalName);
      foreach (IAttr attribute in (IEnumerable<IAttr>) element.Attributes)
        sb.Append(" ").Append(HtmlMarkupFormatter.Instance.Attribute(attribute));
      sb.Append('>');
      return sb.ToPool();
    }

    string IMarkupFormatter.CloseTag(IElement element, bool selfClosing)
    {
      string prefix = element.Prefix;
      string localName = element.LocalName;
      string str = !string.IsNullOrEmpty(prefix) ? prefix + ":" + localName : localName;
      return !selfClosing ? "</" + str + ">" : string.Empty;
    }

    string IMarkupFormatter.Attribute(IAttr attr)
    {
      string namespaceUri = attr.NamespaceUri;
      string localName = attr.LocalName;
      string str = attr.Value;
      StringBuilder stringBuilder = Pool.NewStringBuilder();
      if (string.IsNullOrEmpty(namespaceUri))
        stringBuilder.Append(localName);
      else if (namespaceUri.Is(NamespaceNames.XmlUri))
        stringBuilder.Append(NamespaceNames.XmlPrefix).Append(':').Append(localName);
      else if (namespaceUri.Is(NamespaceNames.XLinkUri))
        stringBuilder.Append(NamespaceNames.XLinkPrefix).Append(':').Append(localName);
      else if (namespaceUri.Is(NamespaceNames.XmlNsUri))
        stringBuilder.Append(HtmlMarkupFormatter.XmlNamespaceLocalName(localName));
      else
        stringBuilder.Append(attr.Name);
      stringBuilder.Append('=').Append('"');
      for (int index = 0; index < str.Length; ++index)
      {
        switch (str[index])
        {
          case '"':
            stringBuilder.Append("&quot;");
            break;
          case '&':
            stringBuilder.Append("&amp;");
            break;
          case ' ':
            stringBuilder.Append("&nbsp;");
            break;
          default:
            stringBuilder.Append(str[index]);
            break;
        }
      }
      return stringBuilder.Append('"').ToPool();
    }

    private static string GetIds(string publicId, string systemId)
    {
      if (string.IsNullOrEmpty(publicId) && string.IsNullOrEmpty(systemId))
        return string.Empty;
      return string.IsNullOrEmpty(systemId) ? string.Format(" PUBLIC \"{0}\"", (object) publicId) : (string.IsNullOrEmpty(publicId) ? string.Format(" SYSTEM \"{0}\"", (object) systemId) : string.Format(" PUBLIC \"{0}\" \"{1}\"", (object) publicId, (object) systemId));
    }

    private static string XmlNamespaceLocalName(string name) => !(name != NamespaceNames.XmlNsPrefix) ? name : NamespaceNames.XmlNsPrefix + ":";
  }
}
