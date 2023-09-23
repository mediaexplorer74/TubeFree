// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.StyleSheetList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom
{
  internal sealed class StyleSheetList : IStyleSheetList, IEnumerable<IStyleSheet>, IEnumerable
  {
    private readonly IEnumerable<IStyleSheet> _sheets;

    internal StyleSheetList(IEnumerable<IStyleSheet> sheets) => this._sheets = sheets;

    public IStyleSheet this[int index] => this._sheets.Skip<IStyleSheet>(index).FirstOrDefault<IStyleSheet>();

    public int Length => this._sheets.Count<IStyleSheet>();

    public IEnumerator<IStyleSheet> GetEnumerator() => this._sheets.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
