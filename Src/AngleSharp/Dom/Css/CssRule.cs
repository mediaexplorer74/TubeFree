// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssRule : CssNode, ICssRule, ICssNode, IStyleFormattable
  {
    private readonly CssRuleType _type;
    private readonly CssParser _parser;
    private ICssStyleSheet _ownerSheet;
    private ICssRule _parentRule;

    internal CssRule(CssRuleType type, CssParser parser)
    {
      this._type = type;
      this._parser = parser;
    }

    public string CssText
    {
      get => this.ToCss();
      set
      {
        CssRule rule = this._parser.ParseRule(value);
        if (rule == null)
          throw new DomException(DomError.Syntax);
        if (rule.Type != this._type)
          throw new DomException(DomError.InvalidModification);
        this.ReplaceWith((ICssRule) rule);
      }
    }

    public ICssRule Parent
    {
      get => this._parentRule;
      internal set
      {
        this._parentRule = value;
        if (value == null)
          return;
        this._ownerSheet = this._parentRule.Owner;
      }
    }

    public ICssStyleSheet Owner
    {
      get => this._ownerSheet;
      internal set => this._ownerSheet = value;
    }

    public CssRuleType Type => this._type;

    internal CssParser Parser => this._parser;

    protected virtual void ReplaceWith(ICssRule rule) => this.ReplaceAll((ICssNode) rule);

    protected void ReplaceSingle(ICssNode oldNode, ICssNode newNode)
    {
      if (oldNode != null)
      {
        if (newNode != null)
          this.ReplaceChild(oldNode, newNode);
        else
          this.RemoveChild(oldNode);
      }
      else
      {
        if (newNode == null)
          return;
        this.AppendChild(newNode);
      }
    }
  }
}
