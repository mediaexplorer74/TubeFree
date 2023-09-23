// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssRuleList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssRuleList : ICssRuleList, IEnumerable<ICssRule>, IEnumerable
  {
    private readonly CssNode _parent;

    internal CssRuleList(CssNode parent) => this._parent = parent;

    public CssRule this[int index] => this.Nodes.GetItemByIndex<CssRule>(index);

    ICssRule ICssRuleList.this[int index] => (ICssRule) this[index];

    public bool HasDeclarativeRules => this.Nodes.Any<CssRule>((Func<CssRule, bool>) (m => CssRuleList.IsDeclarativeRule(m)));

    public IEnumerable<CssRule> Nodes => this._parent.Children.OfType<CssRule>();

    public int Length => this.Nodes.Count<CssRule>();

    internal void RemoveAt(int index)
    {
      CssRule rule = index >= 0 && index < this.Length ? this[index] : throw new DomException(DomError.IndexSizeError);
      if (rule.Type == CssRuleType.Namespace && this.HasDeclarativeRules)
        throw new DomException(DomError.InvalidState);
      this.Remove(rule);
    }

    internal void Remove(CssRule rule)
    {
      if (rule == null)
        return;
      this._parent.RemoveChild((ICssNode) rule);
    }

    internal void Insert(int index, CssRule rule)
    {
      if (rule == null)
        throw new DomException(DomError.Syntax);
      if (rule.Type == CssRuleType.Charset)
        throw new DomException(DomError.Syntax);
      if (index > this.Length || index < 0)
        throw new DomException(DomError.IndexSizeError);
      if (rule.Type == CssRuleType.Namespace && this.HasDeclarativeRules)
        throw new DomException(DomError.InvalidState);
      if (index == this.Length)
        this._parent.AppendChild((ICssNode) rule);
      else
        this._parent.InsertBefore((ICssNode) this[index], (ICssNode) rule);
    }

    internal void Add(CssRule rule)
    {
      if (rule == null)
        return;
      this._parent.AppendChild((ICssNode) rule);
    }

    public IEnumerator<ICssRule> GetEnumerator() => (IEnumerator<ICssRule>) this.Nodes.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    private static bool IsDeclarativeRule(CssRule rule)
    {
      CssRuleType type = rule.Type;
      switch (type)
      {
        case CssRuleType.Charset:
        case CssRuleType.Import:
          return false;
        default:
          return type != CssRuleType.Namespace;
      }
    }
  }
}
