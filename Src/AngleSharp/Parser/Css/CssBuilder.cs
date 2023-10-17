// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssBuilder
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;
using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssBuilder
  {
    private readonly CssTokenizer _tokenizer;
    private readonly CssParser _parser;
    private readonly Stack<CssNode> _nodes;

    public CssBuilder(CssTokenizer tokenizer, CssParser parser)
    {
      this._tokenizer = tokenizer;
      this._parser = parser;
      this._nodes = new Stack<CssNode>();
    }

    public CssRule CreateAtRule(CssToken token)
    {
      if (token.Data.Is(RuleNames.Media))
        return this.CreateMedia(token);
      if (token.Data.Is(RuleNames.FontFace))
        return this.CreateFontFace(token);
      if (token.Data.Is(RuleNames.Keyframes))
        return this.CreateKeyframes(token);
      if (token.Data.Is(RuleNames.Import))
        return this.CreateImport(token);
      if (token.Data.Is(RuleNames.Charset))
        return this.CreateCharset(token);
      if (token.Data.Is(RuleNames.Namespace))
        return this.CreateNamespace(token);
      if (token.Data.Is(RuleNames.Page))
        return this.CreatePage(token);
      if (token.Data.Is(RuleNames.Supports))
        return this.CreateSupports(token);
      if (token.Data.Is(RuleNames.ViewPort))
        return this.CreateViewport(token);
      return token.Data.Is(RuleNames.Document) ? this.CreateDocument(token) : this.CreateUnknown(token);
    }

    public CssRule CreateRule(CssToken token)
    {
      switch (token.Type)
      {
        case CssTokenType.String:
        case CssTokenType.Url:
        case CssTokenType.RoundBracketClose:
        case CssTokenType.CurlyBracketClose:
        case CssTokenType.SquareBracketClose:
          this.RaiseErrorOccurred(CssParseError.InvalidToken, token.Position);
          this.JumpToRuleEnd(ref token);
          return (CssRule) null;
        case CssTokenType.AtKeyword:
          return this.CreateAtRule(token);
        case CssTokenType.CurlyBracketOpen:
          this.RaiseErrorOccurred(CssParseError.InvalidBlockStart, token.Position);
          this.JumpToRuleEnd(ref token);
          return (CssRule) null;
        default:
          return this.CreateStyle(token);
      }
    }

    public CssRule CreateCharset(CssToken current)
    {
      CssCharsetRule charset = new CssCharsetRule(this._parser);
      TextPosition position = current.Position;
      CssToken cssToken = this.NextToken();
      this._nodes.Push((CssNode) charset);
      this.CollectTrivia(ref cssToken);
      if (cssToken.Type == CssTokenType.String)
        charset.CharacterSet = cssToken.Data;
      this.JumpToEnd(ref cssToken);
      charset.SourceCode = this.CreateView(position, cssToken.Position);
      this._nodes.Pop();
      return (CssRule) charset;
    }

    public CssRule CreateDocument(CssToken current)
    {
      CssDocumentRule rule = new CssDocumentRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) rule);
      this.CollectTrivia(ref token);
      this.FillFunctions((Action<DocumentFunction>) (function => rule.AppendChild((ICssNode) function)), ref token);
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.CurlyBracketOpen)
      {
        TextPosition end = this.FillRules((CssGroupingRule) rule);
        rule.SourceCode = this.CreateView(position, end);
        this._nodes.Pop();
        return (CssRule) rule;
      }
      this._nodes.Pop();
      return this.SkipDeclarations(token);
    }

    public CssRule CreateViewport(CssToken current)
    {
      CssViewportRule rule = new CssViewportRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) rule);
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.CurlyBracketOpen)
      {
        TextPosition end = this.FillDeclarations((CssDeclarationRule) rule, new Func<string, CssProperty>(Factory.Properties.CreateViewport));
        rule.SourceCode = this.CreateView(position, end);
        this._nodes.Pop();
        return (CssRule) rule;
      }
      this._nodes.Pop();
      return this.SkipDeclarations(token);
    }

    public CssRule CreateFontFace(CssToken current)
    {
      CssFontFaceRule rule = new CssFontFaceRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) rule);
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.CurlyBracketOpen)
      {
        TextPosition end = this.FillDeclarations((CssDeclarationRule) rule, new Func<string, CssProperty>(Factory.Properties.CreateFont));
        rule.SourceCode = this.CreateView(position, end);
        this._nodes.Pop();
        return (CssRule) rule;
      }
      this._nodes.Pop();
      return this.SkipDeclarations(token);
    }

    public CssRule CreateImport(CssToken current)
    {
      CssImportRule import = new CssImportRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) import);
      this.CollectTrivia(ref token);
      if (token.Is(CssTokenType.String, CssTokenType.Url))
      {
        import.Href = token.Data;
        token = this.NextToken();
        this.CollectTrivia(ref token);
        this.FillMediaList(import.Media, CssTokenType.Semicolon, ref token);
      }
      this.CollectTrivia(ref token);
      this.JumpToEnd(ref token);
      import.SourceCode = this.CreateView(position, token.Position);
      this._nodes.Pop();
      return (CssRule) import;
    }

    public CssRule CreateKeyframes(CssToken current)
    {
      CssKeyframesRule parentRule = new CssKeyframesRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) parentRule);
      this.CollectTrivia(ref token);
      parentRule.Name = this.GetRuleName(ref token);
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.CurlyBracketOpen)
      {
        TextPosition end = this.FillKeyframeRules(parentRule);
        parentRule.SourceCode = this.CreateView(position, end);
        this._nodes.Pop();
        return (CssRule) parentRule;
      }
      this._nodes.Pop();
      return this.SkipDeclarations(token);
    }

    public CssRule CreateMedia(CssToken current)
    {
      CssMediaRule group = new CssMediaRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) group);
      this.CollectTrivia(ref token);
      this.FillMediaList(group.Media, CssTokenType.CurlyBracketOpen, ref token);
      this.CollectTrivia(ref token);
      if (token.Type != CssTokenType.CurlyBracketOpen)
      {
        for (; token.Type != CssTokenType.EndOfFile; token = this.NextToken())
        {
          if (token.Type == CssTokenType.Semicolon)
          {
            this._nodes.Pop();
            return (CssRule) null;
          }
          if (token.Type == CssTokenType.CurlyBracketOpen)
            break;
        }
      }
      TextPosition end = this.FillRules((CssGroupingRule) group);
      group.SourceCode = this.CreateView(position, end);
      this._nodes.Pop();
      return (CssRule) group;
    }

    public CssRule CreateNamespace(CssToken current)
    {
      CssNamespaceRule cssNamespaceRule = new CssNamespaceRule(this._parser);
      TextPosition position = current.Position;
      CssToken cssToken = this.NextToken();
      this._nodes.Push((CssNode) cssNamespaceRule);
      this.CollectTrivia(ref cssToken);
      cssNamespaceRule.Prefix = this.GetRuleName(ref cssToken);
      this.CollectTrivia(ref cssToken);
      if (cssToken.Type == CssTokenType.Url)
        cssNamespaceRule.NamespaceUri = cssToken.Data;
      this.JumpToEnd(ref cssToken);
      cssNamespaceRule.SourceCode = this.CreateView(position, cssToken.Position);
      this._nodes.Pop();
      return (CssRule) cssNamespaceRule;
    }

    public CssRule CreatePage(CssToken current)
    {
      CssPageRule page = new CssPageRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) page);
      this.CollectTrivia(ref token);
      page.Selector = this.CreateSelector(ref token);
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.CurlyBracketOpen)
      {
        TextPosition end = this.FillDeclarations(page.Style);
        page.SourceCode = this.CreateView(position, end);
        this._nodes.Pop();
        return (CssRule) page;
      }
      this._nodes.Pop();
      return this.SkipDeclarations(token);
    }

    public CssRule CreateSupports(CssToken current)
    {
      CssSupportsRule group = new CssSupportsRule(this._parser);
      TextPosition position = current.Position;
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) group);
      this.CollectTrivia(ref token);
      group.Condition = this.AggregateCondition(ref token);
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.CurlyBracketOpen)
      {
        TextPosition end = this.FillRules((CssGroupingRule) group);
        group.SourceCode = this.CreateView(position, end);
        this._nodes.Pop();
        return (CssRule) group;
      }
      this._nodes.Pop();
      return this.SkipDeclarations(token);
    }

    public CssRule CreateStyle(CssToken current)
    {
      CssStyleRule cssStyleRule = new CssStyleRule(this._parser);
      TextPosition position = current.Position;
      this._nodes.Push((CssNode) cssStyleRule);
      this.CollectTrivia(ref current);
      cssStyleRule.Selector = this.CreateSelector(ref current);
      TextPosition end = this.FillDeclarations(cssStyleRule.Style);
      cssStyleRule.SourceCode = this.CreateView(position, end);
      this._nodes.Pop();
      return cssStyleRule.Selector == null ? (CssRule) null : (CssRule) cssStyleRule;
    }

    public CssKeyframeRule CreateKeyframeRule(CssToken current)
    {
      CssKeyframeRule cssKeyframeRule = new CssKeyframeRule(this._parser);
      TextPosition position = current.Position;
      this._nodes.Push((CssNode) cssKeyframeRule);
      this.CollectTrivia(ref current);
      cssKeyframeRule.Key = (IKeyframeSelector) this.CreateKeyframeSelector(ref current);
      TextPosition end = this.FillDeclarations(cssKeyframeRule.Style);
      cssKeyframeRule.SourceCode = this.CreateView(position, end);
      this._nodes.Pop();
      return cssKeyframeRule.Key == null ? (CssKeyframeRule) null : cssKeyframeRule;
    }

    public CssRule CreateUnknown(CssToken current)
    {
      TextPosition position = current.Position;
      if (this._parser.Options.IsIncludingUnknownRules)
      {
        CssToken token = this.NextToken();
        CssUnknownRule unknown = new CssUnknownRule(current.Data, this._parser);
        this._nodes.Push((CssNode) unknown);
        while (token.IsNot(CssTokenType.CurlyBracketOpen, CssTokenType.Semicolon, CssTokenType.EndOfFile))
          token = this.NextToken();
        if (token.Type == CssTokenType.CurlyBracketOpen)
        {
          int num = 1;
          do
          {
            token = this.NextToken();
            switch (token.Type)
            {
              case CssTokenType.CurlyBracketOpen:
                ++num;
                break;
              case CssTokenType.CurlyBracketClose:
                --num;
                break;
              case CssTokenType.EndOfFile:
                num = 0;
                break;
            }
          }
          while (num != 0);
        }
        unknown.SourceCode = this.CreateView(position, token.Position);
        this._nodes.Pop();
        return (CssRule) unknown;
      }
      this.RaiseErrorOccurred(CssParseError.UnknownAtRule, position);
      this.JumpToRuleEnd(ref current);
      return (CssRule) null;
    }

    public CssValue CreateValue(ref CssToken token)
    {
      bool important = false;
      return this.CreateValue(CssTokenType.CurlyBracketClose, ref token, out important);
    }

    public List<CssMedium> CreateMedia(ref CssToken token)
    {
      List<CssMedium> media = new List<CssMedium>();
      this.CollectTrivia(ref token);
      while (token.Type != CssTokenType.EndOfFile)
      {
        CssMedium medium = this.CreateMedium(ref token);
        if (medium == null || token.IsNot(CssTokenType.Comma, CssTokenType.EndOfFile))
          throw new DomException(DomError.Syntax);
        token = this.NextToken();
        this.CollectTrivia(ref token);
        media.Add(medium);
      }
      return media;
    }

    public TextPosition CreateRules(CssStyleSheet sheet)
    {
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) sheet);
      this.CollectTrivia(ref token);
      while (token.Type != CssTokenType.EndOfFile)
      {
        CssRule rule = this.CreateRule(token);
        token = this.NextToken();
        this.CollectTrivia(ref token);
        sheet.Rules.Add(rule);
      }
      this._nodes.Pop();
      return token.Position;
    }

    public IConditionFunction CreateCondition(ref CssToken token)
    {
      this.CollectTrivia(ref token);
      return this.AggregateCondition(ref token);
    }

    public KeyframeSelector CreateKeyframeSelector(ref CssToken token)
    {
      List<Percent> stops = new List<Percent>();
      bool flag = true;
      TextPosition position = token.Position;
      this.CollectTrivia(ref token);
      while (token.Type != CssTokenType.EndOfFile)
      {
        if (stops.Count > 0)
        {
          if (token.Type != CssTokenType.CurlyBracketOpen)
          {
            if (token.Type != CssTokenType.Comma)
              flag = false;
            else
              token = this.NextToken();
            this.CollectTrivia(ref token);
          }
          else
            break;
        }
        if (token.Type == CssTokenType.Percentage)
          stops.Add(new Percent(((CssUnitToken) token).Value));
        else if (token.Type == CssTokenType.Ident && token.Data.Is(Keywords.From))
          stops.Add(Percent.Zero);
        else if (token.Type == CssTokenType.Ident && token.Data.Is(Keywords.To))
          stops.Add(Percent.Hundred);
        else
          flag = false;
        token = this.NextToken();
        this.CollectTrivia(ref token);
      }
      if (!flag)
        this.RaiseErrorOccurred(CssParseError.InvalidSelector, position);
      return new KeyframeSelector((IEnumerable<Percent>) stops);
    }

    public List<DocumentFunction> CreateFunctions(ref CssToken token)
    {
      List<DocumentFunction> functions = new List<DocumentFunction>();
      this.CollectTrivia(ref token);
      this.FillFunctions((Action<DocumentFunction>) (function => functions.Add(function)), ref token);
      return functions;
    }

    public TextPosition FillDeclarations(CssStyleDeclaration style)
    {
      CssToken token = this.NextToken();
      this._nodes.Push((CssNode) style);
      this.CollectTrivia(ref token);
      while (token.IsNot(CssTokenType.EndOfFile, CssTokenType.CurlyBracketClose))
      {
        CssProperty declarationWith = this.CreateDeclarationWith(new Func<string, CssProperty>(Factory.Properties.Create), ref token);
        if (declarationWith != null && declarationWith.HasValue)
          style.SetProperty(declarationWith);
        this.CollectTrivia(ref token);
      }
      this._nodes.Pop();
      return token.Position;
    }

    public CssProperty CreateDeclarationWith(
      Func<string, CssProperty> createProperty,
      ref CssToken token)
    {
      CssProperty declarationWith = (CssProperty) null;
      StringBuilder sb = Pool.NewStringBuilder();
      TextPosition position = token.Position;
      while (token.IsDeclarationName())
      {
        sb.Append(token.ToValue());
        token = this.NextToken();
      }
      string pool = sb.ToPool();
      if (pool.Length > 0)
      {
        CssParserOptions options = this._parser.Options;
        CssProperty cssProperty;
        if (!options.IsIncludingUnknownDeclarations)
        {
          options = this._parser.Options;
          if (!options.IsToleratingInvalidValues)
          {
            cssProperty = createProperty(pool);
            goto label_8;
          }
        }
        cssProperty = (CssProperty) new CssUnknownProperty(pool);
label_8:
        declarationWith = cssProperty;
        if (declarationWith == null)
          this.RaiseErrorOccurred(CssParseError.UnknownDeclarationName, position);
        else
          this._nodes.Push((CssNode) declarationWith);
        this.CollectTrivia(ref token);
        if (token.Type == CssTokenType.Colon)
        {
          bool important = false;
          CssValue newValue = this.CreateValue(CssTokenType.CurlyBracketClose, ref token, out important);
          if (newValue == null)
            this.RaiseErrorOccurred(CssParseError.ValueMissing, token.Position);
          else if (declarationWith != null && declarationWith.TrySetValue(newValue))
            declarationWith.IsImportant = important;
          this.CollectTrivia(ref token);
        }
        else
          this.RaiseErrorOccurred(CssParseError.ColonMissing, token.Position);
        this.JumpToDeclEnd(ref token);
        if (declarationWith != null)
          this._nodes.Pop();
      }
      else if (token.Type != CssTokenType.EndOfFile)
      {
        this.RaiseErrorOccurred(CssParseError.IdentExpected, position);
        this.JumpToDeclEnd(ref token);
      }
      if (token.Type == CssTokenType.Semicolon)
        token = this.NextToken();
      return declarationWith;
    }

    public CssProperty CreateDeclaration(ref CssToken token)
    {
      this.CollectTrivia(ref token);
      return this.CreateDeclarationWith(new Func<string, CssProperty>(Factory.Properties.Create), ref token);
    }

    public CssMedium CreateMedium(ref CssToken token)
    {
      CssMedium medium = new CssMedium();
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.Ident)
      {
        string data = token.Data;
        if (data.Isi(Keywords.Not))
        {
          medium.IsInverse = true;
          token = this.NextToken();
          this.CollectTrivia(ref token);
        }
        else if (data.Isi(Keywords.Only))
        {
          medium.IsExclusive = true;
          token = this.NextToken();
          this.CollectTrivia(ref token);
        }
      }
      if (token.Type == CssTokenType.Ident)
      {
        medium.Type = token.Data;
        token = this.NextToken();
        this.CollectTrivia(ref token);
        if (token.Type != CssTokenType.Ident || !token.Data.Isi(Keywords.And))
          return medium;
        token = this.NextToken();
        this.CollectTrivia(ref token);
      }
      while (token.Type == CssTokenType.RoundBracketOpen)
      {
        token = this.NextToken();
        this.CollectTrivia(ref token);
        MediaFeature feature = this.CreateFeature(ref token);
        if (feature != null)
          medium.AppendChild((ICssNode) feature);
        if (token.Type != CssTokenType.RoundBracketClose)
          return (CssMedium) null;
        token = this.NextToken();
        this.CollectTrivia(ref token);
        if (feature == null)
          return (CssMedium) null;
        if (token.Type == CssTokenType.Ident && token.Data.Isi(Keywords.And))
        {
          token = this.NextToken();
          this.CollectTrivia(ref token);
          if (token.Type != CssTokenType.EndOfFile)
            continue;
        }
        return medium;
      }
      return (CssMedium) null;
    }

    private void JumpToEnd(ref CssToken current)
    {
      while (current.IsNot(CssTokenType.EndOfFile, CssTokenType.Semicolon))
        current = this.NextToken();
    }

    private void JumpToRuleEnd(ref CssToken current)
    {
      int num = 0;
      while (current.Type != CssTokenType.EndOfFile)
      {
        if (current.Type == CssTokenType.CurlyBracketOpen)
          ++num;
        else if (current.Type == CssTokenType.CurlyBracketClose)
          --num;
        if (num <= 0 && current.Is(CssTokenType.CurlyBracketClose, CssTokenType.Semicolon))
          break;
        current = this.NextToken();
      }
    }

    private void JumpToArgEnd(ref CssToken current)
    {
      int num = 0;
      while (current.Type != CssTokenType.EndOfFile)
      {
        if (current.Type == CssTokenType.RoundBracketOpen)
        {
          ++num;
        }
        else
        {
          if (num <= 0 && current.Type == CssTokenType.RoundBracketClose)
            break;
          if (current.Type == CssTokenType.RoundBracketClose)
            --num;
        }
        current = this.NextToken();
      }
    }

    private void JumpToDeclEnd(ref CssToken current)
    {
      int num = 0;
      while (current.Type != CssTokenType.EndOfFile)
      {
        if (current.Type == CssTokenType.CurlyBracketOpen)
        {
          ++num;
        }
        else
        {
          if (num <= 0 && current.Is(CssTokenType.CurlyBracketClose, CssTokenType.Semicolon))
            break;
          if (current.Type == CssTokenType.CurlyBracketClose)
            --num;
        }
        current = this.NextToken();
      }
    }

    private CssToken NextToken() => this._tokenizer.Get();

    private TextView CreateView(TextPosition start, TextPosition end) => new TextView(new TextRange(start, end), this._tokenizer.Source);

    private void CollectTrivia(ref CssToken token)
    {
      bool isStoringTrivia = this._parser.Options.IsStoringTrivia;
      while (token.Type == CssTokenType.Whitespace || token.Type == CssTokenType.Comment || token.Type == CssTokenType.Cdc || token.Type == CssTokenType.Cdo)
      {
        if (isStoringTrivia && token.Type == CssTokenType.Comment)
        {
          CssNode cssNode = this._nodes.Peek();
          CssComment cssComment = new CssComment(token.Data);
          TextPosition position = token.Position;
          TextPosition end = position.After(token.ToValue());
          cssComment.SourceCode = this.CreateView(position, end);
          CssComment child = cssComment;
          cssNode.AppendChild((ICssNode) child);
        }
        token = this._tokenizer.Get();
      }
    }

    private CssRule SkipDeclarations(CssToken token)
    {
      this.RaiseErrorOccurred(CssParseError.InvalidToken, token.Position);
      this.JumpToRuleEnd(ref token);
      return (CssRule) null;
    }

    private void RaiseErrorOccurred(CssParseError code, TextPosition position) => this._tokenizer.RaiseErrorOccurred(code, position);

    private IConditionFunction AggregateCondition(ref CssToken token)
    {
      IConditionFunction condition = this.ExtractCondition(ref token);
      if (condition != null)
      {
        this.CollectTrivia(ref token);
        string data = token.Data;
        Func<IEnumerable<IConditionFunction>, IConditionFunction> creator = data.GetCreator();
        if (creator != null)
        {
          token = this.NextToken();
          this.CollectTrivia(ref token);
          List<IConditionFunction> conditionFunctionList = this.MultipleConditions(condition, data, ref token);
          condition = creator((IEnumerable<IConditionFunction>) conditionFunctionList);
        }
      }
      return condition;
    }

    private IConditionFunction ExtractCondition(ref CssToken token)
    {
      if (token.Type == CssTokenType.RoundBracketOpen)
      {
        token = this.NextToken();
        this.CollectTrivia(ref token);
        IConditionFunction condition = this.AggregateCondition(ref token);
        if (condition != null)
          condition = (IConditionFunction) new GroupCondition()
          {
            Content = condition
          };
        else if (token.Type == CssTokenType.Ident)
          condition = this.DeclarationCondition(ref token);
        if (token.Type == CssTokenType.RoundBracketClose)
        {
          token = this.NextToken();
          this.CollectTrivia(ref token);
        }
        return condition;
      }
      if (!token.Data.Isi(Keywords.Not))
        return (IConditionFunction) null;
      NotCondition condition1 = new NotCondition();
      token = this.NextToken();
      this.CollectTrivia(ref token);
      condition1.Content = this.ExtractCondition(ref token);
      return (IConditionFunction) condition1;
    }

    private IConditionFunction DeclarationCondition(ref CssToken token)
    {
      CssProperty property = Factory.Properties.Create(token.Data) ?? (CssProperty) new CssUnknownProperty(token.Data);
      AngleSharp.Dom.Css.DeclarationCondition declarationCondition = (AngleSharp.Dom.Css.DeclarationCondition) null;
      token = this.NextToken();
      this.CollectTrivia(ref token);
      if (token.Type == CssTokenType.Colon)
      {
        bool important = false;
        CssValue cssValue = this.CreateValue(CssTokenType.RoundBracketClose, ref token, out important);
        property.IsImportant = important;
        if (cssValue != null)
          declarationCondition = new AngleSharp.Dom.Css.DeclarationCondition(property, cssValue);
      }
      return (IConditionFunction) declarationCondition;
    }

    private List<IConditionFunction> MultipleConditions(
      IConditionFunction condition,
      string connector,
      ref CssToken token)
    {
      List<IConditionFunction> conditionFunctionList = new List<IConditionFunction>();
      this.CollectTrivia(ref token);
      conditionFunctionList.Add(condition);
      while (token.Type != CssTokenType.EndOfFile)
      {
        condition = this.ExtractCondition(ref token);
        if (condition != null)
        {
          conditionFunctionList.Add(condition);
          if (token.Data.Isi(connector))
          {
            token = this.NextToken();
            this.CollectTrivia(ref token);
          }
          else
            break;
        }
        else
          break;
      }
      return conditionFunctionList;
    }

    private void FillFunctions(Action<DocumentFunction> add, ref CssToken token)
    {
      do
      {
        DocumentFunction documentFunction = token.ToDocumentFunction();
        if (documentFunction != null)
        {
          token = this.NextToken();
          this.CollectTrivia(ref token);
          add(documentFunction);
          if (token.Type == CssTokenType.Comma)
          {
            token = this.NextToken();
            this.CollectTrivia(ref token);
          }
          else
            goto label_4;
        }
        else
          goto label_3;
      }
      while (token.Type != CssTokenType.EndOfFile);
      goto label_5;
label_3:
      return;
label_4:
      return;
label_5:;
    }

    private TextPosition FillKeyframeRules(CssKeyframesRule parentRule)
    {
      CssToken token = this.NextToken();
      this.CollectTrivia(ref token);
      while (token.IsNot(CssTokenType.EndOfFile, CssTokenType.CurlyBracketClose))
      {
        CssKeyframeRule keyframeRule = this.CreateKeyframeRule(token);
        token = this.NextToken();
        this.CollectTrivia(ref token);
        parentRule.Rules.Add((CssRule) keyframeRule);
      }
      return token.Position;
    }

    private TextPosition FillDeclarations(
      CssDeclarationRule rule,
      Func<string, CssProperty> createProperty)
    {
      CssToken token = this.NextToken();
      this.CollectTrivia(ref token);
      while (token.IsNot(CssTokenType.EndOfFile, CssTokenType.CurlyBracketClose))
      {
        CssProperty declarationWith = this.CreateDeclarationWith(createProperty, ref token);
        if (declarationWith != null && declarationWith.HasValue)
          rule.SetProperty(declarationWith);
        this.CollectTrivia(ref token);
      }
      return token.Position;
    }

    private TextPosition FillRules(CssGroupingRule group)
    {
      CssToken token = this.NextToken();
      this.CollectTrivia(ref token);
      while (token.IsNot(CssTokenType.EndOfFile, CssTokenType.CurlyBracketClose))
      {
        CssRule rule = this.CreateRule(token);
        token = this.NextToken();
        this.CollectTrivia(ref token);
        group.Rules.Add(rule);
      }
      return token.Position;
    }

    private void FillMediaList(MediaList list, CssTokenType end, ref CssToken token)
    {
      this._nodes.Push((CssNode) list);
      if (token.Type != end)
      {
        while (token.Type != CssTokenType.EndOfFile)
        {
          CssMedium medium = this.CreateMedium(ref token);
          if (medium != null)
            list.AppendChild((ICssNode) medium);
          if (token.Type == CssTokenType.Comma)
          {
            token = this.NextToken();
            this.CollectTrivia(ref token);
          }
          else
            break;
        }
        if (token.Type != end || list.Length == 0)
        {
          list.Clear();
          list.AppendChild((ICssNode) new CssMedium()
          {
            IsInverse = true,
            Type = Keywords.All
          });
        }
      }
      this._nodes.Pop();
    }

    private ISelector CreateSelector(ref CssToken token)
    {
      CssSelectorConstructor selectorCreator = this._parser.GetSelectorCreator();
      TextPosition position = token.Position;
      while (token.IsNot(CssTokenType.EndOfFile, CssTokenType.CurlyBracketOpen, CssTokenType.CurlyBracketClose))
      {
        selectorCreator.Apply(token);
        token = this.NextToken();
      }
      bool isValid = selectorCreator.IsValid;
      ISelector selector = selectorCreator.ToPool();
      if (selector is CssNode cssNode)
      {
        TextPosition end = token.Position.Shift(-1);
        cssNode.SourceCode = this.CreateView(position, end);
      }
      if (!isValid && !this._parser.Options.IsToleratingInvalidValues)
      {
        this.RaiseErrorOccurred(CssParseError.InvalidSelector, position);
        selector = (ISelector) null;
      }
      return selector;
    }

    private CssValue CreateValue(CssTokenType closing, ref CssToken token, out bool important)
    {
      CssValueBuilder vb = Pool.NewValueBuilder();
      this._tokenizer.IsInValue = true;
      token = this.NextToken();
      TextPosition position = token.Position;
      while (token.IsNot(CssTokenType.EndOfFile, CssTokenType.Semicolon, closing))
      {
        vb.Apply(token);
        token = this.NextToken();
      }
      important = vb.IsImportant;
      this._tokenizer.IsInValue = false;
      int num = vb.IsValid ? 1 : 0;
      CssValue cssValue = vb.ToPool();
      CssNode cssNode = (CssNode) cssValue;
      if (cssNode != null)
      {
        TextPosition end = token.Position.Shift(-1);
        cssNode.SourceCode = this.CreateView(position, end);
      }
      if (num == 0 && !this._parser.Options.IsToleratingInvalidValues)
      {
        this.RaiseErrorOccurred(CssParseError.InvalidValue, position);
        cssValue = (CssValue) null;
      }
      return cssValue;
    }

    private string GetRuleName(ref CssToken token)
    {
      string ruleName = string.Empty;
      if (token.Type == CssTokenType.Ident)
      {
        ruleName = token.Data;
        token = this.NextToken();
      }
      return ruleName;
    }

    private MediaFeature CreateFeature(ref CssToken token)
    {
      if (token.Type == CssTokenType.Ident)
      {
        TextPosition position = token.Position;
        CssValue cssValue = CssValue.Empty;
        MediaFeature feature = this._parser.Options.IsToleratingInvalidConstraints ? (MediaFeature) new UnknownMediaFeature(token.Data) : Factory.MediaFeatures.Create(token.Data);
        token = this.NextToken();
        if (token.Type == CssTokenType.Colon)
        {
          CssValueBuilder vb = Pool.NewValueBuilder();
          token = this.NextToken();
          while (token.IsNot(CssTokenType.RoundBracketClose, CssTokenType.EndOfFile) || !vb.IsReady)
          {
            vb.Apply(token);
            token = this.NextToken();
          }
          cssValue = vb.ToPool();
        }
        else if (token.Type == CssTokenType.EndOfFile)
          return (MediaFeature) null;
        if (feature != null && feature.TrySetValue(cssValue))
        {
          CssNode cssNode = (CssNode) feature;
          if (cssNode != null)
          {
            TextPosition end = token.Position.Shift(-1);
            cssNode.SourceCode = this.CreateView(position, end);
          }
          return feature;
        }
      }
      else
        this.JumpToArgEnd(ref token);
      return (MediaFeature) null;
    }
  }
}
