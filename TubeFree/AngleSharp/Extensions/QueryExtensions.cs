// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.QueryExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System.Collections.Generic;

namespace AngleSharp.Extensions
{
  internal static class QueryExtensions
  {
    public static IElement QuerySelector(this INodeList elements, string selectors)
    {
      ISelector selector = CssParser.Default.ParseSelector(selectors);
      QueryExtensions.Validate(selector);
      return elements.QuerySelector(selector);
    }

    public static HtmlCollection<IElement> QuerySelectorAll(
      this INodeList elements,
      string selectors)
    {
      ISelector selector = CssParser.Default.ParseSelector(selectors);
      QueryExtensions.Validate(selector);
      List<IElement> result = new List<IElement>();
      elements.QuerySelectorAll(selector, result);
      return new HtmlCollection<IElement>((IEnumerable<IElement>) result);
    }

    public static HtmlCollection<IElement> GetElementsByClassName(
      this INodeList elements,
      string classNames)
    {
      List<IElement> result = new List<IElement>();
      string[] classNames1 = classNames.SplitSpaces();
      if (classNames1.Length != 0)
        elements.GetElementsByClassName(classNames1, result);
      return new HtmlCollection<IElement>((IEnumerable<IElement>) result);
    }

    public static HtmlCollection<IElement> GetElementsByTagName(
      this INodeList elements,
      string tagName)
    {
      List<IElement> result = new List<IElement>();
      elements.GetElementsByTagName(tagName.Is(Keywords.Asterisk) ? (string) null : tagName, result);
      return new HtmlCollection<IElement>((IEnumerable<IElement>) result);
    }

    public static HtmlCollection<IElement> GetElementsByTagName(
      this INodeList elements,
      string namespaceUri,
      string localName)
    {
      List<IElement> result = new List<IElement>();
      elements.GetElementsByTagName(namespaceUri, localName.Is(Keywords.Asterisk) ? (string) null : localName, result);
      return new HtmlCollection<IElement>((IEnumerable<IElement>) result);
    }

    public static T QuerySelector<T>(this INodeList elements, ISelector selectors) where T : class, IElement => elements.QuerySelector(selectors) as T;

    public static IElement QuerySelector(this INodeList elements, ISelector selector)
    {
      for (int index = 0; index < elements.Length; ++index)
      {
        if (elements[index] is IElement element1)
        {
          if (selector.Match(element1))
            return element1;
          if (element1.HasChildNodes)
          {
            IElement element = element1.ChildNodes.QuerySelector(selector);
            if (element != null)
              return element;
          }
        }
      }
      return (IElement) null;
    }

    public static HtmlCollection<IElement> QuerySelectorAll(
      this INodeList elements,
      ISelector selector)
    {
      List<IElement> result = new List<IElement>();
      elements.QuerySelectorAll(selector, result);
      return new HtmlCollection<IElement>((IEnumerable<IElement>) result);
    }

    public static void QuerySelectorAll(
      this INodeList elements,
      ISelector selector,
      List<IElement> result)
    {
      for (int index = 0; index < elements.Length; ++index)
      {
        if (elements[index] is IElement element1)
        {
          foreach (IElement element in element1.DescendentsAndSelf<IElement>())
          {
            if (selector.Match(element))
              result.Add(element);
          }
        }
      }
    }

    public static bool Contains(this ITokenList list, string[] tokens)
    {
      for (int index = 0; index < tokens.Length; ++index)
      {
        if (!list.Contains(tokens[index]))
          return false;
      }
      return true;
    }

    public static void GetElementsByClassName(
      this INodeList elements,
      string[] classNames,
      List<IElement> result)
    {
      for (int index = 0; index < elements.Length; ++index)
      {
        if (elements[index] is IElement element)
        {
          if (element.ClassList.Contains(classNames))
            result.Add(element);
          if (element.ChildElementCount != 0)
            element.ChildNodes.GetElementsByClassName(classNames, result);
        }
      }
    }

    public static void GetElementsByTagName(
      this INodeList elements,
      string tagName,
      List<IElement> result)
    {
      for (int index = 0; index < elements.Length; ++index)
      {
        if (elements[index] is IElement element)
        {
          if (tagName == null || tagName.Isi(element.LocalName))
            result.Add(element);
          if (element.ChildElementCount != 0)
            element.ChildNodes.GetElementsByTagName(tagName, result);
        }
      }
    }

    public static void GetElementsByTagName(
      this INodeList elements,
      string namespaceUri,
      string localName,
      List<IElement> result)
    {
      for (int index = 0; index < elements.Length; ++index)
      {
        if (elements[index] is IElement element)
        {
          if (element.NamespaceUri.Is(namespaceUri) && (localName == null || localName.Isi(element.LocalName)))
            result.Add(element);
          if (element.ChildElementCount != 0)
            element.ChildNodes.GetElementsByTagName(namespaceUri, localName, result);
        }
      }
    }

    private static void Validate(ISelector selector)
    {
      switch (selector)
      {
        case null:
        case UnknownSelector _:
          throw new DomException(DomError.Syntax);
      }
    }
  }
}
