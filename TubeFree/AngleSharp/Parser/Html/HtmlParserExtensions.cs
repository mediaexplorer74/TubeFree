// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlParserExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AngleSharp.Parser.Html
{
  internal static class HtmlParserExtensions
  {
    public static void SetAttributes(
      this Element element,
      List<KeyValuePair<string, string>> attributes)
    {
      NamedNodeMap attributes1 = element.Attributes;
      for (int index = 0; index < attributes.Count; ++index)
      {
        KeyValuePair<string, string> attribute = attributes[index];
        Attr attr = new Attr(attribute.Key, attribute.Value);
        attributes1.FastAddItem(attr);
      }
    }

    public static HtmlTreeMode? SelectMode(
      this Element element,
      bool isLast,
      Stack<HtmlTreeMode> templateModes)
    {
      string localName = element.LocalName;
      if (localName.Is(TagNames.Select))
        return new HtmlTreeMode?(HtmlTreeMode.InSelect);
      if (TagNames.AllTableCells.Contains(localName))
        return new HtmlTreeMode?(isLast ? HtmlTreeMode.InBody : HtmlTreeMode.InCell);
      if (localName.Is(TagNames.Tr))
        return new HtmlTreeMode?(HtmlTreeMode.InRow);
      if (TagNames.AllTableSections.Contains(localName))
        return new HtmlTreeMode?(HtmlTreeMode.InTableBody);
      if (localName.Is(TagNames.Body))
        return new HtmlTreeMode?(HtmlTreeMode.InBody);
      if (localName.Is(TagNames.Table))
        return new HtmlTreeMode?(HtmlTreeMode.InTable);
      if (localName.Is(TagNames.Caption))
        return new HtmlTreeMode?(HtmlTreeMode.InCaption);
      if (localName.Is(TagNames.Colgroup))
        return new HtmlTreeMode?(HtmlTreeMode.InColumnGroup);
      if (localName.Is(TagNames.Template))
        return new HtmlTreeMode?(templateModes.Peek());
      if (localName.Is(TagNames.Html))
        return new HtmlTreeMode?(HtmlTreeMode.BeforeHead);
      if (localName.Is(TagNames.Head))
        return new HtmlTreeMode?(isLast ? HtmlTreeMode.InBody : HtmlTreeMode.InHead);
      if (localName.Is(TagNames.Frameset))
        return new HtmlTreeMode?(HtmlTreeMode.InFrameset);
      return isLast ? new HtmlTreeMode?(HtmlTreeMode.InBody) : new HtmlTreeMode?();
    }

    public static int GetCode(this HtmlParseError code) => (int) code;

    public static void SetUniqueAttributes(
      this Element element,
      List<KeyValuePair<string, string>> attributes)
    {
      for (int index = attributes.Count - 1; index >= 0; --index)
      {
        if (element.HasAttribute(attributes[index].Key))
          attributes.RemoveAt(index);
      }
      element.SetAttributes(attributes);
    }

    public static void AddFormatting(this List<Element> formatting, Element element)
    {
      int num = 0;
      for (int index = formatting.Count - 1; index >= 0; --index)
      {
        Element element1 = formatting[index];
        if (element1 != null)
        {
          if (element1.NodeName.Is(element.NodeName) && element1.NamespaceUri.Is(element.NamespaceUri) && element1.Attributes.AreEqual((INamedNodeMap) element.Attributes) && ++num == 3)
          {
            formatting.RemoveAt(index);
            break;
          }
        }
        else
          break;
      }
      formatting.Add(element);
    }

    public static void ClearFormatting(this List<Element> formatting)
    {
      while (formatting.Count != 0)
      {
        int index = formatting.Count - 1;
        Element element = formatting[index];
        formatting.RemoveAt(index);
        if (element == null)
          break;
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddScopeMarker(this List<Element> formatting) => formatting.Add((Element) null);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddComment(this Node parent, HtmlToken token) => parent.AddNode((Node) new Comment(parent.Owner, token.Data));

    public static QuirksMode GetQuirksMode(this HtmlDoctypeToken doctype)
    {
      if (doctype.IsFullQuirks)
        return QuirksMode.On;
      return doctype.IsLimitedQuirks ? QuirksMode.Limited : QuirksMode.Off;
    }
  }
}
