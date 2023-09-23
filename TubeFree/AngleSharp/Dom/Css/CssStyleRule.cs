// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssStyleRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Parser.Css;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssStyleRule : CssRule, ICssStyleRule, ICssRule, ICssNode, IStyleFormattable
  {
    internal CssStyleRule(CssParser parser)
      : base(CssRuleType.Style, parser)
    {
      this.AppendChild((ICssNode) SimpleSelector.All);
      this.AppendChild((ICssNode) new CssStyleDeclaration((CssRule) this));
    }

    public ISelector Selector
    {
      get => this.Children.OfType<ISelector>().FirstOrDefault<ISelector>();
      set => this.ReplaceSingle((ICssNode) this.Selector, (ICssNode) value);
    }

    public string SelectorText
    {
      get => this.Selector.Text;
      set => this.Selector = this.Parser.ParseSelector(value);
    }

    ICssStyleDeclaration ICssStyleRule.Style => (ICssStyleDeclaration) this.Style;

    public CssStyleDeclaration Style => this.Children.OfType<CssStyleDeclaration>().FirstOrDefault<CssStyleDeclaration>();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Style(this.SelectorText, (IStyleFormattable) this.Style));
  }
}
