// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ComplexSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class ComplexSelector : CssNode, ISelector, ICssNode, IStyleFormattable
  {
    private readonly List<ComplexSelector.CombinatorSelector> _selectors;

    public ComplexSelector() => this._selectors = new List<ComplexSelector.CombinatorSelector>();

    public Priority Specifity
    {
      get
      {
        Priority specifity = new Priority();
        int count = this._selectors.Count;
        for (int index = 0; index < count; ++index)
          specifity += this._selectors[index].Selector.Specifity;
        return specifity;
      }
    }

    public string Text => this.ToCss();

    public int Length => this._selectors.Count;

    public bool IsReady { get; private set; }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      if (this._selectors.Count <= 0)
        return;
      int index1 = this._selectors.Count - 1;
      for (int index2 = 0; index2 < index1; ++index2)
      {
        writer.Write(this._selectors[index2].Selector.Text);
        writer.Write(this._selectors[index2].Delimiter);
      }
      writer.Write(this._selectors[index1].Selector.Text);
    }

    public bool Match(IElement element)
    {
      int index = this._selectors.Count - 1;
      if (!this._selectors[index].Selector.Match(element))
        return false;
      return index <= 0 || this.MatchCascade(index - 1, element);
    }

    public void ConcludeSelector(ISelector selector)
    {
      if (this.IsReady)
        return;
      this._selectors.Add(new ComplexSelector.CombinatorSelector()
      {
        Selector = selector,
        Transform = (Func<IElement, IEnumerable<IElement>>) null,
        Delimiter = (string) null
      });
      this.IsReady = true;
    }

    public void AppendSelector(ISelector selector, CssCombinator combinator)
    {
      if (this.IsReady)
        return;
      this._selectors.Add(new ComplexSelector.CombinatorSelector()
      {
        Selector = combinator.Change(selector),
        Transform = combinator.Transform,
        Delimiter = combinator.Delimiter
      });
    }

    private bool MatchCascade(int pos, IElement element)
    {
      foreach (IElement element1 in this._selectors[pos].Transform(element))
      {
        if (this._selectors[pos].Selector.Match(element1) && (pos == 0 || this.MatchCascade(pos - 1, element1)))
          return true;
      }
      return false;
    }

    private struct CombinatorSelector
    {
      public string Delimiter;
      public Func<IElement, IEnumerable<IElement>> Transform;
      public ISelector Selector;
    }
  }
}
