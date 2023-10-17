// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.HtmlAllCollection
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class HtmlAllCollection : 
    IHtmlAllCollection,
    IHtmlCollection<IElement>,
    IEnumerable<IElement>,
    IEnumerable
  {
    private readonly IEnumerable<IElement> _elements;

    public HtmlAllCollection(IDocument document) => this._elements = document.GetElements<IElement>();

    public IElement this[int index] => this._elements.GetItemByIndex<IElement>(index);

    public IElement this[string id] => this._elements.GetElementById<IElement>(id);

    public int Length => this._elements.Count<IElement>();

    public IEnumerator<IElement> GetEnumerator() => this._elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._elements.GetEnumerator();
  }
}
