// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.SelectorExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Css;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  public static class SelectorExtensions
  {
    public static IEnumerable<T> Is<T>(this IEnumerable<T> elements, string selectorText) where T : IElement => elements.Filter<T>(selectorText, true);

    public static IEnumerable<T> Not<T>(this IEnumerable<T> elements, string selectorText) where T : IElement => elements.Filter<T>(selectorText, false);

    public static IEnumerable<IElement> Children(
      this IEnumerable<IElement> elements,
      string selectorText = null)
    {
      return elements.GetMany((Func<IElement, IEnumerable<IElement>>) (m => (IEnumerable<IElement>) m.Children), selectorText);
    }

    public static IEnumerable<IElement> Siblings(
      this IEnumerable<IElement> elements,
      string selectorText = null)
    {
      return elements.GetMany((Func<IElement, IEnumerable<IElement>>) (m => m.Parent.ChildNodes.OfType<IElement>().Except(m)), selectorText);
    }

    public static IEnumerable<IElement> Parent(
      this IEnumerable<IElement> elements,
      string selectorText = null)
    {
      return elements.Get((Func<IElement, IElement>) (m => m.ParentElement), selectorText);
    }

    public static IEnumerable<IElement> Next(
      this IEnumerable<IElement> elements,
      string selectorText = null)
    {
      return elements.Get((Func<IElement, IElement>) (m => m.NextElementSibling), selectorText);
    }

    public static IEnumerable<IElement> Previous(
      this IEnumerable<IElement> elements,
      string selectorText = null)
    {
      return elements.Get((Func<IElement, IElement>) (m => m.PreviousElementSibling), selectorText);
    }

    public static IEnumerable<T> Is<T>(this IEnumerable<T> elements, ISelector selector) where T : IElement => elements.Filter<T>(selector, true);

    public static IEnumerable<T> Not<T>(this IEnumerable<T> elements, ISelector selector) where T : IElement => elements.Filter<T>(selector, false);

    public static IEnumerable<IElement> Children(
      this IEnumerable<IElement> elements,
      ISelector selector = null)
    {
      return elements.GetMany((Func<IElement, IEnumerable<IElement>>) (m => (IEnumerable<IElement>) m.Children), selector);
    }

    public static IEnumerable<IElement> Siblings(
      this IEnumerable<IElement> elements,
      ISelector selector = null)
    {
      return elements.GetMany((Func<IElement, IEnumerable<IElement>>) (m => m.Parent.ChildNodes.OfType<IElement>().Except(m)), selector);
    }

    public static IEnumerable<IElement> Parent(
      this IEnumerable<IElement> elements,
      ISelector selector = null)
    {
      return elements.Get((Func<IElement, IElement>) (m => m.ParentElement), selector);
    }

    public static IEnumerable<IElement> Next(
      this IEnumerable<IElement> elements,
      ISelector selector = null)
    {
      return elements.Get((Func<IElement, IElement>) (m => m.NextElementSibling), selector);
    }

    public static IEnumerable<IElement> Previous(
      this IEnumerable<IElement> elements,
      ISelector selector = null)
    {
      return elements.Get((Func<IElement, IElement>) (m => m.PreviousElementSibling), selector);
    }

    private static IEnumerable<IElement> GetMany(
      this IEnumerable<IElement> elements,
      Func<IElement, IEnumerable<IElement>> getter,
      ISelector selector)
    {
      if (selector == null)
        selector = (ISelector) SimpleSelector.All;
      foreach (IElement element1 in elements)
      {
        foreach (IElement element2 in getter(element1))
        {
          if (selector.Match(element2))
            yield return element2;
        }
      }
    }

    private static IEnumerable<IElement> GetMany(
      this IEnumerable<IElement> elements,
      Func<IElement, IEnumerable<IElement>> getter,
      string selectorText)
    {
      if (selectorText == null)
        return elements.GetMany(getter, (ISelector) SimpleSelector.All);
      ISelector selector = SelectorExtensions.CreateSelector(selectorText);
      return elements.GetMany(getter, selector);
    }

    private static IEnumerable<IElement> Get(
      this IEnumerable<IElement> elements,
      Func<IElement, IElement> getter,
      ISelector selector)
    {
      if (selector == null)
        selector = (ISelector) SimpleSelector.All;
      foreach (IElement element in elements)
      {
        IElement child;
        for (child = getter(element); child != null; child = getter(child))
        {
          if (selector.Match(child))
          {
            yield return child;
            break;
          }
        }
        child = (IElement) null;
      }
    }

    private static IEnumerable<IElement> Get(
      this IEnumerable<IElement> elements,
      Func<IElement, IElement> getter,
      string selectorText)
    {
      if (selectorText == null)
        return elements.Get(getter, (ISelector) SimpleSelector.All);
      ISelector selector = SelectorExtensions.CreateSelector(selectorText);
      return elements.Get(getter, selector);
    }

    private static IEnumerable<IElement> Except(
      this IEnumerable<IElement> elements,
      IElement excluded)
    {
      foreach (IElement element in elements)
      {
        if (element != excluded)
          yield return element;
      }
    }

    private static IEnumerable<T> Filter<T>(
      this IEnumerable<T> elements,
      ISelector selector,
      bool result)
      where T : IElement
    {
      if (selector == null)
        selector = (ISelector) SimpleSelector.All;
      foreach (T element in elements)
      {
        if (selector.Match((IElement) element) == result)
          yield return element;
      }
    }

    private static IEnumerable<T> Filter<T>(
      this IEnumerable<T> elements,
      string selectorText,
      bool result)
      where T : IElement
    {
      if (selectorText == null)
        return elements.Filter<T>((ISelector) SimpleSelector.All, result);
      ISelector selector = SelectorExtensions.CreateSelector(selectorText);
      return elements.Filter<T>(selector, result);
    }

    private static ISelector CreateSelector(string selector) => CssParser.Default.ParseSelector(selector);
  }
}
