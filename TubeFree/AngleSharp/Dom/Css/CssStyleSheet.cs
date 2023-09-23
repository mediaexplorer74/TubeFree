// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssStyleSheet
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssStyleSheet : 
    CssNode,
    ICssStyleSheet,
    IStyleSheet,
    IStyleFormattable,
    ICssNode,
    ICssRuleCreator
  {
    private readonly MediaList _media;
    private readonly string _url;
    private readonly IElement _owner;
    private readonly ICssStyleSheet _parent;
    private readonly CssRuleList _rules;
    private readonly CssParser _parser;
    private readonly ICssRule _ownerRule;

    internal CssStyleSheet(CssParser parser, string url, IElement owner)
    {
      this._media = new MediaList(parser);
      this._owner = owner;
      this._url = url;
      this._rules = new CssRuleList((CssNode) this);
      this._parser = parser;
    }

    internal CssStyleSheet(CssParser parser, string url, ICssStyleSheet parent)
      : this(parser, url, parent?.OwnerNode)
    {
      this._parent = parent;
    }

    internal CssStyleSheet(CssParser parser)
      : this(parser, (string) null, (ICssStyleSheet) null)
    {
    }

    internal CssStyleSheet(CssRule ownerRule, string url)
      : this(ownerRule.Parser, url, ownerRule.Owner)
    {
      this._ownerRule = (ICssRule) ownerRule;
    }

    public string Type => MimeTypeNames.Css;

    public bool IsDisabled { get; set; }

    public IElement OwnerNode => this._owner;

    public ICssStyleSheet Parent => this._parent;

    public string Href => this._url;

    public string Title => this._owner?.GetAttribute(AttributeNames.Title);

    public IMediaList Media => (IMediaList) this._media;

    ICssRuleList ICssStyleSheet.Rules => (ICssRuleList) this.Rules;

    public ICssRule OwnerRule => this._ownerRule;

    internal CssRuleList Rules => this._rules;

    public ICssRule AddNewRule(CssRuleType ruleType)
    {
      CssRule rule = this._parser.CreateRule(ruleType);
      this.Rules.Add(rule);
      return (ICssRule) rule;
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Sheet((IEnumerable<IStyleFormattable>) this.Rules));

    public void RemoveAt(int index) => this.Rules.RemoveAt(index);

    public int Insert(string ruleText, int index)
    {
      CssRule rule = this._parser.ParseRule(ruleText);
      rule.Owner = (ICssStyleSheet) this;
      this.Rules.Insert(index, rule);
      return index;
    }
  }
}
