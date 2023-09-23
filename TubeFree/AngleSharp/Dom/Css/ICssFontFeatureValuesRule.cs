// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssFontFeatureValuesRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSFontFeatureValuesRule")]
  public interface ICssFontFeatureValuesRule : ICssRule, ICssNode, IStyleFormattable
  {
    [DomName("fontFamily")]
    string Family { get; set; }
  }
}
