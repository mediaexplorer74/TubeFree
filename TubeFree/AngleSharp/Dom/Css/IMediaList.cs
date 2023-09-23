// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.IMediaList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Css;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  [DomName("MediaList")]
  public interface IMediaList : ICssNode, IStyleFormattable, IEnumerable<ICssMedium>, IEnumerable
  {
    [DomName("mediaText")]
    string MediaText { get; set; }

    [DomName("length")]
    int Length { get; }

    [DomAccessor(Accessors.Getter)]
    [DomName("item")]
    string this[int index] { get; }

    [DomName("appendMedium")]
    void Add(string medium);

    [DomName("removeMedium")]
    void Remove(string medium);

    bool Validate(RenderDevice device);
  }
}
