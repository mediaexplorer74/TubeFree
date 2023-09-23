// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssDocumentRule
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
  internal sealed class CssDocumentRule : 
    CssGroupingRule,
    ICssDocumentRule,
    ICssConditionRule,
    ICssGroupingRule,
    ICssRule,
    ICssNode,
    IStyleFormattable,
    ICssRuleCreator
  {
    internal CssDocumentRule(CssParser parser)
      : base(CssRuleType.Document, parser)
    {
    }

    public string ConditionText
    {
      get => string.Join(", ", this.Conditions.Select<IDocumentFunction, string>((Func<IDocumentFunction, string>) (m => m.ToCss())));
      set
      {
        List<DocumentFunction> documentRules = this.Parser.ParseDocumentRules(value);
        if (documentRules == null)
          throw new DomException(DomError.Syntax);
        this.Clear();
        foreach (ICssNode child in documentRules)
          this.AppendChild(child);
      }
    }

    public IEnumerable<IDocumentFunction> Conditions => this.Children.OfType<IDocumentFunction>();

    internal bool IsValid(Url url) => this.Conditions.Any<IDocumentFunction>((Func<IDocumentFunction, bool>) (m => m.Matches(url)));

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string rules = formatter.Block((IEnumerable<IStyleFormattable>) this.Rules);
      writer.Write(formatter.Rule("@document", this.ConditionText, rules));
    }
  }
}
