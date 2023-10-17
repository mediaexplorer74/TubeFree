// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.PseudoElementSelectorFactory
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
  public class PseudoElementSelectorFactory : IPseudoElementSelectorFactory
  {
    private readonly Dictionary<string, ISelector> _selectors = new Dictionary<string, ISelector>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        PseudoElementNames.Before,
        (ISelector) SimpleSelector.PseudoElement((Predicate<IElement>) (el => el.IsPseudo("::" + PseudoElementNames.Before)), PseudoElementNames.Before)
      },
      {
        PseudoElementNames.After,
        (ISelector) SimpleSelector.PseudoElement((Predicate<IElement>) (el => el.IsPseudo("::" + PseudoElementNames.After)), PseudoElementNames.After)
      },
      {
        PseudoElementNames.Selection,
        (ISelector) SimpleSelector.PseudoElement((Predicate<IElement>) (el => false), PseudoElementNames.Selection)
      },
      {
        PseudoElementNames.FirstLine,
        (ISelector) SimpleSelector.PseudoElement((Predicate<IElement>) (el => el.HasChildNodes && el.ChildNodes[0].NodeType == NodeType.Text), PseudoElementNames.FirstLine)
      },
      {
        PseudoElementNames.FirstLetter,
        (ISelector) SimpleSelector.PseudoElement((Predicate<IElement>) (el => el.HasChildNodes && el.ChildNodes[0].NodeType == NodeType.Text && el.ChildNodes[0].TextContent.Length > 0), PseudoElementNames.FirstLetter)
      },
      {
        PseudoElementNames.Content,
        (ISelector) SimpleSelector.PseudoElement((Predicate<IElement>) (el => false), PseudoElementNames.Content)
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
