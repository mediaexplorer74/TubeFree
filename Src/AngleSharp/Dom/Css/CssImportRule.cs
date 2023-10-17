// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssImportRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Extensions;
using AngleSharp.Network;
using AngleSharp.Parser.Css;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssImportRule : 
    CssRule,
    ICssImportRule,
    ICssRule,
    ICssNode,
    IStyleFormattable
  {
    private string _href;
    private CssStyleSheet _styleSheet;

    internal CssImportRule(CssParser parser)
      : base(CssRuleType.Import, parser)
    {
      this.AppendChild((ICssNode) new MediaList(parser));
    }

    public string Href
    {
      get => this._href;
      set => this._href = value;
    }

    public MediaList Media => this.Children.OfType<MediaList>().FirstOrDefault<MediaList>();

    IMediaList ICssImportRule.Media => (IMediaList) this.Media;

    public ICssStyleSheet Sheet => (ICssStyleSheet) this._styleSheet;

    internal async Task LoadStylesheetFromAsync(Document document)
    {
      if (document == null)
        return;
      IResourceLoader loader = document.Loader;
      Url url = new Url(Url.Create(this.Owner.Href ?? document.BaseUri), this._href);
      if (this.IsRecursion(url) || loader == null)
        return;
      ResourceRequest requestFor = this.Owner.OwnerNode.CreateRequestFor(url);
      using (IResponse response = await loader.DownloadAsync(requestFor).Task.ConfigureAwait(false))
      {
        CssStyleSheet sheet = new CssStyleSheet((CssRule) this, response.Address.Href);
        TextSource source = new TextSource(response.Content);
        CssImportRule cssImportRule = this;
        CssStyleSheet styleSheet = cssImportRule._styleSheet;
        CssStyleSheet cssStyleSheet = await this.Parser.ParseStylesheetAsync(sheet, source).ConfigureAwait(false);
        cssImportRule._styleSheet = cssStyleSheet;
        cssImportRule = (CssImportRule) null;
      }
    }

    protected override void ReplaceWith(ICssRule rule)
    {
      this._href = (rule as CssImportRule)._href;
      this._styleSheet = (CssStyleSheet) null;
      base.ReplaceWith(rule);
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string mediaText = this.Media.MediaText;
      string str1 = string.IsNullOrEmpty(mediaText) ? string.Empty : " ";
      string str2 = this._href.CssUrl() + str1 + mediaText;
      writer.Write(formatter.Rule("@import", str2));
    }

    private bool IsRecursion(Url url)
    {
      string href = url.Href;
      ICssStyleSheet cssStyleSheet = this.Owner;
      while (cssStyleSheet != null && !cssStyleSheet.Href.Is(href))
        cssStyleSheet = cssStyleSheet.Parent;
      return cssStyleSheet != null;
    }
  }
}
