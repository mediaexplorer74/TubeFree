// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlCanvasElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Media;
using System;
using System.IO;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLCanvasElement")]
  public interface IHtmlCanvasElement : 
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
    [DomName("width")]
    int Width { get; set; }

    [DomName("height")]
    int Height { get; set; }

    [DomName("toDataURL")]
    string ToDataUrl(string type = null);

    [DomName("toBlob")]
    void ToBlob(Action<Stream> callback, string type = null);

    [DomName("getContext")]
    IRenderingContext GetContext(string contextId);

    [DomName("setContext")]
    void SetContext(IRenderingContext context);

    [DomName("probablySupportsContext")]
    bool IsSupportingContext(string contextId);
  }
}
