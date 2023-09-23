// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssSupportsRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssSupportsRule : 
    CssConditionRule,
    ICssSupportsRule,
    ICssConditionRule,
    ICssGroupingRule,
    ICssRule,
    ICssNode,
    IStyleFormattable,
    ICssRuleCreator
  {
    internal CssSupportsRule(CssParser parser)
      : base(CssRuleType.Supports, parser)
    {
    }

    public string ConditionText
    {
      get => this.Condition.ToCss();
      set => this.Condition = this.Parser.ParseCondition(value) ?? throw new DomException(DomError.Syntax);
    }

    public IConditionFunction Condition
    {
      get => this.Children.OfType<IConditionFunction>().FirstOrDefault<IConditionFunction>() ?? (IConditionFunction) new EmptyCondition();
      set
      {
        if (value == null)
          return;
        this.RemoveChild((ICssNode) this.Condition);
        this.AppendChild((ICssNode) value);
      }
    }

    internal override bool IsValid(RenderDevice device) => this.Condition.Check();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string rules = formatter.Block((IEnumerable<IStyleFormattable>) this.Rules);
      writer.Write(formatter.Rule("@supports", this.ConditionText, rules));
    }
  }
}
