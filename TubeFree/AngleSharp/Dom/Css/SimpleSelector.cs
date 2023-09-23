// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.SimpleSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class SimpleSelector : CssNode, ISelector, ICssNode, IStyleFormattable
  {
    private readonly Predicate<IElement> _matches;
    private readonly Priority _specifity;
    private readonly string _code;
    public static readonly SimpleSelector All = new SimpleSelector();

    public SimpleSelector()
      : this((Predicate<IElement>) (_ => true), Priority.Zero, Keywords.Asterisk)
    {
    }

    public SimpleSelector(string match)
      : this((Predicate<IElement>) (el => match.Isi(el.LocalName)), Priority.OneTag, match)
    {
    }

    public SimpleSelector(Predicate<IElement> matches, Priority specifify, string code)
    {
      this._matches = matches;
      this._specifity = specifify;
      this._code = code;
    }

    public Priority Specifity => this._specifity;

    public string Text => this._code;

    public static SimpleSelector PseudoElement(Predicate<IElement> action, string pseudoElement) => new SimpleSelector(action, Priority.OneTag, PseudoElementNames.Separator + pseudoElement);

    public static SimpleSelector PseudoClass(Predicate<IElement> action, string pseudoClass) => new SimpleSelector(action, Priority.OneClass, PseudoClassNames.Separator + pseudoClass);

    public static SimpleSelector Class(string match) => new SimpleSelector((Predicate<IElement>) (_ => _.ClassList.Contains(match)), Priority.OneClass, "." + match);

    public static SimpleSelector Id(string match) => new SimpleSelector((Predicate<IElement>) (_ => _.Id.Is(match)), Priority.OneId, "#" + match);

    public static SimpleSelector AttrAvailable(string match, string prefix = null, bool insensitive = false)
    {
      string content = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        content = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(content);
      return new SimpleSelector((Predicate<IElement>) (_ => _.HasAttribute(match)), Priority.OneClass, code);
    }

    public static SimpleSelector AttrMatch(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector((Predicate<IElement>) (_ => string.Equals(_.GetAttribute(match), value, comparison)), Priority.OneClass, code);
    }

    public static SimpleSelector AttrNotMatch(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "!=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector((Predicate<IElement>) (_ => !string.Equals(_.GetAttribute(match), value, comparison)), Priority.OneClass, code);
    }

    public static SimpleSelector AttrList(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "~=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector(SimpleSelector.Select(value, (Predicate<IElement>) (_ => (_.GetAttribute(match) ?? string.Empty).SplitSpaces().Contains(value, comparison))), Priority.OneClass, code);
    }

    public static SimpleSelector AttrBegins(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "^=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector(SimpleSelector.Select(value, (Predicate<IElement>) (_ => (_.GetAttribute(match) ?? string.Empty).StartsWith(value, comparison))), Priority.OneClass, code);
    }

    public static SimpleSelector AttrEnds(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "$=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector(SimpleSelector.Select(value, (Predicate<IElement>) (_ => (_.GetAttribute(match) ?? string.Empty).EndsWith(value, comparison))), Priority.OneClass, code);
    }

    public static SimpleSelector AttrContains(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "*=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector(SimpleSelector.Select(value, (Predicate<IElement>) (_ => (_.GetAttribute(match) ?? string.Empty).IndexOf(value, comparison) != -1)), Priority.OneClass, code);
    }

    public static SimpleSelector AttrHyphen(
      string match,
      string value,
      string prefix = null,
      bool insensitive = false)
    {
      string name = match;
      if (!string.IsNullOrEmpty(prefix))
      {
        name = SimpleSelector.FormFront(prefix, match);
        match = SimpleSelector.FormMatch(prefix, match);
      }
      string code = SimpleSelector.FormCode(name, "|=", value.CssString());
      StringComparison comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      return new SimpleSelector(SimpleSelector.Select(value, (Predicate<IElement>) (_ => (_.GetAttribute(match) ?? string.Empty).HasHyphen(value, comparison))), Priority.OneClass, code);
    }

    public static SimpleSelector Type(string match) => new SimpleSelector(match);

    public bool Match(IElement element) => this._matches(element);

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(this.Text);

    private static Predicate<IElement> Select(string value, Predicate<IElement> predicate) => !string.IsNullOrEmpty(value) ? predicate : (Predicate<IElement>) (_ => false);

    private static string FormCode(string content) => "[" + content + "]";

    private static string FormCode(string name, string op, string value) => SimpleSelector.FormCode(name + op + value);

    private static string FormFront(string prefix, string match) => prefix + CombinatorSymbols.Pipe + match;

    private static string FormMatch(string prefix, string match) => !prefix.Is(Keywords.Asterisk) ? prefix + PseudoClassNames.Separator + match : match;
  }
}
