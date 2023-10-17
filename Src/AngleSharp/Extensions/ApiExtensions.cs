// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ApiExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Html;
using AngleSharp.Html;
using AngleSharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Extensions
{
  public static class ApiExtensions
  {
    public static TElement CreateElement<TElement>(this IDocument document) where TElement : IElement
    {
      if (document == null)
        throw new ArgumentNullException(nameof (document));
      Type type = ((IEnumerable<Type>) typeof (ApiExtensions).GetAssembly().GetTypes()).Where<Type>((Func<Type, bool>) (m => m.Implements<TElement>())).FirstOrDefault<Type>((Func<Type, bool>) (m => !m.IsAbstractClass()));
      if (type != null)
      {
        foreach (ConstructorInfo constructorInfo in (IEnumerable<ConstructorInfo>) ((IEnumerable<ConstructorInfo>) type.GetConstructors()).OrderBy<ConstructorInfo, int>((Func<ConstructorInfo, int>) (m => m.GetParameters().Length)))
        {
          ParameterInfo[] parameters1 = constructorInfo.GetParameters();
          object[] parameters2 = new object[parameters1.Length];
          for (int index = 0; index < parameters1.Length; ++index)
          {
            bool flag = parameters1[index].ParameterType == typeof (Document);
            parameters2[index] = flag ? (object) document : parameters1[index].DefaultValue;
          }
          object obj = constructorInfo.Invoke(parameters2);
          if (obj != null)
          {
            TElement externalNode = (TElement) obj;
            if (externalNode is Element element)
              element.SetupElement();
            document.Adopt((INode) externalNode);
            return externalNode;
          }
        }
      }
      throw new ArgumentException("No element could be created for the provided interface.");
    }

    public static async Task<Event> AwaitEventAsync<TEventTarget>(
      this TEventTarget node,
      string eventName)
      where TEventTarget : IEventTarget
    {
      if ((object) (TEventTarget) node == null)
        throw new ArgumentNullException(nameof (node));
      if (eventName == null)
        throw new ArgumentNullException(nameof (eventName));
      TaskCompletionSource<Event> completion = new TaskCompletionSource<Event>();
      DomEventHandler handler = (DomEventHandler) ((s, ev) => completion.TrySetResult(ev));
      node.AddEventListener(eventName, handler, false);
      Event @event;
      try
      {
        @event = await completion.Task.ConfigureAwait(false);
      }
      finally
      {
        node.RemoveEventListener(eventName, handler, false);
      }
      return @event;
    }

    public static TElement AppendElement<TElement>(this INode parent, TElement element) where TElement : class, IElement => parent != null ? parent.AppendChild((INode) element) as TElement : throw new ArgumentNullException(nameof (parent));

    public static TElement InsertElement<TElement>(
      this INode parent,
      TElement newElement,
      INode referenceElement)
      where TElement : class, IElement
    {
      if (parent == null)
        throw new ArgumentNullException(nameof (parent));
      return parent.InsertBefore((INode) newElement, referenceElement) as TElement;
    }

    public static TElement RemoveElement<TElement>(this INode parent, TElement element) where TElement : class, IElement => parent != null ? parent.RemoveChild((INode) element) as TElement : throw new ArgumentNullException(nameof (parent));

    public static TElement QuerySelector<TElement>(this IParentNode parent, string selectors) where TElement : class, IElement
    {
      if (parent == null)
        throw new ArgumentNullException(nameof (parent));
      return selectors != null ? parent.QuerySelector(selectors) as TElement : throw new ArgumentNullException(nameof (selectors));
    }

    public static IEnumerable<TElement> QuerySelectorAll<TElement>(
      this IParentNode parent,
      string selectors)
      where TElement : IElement
    {
      if (parent == null)
        throw new ArgumentNullException(nameof (parent));
      return selectors != null ? parent.QuerySelectorAll(selectors).OfType<TElement>() : throw new ArgumentNullException(nameof (selectors));
    }

    public static IEnumerable<TNode> Descendents<TNode>(this INode parent) => parent.Descendents().OfType<TNode>();

    public static IEnumerable<INode> Descendents(this INode parent) => parent != null ? parent.GetDescendants() : throw new ArgumentNullException(nameof (parent));

    public static IEnumerable<TNode> Ancestors<TNode>(this INode child) => child.Ancestors().OfType<TNode>();

    public static IEnumerable<INode> Ancestors(this INode child) => child != null ? child.GetAncestors() : throw new ArgumentNullException(nameof (child));

    public static IHtmlFormElement SetValues(
      this IHtmlFormElement form,
      IDictionary<string, string> fields,
      bool createMissing = false)
    {
      if (form == null)
        throw new ArgumentNullException(nameof (form));
      if (fields == null)
        throw new ArgumentNullException(nameof (fields));
      IEnumerable<HtmlFormControlElement> source = form.Elements.OfType<HtmlFormControlElement>();
      foreach (KeyValuePair<string, string> field1 in (IEnumerable<KeyValuePair<string, string>>) fields)
      {
        KeyValuePair<string, string> field = field1;
        HtmlFormControlElement targetInput = source.FirstOrDefault<HtmlFormControlElement>((Func<HtmlFormControlElement, bool>) (e => e.Name.Is(field.Key)));
        if (targetInput != null)
        {
          if (targetInput is IHtmlInputElement)
          {
            IHtmlInputElement htmlInputElement1 = (IHtmlInputElement) targetInput;
            if (htmlInputElement1.Type.Is(InputTypeNames.Radio))
            {
              foreach (IHtmlInputElement htmlInputElement2 in source.OfType<IHtmlInputElement>().Where<IHtmlInputElement>((Func<IHtmlInputElement, bool>) (i => i.Name.Is(targetInput.Name))))
                htmlInputElement2.IsChecked = htmlInputElement2.Value.Is(field.Value);
            }
            else
              htmlInputElement1.Value = field.Value;
          }
          else if (targetInput is IHtmlTextAreaElement)
            ((IHtmlTextAreaElement) targetInput).Value = field.Value;
          else if (targetInput is IHtmlSelectElement)
            ((IHtmlSelectElement) targetInput).Value = field.Value;
        }
        else if (createMissing)
        {
          IHtmlInputElement element = form.Owner.CreateElement<IHtmlInputElement>();
          element.Type = InputTypeNames.Hidden;
          element.Name = field.Key;
          element.Value = field.Value;
          form.AppendChild((INode) element);
        }
        else
          throw new KeyNotFoundException(string.Format("Field {0} not found.", (object) field.Key));
      }
      return form;
    }

    public static Task<IDocument> NavigateAsync<TElement>(this TElement element) where TElement : IUrlUtilities, IElement => element.NavigateAsync<TElement>(CancellationToken.None);

    public static Task<IDocument> NavigateAsync<TElement>(
      this TElement element,
      CancellationToken cancel)
      where TElement : IUrlUtilities, IElement
    {
      Url url = (object) element != null ? Url.Create(element.Href) : throw new ArgumentNullException(nameof (element));
      return element.Owner.Context.OpenAsync(url, cancel);
    }

    public static Task<IDocument> SubmitAsync(this IHtmlFormElement form, object fields) => ApiExtensions.SubmitAsync(form, (IDictionary<string, string>) fields.ToDictionary(), false);

    public static Task<IDocument> SubmitAsync(
      this IHtmlFormElement form,
      IDictionary<string, string> fields,
      bool createMissing = false)
    {
      form.SetValues(fields, createMissing);
      return form.SubmitAsync();
    }

    public static Task<IDocument> SubmitAsync(this IHtmlElement element, object fields = null) => element.SubmitAsync((IDictionary<string, string>) fields.ToDictionary(), false);

    public static Task<IDocument> SubmitAsync(
      this IHtmlElement element,
      IDictionary<string, string> fields,
      bool createMissing = false)
    {
      IHtmlFormElement form = element is HtmlFormControlElement sourceElement ? sourceElement.Form : throw new ArgumentException(nameof (element));
      if (form == null)
        return (Task<IDocument>) null;
      form.SetValues(fields, createMissing);
      return form.SubmitAsync((IHtmlElement) sourceElement);
    }

    public static T Eq<T>(this IEnumerable<T> elements, int index) where T : IElement => elements != null ? elements.Skip<T>(index).FirstOrDefault<T>() : throw new ArgumentNullException(nameof (elements));

    public static IEnumerable<T> Gt<T>(this IEnumerable<T> elements, int index) where T : IElement => elements != null ? elements.Skip<T>(index + 1) : throw new ArgumentNullException(nameof (elements));

    public static IEnumerable<T> Lt<T>(this IEnumerable<T> elements, int index) where T : IElement => elements != null ? elements.Take<T>(index) : throw new ArgumentNullException(nameof (elements));

    public static IEnumerable<T> Even<T>(this IEnumerable<T> elements) where T : IElement
    {
      if (elements == null)
        throw new ArgumentNullException(nameof (elements));
      bool even = true;
      foreach (T element in elements)
      {
        if (even)
          yield return element;
        even = !even;
      }
    }

    public static IEnumerable<T> Odd<T>(this IEnumerable<T> elements) where T : IElement
    {
      if (elements == null)
        throw new ArgumentNullException(nameof (elements));
      bool odd = false;
      foreach (T element in elements)
      {
        if (odd)
          yield return element;
        odd = !odd;
      }
    }

    public static ICssStyleDeclaration ComputeCurrentStyle(this IElement element)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      return element.Owner?.DefaultView?.GetComputedStyle(element);
    }

    public static T Attr<T>(this T elements, string attributeName, string attributeValue) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      if (attributeName == null)
        throw new ArgumentNullException(nameof (attributeName));
      foreach (IElement element in elements)
        element.SetAttribute(attributeName, attributeValue);
      return elements;
    }

    public static T Attr<T>(
      this T elements,
      IEnumerable<KeyValuePair<string, string>> attributes)
      where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      if (attributes == null)
        throw new ArgumentNullException(nameof (attributes));
      foreach (IElement element in elements)
      {
        foreach (KeyValuePair<string, string> attribute in attributes)
          element.SetAttribute(attribute.Key, attribute.Value);
      }
      return elements;
    }

    public static T Attr<T>(this T elements, object attributes) where T : IEnumerable<IElement>
    {
      Dictionary<string, string> dictionary = attributes.ToDictionary();
      return ApiExtensions.Attr<T>(elements, (IEnumerable<KeyValuePair<string, string>>) dictionary);
    }

    public static IEnumerable<string> Attr<T>(this T elements, string attributeName) where T : IEnumerable<IElement> => elements.Select<IElement, string>((Func<IElement, string>) (m => m.GetAttribute(attributeName)));

    public static IElement ClearAttr(this IElement element)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      element.Attributes.Clear();
      return element;
    }

    public static T ClearAttr<T>(this T elements) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
        element.ClearAttr();
      return elements;
    }

    public static IElement Empty(this IElement element)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      element.InnerHtml = string.Empty;
      return element;
    }

    public static T Empty<T>(this T elements) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
        element.Empty();
      return elements;
    }

    public static T Css<T>(this T elements, string propertyName, string propertyValue) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      if (propertyName == null)
        throw new ArgumentNullException(nameof (propertyName));
      foreach (IElementCssInlineStyle elementCssInlineStyle in elements.OfType<IHtmlElement>())
        elementCssInlineStyle.Style.SetProperty(propertyName, propertyValue);
      return elements;
    }

    public static T Css<T>(
      this T elements,
      IEnumerable<KeyValuePair<string, string>> properties)
      where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      if (properties == null)
        throw new ArgumentNullException(nameof (properties));
      foreach (IHtmlElement htmlElement in elements.OfType<IHtmlElement>())
      {
        foreach (KeyValuePair<string, string> property in properties)
          htmlElement.Style.SetProperty(property.Key, property.Value);
      }
      return elements;
    }

    public static T Css<T>(this T elements, object properties) where T : IEnumerable<IElement>
    {
      Dictionary<string, string> dictionary = properties.ToDictionary();
      return ApiExtensions.Css<T>(elements, (IEnumerable<KeyValuePair<string, string>>) dictionary);
    }

    public static string Html(this IElement element) => element != null ? element.InnerHtml : throw new ArgumentNullException(nameof (element));

    public static T Html<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
        element.InnerHtml = html;
      return elements;
    }

    public static T AddClass<T>(this T elements, string className) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      string[] strArray = className != null ? className.SplitSpaces() : throw new ArgumentNullException(nameof (className));
      foreach (IElement element in elements)
        element.ClassList.Add(strArray);
      return elements;
    }

    public static T RemoveClass<T>(this T elements, string className) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      string[] strArray = className != null ? className.SplitSpaces() : throw new ArgumentNullException(nameof (className));
      foreach (IElement element in elements)
        element.ClassList.Remove(strArray);
      return elements;
    }

    public static T ToggleClass<T>(this T elements, string className) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      string[] strArray = className != null ? className.SplitSpaces() : throw new ArgumentNullException(nameof (className));
      foreach (IElement element in elements)
      {
        foreach (string token in strArray)
          element.ClassList.Toggle(token);
      }
      return elements;
    }

    public static bool HasClass(this IEnumerable<IElement> elements, string className)
    {
      if (elements == null)
        throw new ArgumentNullException(nameof (elements));
      string[] strArray = className != null ? className.SplitSpaces() : throw new ArgumentNullException(nameof (className));
      foreach (IElement element in elements)
      {
        bool flag = true;
        foreach (string token in strArray)
        {
          if (!element.ClassList.Contains(token))
          {
            flag = false;
            break;
          }
        }
        if (flag)
          return true;
      }
      return false;
    }

    public static T Before<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
      {
        IElement parentElement = element.ParentElement;
        if (parentElement != null)
        {
          IDocumentFragment fragment = parentElement.CreateFragment(html);
          parentElement.InsertBefore((INode) fragment, (INode) element);
        }
      }
      return elements;
    }

    public static T After<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
      {
        IElement parentElement = element.ParentElement;
        if (parentElement != null)
        {
          IDocumentFragment fragment = parentElement.CreateFragment(html);
          parentElement.InsertBefore((INode) fragment, element.NextSibling);
        }
      }
      return elements;
    }

    public static T Append<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
        element.Append((INode) element.CreateFragment(html));
      return elements;
    }

    public static T Prepend<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
      {
        IDocumentFragment fragment = element.CreateFragment(html);
        element.InsertBefore((INode) fragment, element.FirstChild);
      }
      return elements;
    }

    public static T Wrap<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
      {
        IDocumentFragment fragment = element.CreateFragment(html);
        IElement innerMostElement = fragment.GetInnerMostElement();
        element.Parent?.InsertBefore((INode) fragment, (INode) element);
        IElement child = element;
        innerMostElement.AppendChild((INode) child);
      }
      return elements;
    }

    public static T WrapInner<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      if ((object) elements == null)
        throw new ArgumentNullException(nameof (elements));
      foreach (IElement element in elements)
      {
        IDocumentFragment fragment = element.CreateFragment(html);
        IElement innerMostElement = fragment.GetInnerMostElement();
        while (element.ChildNodes.Length > 0)
        {
          INode childNode = element.ChildNodes[0];
          innerMostElement.AppendChild(childNode);
        }
        element.AppendChild((INode) fragment);
      }
      return elements;
    }

    public static T WrapAll<T>(this T elements, string html) where T : IEnumerable<IElement>
    {
      IElement element1 = (object) elements != null ? elements.FirstOrDefault<IElement>() : throw new ArgumentNullException(nameof (elements));
      if (element1 != null)
      {
        IDocumentFragment fragment = element1.CreateFragment(html);
        IElement innerMostElement = fragment.GetInnerMostElement();
        element1.Parent?.InsertBefore((INode) fragment, (INode) element1);
        foreach (IElement element2 in elements)
          innerMostElement.AppendChild((INode) element2);
      }
      return elements;
    }

    public static IHtmlCollection<TElement> ToCollection<TElement>(
      this IEnumerable<TElement> elements)
      where TElement : class, IElement
    {
      return (IHtmlCollection<TElement>) new HtmlCollection<TElement>(elements);
    }

    public static INamedNodeMap Clear(this INamedNodeMap attributes)
    {
      if (attributes == null)
        throw new ArgumentNullException(nameof (attributes));
      while (attributes.Length > 0)
      {
        string name = attributes[attributes.Length - 1].Name;
        attributes.RemoveNamedItem(name);
      }
      return attributes;
    }

    public static IEnumerable<IDownload> GetDownloads(this IDocument document)
    {
      if (document == null)
        throw new ArgumentNullException(nameof (document));
      return document.All.OfType<ILoadableElement>().Select<ILoadableElement, IDownload>((Func<ILoadableElement, IDownload>) (m => m.CurrentDownload)).Where<IDownload>((Func<IDownload, bool>) (m => m != null));
    }

    private static IDocumentFragment CreateFromHtml(this IDocument document, string html)
    {
      if (document == null)
        throw new ArgumentNullException(nameof (document));
      if (!(document.Body is Element body))
        throw new ArgumentException("The provided document does not have a valid body element.");
      string html1 = html ?? string.Empty;
      return (IDocumentFragment) new DocumentFragment(body, html1);
    }

    public static string Text(this INode node) => node != null ? node.TextContent : throw new ArgumentNullException(nameof (node));

    public static T Text<T>(this T nodes, string text) where T : IEnumerable<INode>
    {
      if ((object) nodes == null)
        throw new ArgumentNullException(nameof (nodes));
      foreach (INode node in nodes)
        node.TextContent = text;
      return nodes;
    }

    public static int Index(this IEnumerable<INode> nodes, INode item)
    {
      if (nodes == null)
        throw new ArgumentNullException(nameof (nodes));
      if (item != null)
      {
        int num = 0;
        foreach (INode node in nodes)
        {
          if (node == item)
            return num;
          ++num;
        }
      }
      return -1;
    }

    private static IDocumentFragment CreateFragment(this IElement context, string html) => (IDocumentFragment) new DocumentFragment(context as Element, html ?? string.Empty);

    private static IElement GetInnerMostElement(this IDocumentFragment fragment)
    {
      IElement element = fragment.ChildElementCount == 1 ? fragment.FirstElementChild : throw new InvalidOperationException("The provided HTML code did not result in any element.");
      IElement innerMostElement;
      do
      {
        innerMostElement = element;
        element = innerMostElement.FirstElementChild;
      }
      while (element != null);
      return innerMostElement;
    }
  }
}
