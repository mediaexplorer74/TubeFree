// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.HtmlCollection`1
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class HtmlCollection<T> : IHtmlCollection<T>, IEnumerable<T>, IEnumerable where T : class, IElement
  {
    private readonly IEnumerable<T> _elements;

    public HtmlCollection(IEnumerable<T> elements) => this._elements = elements;

    public HtmlCollection(INode parent, bool deep = true, Predicate<T> predicate = null) => this._elements = parent.GetElements<T>(deep, predicate);

    public T this[int index] => this._elements.GetItemByIndex<T>(index);

    public T this[string id] => this._elements.GetElementById<T>(id);

    public int Length => this._elements.Count<T>();

    public IEnumerator<T> GetEnumerator() => this._elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._elements.GetEnumerator();
  }
}
