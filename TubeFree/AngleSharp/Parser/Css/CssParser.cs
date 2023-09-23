// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssParser
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Parser.Css
{
  public class CssParser
  {
    private readonly CssParserOptions _options;
    private readonly IConfiguration _configuration;
    internal static readonly CssParser Default = new CssParser();

    public CssParser()
      : this(Configuration.Default)
    {
    }

    public CssParser(CssParserOptions options)
      : this(options, Configuration.Default)
    {
    }

    public CssParser(IConfiguration configuration)
      : this(new CssParserOptions(), configuration)
    {
    }

    public CssParser(CssParserOptions options, IConfiguration configuration)
    {
      this._options = options;
      this._configuration = configuration ?? Configuration.Default;
    }

    public CssParserOptions Options => this._options;

    public IConfiguration Config => this._configuration;

    public ICssStyleSheet ParseStylesheet(string content) => this.ParseStylesheet(new TextSource(content));

    public ICssStyleSheet ParseStylesheet(Stream content) => this.ParseStylesheet(new TextSource(content));

    public Task<ICssStyleSheet> ParseStylesheetAsync(string content) => this.ParseStylesheetAsync(content, CancellationToken.None);

    public async Task<ICssStyleSheet> ParseStylesheetAsync(
      string content,
      CancellationToken cancelToken)
    {
      TextSource source = new TextSource(content);
      await source.PrefetchAllAsync(cancelToken).ConfigureAwait(false);
      return this.ParseStylesheet(source);
    }

    public Task<ICssStyleSheet> ParseStylesheetAsync(Stream content) => this.ParseStylesheetAsync(content, CancellationToken.None);

    public async Task<ICssStyleSheet> ParseStylesheetAsync(
      Stream content,
      CancellationToken cancelToken)
    {
      TextSource source = new TextSource(content);
      await source.PrefetchAllAsync(cancelToken).ConfigureAwait(false);
      return this.ParseStylesheet(source);
    }

    public ISelector ParseSelector(string selectorText)
    {
      CssTokenizer tokenizer = CssParser.CreateTokenizer(selectorText);
      CssToken token = tokenizer.Get();
      CssSelectorConstructor selectorCreator = this.GetSelectorCreator();
      for (; token.Type != CssTokenType.EndOfFile; token = tokenizer.Get())
        selectorCreator.Apply(token);
      tokenizer.Dispose();
      bool isValid = selectorCreator.IsValid;
      ISelector pool = selectorCreator.ToPool();
      return !isValid && !this._options.IsToleratingInvalidSelectors ? (ISelector) null : pool;
    }

    public IKeyframeSelector ParseKeyframeSelector(string keyText) => (IKeyframeSelector) this.Parse<KeyframeSelector>(keyText, (Func<CssBuilder, CssToken, Tuple<KeyframeSelector, CssToken>>) ((b, t) => Tuple.Create<KeyframeSelector, CssToken>(b.CreateKeyframeSelector(ref t), t)));

    internal CssSelectorConstructor GetSelectorCreator()
    {
      IAttributeSelectorFactory factory1 = this._configuration.GetFactory<IAttributeSelectorFactory>();
      IPseudoClassSelectorFactory factory2 = this._configuration.GetFactory<IPseudoClassSelectorFactory>();
      IPseudoElementSelectorFactory factory3 = this._configuration.GetFactory<IPseudoElementSelectorFactory>();
      IPseudoClassSelectorFactory pseudoClassSelector = factory2;
      IPseudoElementSelectorFactory pseudoElementSelector = factory3;
      return Pool.NewSelectorConstructor(factory1, pseudoClassSelector, pseudoElementSelector);
    }

    internal ICssStyleSheet ParseStylesheet(TextSource source)
    {
      CssStyleSheet sheet = new CssStyleSheet(this);
      CssTokenizer tokenizer = new CssTokenizer(source);
      TextRange range = new TextRange(tokenizer.GetCurrentPosition(), new CssBuilder(tokenizer, this).CreateRules(sheet));
      sheet.SourceCode = new TextView(range, source);
      return (ICssStyleSheet) sheet;
    }

    internal async Task<CssStyleSheet> ParseStylesheetAsync(CssStyleSheet sheet, TextSource source)
    {
      await source.PrefetchAllAsync(CancellationToken.None).ConfigureAwait(false);
      CssTokenizer tokenizer = new CssTokenizer(source);
      TextPosition currentPosition = tokenizer.GetCurrentPosition();
      CssBuilder cssBuilder = new CssBuilder(tokenizer, this);
      Document document = sheet.GetDocument() as Document;
      List<Task> taskList = new List<Task>();
      CssStyleSheet sheet1 = sheet;
      TextPosition rules = cssBuilder.CreateRules(sheet1);
      sheet.SourceCode = new TextView(new TextRange(currentPosition, rules), source);
      foreach (ICssRule rule in sheet.Rules)
      {
        if (rule.Type != CssRuleType.Charset)
        {
          if (rule.Type == CssRuleType.Import)
          {
            CssImportRule cssImportRule = (CssImportRule) rule;
            taskList.Add(cssImportRule.LoadStylesheetFromAsync(document));
          }
          else
            break;
        }
      }
      await TaskEx.WhenAll((IEnumerable<Task>) taskList).ConfigureAwait(false);
      return sheet;
    }

    internal CssValue ParseValue(string valueText)
    {
      CssTokenizer tokenizer = CssParser.CreateTokenizer(valueText);
      CssToken token = (CssToken) null;
      CssValue cssValue = new CssBuilder(tokenizer, this).CreateValue(ref token);
      return token.Type != CssTokenType.EndOfFile ? (CssValue) null : cssValue;
    }

    internal CssRule ParseRule(string ruleText) => this.Parse<CssRule>(ruleText, (Func<CssBuilder, CssToken, CssRule>) ((b, t) => b.CreateRule(t)));

    internal CssProperty ParseDeclaration(string declarationText) => this.Parse<CssProperty>(declarationText, (Func<CssBuilder, CssToken, Tuple<CssProperty, CssToken>>) ((b, t) => Tuple.Create<CssProperty, CssToken>(b.CreateDeclaration(ref t), t)));

    internal List<CssMedium> ParseMediaList(string mediaText) => this.Parse<List<CssMedium>>(mediaText, (Func<CssBuilder, CssToken, Tuple<List<CssMedium>, CssToken>>) ((b, t) => Tuple.Create<List<CssMedium>, CssToken>(b.CreateMedia(ref t), t)));

    internal IConditionFunction ParseCondition(string conditionText) => this.Parse<IConditionFunction>(conditionText, (Func<CssBuilder, CssToken, Tuple<IConditionFunction, CssToken>>) ((b, t) => Tuple.Create<IConditionFunction, CssToken>(b.CreateCondition(ref t), t)));

    internal List<DocumentFunction> ParseDocumentRules(string documentText) => this.Parse<List<DocumentFunction>>(documentText, (Func<CssBuilder, CssToken, Tuple<List<DocumentFunction>, CssToken>>) ((b, t) => Tuple.Create<List<DocumentFunction>, CssToken>(b.CreateFunctions(ref t), t)));

    internal CssMedium ParseMedium(string mediumText) => this.Parse<CssMedium>(mediumText, (Func<CssBuilder, CssToken, Tuple<CssMedium, CssToken>>) ((b, t) => Tuple.Create<CssMedium, CssToken>(b.CreateMedium(ref t), t)));

    internal CssKeyframeRule ParseKeyframeRule(string ruleText) => this.Parse<CssKeyframeRule>(ruleText, (Func<CssBuilder, CssToken, CssKeyframeRule>) ((b, t) => b.CreateKeyframeRule(t)));

    internal void AppendDeclarations(CssStyleDeclaration style, string declarations) => new CssBuilder(CssParser.CreateTokenizer(declarations), this).FillDeclarations(style);

    private T Parse<T>(string source, Func<CssBuilder, CssToken, T> create)
    {
      CssTokenizer tokenizer = CssParser.CreateTokenizer(source);
      CssToken cssToken = tokenizer.Get();
      CssBuilder cssBuilder = new CssBuilder(tokenizer, this);
      T obj = create(cssBuilder, cssToken);
      return tokenizer.Get().Type != CssTokenType.EndOfFile ? default (T) : obj;
    }

    private T Parse<T>(
      string source,
      Func<CssBuilder, CssToken, Tuple<T, CssToken>> create)
    {
      CssTokenizer tokenizer = CssParser.CreateTokenizer(source);
      CssToken cssToken = tokenizer.Get();
      CssBuilder cssBuilder = new CssBuilder(tokenizer, this);
      Tuple<T, CssToken> tuple = create(cssBuilder, cssToken);
      return tuple.Item2.Type != CssTokenType.EndOfFile ? default (T) : tuple.Item1;
    }

    private static CssTokenizer CreateTokenizer(string sourceCode) => new CssTokenizer(new TextSource(sourceCode));

    private static CssTokenizer CreateTokenizer(Stream sourceCode) => new CssTokenizer(new TextSource(sourceCode));
  }
}
