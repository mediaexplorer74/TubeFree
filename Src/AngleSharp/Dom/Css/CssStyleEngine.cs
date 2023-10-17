// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssStyleEngine
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Network;
using AngleSharp.Parser.Css;
using AngleSharp.Services.Styling;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Css
{
  public class CssStyleEngine : ICssStyleEngine, IStyleEngine
  {
    private ICssStyleSheet _default;
    private CssParserOptions _options;
    public static readonly string DefaultSource = "\nhtml, address,\nblockquote,\nbody, dd, div,\ndl, dt, fieldset, form,\nframe, frameset,\nh1, h2, h3, h4,\nh5, h6, noframes,\nol, p, ul, center,\ndir, hr, menu, pre   { display: block; unicode-bidi: embed }\nli              { display: list-item }\nhead            { display: none }\ntable           { display: table }\ntr              { display: table-row }\nthead           { display: table-header-group }\ntbody           { display: table-row-group }\ntfoot           { display: table-footer-group }\ncol             { display: table-column }\ncolgroup        { display: table-column-group }\ntd, th          { display: table-cell }\ncaption         { display: table-caption }\nth              { font-weight: bolder; text-align: center }\ncaption         { text-align: center }\nbody            { margin: 8px }\nh1              { font-size: 2em; margin: .67em 0 }\nh2              { font-size: 1.5em; margin: .75em 0 }\nh3              { font-size: 1.17em; margin: .83em 0 }\nh4, p,\nblockquote, ul,\nfieldset, form,\nol, dl, dir,\nmenu            { margin: 1.12em 0 }\nh5              { font-size: .83em; margin: 1.5em 0 }\nh6              { font-size: .75em; margin: 1.67em 0 }\nh1, h2, h3, h4,\nh5, h6, b,\nstrong          { font-weight: bolder }\nblockquote      { margin-left: 40px; margin-right: 40px }\ni, cite, em,\nvar, address    { font-style: italic }\npre, tt, code,\nkbd, samp       { font-family: monospace }\npre             { white-space: pre }\nbutton, textarea,\ninput, select   { display: inline-block }\nbig             { font-size: 1.17em }\nsmall, sub, sup { font-size: .83em }\nsub             { vertical-align: sub }\nsup             { vertical-align: super }\ntable           { border-spacing: 2px; }\nthead, tbody,\ntfoot           { vertical-align: middle }\ntd, th, tr      { vertical-align: inherit }\ns, strike, del  { text-decoration: line-through }\nhr              { border: 1px inset }\nol, ul, dir,\nmenu, dd        { margin-left: 40px }\nol              { list-style-type: decimal }\nol ul, ul ol,\nul ul, ol ol    { margin-top: 0; margin-bottom: 0 }\nu, ins          { text-decoration: underline }\nbr:before       { content: '\\A'; white-space: pre-line }\ncenter          { text-align: center }\n:link, :visited { text-decoration: underline }\n:focus          { outline: thin dotted invert }\n\n/* Begin bidirectionality settings (do not change) */\nBDO[DIR='ltr']  { direction: ltr; unicode-bidi: bidi-override }\nBDO[DIR='rtl']  { direction: rtl; unicode-bidi: bidi-override }\n\n*[DIR='ltr']    { direction: ltr; unicode-bidi: embed }\n*[DIR='rtl']    { direction: rtl; unicode-bidi: embed }\n\n@media print {\n  h1            { page-break-before: always }\n  h1, h2, h3,\n  h4, h5, h6    { page-break-after: avoid }\n  ul, ol, dl    { page-break-before: avoid }\n}";

    public CssStyleEngine() => this._options = new CssParserOptions();

    public string Type => MimeTypeNames.Css;

    public ICssStyleSheet Default => this._default ?? this.SetDefault(CssStyleEngine.DefaultSource);

    public CssParserOptions Options
    {
      get => this._options;
      set => this._options = value;
    }

    public ICssStyleSheet SetDefault(string sourceCode)
    {
      ICssStyleSheet stylesheet = new CssParser(this._options, Configuration.Default).ParseStylesheet(sourceCode);
      this._default = stylesheet;
      return stylesheet;
    }

    public async Task<IStyleSheet> ParseStylesheetAsync(
      IResponse response,
      StyleOptions options,
      CancellationToken cancel)
    {
      IBrowsingContext context = options.Context;
      CssParser parser = new CssParser(this._options, context.Configuration);
      string href = response.Address?.Href;
      CssStyleSheet sheet = new CssStyleSheet(parser, href, options.Element)
      {
        IsDisabled = options.IsDisabled
      };
      TextSource source = new TextSource(response.Content);
      CssTokenizer tokenizer = new CssTokenizer(source);
      tokenizer.Error += (EventHandler<CssErrorEvent>) ((_, ev) => context.Fire((Event) ev));
      CssBuilder cssBuilder = new CssBuilder(tokenizer, parser);
      context.Fire((Event) new CssParseEvent((ICssStyleSheet) sheet, false));
      CssStyleSheet cssStyleSheet = await parser.ParseStylesheetAsync(sheet, source).ConfigureAwait(false);
      context.Fire((Event) new CssParseEvent((ICssStyleSheet) sheet, true));
      return (IStyleSheet) sheet;
    }

    public ICssStyleDeclaration ParseDeclaration(string source, StyleOptions options)
    {
      CssStyleDeclaration declaration = new CssStyleDeclaration(new CssParser(this._options, options.Context.Configuration));
      declaration.Update(source);
      return (ICssStyleDeclaration) declaration;
    }

    public IMediaList ParseMedia(string source, StyleOptions options) => (IMediaList) new MediaList(new CssParser(this._options, options.Context.Configuration))
    {
      MediaText = source
    };
  }
}
