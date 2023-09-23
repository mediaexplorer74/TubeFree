// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ElementExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Network.RequestProcessors;
using AngleSharp.Services.Media;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Extensions
{
  internal static class ElementExtensions
  {
    public static string LocatePrefixFor(this IElement element, string namespaceUri)
    {
      if (element.NamespaceUri.Is(namespaceUri) && element.Prefix != null)
        return element.Prefix;
      foreach (IAttr attribute in (IEnumerable<IAttr>) element.Attributes)
      {
        if (attribute.Prefix.Is(NamespaceNames.XmlNsPrefix) && attribute.Value.Is(namespaceUri))
          return attribute.LocalName;
      }
      IElement parentElement = element.ParentElement;
      return parentElement == null ? (string) null : parentElement.LocatePrefixFor(namespaceUri);
    }

    public static string LocateNamespaceFor(this IElement element, string prefix)
    {
      string namespaceUri = element.NamespaceUri;
      string prefix1 = element.Prefix;
      if (!string.IsNullOrEmpty(namespaceUri) && prefix1.Is(prefix))
        return namespaceUri;
      Predicate<IAttr> predicate = prefix == null ? (Predicate<IAttr>) (attr => attr.NamespaceUri.Is(NamespaceNames.XmlNsUri) && attr.Prefix == null && attr.LocalName.Is(NamespaceNames.XmlNsPrefix)) : (Predicate<IAttr>) (attr => attr.NamespaceUri.Is(NamespaceNames.XmlNsUri) && attr.Prefix.Is(NamespaceNames.XmlNsPrefix) && attr.LocalName.Is(prefix));
      foreach (IAttr attribute in (IEnumerable<IAttr>) element.Attributes)
      {
        if (predicate(attribute))
        {
          string str = attribute.Value;
          if (string.IsNullOrEmpty(str))
            str = (string) null;
          return str;
        }
      }
      IElement parentElement = element.ParentElement;
      return parentElement == null ? (string) null : parentElement.LocateNamespaceFor(prefix);
    }

    public static ResourceRequest CreateRequestFor(this IElement element, Url url) => new ResourceRequest(element, url);

    public static bool MatchesCssNamespace(this IElement el, string prefix)
    {
      if (prefix.Is(Keywords.Asterisk))
        return true;
      string current = el.GetAttribute(NamespaceNames.XmlNsPrefix) ?? el.NamespaceUri;
      return prefix.Is(string.Empty) ? current.Is(string.Empty) : current.Is(el.GetCssNamespace(prefix));
    }

    public static string GetCssNamespace(this IElement el, string prefix)
    {
      IDocument owner = el.Owner;
      return (owner != null ? owner.StyleSheets.LocateNamespace(prefix) : (string) null) ?? el.LocateNamespaceFor(prefix);
    }

    public static bool IsHovered(this IElement element) => false;

    public static bool IsOnlyOfType(this IElement element)
    {
      IElement parentElement = element.ParentElement;
      if (parentElement == null)
        return false;
      for (int index = 0; index < parentElement.ChildNodes.Length; ++index)
      {
        if (parentElement.ChildNodes[index].NodeName.Is(element.NodeName) && parentElement.ChildNodes[index] != element)
          return false;
      }
      return true;
    }

    public static bool IsFirstOfType(this IElement element)
    {
      IElement parentElement = element.ParentElement;
      if (parentElement != null)
      {
        for (int index = 0; index < parentElement.ChildNodes.Length; ++index)
        {
          if (parentElement.ChildNodes[index].NodeName.Is(element.NodeName))
            return parentElement.ChildNodes[index] == element;
        }
      }
      return false;
    }

    public static bool IsLastOfType(this IElement element)
    {
      IElement parentElement = element.ParentElement;
      if (parentElement != null)
      {
        for (int index = parentElement.ChildNodes.Length - 1; index >= 0; --index)
        {
          if (parentElement.ChildNodes[index].NodeName.Is(element.NodeName))
            return parentElement.ChildNodes[index] == element;
        }
      }
      return false;
    }

    public static bool IsTarget(this IElement element)
    {
      string id = element.Id;
      string hash = element.Owner?.Location.Hash;
      return id != null && hash != null && string.Compare(id, 0, hash, hash.Length > 0 ? 1 : 0, int.MaxValue) == 0;
    }

    public static bool IsEnabled(this IElement element)
    {
      switch (element)
      {
        case HtmlAnchorElement _:
        case HtmlAreaElement _:
        case HtmlLinkElement _:
          return !string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Href));
        case HtmlButtonElement _:
          return !((HtmlFormControlElement) element).IsDisabled;
        case HtmlInputElement _:
          return !((HtmlFormControlElement) element).IsDisabled;
        case HtmlSelectElement _:
          return !((HtmlFormControlElement) element).IsDisabled;
        case HtmlTextAreaElement _:
          return !((HtmlFormControlElement) element).IsDisabled;
        case HtmlOptionElement _:
          return !((HtmlOptionElement) element).IsDisabled;
        case HtmlOptionsGroupElement _:
        case HtmlMenuItemElement _:
        case HtmlFieldSetElement _:
          return string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Disabled));
        default:
          return false;
      }
    }

    public static bool IsDisabled(this IElement element)
    {
      switch (element)
      {
        case HtmlButtonElement _:
          return ((HtmlFormControlElement) element).IsDisabled;
        case HtmlInputElement _:
          return ((HtmlFormControlElement) element).IsDisabled;
        case HtmlSelectElement _:
          return ((HtmlFormControlElement) element).IsDisabled;
        case HtmlTextAreaElement _:
          return ((HtmlFormControlElement) element).IsDisabled;
        case HtmlOptionElement _:
          return ((HtmlOptionElement) element).IsDisabled;
        case HtmlOptionsGroupElement _:
        case HtmlMenuItemElement _:
        case HtmlFieldSetElement _:
          return !string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Disabled));
        default:
          return false;
      }
    }

    public static bool IsDefault(this IElement element)
    {
      switch (element)
      {
        case HtmlButtonElement _:
          if (((HtmlFormControlElement) element).Form != null)
            return true;
          break;
        case HtmlInputElement _:
          HtmlInputElement htmlInputElement = (HtmlInputElement) element;
          string type = htmlInputElement.Type;
          if ((type == InputTypeNames.Submit || type == InputTypeNames.Image) && htmlInputElement.Form != null)
            return true;
          break;
        case HtmlOptionElement _:
          return !string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Selected));
      }
      return false;
    }

    public static bool IsPseudo(this IElement element, string name) => element is PseudoElement pseudoElement && pseudoElement.PseudoName.Is(name);

    public static bool IsChecked(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          HtmlInputElement htmlInputElement = (HtmlInputElement) element;
          return htmlInputElement.Type.IsOneOf(InputTypeNames.Checkbox, InputTypeNames.Radio) && htmlInputElement.IsChecked;
        case HtmlMenuItemElement _:
          HtmlMenuItemElement htmlMenuItemElement = (HtmlMenuItemElement) element;
          return htmlMenuItemElement.Type.IsOneOf(InputTypeNames.Checkbox, InputTypeNames.Radio) && htmlMenuItemElement.IsChecked;
        case HtmlOptionElement _:
          return ((HtmlOptionElement) element).IsSelected;
        default:
          return false;
      }
    }

    public static bool IsIndeterminate(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          HtmlInputElement htmlInputElement = (HtmlInputElement) element;
          return htmlInputElement.Type.Is(InputTypeNames.Checkbox) && htmlInputElement.IsIndeterminate;
        case HtmlProgressElement _:
          return string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Value));
        default:
          return false;
      }
    }

    public static bool IsPlaceholderShown(this IElement element) => element is HtmlInputElement htmlInputElement && !string.IsNullOrEmpty(htmlInputElement.Placeholder) & string.IsNullOrEmpty(htmlInputElement.Value);

    public static bool IsUnchecked(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          HtmlInputElement htmlInputElement = (HtmlInputElement) element;
          return htmlInputElement.Type.IsOneOf(InputTypeNames.Checkbox, InputTypeNames.Radio) && !htmlInputElement.IsChecked;
        case HtmlMenuItemElement _:
          HtmlMenuItemElement htmlMenuItemElement = (HtmlMenuItemElement) element;
          return htmlMenuItemElement.Type.IsOneOf(InputTypeNames.Checkbox, InputTypeNames.Radio) && !htmlMenuItemElement.IsChecked;
        case HtmlOptionElement _:
          return !((HtmlOptionElement) element).IsSelected;
        default:
          return false;
      }
    }

    public static bool IsActive(this IElement element)
    {
      switch (element)
      {
        case HtmlAnchorElement _:
          HtmlAnchorElement htmlAnchorElement = (HtmlAnchorElement) element;
          return !string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Href)) && htmlAnchorElement.IsActive;
        case HtmlAreaElement _:
          HtmlAreaElement htmlAreaElement = (HtmlAreaElement) element;
          return !string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Href)) && htmlAreaElement.IsActive;
        case HtmlLinkElement _:
          HtmlLinkElement htmlLinkElement = (HtmlLinkElement) element;
          return !string.IsNullOrEmpty(element.GetAttribute((string) null, AttributeNames.Href)) && htmlLinkElement.IsActive;
        case HtmlButtonElement _:
          HtmlButtonElement htmlButtonElement = (HtmlButtonElement) element;
          return !htmlButtonElement.IsDisabled && htmlButtonElement.IsActive;
        case HtmlInputElement _:
          HtmlInputElement htmlInputElement = (HtmlInputElement) element;
          return htmlInputElement.Type.IsOneOf(InputTypeNames.Submit, InputTypeNames.Image, InputTypeNames.Reset, InputTypeNames.Button) && htmlInputElement.IsActive;
        case HtmlMenuItemElement _:
          HtmlMenuItemElement htmlMenuItemElement = (HtmlMenuItemElement) element;
          return !htmlMenuItemElement.IsDisabled && htmlMenuItemElement.IsActive;
        default:
          return false;
      }
    }

    public static bool IsVisited(this IElement element)
    {
      switch (element)
      {
        case HtmlAnchorElement _:
          string attribute1 = element.GetAttribute((string) null, AttributeNames.Href);
          HtmlAnchorElement htmlAnchorElement = (HtmlAnchorElement) element;
          return !string.IsNullOrEmpty(attribute1) && htmlAnchorElement.IsVisited;
        case HtmlAreaElement _:
          string attribute2 = element.GetAttribute((string) null, AttributeNames.Href);
          HtmlAreaElement htmlAreaElement = (HtmlAreaElement) element;
          return !string.IsNullOrEmpty(attribute2) && htmlAreaElement.IsVisited;
        case HtmlLinkElement _:
          string attribute3 = element.GetAttribute((string) null, AttributeNames.Href);
          HtmlLinkElement htmlLinkElement = (HtmlLinkElement) element;
          return !string.IsNullOrEmpty(attribute3) && htmlLinkElement.IsVisited;
        default:
          return false;
      }
    }

    public static bool IsLink(this IElement element)
    {
      switch (element)
      {
        case HtmlAnchorElement _:
          string attribute1 = element.GetAttribute((string) null, AttributeNames.Href);
          HtmlAnchorElement htmlAnchorElement = (HtmlAnchorElement) element;
          return !string.IsNullOrEmpty(attribute1) && !htmlAnchorElement.IsVisited;
        case HtmlAreaElement _:
          string attribute2 = element.GetAttribute((string) null, AttributeNames.Href);
          HtmlAreaElement htmlAreaElement = (HtmlAreaElement) element;
          return !string.IsNullOrEmpty(attribute2) && !htmlAreaElement.IsVisited;
        case HtmlLinkElement _:
          string attribute3 = element.GetAttribute((string) null, AttributeNames.Href);
          HtmlLinkElement htmlLinkElement = (HtmlLinkElement) element;
          return !string.IsNullOrEmpty(attribute3) && !htmlLinkElement.IsVisited;
        default:
          return false;
      }
    }

    public static bool IsShadow(this IElement element) => element?.ShadowRoot != null;

    public static bool IsOptional(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          return !((HtmlTextFormControlElement) element).IsRequired;
        case HtmlSelectElement _:
          return !((HtmlSelectElement) element).IsRequired;
        case HtmlTextAreaElement _:
          return !((HtmlTextFormControlElement) element).IsRequired;
        default:
          return false;
      }
    }

    public static bool IsRequired(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          return ((HtmlTextFormControlElement) element).IsRequired;
        case HtmlSelectElement _:
          return ((HtmlSelectElement) element).IsRequired;
        case HtmlTextAreaElement _:
          return ((HtmlTextFormControlElement) element).IsRequired;
        default:
          return false;
      }
    }

    public static bool IsInvalid(this IElement element)
    {
      switch (element)
      {
        case IValidation _:
          return !((IValidation) element).CheckValidity();
        case HtmlFormElement _:
          return !((HtmlFormElement) element).CheckValidity();
        default:
          return false;
      }
    }

    public static bool IsValid(this IElement element)
    {
      switch (element)
      {
        case IValidation _:
          return ((IValidation) element).CheckValidity();
        case HtmlFormElement _:
          return ((HtmlFormElement) element).CheckValidity();
        default:
          return false;
      }
    }

    public static bool IsReadOnly(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          return !((HtmlInputElement) element).IsMutable;
        case HtmlTextAreaElement _:
          return !((HtmlTextAreaElement) element).IsMutable;
        case IHtmlElement _:
          return !((IHtmlElement) element).IsContentEditable;
        default:
          return true;
      }
    }

    public static bool IsEditable(this IElement element)
    {
      switch (element)
      {
        case HtmlInputElement _:
          return ((HtmlInputElement) element).IsMutable;
        case HtmlTextAreaElement _:
          return ((HtmlTextAreaElement) element).IsMutable;
        case IHtmlElement _:
          return ((IHtmlElement) element).IsContentEditable;
        default:
          return false;
      }
    }

    public static bool IsOutOfRange(this IElement element)
    {
      if (!(element is IValidation validation))
        return false;
      IValidityState validity = validation.Validity;
      return validity.IsRangeOverflow || validity.IsRangeUnderflow;
    }

    public static bool IsInRange(this IElement element)
    {
      if (!(element is IValidation validation))
        return false;
      IValidityState validity = validation.Validity;
      return !validity.IsRangeOverflow && !validity.IsRangeUnderflow;
    }

    public static bool IsOnlyChild(this IElement element)
    {
      IElement parentElement = element.ParentElement;
      return parentElement != null && parentElement.ChildElementCount == 1 && parentElement.FirstElementChild == element;
    }

    public static bool IsFirstChild(this IElement element) => element.ParentElement?.FirstElementChild == element;

    public static bool IsLastChild(this IElement element) => element.ParentElement?.LastElementChild == element;

    public static void Process(this Element element, IRequestProcessor processor, Url url)
    {
      ResourceRequest requestFor = element.CreateRequestFor(url);
      Task task = processor?.ProcessAsync(requestFor);
      if (task == null)
        return;
      element.Owner?.DelayLoad(task);
    }

    public static Url GetImageCandidate(this HtmlImageElement img)
    {
      Document owner = img.Owner;
      SourceSet sourceSet = new SourceSet((IDocument) owner);
      IConfiguration options = owner.Options;
      Stack<IHtmlSourceElement> sources = img.GetSources();
      while (sources.Count > 0)
      {
        IHtmlSourceElement htmlSourceElement = sources.Pop();
        string type = htmlSourceElement.Type;
        if (string.IsNullOrEmpty(type) || options.GetResourceService<IImageInfo>(type) != null)
        {
          using (IEnumerator<string> enumerator = sourceSet.GetCandidates(htmlSourceElement.SourceSet, htmlSourceElement.Sizes).GetEnumerator())
          {
            if (enumerator.MoveNext())
            {
              string current = enumerator.Current;
              return new Url(img.BaseUrl, current);
            }
          }
        }
      }
      using (IEnumerator<string> enumerator = sourceSet.GetCandidates(img.SourceSet, img.Sizes).GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          string current = enumerator.Current;
          return new Url(img.BaseUrl, current);
        }
      }
      return Url.Create(img.Source);
    }

    public static async Task<IDocument> NavigateToAsync(
      this Element element,
      DocumentRequest request)
    {
      IResponse response = await element.Owner.Context.Loader.DownloadAsync(request).Task.ConfigureAwait(false);
      return await element.Owner.Context.OpenAsync(response, CancellationToken.None).ConfigureAwait(false);
    }

    public static string GetOwnAttribute(this Element element, string name) => element.Attributes.GetNamedItem((string) null, name)?.Value;

    public static bool HasOwnAttribute(this Element element, string name) => element.Attributes.GetNamedItem((string) null, name) != null;

    public static string GetUrlAttribute(this Element element, string name)
    {
      string ownAttribute = element.GetOwnAttribute(name);
      Url url = ownAttribute != null ? new Url(element.BaseUrl, ownAttribute) : (Url) null;
      return url == null || url.IsInvalid ? string.Empty : url.Href;
    }

    public static bool GetBoolAttribute(this Element element, string name) => element.GetOwnAttribute(name) != null;

    public static void SetBoolAttribute(this Element element, string name, bool value)
    {
      if (value)
        element.SetOwnAttribute(name, string.Empty);
      else
        element.Attributes.RemoveNamedItemOrDefault(name, true);
    }

    public static void SetOwnAttribute(
      this Element element,
      string name,
      string value,
      bool suppressCallbacks = false)
    {
      element.Attributes.SetNamedItemWithNamespaceUri((IAttr) new Attr(name, value), suppressCallbacks);
    }

    private static Stack<IHtmlSourceElement> GetSources(this IHtmlImageElement img)
    {
      IElement parentElement = img.ParentElement;
      Stack<IHtmlSourceElement> sources = new Stack<IHtmlSourceElement>();
      if (parentElement != null && parentElement.LocalName.Is(TagNames.Picture))
      {
        for (IHtmlSourceElement previousElementSibling = img.PreviousElementSibling as IHtmlSourceElement; previousElementSibling != null; previousElementSibling = previousElementSibling.PreviousElementSibling as IHtmlSourceElement)
          sources.Push(previousElementSibling);
      }
      return sources;
    }
  }
}
