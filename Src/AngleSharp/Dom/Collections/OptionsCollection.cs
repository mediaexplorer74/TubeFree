// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.OptionsCollection
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class OptionsCollection : 
    IHtmlOptionsCollection,
    IHtmlCollection<IHtmlOptionElement>,
    IEnumerable<IHtmlOptionElement>,
    IEnumerable
  {
    private readonly IElement _parent;
    private readonly IEnumerable<IHtmlOptionElement> _options;

    public OptionsCollection(IElement parent)
    {
      this._parent = parent;
      this._options = this.GetOptions();
    }

    public IHtmlOptionElement this[int index] => this.GetOptionAt(index);

    public IHtmlOptionElement this[string name]
    {
      get
      {
        if (string.IsNullOrEmpty(name))
          return (IHtmlOptionElement) null;
        foreach (IHtmlOptionElement option in this._options)
        {
          if (option.Id.Is(name))
            return option;
        }
        return this._parent.Children[name] as IHtmlOptionElement;
      }
    }

    public int SelectedIndex
    {
      get
      {
        int selectedIndex = 0;
        foreach (IHtmlOptionElement option in this._options)
        {
          if (option.IsSelected)
            return selectedIndex;
          ++selectedIndex;
        }
        return -1;
      }
      set
      {
        int num = 0;
        foreach (IHtmlOptionElement option in this._options)
          option.IsSelected = num++ == value;
      }
    }

    public int Length => this._options.Count<IHtmlOptionElement>();

    public IHtmlOptionElement GetOptionAt(int index) => this._options.GetItemByIndex<IHtmlOptionElement>(index);

    public void SetOptionAt(int index, IHtmlOptionElement value)
    {
      IHtmlOptionElement optionAt = this.GetOptionAt(index);
      if (optionAt != null)
        this._parent.ReplaceChild((INode) value, (INode) optionAt);
      else
        this._parent.AppendChild((INode) value);
    }

    public void Add(IHtmlOptionElement element, IHtmlElement before = null) => this._parent.InsertBefore((INode) element, (INode) before);

    public void Add(IHtmlOptionsGroupElement element, IHtmlElement before = null) => this._parent.InsertBefore((INode) element, (INode) before);

    public void Remove(int index)
    {
      if (index < 0 || index >= this.Length)
        return;
      this._parent.RemoveChild((INode) this.GetOptionAt(index));
    }

    private IEnumerable<IHtmlOptionElement> GetOptions()
    {
      foreach (INode child in (IEnumerable<INode>) this._parent.ChildNodes)
      {
        switch (child)
        {
          case IHtmlOptionsGroupElement optionsGroupElement:
            foreach (INode childNode in (IEnumerable<INode>) optionsGroupElement.ChildNodes)
            {
              if (childNode is IHtmlOptionElement option)
                yield return option;
            }
            break;
          case IHtmlOptionElement _:
            yield return (IHtmlOptionElement) child;
            break;
        }
      }
    }

    public IEnumerator<IHtmlOptionElement> GetEnumerator() => this._options.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
