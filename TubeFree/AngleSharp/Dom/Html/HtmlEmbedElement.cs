// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlEmbedElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Network.RequestProcessors;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlEmbedElement : 
    HtmlElement,
    IHtmlEmbedElement,
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
    ILoadableElement
  {
    private readonly ObjectRequestProcessor _request;

    public HtmlEmbedElement(Document owner, string prefix = null)
      : base(owner, TagNames.Embed, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
      this._request = ObjectRequestProcessor.Create((Element) this);
    }

    public IDownload CurrentDownload => this._request?.Download;

    public string Source
    {
      get => this.GetOwnAttribute(AttributeNames.Src);
      set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Type
    {
      get => this.GetOwnAttribute(AttributeNames.Type);
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string DisplayWidth
    {
      get => this.GetOwnAttribute(AttributeNames.Width);
      set => this.SetOwnAttribute(AttributeNames.Width, value);
    }

    public string DisplayHeight
    {
      get => this.GetOwnAttribute(AttributeNames.Height);
      set => this.SetOwnAttribute(AttributeNames.Height, value);
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      string ownAttribute = this.GetOwnAttribute(AttributeNames.Src);
      if (ownAttribute == null)
        return;
      this.UpdateSource(ownAttribute);
    }

    internal void UpdateSource(string value) => this.Process((IRequestProcessor) this._request, new Url(this.Source));
  }
}
