// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssNamespaceRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssNamespaceRule : 
    CssRule,
    ICssNamespaceRule,
    ICssRule,
    ICssNode,
    IStyleFormattable
  {
    private string _namespaceUri;
    private string _prefix;

    internal CssNamespaceRule(CssParser parser)
      : base(CssRuleType.Namespace, parser)
    {
    }

    public string NamespaceUri
    {
      get => this._namespaceUri;
      set
      {
        this.CheckValidity();
        this._namespaceUri = value ?? string.Empty;
      }
    }

    public string Prefix
    {
      get => this._prefix;
      set
      {
        this.CheckValidity();
        this._prefix = value ?? string.Empty;
      }
    }

    protected override void ReplaceWith(ICssRule rule)
    {
      CssNamespaceRule cssNamespaceRule = rule as CssNamespaceRule;
      this._namespaceUri = cssNamespaceRule._namespaceUri;
      this._prefix = cssNamespaceRule._prefix;
      base.ReplaceWith(rule);
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string str = this._prefix + (string.IsNullOrEmpty(this._prefix) ? string.Empty : " ") + this._namespaceUri.CssUrl();
      writer.Write(formatter.Rule("@namespace", str));
    }

    private static bool IsNotSupported(CssRuleType type) => type != CssRuleType.Charset && type != CssRuleType.Import && type != CssRuleType.Namespace;

    private void CheckValidity()
    {
      ICssRuleList rules = this.Owner?.Rules;
      if (rules == null)
        return;
      foreach (ICssRule cssRule in (IEnumerable<ICssRule>) rules)
      {
        if (CssNamespaceRule.IsNotSupported(cssRule.Type))
          throw new DomException(DomError.InvalidState);
      }
    }
  }
}
