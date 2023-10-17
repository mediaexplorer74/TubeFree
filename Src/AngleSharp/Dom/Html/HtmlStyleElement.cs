// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlStyleElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Services.Styling;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlStyleElement : 
    HtmlElement,
    IHtmlStyleElement,
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers,
    ILinkStyle
  {
    private IStyleSheet _sheet;

    public HtmlStyleElement(Document owner, string prefix = null)
      : base(owner, TagNames.Style, prefix, NodeFlags.Special | NodeFlags.LiteralText)
    {
    }

    public bool IsScoped
    {
      get => this.GetBoolAttribute(AttributeNames.Scoped);
      set => this.SetBoolAttribute(AttributeNames.Scoped, value);
    }

    public IStyleSheet Sheet => this._sheet;

    public bool IsDisabled
    {
      get => this.GetBoolAttribute(AttributeNames.Disabled);
      set
      {
        this.SetBoolAttribute(AttributeNames.Disabled, value);
        if (this._sheet == null)
          return;
        this._sheet.IsDisabled = value;
      }
    }

    public string Media
    {
      get => this.GetOwnAttribute(AttributeNames.Media);
      set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Type
    {
      get => this.GetOwnAttribute(AttributeNames.Type);
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      this.UpdateSheet();
    }

    internal override void NodeIsInserted(Node newNode)
    {
      base.NodeIsInserted(newNode);
      this.UpdateSheet();
    }

    internal override void NodeIsRemoved(Node removedNode, Node oldPreviousSibling)
    {
      base.NodeIsRemoved(removedNode, oldPreviousSibling);
      this.UpdateSheet();
    }

    internal void UpdateMedia(string value)
    {
      if (this._sheet == null)
        return;
      this._sheet.Media.MediaText = value;
    }

    private void UpdateSheet()
    {
      Document owner = this.Owner;
      if (owner == null)
        return;
      IConfiguration options = owner.Options;
      IBrowsingContext context = owner.Context;
      string type = this.Type ?? MimeTypeNames.Css;
      IStyleEngine styleEngine = options.GetStyleEngine(type);
      if (styleEngine == null)
        return;
      Task sheetAsync = this.CreateSheetAsync(styleEngine, context);
      owner.DelayLoad(sheetAsync);
    }

    private async Task CreateSheetAsync(IStyleEngine engine, IBrowsingContext context)
    {
      CancellationToken none = CancellationToken.None;
      IResponse response = VirtualResponse.Create((Action<VirtualResponse>) (res => res.Content(this.TextContent).Address((Url) null)));
      StyleOptions options = new StyleOptions(context)
      {
        Element = (IElement) this,
        IsDisabled = this.IsDisabled,
        IsAlternate = false
      };
      Task<IStyleSheet> stylesheetAsync = engine.ParseStylesheetAsync(response, options, none);
      HtmlStyleElement htmlStyleElement = this;
      IStyleSheet sheet = htmlStyleElement._sheet;
      IStyleSheet styleSheet = await stylesheetAsync.ConfigureAwait(false);
      htmlStyleElement._sheet = styleSheet;
      htmlStyleElement = (HtmlStyleElement) null;
    }
  }
}
