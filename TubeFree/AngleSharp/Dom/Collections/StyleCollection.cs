// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.StyleCollection
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using System.Collections;
using System.Collections.Generic;

namespace AngleSharp.Dom.Collections
{
  internal sealed class StyleCollection : IEnumerable<CssStyleRule>, IEnumerable
  {
    private readonly IEnumerable<CssStyleSheet> _sheets;
    private readonly RenderDevice _device;

    public StyleCollection(IEnumerable<CssStyleSheet> sheets, RenderDevice device)
    {
      this._sheets = sheets;
      this._device = device;
    }

    public RenderDevice Device => this._device;

    public IEnumerator<CssStyleRule> GetEnumerator()
    {
      foreach (CssStyleSheet sheet in this._sheets)
      {
        if (!sheet.IsDisabled && sheet.Media.Validate(this._device))
        {
          foreach (CssStyleRule rule in this.GetRules(sheet.Rules))
            yield return rule;
        }
      }
    }

    private IEnumerable<CssStyleRule> GetRules(CssRuleList rules)
    {
      foreach (ICssRule rule1 in rules)
      {
        if (rule1.Type == CssRuleType.Media)
        {
          CssMediaRule cssMediaRule = (CssMediaRule) rule1;
          if (cssMediaRule.IsValid(this._device))
          {
            foreach (CssStyleRule rule2 in this.GetRules(cssMediaRule.Rules))
              yield return rule2;
          }
        }
        else if (rule1.Type == CssRuleType.Supports)
        {
          CssSupportsRule cssSupportsRule = (CssSupportsRule) rule1;
          if (cssSupportsRule.IsValid(this._device))
          {
            foreach (CssStyleRule rule3 in this.GetRules(cssSupportsRule.Rules))
              yield return rule3;
          }
        }
        else if (rule1.Type == CssRuleType.Style)
          yield return (CssStyleRule) rule1;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
