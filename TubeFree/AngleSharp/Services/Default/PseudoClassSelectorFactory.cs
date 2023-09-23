// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.PseudoClassSelectorFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  public class PseudoClassSelectorFactory : IPseudoClassSelectorFactory
  {
    private readonly Dictionary<string, ISelector> _selectors = new Dictionary<string, ISelector>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        PseudoClassNames.Root,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.Owner.DocumentElement == el), PseudoClassNames.Root)
      },
      {
        PseudoClassNames.Scope,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.Owner.DocumentElement == el), PseudoClassNames.Scope)
      },
      {
        PseudoClassNames.OnlyType,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsOnlyOfType()), PseudoClassNames.OnlyType)
      },
      {
        PseudoClassNames.FirstOfType,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsFirstOfType()), PseudoClassNames.FirstOfType)
      },
      {
        PseudoClassNames.LastOfType,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsLastOfType()), PseudoClassNames.LastOfType)
      },
      {
        PseudoClassNames.OnlyChild,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsOnlyChild()), PseudoClassNames.OnlyChild)
      },
      {
        PseudoClassNames.FirstChild,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsFirstChild()), PseudoClassNames.FirstChild)
      },
      {
        PseudoClassNames.LastChild,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsLastChild()), PseudoClassNames.LastChild)
      },
      {
        PseudoClassNames.Empty,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.ChildElementCount == 0 && el.TextContent.Is(string.Empty)), PseudoClassNames.Empty)
      },
      {
        PseudoClassNames.AnyLink,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsLink() || el.IsVisited()), PseudoClassNames.AnyLink)
      },
      {
        PseudoClassNames.Link,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsLink()), PseudoClassNames.Link)
      },
      {
        PseudoClassNames.Visited,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsVisited()), PseudoClassNames.Visited)
      },
      {
        PseudoClassNames.Active,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsActive()), PseudoClassNames.Active)
      },
      {
        PseudoClassNames.Hover,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsHovered()), PseudoClassNames.Hover)
      },
      {
        PseudoClassNames.Focus,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsFocused), PseudoClassNames.Focus)
      },
      {
        PseudoClassNames.Target,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsTarget()), PseudoClassNames.Target)
      },
      {
        PseudoClassNames.Enabled,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsEnabled()), PseudoClassNames.Enabled)
      },
      {
        PseudoClassNames.Disabled,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsDisabled()), PseudoClassNames.Disabled)
      },
      {
        PseudoClassNames.Default,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsDefault()), PseudoClassNames.Default)
      },
      {
        PseudoClassNames.Checked,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsChecked()), PseudoClassNames.Checked)
      },
      {
        PseudoClassNames.Indeterminate,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsIndeterminate()), PseudoClassNames.Indeterminate)
      },
      {
        PseudoClassNames.PlaceholderShown,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsPlaceholderShown()), PseudoClassNames.PlaceholderShown)
      },
      {
        PseudoClassNames.Unchecked,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsUnchecked()), PseudoClassNames.Unchecked)
      },
      {
        PseudoClassNames.Valid,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsValid()), PseudoClassNames.Valid)
      },
      {
        PseudoClassNames.Invalid,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsInvalid()), PseudoClassNames.Invalid)
      },
      {
        PseudoClassNames.Required,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsRequired()), PseudoClassNames.Required)
      },
      {
        PseudoClassNames.ReadOnly,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsReadOnly()), PseudoClassNames.ReadOnly)
      },
      {
        PseudoClassNames.ReadWrite,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsEditable()), PseudoClassNames.ReadWrite)
      },
      {
        PseudoClassNames.InRange,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsInRange()), PseudoClassNames.InRange)
      },
      {
        PseudoClassNames.OutOfRange,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsOutOfRange()), PseudoClassNames.OutOfRange)
      },
      {
        PseudoClassNames.Optional,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsOptional()), PseudoClassNames.Optional)
      },
      {
        PseudoClassNames.Shadow,
        (ISelector) SimpleSelector.PseudoClass((Predicate<IElement>) (el => el.IsShadow()), PseudoClassNames.Shadow)
      },
      {
        PseudoElementNames.Before,
        Factory.PseudoElementSelector.Create(PseudoElementNames.Before)
      },
      {
        PseudoElementNames.After,
        Factory.PseudoElementSelector.Create(PseudoElementNames.After)
      },
      {
        PseudoElementNames.FirstLine,
        Factory.PseudoElementSelector.Create(PseudoElementNames.FirstLine)
      },
      {
        PseudoElementNames.FirstLetter,
        Factory.PseudoElementSelector.Create(PseudoElementNames.FirstLetter)
      }
    };

    public void Register(string name, ISelector selector) => this._selectors.Add(name, selector);

    public ISelector Unregister(string name)
    {
      ISelector selector = (ISelector) null;
      if (this._selectors.TryGetValue(name, out selector))
        this._selectors.Remove(name);
      return selector;
    }

    protected virtual ISelector CreateDefault(string name) => (ISelector) null;

    public ISelector Create(string name)
    {
      ISelector selector = (ISelector) null;
      return this._selectors.TryGetValue(name, out selector) ? selector : this.CreateDefault(name);
    }
  }
}
