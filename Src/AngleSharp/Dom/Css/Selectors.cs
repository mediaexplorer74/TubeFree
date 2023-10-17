// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.Selectors
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  internal abstract class Selectors : CssNode, IEnumerable<ISelector>, IEnumerable
  {
    protected readonly List<ISelector> _selectors;

    public Selectors() => this._selectors = new List<ISelector>();

    public Priority Specifity
    {
      get
      {
        Priority specifity = new Priority();
        for (int index = 0; index < this._selectors.Count; ++index)
          specifity += this._selectors[index].Specifity;
        return specifity;
      }
    }

    public string Text => this.ToCss();

    public int Length => this._selectors.Count;

    public ISelector this[int index]
    {
      get => this._selectors[index];
      set => this._selectors[index] = value;
    }

    public void Add(ISelector selector) => this._selectors.Add(selector);

    public void Remove(ISelector selector) => this._selectors.Remove(selector);

    public IEnumerator<ISelector> GetEnumerator() => (IEnumerator<ISelector>) this._selectors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
