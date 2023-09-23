// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssFontFaceRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSFontFaceRule")]
  public interface ICssFontFaceRule : 
    ICssRule,
    ICssNode,
    IStyleFormattable,
    ICssProperties,
    IEnumerable<ICssProperty>,
    IEnumerable
  {
    [DomName("family")]
    string Family { get; set; }

    [DomName("src")]
    string Source { get; set; }

    [DomName("style")]
    string Style { get; set; }

    [DomName("weight")]
    string Weight { get; set; }

    [DomName("stretch")]
    string Stretch { get; set; }

    [DomName("unicodeRange")]
    string Range { get; set; }

    [DomName("variant")]
    string Variant { get; set; }

    [DomName("featureSettings")]
    string Features { get; set; }
  }
}
