// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssKeyframeRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Parser.Css;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssKeyframeRule : 
    CssRule,
    ICssKeyframeRule,
    ICssRule,
    ICssNode,
    IStyleFormattable
  {
    internal CssKeyframeRule(CssParser parser)
      : base(CssRuleType.Keyframe, parser)
    {
      this.AppendChild((ICssNode) new CssStyleDeclaration((CssRule) this));
    }

    public string KeyText
    {
      get => this.Key.Text;
      set => this.Key = this.Parser.ParseKeyframeSelector(value) ?? throw new DomException(DomError.Syntax);
    }

    public IKeyframeSelector Key
    {
      get => this.Children.OfType<IKeyframeSelector>().FirstOrDefault<IKeyframeSelector>();
      set => this.ReplaceSingle((ICssNode) this.Key, (ICssNode) value);
    }

    ICssStyleDeclaration ICssKeyframeRule.Style => (ICssStyleDeclaration) this.Style;

    public CssStyleDeclaration Style => this.Children.OfType<CssStyleDeclaration>().FirstOrDefault<CssStyleDeclaration>();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Style(this.KeyText, (IStyleFormattable) this.Style));
  }
}
