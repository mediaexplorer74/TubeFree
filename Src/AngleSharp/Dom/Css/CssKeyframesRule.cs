// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssKeyframesRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssKeyframesRule : 
    CssRule,
    ICssKeyframesRule,
    ICssRule,
    ICssNode,
    IStyleFormattable
  {
    private readonly CssRuleList _rules;
    private string _name;

    internal CssKeyframesRule(CssParser parser)
      : base(CssRuleType.Keyframes, parser)
    {
      this._rules = new CssRuleList((CssNode) this);
    }

    public string Name
    {
      get => this._name;
      set => this._name = value;
    }

    public CssRuleList Rules => this._rules;

    ICssRuleList ICssKeyframesRule.Rules => (ICssRuleList) this._rules;

    public void Add(string ruleText) => this._rules.Add((CssRule) this.Parser.ParseKeyframeRule(ruleText));

    public void Remove(string key) => this._rules.Remove((CssRule) this.Find(key));

    public CssKeyframeRule Find(string key) => this._rules.OfType<CssKeyframeRule>().FirstOrDefault<CssKeyframeRule>((Func<CssKeyframeRule, bool>) (m => key.Isi(m.KeyText)));

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string rules = formatter.Block((IEnumerable<IStyleFormattable>) this.Rules);
      writer.Write(formatter.Rule("@keyframes", this._name, rules));
    }

    ICssKeyframeRule ICssKeyframesRule.Find(string key) => (ICssKeyframeRule) this.Find(key);

    protected override void ReplaceWith(ICssRule rule)
    {
      this._name = (rule as CssKeyframesRule)._name;
      base.ReplaceWith(rule);
    }
  }
}
