// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IStyleSheet
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;

namespace AngleSharp.Dom
{
  [DomName("StyleSheet")]
  public interface IStyleSheet : IStyleFormattable
  {
    [DomName("type")]
    string Type { get; }

    [DomName("href")]
    string Href { get; }

    [DomName("ownerNode")]
    IElement OwnerNode { get; }

    [DomName("title")]
    string Title { get; }

    [DomName("media")]
    [DomPutForwards("mediaText")]
    IMediaList Media { get; }

    [DomName("disabled")]
    bool IsDisabled { get; set; }
  }
}
