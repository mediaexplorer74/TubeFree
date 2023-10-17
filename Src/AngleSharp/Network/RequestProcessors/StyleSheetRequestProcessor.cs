// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.RequestProcessors.StyleSheetRequestProcessor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Services;
using AngleSharp.Services.Styling;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.RequestProcessors
{
  internal sealed class StyleSheetRequestProcessor : BaseRequestProcessor
  {
    private readonly HtmlLinkElement _link;
    private readonly Document _document;
    private readonly IResourceLoader _loader;
    private IStyleEngine _engine;

    private StyleSheetRequestProcessor(
      HtmlLinkElement link,
      Document document,
      IResourceLoader loader)
      : base(loader)
    {
      this._link = link;
      this._document = document;
      this._loader = loader;
    }

    internal static StyleSheetRequestProcessor Create(HtmlLinkElement element)
    {
      Document owner = element.Owner;
      IResourceLoader loader = owner.Loader;
      return loader == null ? (StyleSheetRequestProcessor) null : new StyleSheetRequestProcessor(element, owner, loader);
    }

    public IStyleSheet Sheet { get; private set; }

    public IStyleEngine Engine => this._engine ?? (this._engine = this._document.Options.GetStyleEngine(this.LinkType));

    public string LinkType => this._link.Type ?? MimeTypeNames.Css;

    public override Task ProcessAsync(ResourceRequest request)
    {
      if (this.Engine == null || !this.IsDifferentToCurrentDownloadUrl(request.Target))
        return (Task) null;
      this.CancelDownload();
      this.Download = this.DownloadWithCors(request);
      return this.FinishDownloadAsync();
    }

    protected override async Task ProcessResponseAsync(IResponse response)
    {
      CancellationToken none = CancellationToken.None;
      IStyleSheet styleSheet = await this._engine.ParseStylesheetAsync(response, new StyleOptions(this._document.Context)
      {
        Element = (IElement) this._link,
        IsDisabled = this._link.IsDisabled,
        IsAlternate = this._link.RelationList.Contains(Keywords.Alternate)
      }, none).ConfigureAwait(false);
      styleSheet.Media.MediaText = this._link.Media ?? string.Empty;
      this.Sheet = styleSheet;
    }

    private IDownload DownloadWithCors(ResourceRequest request) => this._loader.FetchWithCors(new CorsRequest(request)
    {
      Setting = this._link.CrossOrigin.ToEnum<CorsSetting>(CorsSetting.None),
      Behavior = OriginBehavior.Taint,
      Integrity = this._document.Options.GetProvider<IIntegrityProvider>()
    });
  }
}
