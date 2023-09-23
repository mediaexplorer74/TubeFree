// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLElement")]
  public interface IHtmlElement : 
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
    [DomName("lang")]
    string Language { get; set; }

    [DomName("title")]
    string Title { get; set; }

    [DomName("dir")]
    string Direction { get; set; }

    [DomName("dataset")]
    IStringMap Dataset { get; }

    [DomName("translate")]
    bool IsTranslated { get; set; }

    [DomName("tabIndex")]
    int TabIndex { get; set; }

    [DomName("spellcheck")]
    bool IsSpellChecked { get; set; }

    [DomName("contentEditable")]
    string ContentEditable { get; set; }

    [DomName("isContentEditable")]
    bool IsContentEditable { get; }

    [DomName("hidden")]
    bool IsHidden { get; set; }

    [DomName("draggable")]
    bool IsDraggable { get; set; }

    [DomName("accessKey")]
    string AccessKey { get; set; }

    [DomName("accessKeyLabel")]
    string AccessKeyLabel { get; }

    [DomName("contextMenu")]
    IHtmlMenuElement ContextMenu { get; set; }

    [DomName("dropzone")]
    [DomPutForwards("value")]
    ISettableTokenList DropZone { get; }

    [DomName("innerText")]
    string InnerText { get; set; }

    [DomName("click")]
    void DoClick();

    [DomName("focus")]
    void DoFocus();

    [DomName("blur")]
    void DoBlur();

    [DomName("forceSpellCheck")]
    void DoSpellCheck();
  }
}
