// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.StyleSheetExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Html;
using AngleSharp.Html;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  public static class StyleSheetExtensions
  {
    private static readonly Dictionary<string, CssRuleType> RuleMapping = new Dictionary<string, CssRuleType>()
    {
      {
        typeof (ICssCharsetRule).FullName,
        CssRuleType.Charset
      },
      {
        typeof (ICssCounterStyleRule).FullName,
        CssRuleType.CounterStyle
      },
      {
        typeof (ICssDocumentRule).FullName,
        CssRuleType.Document
      },
      {
        typeof (ICssFontFaceRule).FullName,
        CssRuleType.FontFace
      },
      {
        typeof (ICssFontFeatureValuesRule).FullName,
        CssRuleType.FontFeatureValues
      },
      {
        typeof (ICssImportRule).FullName,
        CssRuleType.Import
      },
      {
        typeof (ICssKeyframeRule).FullName,
        CssRuleType.Keyframe
      },
      {
        typeof (ICssKeyframesRule).FullName,
        CssRuleType.Keyframes
      },
      {
        typeof (ICssMediaRule).FullName,
        CssRuleType.Media
      },
      {
        typeof (ICssNamespaceRule).FullName,
        CssRuleType.Namespace
      },
      {
        typeof (ICssPageRule).FullName,
        CssRuleType.Page
      },
      {
        typeof (ICssStyleRule).FullName,
        CssRuleType.Style
      },
      {
        typeof (ICssSupportsRule).FullName,
        CssRuleType.Supports
      }
    };

    public static TRule AddNewRule<TRule>(this ICssRuleCreator creator) where TRule : ICssRule
    {
      string fullName = typeof (TRule).FullName;
      CssRuleType ruleType = CssRuleType.Unknown;
      return StyleSheetExtensions.RuleMapping.TryGetValue(fullName, out ruleType) && creator.AddNewRule(ruleType) is TRule rule ? rule : default (TRule);
    }

    public static ICssStyleRule AddNewStyle(
      this ICssRuleCreator creator,
      string selector = null,
      IDictionary<string, string> declarations = null)
    {
      ICssStyleRule cssStyleRule = creator.AddNewRule<ICssStyleRule>();
      if (!string.IsNullOrEmpty(selector))
        cssStyleRule.SelectorText = selector;
      if (declarations != null)
      {
        foreach (KeyValuePair<string, string> declaration in (IEnumerable<KeyValuePair<string, string>>) declarations)
          cssStyleRule.Style.SetProperty(declaration.Key, declaration.Value);
      }
      return cssStyleRule;
    }

    public static ICssStyleRule AddNewStyle(
      this ICssRuleCreator creator,
      string selector,
      object declarations)
    {
      return StyleSheetExtensions.AddNewStyle(creator, selector, (IDictionary<string, string>) declarations.ToDictionary());
    }

    public static IEnumerable<TRule> RulesOf<TRule>(this IEnumerable<IStyleSheet> sheets) where TRule : ICssRule
    {
      if (sheets == null)
        throw new ArgumentNullException(nameof (sheets));
      return sheets.Where<IStyleSheet>((Func<IStyleSheet, bool>) (m => !m.IsDisabled)).OfType<ICssStyleSheet>().SelectMany<ICssStyleSheet, ICssRule>((Func<ICssStyleSheet, IEnumerable<ICssRule>>) (m => (IEnumerable<ICssRule>) m.Rules)).OfType<TRule>();
    }

    public static IEnumerable<ICssStyleRule> StylesWith(
      this IEnumerable<IStyleSheet> sheets,
      ISelector selector)
    {
      string selectorText = selector != null ? selector.Text : throw new ArgumentNullException(nameof (selector));
      return sheets.RulesOf<ICssStyleRule>().Where<ICssStyleRule>((Func<ICssStyleRule, bool>) (m => m.SelectorText == selectorText));
    }

    public static IDocument GetDocument(this IStyleSheet sheet) => sheet?.OwnerNode?.Owner;

    public static IEnumerable<ICssComment> GetComments(this ICssNode node) => node.GetAll<ICssComment>();

    public static IEnumerable<ICssNode> GetAllDescendents(this ICssNode node)
    {
      if (node == null)
        throw new ArgumentNullException(nameof (node));
      return node.Children.SelectMany<ICssNode, ICssNode>((Func<ICssNode, IEnumerable<ICssNode>>) (m => m.GetAllDescendents()));
    }

    public static IEnumerable<T> GetAll<T>(this ICssNode node) where T : IStyleFormattable
    {
      if (node == null)
        throw new ArgumentNullException(nameof (node));
      if (node is T obj1)
        yield return obj1;
      foreach (T obj2 in node.Children.SelectMany<ICssNode, T>((Func<ICssNode, IEnumerable<T>>) (m => m.GetAll<T>())))
        yield return obj2;
    }

    public static bool IsPersistent(this IHtmlLinkElement link) => link.Relation.Isi(LinkRelNames.StyleSheet) && link.Title == null;

    public static bool IsPreferred(this IHtmlLinkElement link) => link.Relation.Isi(LinkRelNames.StyleSheet) && link.Title != null;

    public static bool IsAlternate(this IHtmlLinkElement link)
    {
      ITokenList relationList = link.RelationList;
      return relationList.Contains(LinkRelNames.StyleSheet) && relationList.Contains(LinkRelNames.Alternate) && link.Title != null;
    }
  }
}
