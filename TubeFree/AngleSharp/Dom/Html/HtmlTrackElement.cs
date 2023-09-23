// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTrackElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlTrackElement : 
    HtmlElement,
    IHtmlTrackElement,
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers
  {
    private TrackReadyState _ready;

    public HtmlTrackElement(Document owner, string prefix = null)
      : base(owner, TagNames.Track, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
      this._ready = TrackReadyState.None;
    }

    public string Kind
    {
      get => this.GetOwnAttribute(AttributeNames.Kind);
      set => this.SetOwnAttribute(AttributeNames.Kind, value);
    }

    public string Source
    {
      get => this.GetUrlAttribute(AttributeNames.Src);
      set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string SourceLanguage
    {
      get => this.GetOwnAttribute(AttributeNames.SrcLang);
      set => this.SetOwnAttribute(AttributeNames.SrcLang, value);
    }

    public string Label
    {
      get => this.GetOwnAttribute(AttributeNames.Label);
      set => this.SetOwnAttribute(AttributeNames.Label, value);
    }

    public bool IsDefault
    {
      get => this.GetBoolAttribute(AttributeNames.Default);
      set => this.SetBoolAttribute(AttributeNames.Default, value);
    }

    public TrackReadyState ReadyState => this._ready;

    public ITextTrack Track => (ITextTrack) null;
  }
}
