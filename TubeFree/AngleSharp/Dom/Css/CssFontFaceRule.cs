// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssFontFaceRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Parser.Css;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssFontFaceRule : 
    CssDeclarationRule,
    ICssFontFaceRule,
    ICssRule,
    ICssNode,
    IStyleFormattable,
    ICssProperties,
    IEnumerable<ICssProperty>,
    IEnumerable
  {
    internal CssFontFaceRule(CssParser parser)
      : base(CssRuleType.FontFace, RuleNames.FontFace, parser)
    {
    }

    string ICssFontFaceRule.Family
    {
      get => this.GetValue(PropertyNames.FontFamily);
      set => this.SetValue(PropertyNames.FontFamily, value);
    }

    string ICssFontFaceRule.Source
    {
      get => this.GetValue(PropertyNames.Src);
      set => this.SetValue(PropertyNames.Src, value);
    }

    string ICssFontFaceRule.Style
    {
      get => this.GetValue(PropertyNames.FontStyle);
      set => this.SetValue(PropertyNames.FontStyle, value);
    }

    string ICssFontFaceRule.Weight
    {
      get => this.GetValue(PropertyNames.FontWeight);
      set => this.SetValue(PropertyNames.FontWeight, value);
    }

    string ICssFontFaceRule.Stretch
    {
      get => this.GetValue(PropertyNames.FontStretch);
      set => this.SetValue(PropertyNames.FontStretch, value);
    }

    string ICssFontFaceRule.Range
    {
      get => this.GetValue(PropertyNames.UnicodeRange);
      set => this.SetValue(PropertyNames.UnicodeRange, value);
    }

    string ICssFontFaceRule.Variant
    {
      get => this.GetValue(PropertyNames.FontVariant);
      set => this.SetValue(PropertyNames.FontVariant, value);
    }

    string ICssFontFaceRule.Features
    {
      get => string.Empty;
      set
      {
      }
    }

    protected override CssProperty CreateNewProperty(string name) => Factory.Properties.CreateFont(name);
  }
}
