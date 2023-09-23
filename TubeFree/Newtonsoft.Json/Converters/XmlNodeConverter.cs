﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XmlNodeConverter
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
  public class XmlNodeConverter : JsonConverter
  {
    internal static readonly List<IXmlNode> EmptyChildNodes = new List<IXmlNode>();
    private const string TextName = "#text";
    private const string CommentName = "#comment";
    private const string CDataName = "#cdata-section";
    private const string WhitespaceName = "#whitespace";
    private const string SignificantWhitespaceName = "#significant-whitespace";
    private const string DeclarationName = "?xml";
    private const string JsonNamespaceUri = "http://james.newtonking.com/projects/json";

    public string DeserializeRootElementName { get; set; }

    public bool WriteArrayAttribute { get; set; }

    public bool OmitRootObject { get; set; }

    public bool EncodeSpecialCharacters { get; set; }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (value == null)
      {
        writer.WriteNull();
      }
      else
      {
        IXmlNode node = this.WrapXml(value);
        XmlNamespaceManager manager = new XmlNamespaceManager((XmlNameTable) new NameTable());
        this.PushParentNamespaces(node, manager);
        if (!this.OmitRootObject)
          writer.WriteStartObject();
        this.SerializeNode(writer, node, manager, !this.OmitRootObject);
        if (this.OmitRootObject)
          return;
        writer.WriteEndObject();
      }
    }

    private IXmlNode WrapXml(object value) => value is XObject node ? XContainerWrapper.WrapNode(node) : throw new ArgumentException("Value must be an XML object.", nameof (value));

    private void PushParentNamespaces(IXmlNode node, XmlNamespaceManager manager)
    {
      List<IXmlNode> xmlNodeList = (List<IXmlNode>) null;
      IXmlNode xmlNode1 = node;
      while ((xmlNode1 = xmlNode1.ParentNode) != null)
      {
        if (xmlNode1.NodeType == XmlNodeType.Element)
        {
          if (xmlNodeList == null)
            xmlNodeList = new List<IXmlNode>();
          xmlNodeList.Add(xmlNode1);
        }
      }
      if (xmlNodeList == null)
        return;
      xmlNodeList.Reverse();
      foreach (IXmlNode xmlNode2 in xmlNodeList)
      {
        manager.PushScope();
        foreach (IXmlNode attribute in xmlNode2.Attributes)
        {
          if (attribute.NamespaceUri == "http://www.w3.org/2000/xmlns/" && attribute.LocalName != "xmlns")
            manager.AddNamespace(attribute.LocalName, attribute.Value);
        }
      }
    }

    private string ResolveFullName(IXmlNode node, XmlNamespaceManager manager)
    {
      string str = node.NamespaceUri == null || node.LocalName == "xmlns" && node.NamespaceUri == "http://www.w3.org/2000/xmlns/" ? (string) null : manager.LookupPrefix(node.NamespaceUri);
      return !string.IsNullOrEmpty(str) ? str + ":" + XmlConvert.DecodeName(node.LocalName) : XmlConvert.DecodeName(node.LocalName);
    }

    private string GetPropertyName(IXmlNode node, XmlNamespaceManager manager)
    {
      switch (node.NodeType)
      {
        case XmlNodeType.Element:
          return node.NamespaceUri == "http://james.newtonking.com/projects/json" ? "$" + node.LocalName : this.ResolveFullName(node, manager);
        case XmlNodeType.Attribute:
          return node.NamespaceUri == "http://james.newtonking.com/projects/json" ? "$" + node.LocalName : "@" + this.ResolveFullName(node, manager);
        case XmlNodeType.Text:
          return "#text";
        case XmlNodeType.CDATA:
          return "#cdata-section";
        case XmlNodeType.ProcessingInstruction:
          return "?" + this.ResolveFullName(node, manager);
        case XmlNodeType.Comment:
          return "#comment";
        case XmlNodeType.DocumentType:
          return "!" + this.ResolveFullName(node, manager);
        case XmlNodeType.Whitespace:
          return "#whitespace";
        case XmlNodeType.SignificantWhitespace:
          return "#significant-whitespace";
        case XmlNodeType.XmlDeclaration:
          return "?xml";
        default:
          throw new JsonSerializationException("Unexpected XmlNodeType when getting node name: " + (object) node.NodeType);
      }
    }

    private bool IsArray(IXmlNode node)
    {
      foreach (IXmlNode attribute in node.Attributes)
      {
        if (attribute.LocalName == "Array" && attribute.NamespaceUri == "http://james.newtonking.com/projects/json")
          return XmlConvert.ToBoolean(attribute.Value);
      }
      return false;
    }

    private void SerializeGroupedNodes(
      JsonWriter writer,
      IXmlNode node,
      XmlNamespaceManager manager,
      bool writePropertyName)
    {
      switch (node.ChildNodes.Count)
      {
        case 0:
          break;
        case 1:
          string propertyName1 = this.GetPropertyName(node.ChildNodes[0], manager);
          this.WriteGroupedNodes(writer, manager, writePropertyName, node.ChildNodes, propertyName1);
          break;
        default:
          Dictionary<string, object> dictionary = (Dictionary<string, object>) null;
          string str = (string) null;
          for (int index1 = 0; index1 < node.ChildNodes.Count; ++index1)
          {
            IXmlNode childNode = node.ChildNodes[index1];
            string propertyName2 = this.GetPropertyName(childNode, manager);
            if (dictionary == null)
            {
              if (str == null)
                str = propertyName2;
              else if (!(propertyName2 == str))
              {
                dictionary = new Dictionary<string, object>();
                if (index1 > 1)
                {
                  List<IXmlNode> xmlNodeList = new List<IXmlNode>(index1);
                  for (int index2 = 0; index2 < index1; ++index2)
                    xmlNodeList.Add(node.ChildNodes[index2]);
                  dictionary.Add(str, (object) xmlNodeList);
                }
                else
                  dictionary.Add(str, (object) node.ChildNodes[0]);
                dictionary.Add(propertyName2, (object) childNode);
              }
            }
            else
            {
              object obj;
              if (!dictionary.TryGetValue(propertyName2, out obj))
              {
                dictionary.Add(propertyName2, (object) childNode);
              }
              else
              {
                if (!(obj is List<IXmlNode> xmlNodeList))
                {
                  xmlNodeList = new List<IXmlNode>()
                  {
                    (IXmlNode) obj
                  };
                  dictionary[propertyName2] = (object) xmlNodeList;
                }
                xmlNodeList.Add(childNode);
              }
            }
          }
          if (dictionary == null)
          {
            this.WriteGroupedNodes(writer, manager, writePropertyName, node.ChildNodes, str);
            break;
          }
          using (Dictionary<string, object>.Enumerator enumerator = dictionary.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              KeyValuePair<string, object> current = enumerator.Current;
              if (current.Value is List<IXmlNode> groupedNodes)
                this.WriteGroupedNodes(writer, manager, writePropertyName, groupedNodes, current.Key);
              else
                this.WriteGroupedNodes(writer, manager, writePropertyName, (IXmlNode) current.Value, current.Key);
            }
            break;
          }
      }
    }

    private void WriteGroupedNodes(
      JsonWriter writer,
      XmlNamespaceManager manager,
      bool writePropertyName,
      List<IXmlNode> groupedNodes,
      string elementNames)
    {
      if ((groupedNodes.Count != 1 ? 1 : (this.IsArray(groupedNodes[0]) ? 1 : 0)) == 0)
      {
        this.SerializeNode(writer, groupedNodes[0], manager, writePropertyName);
      }
      else
      {
        if (writePropertyName)
          writer.WritePropertyName(elementNames);
        writer.WriteStartArray();
        for (int index = 0; index < groupedNodes.Count; ++index)
          this.SerializeNode(writer, groupedNodes[index], manager, false);
        writer.WriteEndArray();
      }
    }

    private void WriteGroupedNodes(
      JsonWriter writer,
      XmlNamespaceManager manager,
      bool writePropertyName,
      IXmlNode node,
      string elementNames)
    {
      if (!this.IsArray(node))
      {
        this.SerializeNode(writer, node, manager, writePropertyName);
      }
      else
      {
        if (writePropertyName)
          writer.WritePropertyName(elementNames);
        writer.WriteStartArray();
        this.SerializeNode(writer, node, manager, false);
        writer.WriteEndArray();
      }
    }

    private void SerializeNode(
      JsonWriter writer,
      IXmlNode node,
      XmlNamespaceManager manager,
      bool writePropertyName)
    {
      switch (node.NodeType)
      {
        case XmlNodeType.Element:
          if (this.IsArray(node) && XmlNodeConverter.AllSameName(node) && node.ChildNodes.Count > 0)
          {
            this.SerializeGroupedNodes(writer, node, manager, false);
            break;
          }
          manager.PushScope();
          foreach (IXmlNode attribute in node.Attributes)
          {
            if (attribute.NamespaceUri == "http://www.w3.org/2000/xmlns/")
            {
              string prefix = attribute.LocalName != "xmlns" ? XmlConvert.DecodeName(attribute.LocalName) : string.Empty;
              string uri = attribute.Value;
              manager.AddNamespace(prefix, uri);
            }
          }
          if (writePropertyName)
            writer.WritePropertyName(this.GetPropertyName(node, manager));
          if (!this.ValueAttributes(node.Attributes) && node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)
            writer.WriteValue(node.ChildNodes[0].Value);
          else if (node.ChildNodes.Count == 0 && node.Attributes.Count == 0)
          {
            if (((IXmlElement) node).IsEmpty)
              writer.WriteNull();
            else
              writer.WriteValue(string.Empty);
          }
          else
          {
            writer.WriteStartObject();
            for (int index = 0; index < node.Attributes.Count; ++index)
              this.SerializeNode(writer, node.Attributes[index], manager, true);
            this.SerializeGroupedNodes(writer, node, manager, true);
            writer.WriteEndObject();
          }
          manager.PopScope();
          break;
        case XmlNodeType.Attribute:
        case XmlNodeType.Text:
        case XmlNodeType.CDATA:
        case XmlNodeType.ProcessingInstruction:
        case XmlNodeType.Whitespace:
        case XmlNodeType.SignificantWhitespace:
          if (node.NamespaceUri == "http://www.w3.org/2000/xmlns/" && node.Value == "http://james.newtonking.com/projects/json" || node.NamespaceUri == "http://james.newtonking.com/projects/json" && node.LocalName == "Array")
            break;
          if (writePropertyName)
            writer.WritePropertyName(this.GetPropertyName(node, manager));
          writer.WriteValue(node.Value);
          break;
        case XmlNodeType.Comment:
          if (!writePropertyName)
            break;
          writer.WriteComment(node.Value);
          break;
        case XmlNodeType.Document:
        case XmlNodeType.DocumentFragment:
          this.SerializeGroupedNodes(writer, node, manager, writePropertyName);
          break;
        case XmlNodeType.DocumentType:
          IXmlDocumentType xmlDocumentType = (IXmlDocumentType) node;
          writer.WritePropertyName(this.GetPropertyName(node, manager));
          writer.WriteStartObject();
          if (!string.IsNullOrEmpty(xmlDocumentType.Name))
          {
            writer.WritePropertyName("@name");
            writer.WriteValue(xmlDocumentType.Name);
          }
          if (!string.IsNullOrEmpty(xmlDocumentType.Public))
          {
            writer.WritePropertyName("@public");
            writer.WriteValue(xmlDocumentType.Public);
          }
          if (!string.IsNullOrEmpty(xmlDocumentType.System))
          {
            writer.WritePropertyName("@system");
            writer.WriteValue(xmlDocumentType.System);
          }
          if (!string.IsNullOrEmpty(xmlDocumentType.InternalSubset))
          {
            writer.WritePropertyName("@internalSubset");
            writer.WriteValue(xmlDocumentType.InternalSubset);
          }
          writer.WriteEndObject();
          break;
        case XmlNodeType.XmlDeclaration:
          IXmlDeclaration xmlDeclaration = (IXmlDeclaration) node;
          writer.WritePropertyName(this.GetPropertyName(node, manager));
          writer.WriteStartObject();
          if (!string.IsNullOrEmpty(xmlDeclaration.Version))
          {
            writer.WritePropertyName("@version");
            writer.WriteValue(xmlDeclaration.Version);
          }
          if (!string.IsNullOrEmpty(xmlDeclaration.Encoding))
          {
            writer.WritePropertyName("@encoding");
            writer.WriteValue(xmlDeclaration.Encoding);
          }
          if (!string.IsNullOrEmpty(xmlDeclaration.Standalone))
          {
            writer.WritePropertyName("@standalone");
            writer.WriteValue(xmlDeclaration.Standalone);
          }
          writer.WriteEndObject();
          break;
        default:
          throw new JsonSerializationException("Unexpected XmlNodeType when serializing nodes: " + (object) node.NodeType);
      }
    }

    private static bool AllSameName(IXmlNode node)
    {
      foreach (IXmlNode childNode in node.ChildNodes)
      {
        if (childNode.LocalName != node.LocalName)
          return false;
      }
      return true;
    }

    public override object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer)
    {
      switch (reader.TokenType)
      {
        case JsonToken.StartObject:
          XmlNamespaceManager manager = new XmlNamespaceManager((XmlNameTable) new NameTable());
          IXmlDocument document = (IXmlDocument) null;
          IXmlNode currentNode = (IXmlNode) null;
          if (typeof (XObject).IsAssignableFrom(objectType))
          {
            if (objectType != typeof (XContainer) && objectType != typeof (XDocument) && objectType != typeof (XElement) && objectType != typeof (XNode) && objectType != typeof (XObject))
              throw JsonSerializationException.Create(reader, "XmlNodeConverter only supports deserializing XDocument, XElement, XContainer, XNode or XObject.");
            document = (IXmlDocument) new XDocumentWrapper(new XDocument());
            currentNode = (IXmlNode) document;
          }
          if (document == null || currentNode == null)
            throw JsonSerializationException.Create(reader, "Unexpected type when converting XML: " + (object) objectType);
          if (!string.IsNullOrEmpty(this.DeserializeRootElementName))
          {
            this.ReadElement(reader, document, currentNode, this.DeserializeRootElementName, manager);
          }
          else
          {
            reader.ReadAndAssert();
            this.DeserializeNode(reader, document, manager, currentNode);
          }
          if (objectType != typeof (XElement))
            return document.WrappedNode;
          XElement wrappedNode = (XElement) document.DocumentElement.WrappedNode;
          wrappedNode.Remove();
          return (object) wrappedNode;
        case JsonToken.Null:
          return (object) null;
        default:
          throw JsonSerializationException.Create(reader, "XmlNodeConverter can only convert JSON that begins with an object.");
      }
    }

    private void DeserializeValue(
      JsonReader reader,
      IXmlDocument document,
      XmlNamespaceManager manager,
      string propertyName,
      IXmlNode currentNode)
    {
      if (!this.EncodeSpecialCharacters)
      {
        switch (propertyName)
        {
          case "#text":
            currentNode.AppendChild(document.CreateTextNode(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
            return;
          case "#cdata-section":
            currentNode.AppendChild(document.CreateCDataSection(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
            return;
          case "#whitespace":
            currentNode.AppendChild(document.CreateWhitespace(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
            return;
          case "#significant-whitespace":
            currentNode.AppendChild(document.CreateSignificantWhitespace(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
            return;
          default:
            if (!string.IsNullOrEmpty(propertyName) && propertyName[0] == '?')
            {
              this.CreateInstruction(reader, document, currentNode, propertyName);
              return;
            }
            break;
        }
      }
      if (reader.TokenType == JsonToken.StartArray)
        this.ReadArrayElements(reader, document, propertyName, currentNode, manager);
      else
        this.ReadElement(reader, document, currentNode, propertyName, manager);
    }

    private void ReadElement(
      JsonReader reader,
      IXmlDocument document,
      IXmlNode currentNode,
      string propertyName,
      XmlNamespaceManager manager)
    {
      if (string.IsNullOrEmpty(propertyName))
        throw JsonSerializationException.Create(reader, "XmlNodeConverter cannot convert JSON with an empty property name to XML.");
      Dictionary<string, string> attributeNameValues = (Dictionary<string, string>) null;
      string elementPrefix1 = (string) null;
      if (!this.EncodeSpecialCharacters)
      {
        attributeNameValues = this.ShouldReadInto(reader) ? this.ReadAttributeElements(reader, manager) : (Dictionary<string, string>) null;
        elementPrefix1 = MiscellaneousUtils.GetPrefix(propertyName);
        if (propertyName.StartsWith('@'))
        {
          string str = propertyName.Substring(1);
          string prefix = MiscellaneousUtils.GetPrefix(str);
          XmlNodeConverter.AddAttribute(reader, document, currentNode, propertyName, str, manager, prefix);
          return;
        }
        if (propertyName.StartsWith('$'))
        {
          switch (propertyName)
          {
            case "$values":
              propertyName = propertyName.Substring(1);
              string elementPrefix2 = manager.LookupPrefix("http://james.newtonking.com/projects/json");
              this.CreateElement(reader, document, currentNode, propertyName, manager, elementPrefix2, attributeNameValues);
              return;
            case "$id":
            case "$ref":
            case "$type":
            case "$value":
              string attributeName = propertyName.Substring(1);
              string attributePrefix = manager.LookupPrefix("http://james.newtonking.com/projects/json");
              XmlNodeConverter.AddAttribute(reader, document, currentNode, propertyName, attributeName, manager, attributePrefix);
              return;
          }
        }
      }
      else if (this.ShouldReadInto(reader))
        reader.ReadAndAssert();
      this.CreateElement(reader, document, currentNode, propertyName, manager, elementPrefix1, attributeNameValues);
    }

    private void CreateElement(
      JsonReader reader,
      IXmlDocument document,
      IXmlNode currentNode,
      string elementName,
      XmlNamespaceManager manager,
      string elementPrefix,
      Dictionary<string, string> attributeNameValues)
    {
      IXmlElement element = this.CreateElement(elementName, document, elementPrefix, manager);
      currentNode.AppendChild((IXmlNode) element);
      if (attributeNameValues != null)
      {
        foreach (KeyValuePair<string, string> attributeNameValue in attributeNameValues)
        {
          string str = XmlConvert.EncodeName(attributeNameValue.Key);
          string prefix = MiscellaneousUtils.GetPrefix(attributeNameValue.Key);
          IXmlNode attribute = !string.IsNullOrEmpty(prefix) ? document.CreateAttribute(str, manager.LookupNamespace(prefix) ?? string.Empty, attributeNameValue.Value) : document.CreateAttribute(str, attributeNameValue.Value);
          element.SetAttributeNode(attribute);
        }
      }
      switch (reader.TokenType)
      {
        case JsonToken.Integer:
        case JsonToken.Float:
        case JsonToken.String:
        case JsonToken.Boolean:
        case JsonToken.Date:
        case JsonToken.Bytes:
          string xmlValue = XmlNodeConverter.ConvertTokenToXmlValue(reader);
          if (xmlValue == null)
            break;
          element.AppendChild(document.CreateTextNode(xmlValue));
          break;
        case JsonToken.Null:
          break;
        case JsonToken.EndObject:
          manager.RemoveNamespace(string.Empty, manager.DefaultNamespace);
          break;
        default:
          manager.PushScope();
          this.DeserializeNode(reader, document, manager, (IXmlNode) element);
          manager.PopScope();
          manager.RemoveNamespace(string.Empty, manager.DefaultNamespace);
          break;
      }
    }

    private static void AddAttribute(
      JsonReader reader,
      IXmlDocument document,
      IXmlNode currentNode,
      string propertyName,
      string attributeName,
      XmlNamespaceManager manager,
      string attributePrefix)
    {
      if (currentNode.NodeType == XmlNodeType.Document)
        throw JsonSerializationException.Create(reader, "JSON root object has property '{0}' that will be converted to an attribute. A root object cannot have any attribute properties. Consider specifying a DeserializeRootElementName.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) propertyName));
      string str = XmlConvert.EncodeName(attributeName);
      string xmlValue = XmlNodeConverter.ConvertTokenToXmlValue(reader);
      IXmlNode attribute = !string.IsNullOrEmpty(attributePrefix) ? document.CreateAttribute(str, manager.LookupNamespace(attributePrefix), xmlValue) : document.CreateAttribute(str, xmlValue);
      ((IXmlElement) currentNode).SetAttributeNode(attribute);
    }

    private static string ConvertTokenToXmlValue(JsonReader reader)
    {
      switch (reader.TokenType)
      {
        case JsonToken.Integer:
          return XmlConvert.ToString(Convert.ToInt64(reader.Value, (IFormatProvider) CultureInfo.InvariantCulture));
        case JsonToken.Float:
          if (reader.Value is Decimal num)
            return XmlConvert.ToString(num);
          object obj;
          return (obj = reader.Value) is float ? XmlConvert.ToString((float) obj) : XmlConvert.ToString(Convert.ToDouble(reader.Value, (IFormatProvider) CultureInfo.InvariantCulture));
        case JsonToken.String:
          return reader.Value?.ToString();
        case JsonToken.Boolean:
          return XmlConvert.ToString(Convert.ToBoolean(reader.Value, (IFormatProvider) CultureInfo.InvariantCulture));
        case JsonToken.Null:
          return (string) null;
        case JsonToken.Date:
          if (reader.Value is DateTimeOffset dateTimeOffset)
            return XmlConvert.ToString(dateTimeOffset);
          DateTime dateTime = Convert.ToDateTime(reader.Value, (IFormatProvider) CultureInfo.InvariantCulture);
          return dateTime.ToString(DateTimeUtils.ToDateTimeFormat(dateTime.Kind), (IFormatProvider) CultureInfo.InvariantCulture);
        case JsonToken.Bytes:
          return Convert.ToBase64String((byte[]) reader.Value);
        default:
          throw JsonSerializationException.Create(reader, "Cannot get an XML string value from token type '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
      }
    }

    private void ReadArrayElements(
      JsonReader reader,
      IXmlDocument document,
      string propertyName,
      IXmlNode currentNode,
      XmlNamespaceManager manager)
    {
      string prefix = MiscellaneousUtils.GetPrefix(propertyName);
      IXmlElement element1 = this.CreateElement(propertyName, document, prefix, manager);
      currentNode.AppendChild((IXmlNode) element1);
      int num = 0;
      while (reader.Read() && reader.TokenType != JsonToken.EndArray)
      {
        this.DeserializeValue(reader, document, manager, propertyName, (IXmlNode) element1);
        ++num;
      }
      if (this.WriteArrayAttribute)
        this.AddJsonArrayAttribute(element1, document);
      if (num != 1 || !this.WriteArrayAttribute)
        return;
      foreach (IXmlNode childNode in element1.ChildNodes)
      {
        if (childNode is IXmlElement element2 && element2.LocalName == propertyName)
        {
          this.AddJsonArrayAttribute(element2, document);
          break;
        }
      }
    }

    private void AddJsonArrayAttribute(IXmlElement element, IXmlDocument document)
    {
      element.SetAttributeNode(document.CreateAttribute("json:Array", "http://james.newtonking.com/projects/json", "true"));
      if (!(element is XElementWrapper) || element.GetPrefixOfNamespace("http://james.newtonking.com/projects/json") != null)
        return;
      element.SetAttributeNode(document.CreateAttribute("xmlns:json", "http://www.w3.org/2000/xmlns/", "http://james.newtonking.com/projects/json"));
    }

    private bool ShouldReadInto(JsonReader reader)
    {
      switch (reader.TokenType)
      {
        case JsonToken.StartConstructor:
        case JsonToken.Integer:
        case JsonToken.Float:
        case JsonToken.String:
        case JsonToken.Boolean:
        case JsonToken.Null:
        case JsonToken.Date:
        case JsonToken.Bytes:
          return false;
        default:
          return true;
      }
    }

    private Dictionary<string, string> ReadAttributeElements(
      JsonReader reader,
      XmlNamespaceManager manager)
    {
      Dictionary<string, string> dictionary = (Dictionary<string, string>) null;
      bool flag = false;
      while (!flag && reader.Read())
      {
        switch (reader.TokenType)
        {
          case JsonToken.PropertyName:
            string str1 = reader.Value.ToString();
            if (!string.IsNullOrEmpty(str1))
            {
              switch (str1[0])
              {
                case '$':
                  if (str1 == "$values" || str1 == "$id" || str1 == "$ref" || str1 == "$type" || str1 == "$value")
                  {
                    string prefix = manager.LookupPrefix("http://james.newtonking.com/projects/json");
                    if (prefix == null)
                    {
                      if (dictionary == null)
                        dictionary = new Dictionary<string, string>();
                      int? nullable = new int?();
                      while (manager.LookupNamespace("json" + (object) nullable) != null)
                        nullable = new int?(nullable.GetValueOrDefault() + 1);
                      prefix = "json" + (object) nullable;
                      dictionary.Add("xmlns:" + prefix, "http://james.newtonking.com/projects/json");
                      manager.AddNamespace(prefix, "http://james.newtonking.com/projects/json");
                    }
                    if (str1 == "$values")
                    {
                      flag = true;
                      continue;
                    }
                    string str2 = str1.Substring(1);
                    reader.ReadAndAssert();
                    if (!JsonTokenUtils.IsPrimitiveToken(reader.TokenType))
                      throw JsonSerializationException.Create(reader, "Unexpected JsonToken: " + (object) reader.TokenType);
                    if (dictionary == null)
                      dictionary = new Dictionary<string, string>();
                    string str3 = reader.Value?.ToString();
                    dictionary.Add(prefix + ":" + str2, str3);
                    continue;
                  }
                  flag = true;
                  continue;
                case '@':
                  if (dictionary == null)
                    dictionary = new Dictionary<string, string>();
                  string str4 = str1.Substring(1);
                  reader.ReadAndAssert();
                  string xmlValue = XmlNodeConverter.ConvertTokenToXmlValue(reader);
                  dictionary.Add(str4, xmlValue);
                  string prefix1;
                  if (this.IsNamespaceAttribute(str4, out prefix1))
                  {
                    manager.AddNamespace(prefix1, xmlValue);
                    continue;
                  }
                  continue;
                default:
                  flag = true;
                  continue;
              }
            }
            else
            {
              flag = true;
              continue;
            }
          case JsonToken.Comment:
          case JsonToken.EndObject:
            flag = true;
            continue;
          default:
            throw JsonSerializationException.Create(reader, "Unexpected JsonToken: " + (object) reader.TokenType);
        }
      }
      return dictionary;
    }

    private void CreateInstruction(
      JsonReader reader,
      IXmlDocument document,
      IXmlNode currentNode,
      string propertyName)
    {
      if (propertyName == "?xml")
      {
        string version = (string) null;
        string encoding = (string) null;
        string standalone = (string) null;
        while (reader.Read() && reader.TokenType != JsonToken.EndObject)
        {
          switch (reader.Value.ToString())
          {
            case "@version":
              reader.ReadAndAssert();
              version = XmlNodeConverter.ConvertTokenToXmlValue(reader);
              continue;
            case "@encoding":
              reader.ReadAndAssert();
              encoding = XmlNodeConverter.ConvertTokenToXmlValue(reader);
              continue;
            case "@standalone":
              reader.ReadAndAssert();
              standalone = XmlNodeConverter.ConvertTokenToXmlValue(reader);
              continue;
            default:
              throw JsonSerializationException.Create(reader, "Unexpected property name encountered while deserializing XmlDeclaration: " + reader.Value);
          }
        }
        IXmlNode xmlDeclaration = document.CreateXmlDeclaration(version, encoding, standalone);
        currentNode.AppendChild(xmlDeclaration);
      }
      else
      {
        IXmlNode processingInstruction = document.CreateProcessingInstruction(propertyName.Substring(1), XmlNodeConverter.ConvertTokenToXmlValue(reader));
        currentNode.AppendChild(processingInstruction);
      }
    }

    private IXmlElement CreateElement(
      string elementName,
      IXmlDocument document,
      string elementPrefix,
      XmlNamespaceManager manager)
    {
      string str = this.EncodeSpecialCharacters ? XmlConvert.EncodeLocalName(elementName) : XmlConvert.EncodeName(elementName);
      string namespaceUri = string.IsNullOrEmpty(elementPrefix) ? manager.DefaultNamespace : manager.LookupNamespace(elementPrefix);
      return string.IsNullOrEmpty(namespaceUri) ? document.CreateElement(str) : document.CreateElement(str, namespaceUri);
    }

    private void DeserializeNode(
      JsonReader reader,
      IXmlDocument document,
      XmlNamespaceManager manager,
      IXmlNode currentNode)
    {
      do
      {
        switch (reader.TokenType)
        {
          case JsonToken.StartConstructor:
            string propertyName = reader.Value.ToString();
            while (reader.Read() && reader.TokenType != JsonToken.EndConstructor)
              this.DeserializeValue(reader, document, manager, propertyName, currentNode);
            break;
          case JsonToken.PropertyName:
            if (currentNode.NodeType == XmlNodeType.Document && document.DocumentElement != null)
              throw JsonSerializationException.Create(reader, "JSON root object has multiple properties. The root object must have a single property in order to create a valid XML document. Consider specifying a DeserializeRootElementName.");
            string str1 = reader.Value.ToString();
            reader.ReadAndAssert();
            if (reader.TokenType == JsonToken.StartArray)
            {
              int num = 0;
              while (reader.Read() && reader.TokenType != JsonToken.EndArray)
              {
                this.DeserializeValue(reader, document, manager, str1, currentNode);
                ++num;
              }
              if (num == 1 && this.WriteArrayAttribute)
              {
                string prefix;
                string localName;
                MiscellaneousUtils.GetQualifiedNameParts(str1, out prefix, out localName);
                string str2 = string.IsNullOrEmpty(prefix) ? manager.DefaultNamespace : manager.LookupNamespace(prefix);
                using (List<IXmlNode>.Enumerator enumerator = currentNode.ChildNodes.GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    if (enumerator.Current is IXmlElement current && current.LocalName == localName && current.NamespaceUri == str2)
                    {
                      this.AddJsonArrayAttribute(current, document);
                      break;
                    }
                  }
                  break;
                }
              }
              else
                break;
            }
            else
            {
              this.DeserializeValue(reader, document, manager, str1, currentNode);
              break;
            }
          case JsonToken.Comment:
            currentNode.AppendChild(document.CreateComment((string) reader.Value));
            break;
          case JsonToken.EndObject:
          case JsonToken.EndArray:
            return;
          default:
            throw JsonSerializationException.Create(reader, "Unexpected JsonToken when deserializing node: " + (object) reader.TokenType);
        }
      }
      while (reader.Read());
    }

    private bool IsNamespaceAttribute(string attributeName, out string prefix)
    {
      if (attributeName.StartsWith("xmlns", StringComparison.Ordinal))
      {
        if (attributeName.Length == 5)
        {
          prefix = string.Empty;
          return true;
        }
        if (attributeName[5] == ':')
        {
          prefix = attributeName.Substring(6, attributeName.Length - 6);
          return true;
        }
      }
      prefix = (string) null;
      return false;
    }

    private bool ValueAttributes(List<IXmlNode> c)
    {
      foreach (IXmlNode xmlNode in c)
      {
        if (!(xmlNode.NamespaceUri == "http://james.newtonking.com/projects/json") && (!(xmlNode.NamespaceUri == "http://www.w3.org/2000/xmlns/") || !(xmlNode.Value == "http://james.newtonking.com/projects/json")))
          return true;
      }
      return false;
    }

    public override bool CanConvert(Type valueType) => valueType.AssignableToTypeName("System.Xml.Linq.XObject", false) && this.IsXObject(valueType);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool IsXObject(Type valueType) => typeof (XObject).IsAssignableFrom(valueType);
  }
}
