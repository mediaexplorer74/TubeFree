// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.HtmlFormControlsCollection
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class HtmlFormControlsCollection : 
    IHtmlFormControlsCollection,
    IHtmlCollection<IHtmlElement>,
    IEnumerable<IHtmlElement>,
    IEnumerable
  {
    private readonly IEnumerable<HtmlFormControlElement> _elements;

    public HtmlFormControlsCollection(IElement form, IElement root = null)
    {
      if (root == null)
        root = form.Owner.DocumentElement;
      this._elements = root.GetElements<HtmlFormControlElement>().Where<HtmlFormControlElement>((Func<HtmlFormControlElement, bool>) (m => m.Form == form && (!(m is IHtmlInputElement htmlInputElement) || !htmlInputElement.Type.Is(InputTypeNames.Image))));
    }

    public int Length => this._elements.Count<HtmlFormControlElement>();

    public HtmlFormControlElement this[int index] => this._elements.GetItemByIndex<HtmlFormControlElement>(index);

    public HtmlFormControlElement this[string id] => this._elements.GetElementById<HtmlFormControlElement>(id);

    public IEnumerator<HtmlFormControlElement> GetEnumerator() => this._elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._elements.GetEnumerator();

    IHtmlElement IHtmlCollection<IHtmlElement>.this[int index] => (IHtmlElement) this[index];

    IHtmlElement IHtmlCollection<IHtmlElement>.this[string id] => (IHtmlElement) this[id];

    IEnumerator<IHtmlElement> IEnumerable<IHtmlElement>.GetEnumerator() => (IEnumerator<IHtmlElement>) this._elements.GetEnumerator();
  }
}
