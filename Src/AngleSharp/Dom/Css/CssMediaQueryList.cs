// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssMediaQueryList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using AngleSharp.Html;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssMediaQueryList : EventTarget, IMediaQueryList, IEventTarget
  {
    private readonly IMediaList _media;
    private bool _matched;

    public event DomEventHandler Changed
    {
      add => this.AddEventListener(EventNames.Change, value, false);
      remove => this.RemoveEventListener(EventNames.Change, value, false);
    }

    public CssMediaQueryList(IWindow window, IMediaList media)
    {
      this._media = media;
      this._matched = this.ComputeMatched(window);
      window.Resized += new DomEventHandler(this.Resized);
    }

    public string MediaText => this._media.MediaText;

    public IMediaList Media => this._media;

    public bool IsMatched => this._matched;

    private bool ComputeMatched(IWindow window) => false;

    private void Resized(object sender, Event ev)
    {
      bool matched = this.ComputeMatched((IWindow) sender);
      if (matched != this._matched)
        this.Dispatch((Event) new MediaQueryListEvent(EventNames.Change, media: this._media.MediaText, matches: matched));
      this._matched = matched;
    }
  }
}
