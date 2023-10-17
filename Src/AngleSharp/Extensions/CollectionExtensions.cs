// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.CollectionExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Html;
using System;
using System.Collections.Generic;

namespace AngleSharp.Extensions
{
  internal static class CollectionExtensions
  {
    public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T element)
    {
      foreach (T obj in items)
        yield return obj;
      yield return element;
    }

    public static IEnumerable<T> GetElements<T>(
      this INode parent,
      bool deep = true,
      Predicate<T> predicate = null)
      where T : class, INode
    {
      predicate = predicate ?? (Predicate<T>) (m => true);
      return !deep ? parent.GetDescendendElements<T>(predicate) : parent.GetAllElements<T>(predicate);
    }

    public static T GetItemByIndex<T>(this IEnumerable<T> items, int index)
    {
      if (index >= 0)
      {
        int num = 0;
        foreach (T itemByIndex in items)
        {
          if (num++ == index)
            return itemByIndex;
        }
      }
      throw new ArgumentOutOfRangeException(nameof (index));
    }

    public static IElement GetElementById(this INodeList children, string id)
    {
      for (int index = 0; index < children.Length; ++index)
      {
        if (children[index] is IElement child)
        {
          if (child.Id.Is(id))
            return child;
          IElement elementById = child.ChildNodes.GetElementById(id);
          if (elementById != null)
            return elementById;
        }
      }
      return (IElement) null;
    }

    public static void GetElementsByName(
      this INodeList children,
      string name,
      List<IElement> result)
    {
      for (int index = 0; index < children.Length; ++index)
      {
        if (children[index] is IElement child)
        {
          if (child.GetAttribute((string) null, AttributeNames.Name).Is(name))
            result.Add(child);
          child.ChildNodes.GetElementsByName(name, result);
        }
      }
    }

    public static bool Accepts(this FilterSettings filter, INode node)
    {
      switch (node.NodeType)
      {
        case NodeType.Element:
          return (filter & FilterSettings.Element) == FilterSettings.Element;
        case NodeType.Attribute:
          return (filter & FilterSettings.Attribute) == FilterSettings.Attribute;
        case NodeType.Text:
          return (filter & FilterSettings.Text) == FilterSettings.Text;
        case NodeType.CharacterData:
          return (filter & FilterSettings.CharacterData) == FilterSettings.CharacterData;
        case NodeType.EntityReference:
          return (filter & FilterSettings.EntityReference) == FilterSettings.EntityReference;
        case NodeType.Entity:
          return (filter & FilterSettings.Entity) == FilterSettings.Entity;
        case NodeType.ProcessingInstruction:
          return (filter & FilterSettings.ProcessingInstruction) == FilterSettings.ProcessingInstruction;
        case NodeType.Comment:
          return (filter & FilterSettings.Comment) == FilterSettings.Comment;
        case NodeType.Document:
          return (filter & FilterSettings.Document) == FilterSettings.Document;
        case NodeType.DocumentType:
          return (filter & FilterSettings.DocumentType) == FilterSettings.DocumentType;
        case NodeType.DocumentFragment:
          return (filter & FilterSettings.DocumentFragment) == FilterSettings.DocumentFragment;
        case NodeType.Notation:
          return (filter & FilterSettings.Notation) == FilterSettings.Notation;
        default:
          return filter == FilterSettings.All;
      }
    }

    public static IEnumerable<T> GetElements<T>(this INode parent, FilterSettings filter) where T : class, INode => parent.GetElements<T>(predicate: (Predicate<T>) (node => filter.Accepts((INode) node)));

    public static T GetElementById<T>(this IEnumerable<T> elements, string id) where T : class, IElement
    {
      foreach (T element in elements)
      {
        if (element.Id.Is(id))
          return element;
      }
      foreach (T element in elements)
      {
        if (element.GetAttribute((string) null, AttributeNames.Name).Is(id))
          return element;
      }
      return default (T);
    }

    private static IEnumerable<T> GetAllElements<T>(this INode parent, Predicate<T> predicate) where T : class, INode
    {
      for (int i = 0; i < parent.ChildNodes.Length; ++i)
      {
        if (parent.ChildNodes[i] is T childNode && predicate(childNode))
          yield return childNode;
        foreach (T allElement in parent.ChildNodes[i].GetAllElements<T>(predicate))
          yield return allElement;
      }
    }

    private static IEnumerable<T> GetDescendendElements<T>(
      this INode parent,
      Predicate<T> predicate)
      where T : class, INode
    {
      for (int i = 0; i < parent.ChildNodes.Length; ++i)
      {
        if (parent.ChildNodes[i] is T childNode && predicate(childNode))
          yield return childNode;
      }
    }
  }
}
