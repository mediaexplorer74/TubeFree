// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssParserExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;

namespace AngleSharp.Parser.Css
{
  internal static class CssParserExtensions
  {
    private static readonly Dictionary<string, Func<string, DocumentFunction>> functionTypes = new Dictionary<string, Func<string, DocumentFunction>>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        FunctionNames.Url,
        (Func<string, DocumentFunction>) (str => (DocumentFunction) new UrlFunction(str))
      },
      {
        FunctionNames.Domain,
        (Func<string, DocumentFunction>) (str => (DocumentFunction) new DomainFunction(str))
      },
      {
        FunctionNames.UrlPrefix,
        (Func<string, DocumentFunction>) (str => (DocumentFunction) new UrlPrefixFunction(str))
      }
    };
    private static readonly Dictionary<string, Func<IEnumerable<IConditionFunction>, IConditionFunction>> groupCreators = new Dictionary<string, Func<IEnumerable<IConditionFunction>, IConditionFunction>>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        Keywords.And,
        new Func<IEnumerable<IConditionFunction>, IConditionFunction>(CssParserExtensions.CreateAndCondition)
      },
      {
        Keywords.Or,
        new Func<IEnumerable<IConditionFunction>, IConditionFunction>(CssParserExtensions.CreateOrCondition)
      }
    };

    private static IConditionFunction CreateAndCondition(IEnumerable<IConditionFunction> conditions)
    {
      AndCondition andCondition = new AndCondition();
      foreach (IConditionFunction condition in conditions)
        andCondition.AppendChild((ICssNode) condition);
      return (IConditionFunction) andCondition;
    }

    private static IConditionFunction CreateOrCondition(IEnumerable<IConditionFunction> conditions)
    {
      OrCondition orCondition = new OrCondition();
      foreach (IConditionFunction condition in conditions)
        orCondition.AppendChild((ICssNode) condition);
      return (IConditionFunction) orCondition;
    }

    public static CssTokenType GetTypeFromName(this string functionName)
    {
      Func<string, DocumentFunction> func = (Func<string, DocumentFunction>) null;
      return !CssParserExtensions.functionTypes.TryGetValue(functionName, out func) ? CssTokenType.Function : CssTokenType.Url;
    }

    public static Func<IEnumerable<IConditionFunction>, IConditionFunction> GetCreator(
      this string conjunction)
    {
      Func<IEnumerable<IConditionFunction>, IConditionFunction> creator = (Func<IEnumerable<IConditionFunction>, IConditionFunction>) null;
      CssParserExtensions.groupCreators.TryGetValue(conjunction, out creator);
      return creator;
    }

    public static int GetCode(this CssParseError code) => (int) code;

    public static bool Is(this CssToken token, CssTokenType a, CssTokenType b)
    {
      CssTokenType type = token.Type;
      return type == a || type == b;
    }

    public static bool IsNot(this CssToken token, CssTokenType a, CssTokenType b)
    {
      CssTokenType type = token.Type;
      return type != a && type != b;
    }

    public static bool IsNot(this CssToken token, CssTokenType a, CssTokenType b, CssTokenType c)
    {
      CssTokenType type = token.Type;
      return type != a && type != b && type != c;
    }

    public static bool IsDeclarationName(this CssToken token) => token.Type != CssTokenType.EndOfFile && token.Type != CssTokenType.Colon && token.Type != CssTokenType.Whitespace && token.Type != CssTokenType.Comment && token.Type != CssTokenType.CurlyBracketOpen && token.Type != CssTokenType.Semicolon;

    public static DocumentFunction ToDocumentFunction(this CssToken token)
    {
      if (token.Type == CssTokenType.Url)
      {
        Func<string, DocumentFunction> func = (Func<string, DocumentFunction>) null;
        string functionName = ((CssUrlToken) token).FunctionName;
        CssParserExtensions.functionTypes.TryGetValue(functionName, out func);
        return func(token.Data);
      }
      if (token.Type == CssTokenType.Function && token.Data.Isi(FunctionNames.Regexp))
      {
        string cssString = ((CssFunctionToken) token).ArgumentTokens.ToCssString();
        if (cssString != null)
          return (DocumentFunction) new RegexpFunction(cssString);
      }
      return (DocumentFunction) null;
    }

    public static CssRule CreateRule(this CssParser parser, CssRuleType type)
    {
      switch (type)
      {
        case CssRuleType.Style:
          return (CssRule) new CssStyleRule(parser);
        case CssRuleType.Charset:
          return (CssRule) new CssCharsetRule(parser);
        case CssRuleType.Import:
          return (CssRule) new CssImportRule(parser);
        case CssRuleType.Media:
          return (CssRule) new CssMediaRule(parser);
        case CssRuleType.FontFace:
          return (CssRule) new CssFontFaceRule(parser);
        case CssRuleType.Page:
          return (CssRule) new CssPageRule(parser);
        case CssRuleType.Keyframes:
          return (CssRule) new CssKeyframesRule(parser);
        case CssRuleType.Keyframe:
          return (CssRule) new CssKeyframeRule(parser);
        case CssRuleType.Namespace:
          return (CssRule) new CssNamespaceRule(parser);
        case CssRuleType.Supports:
          return (CssRule) new CssSupportsRule(parser);
        case CssRuleType.Document:
          return (CssRule) new CssDocumentRule(parser);
        case CssRuleType.Viewport:
          return (CssRule) new CssViewportRule(parser);
        default:
          return (CssRule) null;
      }
    }
  }
}
