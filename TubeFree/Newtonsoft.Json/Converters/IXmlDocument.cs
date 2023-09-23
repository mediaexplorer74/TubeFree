// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.IXmlDocument
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

namespace Newtonsoft.Json.Converters
{
  internal interface IXmlDocument : IXmlNode
  {
    IXmlNode CreateComment(string text);

    IXmlNode CreateTextNode(string text);

    IXmlNode CreateCDataSection(string data);

    IXmlNode CreateWhitespace(string text);

    IXmlNode CreateSignificantWhitespace(string text);

    IXmlNode CreateXmlDeclaration(string version, string encoding, string standalone);

    IXmlNode CreateProcessingInstruction(string target, string data);

    IXmlElement CreateElement(string elementName);

    IXmlElement CreateElement(string qualifiedName, string namespaceUri);

    IXmlNode CreateAttribute(string name, string value);

    IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, string value);

    IXmlElement DocumentElement { get; }
  }
}
