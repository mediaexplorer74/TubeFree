// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlVideoElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Services.Media;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlVideoElement : 
    HtmlMediaElement<IVideoInfo>,
    IHtmlVideoElement,
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
    private IVideoTrackList _videos;

    public HtmlVideoElement(Document owner, string prefix = null)
      : base(owner, TagNames.Video, prefix)
    {
      this._videos = (IVideoTrackList) null;
    }

    public override IVideoTrackList VideoTracks => this._videos;

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
        IVideoInfo media = this.Media;
        return media == null ? 0 : media.Width;
      }
    }

    public int OriginalHeight
    {
      get
      {
        IVideoInfo media = this.Media;
        return media == null ? 0 : media.Height;
      }
    }

    public string Poster
    {
      get => this.GetUrlAttribute(AttributeNames.Poster);
      set => this.SetOwnAttribute(AttributeNames.Poster, value);
    }
  }
}
