// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssStyleSheet
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSStyleSheet")]
  public interface ICssStyleSheet : IStyleSheet, IStyleFormattable, ICssNode, ICssRuleCreator
  {
    [DomName("ownerRule")]
    ICssRule OwnerRule { get; }

    [DomName("cssRules")]
    ICssRuleList Rules { get; }

    [DomName("parentStyleSheet")]
    ICssStyleSheet Parent { get; }

    [DomName("insertRule")]
    int Insert(string rule, int index);

    [DomName("deleteRule")]
    void RemoveAt(int index);
  }
}
