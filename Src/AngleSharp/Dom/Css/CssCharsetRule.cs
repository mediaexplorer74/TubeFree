// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssCharsetRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssCharsetRule : 
    CssRule,
    ICssCharsetRule,
    ICssRule,
    ICssNode,
    IStyleFormattable
  {
    internal CssCharsetRule(CssParser parser)
      : base(CssRuleType.Charset, parser)
    {
    }

    public string CharacterSet { get; set; }

    protected override void ReplaceWith(ICssRule rule)
    {
      this.CharacterSet = (rule as CssCharsetRule).CharacterSet;
      base.ReplaceWith(rule);
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Rule("@charset", this.CharacterSet.CssString()));
  }
}
