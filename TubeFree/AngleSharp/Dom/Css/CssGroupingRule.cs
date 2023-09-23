// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssGroupingRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Parser.Css;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssGroupingRule : 
    CssRule,
    ICssGroupingRule,
    ICssRule,
    ICssNode,
    IStyleFormattable,
    ICssRuleCreator
  {
    private readonly CssRuleList _rules;

    internal CssGroupingRule(CssRuleType type, CssParser parser)
      : base(type, parser)
    {
      this._rules = new CssRuleList((CssNode) this);
    }

    public CssRuleList Rules => this._rules;

    ICssRuleList ICssGroupingRule.Rules => (ICssRuleList) this.Rules;

    public ICssRule AddNewRule(CssRuleType ruleType)
    {
      CssRule rule = this.Parser.CreateRule(ruleType);
      this.Rules.Add(rule);
      return (ICssRule) rule;
    }

    public int Insert(string ruleText, int index)
    {
      CssRule rule = this.Parser.ParseRule(ruleText);
      this.Rules.Insert(index, rule);
      return index;
    }

    public void RemoveAt(int index) => this.Rules.RemoveAt(index);
  }
}
