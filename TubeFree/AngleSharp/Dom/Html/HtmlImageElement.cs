// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlImageElement
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
  internal sealed class HtmlImageElement : 
    HtmlElement,
    IHtmlImageElement,
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
    private readonly ImageRequestProcessor _request;

    public HtmlImageElement(Document owner, string prefix = null)
      : base(owner, TagNames.Img, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
      this._request = ImageRequestProcessor.Create((Element) this);
    }

    public IDownload CurrentDownload => this._request?.Download;

    public string ActualSource => !this.IsCompleted ? string.Empty : this._request.Source;

    public string SourceSet
    {
      get => this.GetOwnAttribute(AttributeNames.SrcSet);
      set => this.SetOwnAttribute(AttributeNames.SrcSet, value);
    }

    public string Sizes
    {
      get => this.GetOwnAttribute(AttributeNames.Sizes);
      set => this.SetOwnAttribute(AttributeNames.Sizes, value);
    }

    public string Source
    {
      get => this.GetUrlAttribute(AttributeNames.Src);
      set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string AlternativeText
    {
      get => this.GetOwnAttribute(AttributeNames.Alt);
      set => this.SetOwnAttribute(AttributeNames.Alt, value);
    }

    public string CrossOrigin
    {
      get => this.GetOwnAttribute(AttributeNames.CrossOrigin);
      set => this.SetOwnAttribute(AttributeNames.CrossOrigin, value);
    }

    public string UseMap
    {
      get => this.GetOwnAttribute(AttributeNames.UseMap);
      set => this.SetOwnAttribute(AttributeNames.UseMap, value);
    }

    public int DisplayWidth
    {
      get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(this.OriginalWidth);
      set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int DisplayHeight
    {
      get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(this.OriginalHeight);
      set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public int OriginalWidth
    {
      get
      {
        ImageRequestProcessor request = this._request;
        return request == null ? 0 : request.Width;
      }
    }

    public int OriginalHeight
    {
      get
      {
        ImageRequestProcessor request = this._request;
        return request == null ? 0 : request.Height;
      }
    }

    public bool IsCompleted
    {
      get
      {
        ImageRequestProcessor request = this._request;
        return request != null && request.IsReady;
      }
    }

    public bool IsMap
    {
      get => this.GetBoolAttribute(AttributeNames.IsMap);
      set => this.SetBoolAttribute(AttributeNames.IsMap, value);
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      this.UpdateSource();
    }

    internal void UpdateSource() => this.Process((IRequestProcessor) this._request, this.GetImageCandidate());
  }
}
