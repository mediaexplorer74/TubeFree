// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlAudioElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;
using AngleSharp.Html;
using AngleSharp.Services.Media;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlAudioElement : 
    HtmlMediaElement<IAudioInfo>,
    IHtmlAudioElement,
    IHtmlMediaElement,
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
    IMediaController,
    ILoadableElement
  {
    private IAudioTrackList _audios;

    public HtmlAudioElement(Document owner, string prefix = null)
      : base(owner, TagNames.Audio, prefix)
    {
      this._audios = (IAudioTrackList) null;
    }

    public override IAudioTrackList AudioTracks => this._audios;
  }
}
