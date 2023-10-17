// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlOptionsCollection
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLOptionsCollection")]
  public interface IHtmlOptionsCollection : 
    IHtmlCollection<IHtmlOptionElement>,
    IEnumerable<IHtmlOptionElement>,
    IEnumerable
  {
    [DomAccessor(Accessors.Getter)]
    IHtmlOptionElement GetOptionAt(int index);

    [DomAccessor(Accessors.Setter)]
    void SetOptionAt(int index, IHtmlOptionElement option);

    [DomName("add")]
    void Add(IHtmlOptionElement element, IHtmlElement before = null);

    [DomName("add")]
    void Add(IHtmlOptionsGroupElement element, IHtmlElement before = null);

    [DomName("remove")]
    void Remove(int index);

    [DomName("selectedIndex")]
    int SelectedIndex { get; set; }
  }
}
