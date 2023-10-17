// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssStyleRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSStyleRule")]
  public interface ICssStyleRule : ICssRule, ICssNode, IStyleFormattable
  {
    [DomName("selectorText")]
    string SelectorText { get; set; }

    [DomName("style")]
    [DomPutForwards("cssText")]
    ICssStyleDeclaration Style { get; }

    ISelector Selector { get; set; }
  }
}
