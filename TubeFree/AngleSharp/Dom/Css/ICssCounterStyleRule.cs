// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ICssCounterStyleRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Css
{
  [DomName("CSSCounterStyleRule")]
  public interface ICssCounterStyleRule : ICssRule, ICssNode, IStyleFormattable
  {
    [DomName("name")]
    string Name { get; set; }

    [DomName("system")]
    string System { get; set; }

    [DomName("symbols")]
    string Symbols { get; set; }

    [DomName("additiveSymbols")]
    string AdditiveSymbols { get; set; }

    [DomName("negative")]
    string Negative { get; set; }

    [DomName("prefix")]
    string Prefix { get; set; }

    [DomName("suffix")]
    string Suffix { get; set; }

    [DomName("range")]
    string Range { get; set; }

    [DomName("pad")]
    string Pad { get; set; }

    [DomName("speakAs")]
    string SpeakAs { get; set; }

    [DomName("fallback")]
    string Fallback { get; set; }
  }
}
