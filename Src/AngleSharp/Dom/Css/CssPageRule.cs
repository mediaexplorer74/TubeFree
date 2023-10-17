// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssPageRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssPageRule : CssRule, ICssPageRule, ICssRule, ICssNode, IStyleFormattable
  {
    internal CssPageRule(CssParser parser)
      : base(CssRuleType.Page, parser)
    {
      this.AppendChild((ICssNode) SimpleSelector.All);
      this.AppendChild((ICssNode) new CssStyleDeclaration((CssRule) this));
    }

    public string SelectorText
    {
      get => this.Selector.Text;
      set => this.Selector = this.Parser.ParseSelector(value);
    }

    public ISelector Selector
    {
      get => this.Children.OfType<ISelector>().FirstOrDefault<ISelector>();
      set => this.ReplaceSingle((ICssNode) this.Selector, (ICssNode) value);
    }

    ICssStyleDeclaration ICssPageRule.Style => (ICssStyleDeclaration) this.Style;

    public CssStyleDeclaration Style => this.Children.OfType<CssStyleDeclaration>().FirstOrDefault<CssStyleDeclaration>();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string rules = formatter.Block((IEnumerable<IStyleFormattable>) this.Style);
      writer.Write(formatter.Rule("@page", this.SelectorText, rules));
    }
  }
}
