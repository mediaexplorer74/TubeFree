// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlCanvasElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Services;
using System;
using System.IO;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlCanvasElement : 
    HtmlElement,
    IHtmlCanvasElement,
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
    private HtmlCanvasElement.ContextMode _mode;
    private IRenderingContext _current;

    public HtmlCanvasElement(Document owner, string prefix = null)
      : base(owner, TagNames.Canvas, prefix)
    {
      this._mode = HtmlCanvasElement.ContextMode.None;
    }

    public int Width
    {
      get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(300);
      set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int Height
    {
      get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(150);
      set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public IRenderingContext GetContext(string contextId)
    {
      if (this._current != null && !contextId.Isi(this._current.ContextId))
        return this._current;
      foreach (IRenderingService service in this.Owner.Options.GetServices<IRenderingService>())
      {
        if (service.IsSupportingContext(contextId))
        {
          IRenderingContext context = service.CreateContext((IHtmlCanvasElement) this, contextId);
          if (context != null)
          {
            this._mode = HtmlCanvasElement.GetModeFrom(contextId);
            this._current = context;
          }
          return context;
        }
      }
      return (IRenderingContext) null;
    }

    public bool IsSupportingContext(string contextId)
    {
      foreach (IRenderingService service in this.Owner.Options.GetServices<IRenderingService>())
      {
        if (service.IsSupportingContext(contextId))
          return true;
      }
      return false;
    }

    public void SetContext(IRenderingContext context)
    {
      if (this._mode != HtmlCanvasElement.ContextMode.None && this._mode != HtmlCanvasElement.ContextMode.Indirect)
        throw new DomException(DomError.InvalidState);
      if (context.IsFixed)
        throw new DomException(DomError.InvalidState);
      this._current = context.Host == this ? context : throw new DomException(DomError.InUse);
      this._mode = HtmlCanvasElement.ContextMode.Indirect;
    }

    public string ToDataUrl(string type = null) => Convert.ToBase64String(this.GetImageData(type));

    public void ToBlob(Action<Stream> callback, string type = null)
    {
      MemoryStream memoryStream = new MemoryStream(this.GetImageData(type));
      callback((Stream) memoryStream);
    }

    private byte[] GetImageData(string type) => this._current?.ToImage(type ?? MimeTypeNames.Plain) ?? new byte[0];

    private static HtmlCanvasElement.ContextMode GetModeFrom(string contextId)
    {
      if (contextId.Isi("2d"))
        return HtmlCanvasElement.ContextMode.Direct2d;
      return contextId.Isi("webgl") ? HtmlCanvasElement.ContextMode.DirectWebGl : HtmlCanvasElement.ContextMode.None;
    }

    private enum ContextMode : byte
    {
      None,
      Direct2d,
      DirectWebGl,
      Indirect,
      Proxied,
    }
  }
}
