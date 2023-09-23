// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlDialogElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlDialogElement : 
    HtmlElement,
    IHtmlDialogElement,
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
    private string _returnValue;

    public HtmlDialogElement(Document owner, string prefix = null)
      : base(owner, TagNames.Dialog, prefix)
    {
    }

    public bool Open
    {
      get => this.GetBoolAttribute(AttributeNames.Open);
      set => this.SetBoolAttribute(AttributeNames.Open, value);
    }

    public string ReturnValue
    {
      get => this._returnValue;
      set => this._returnValue = value;
    }

    public void Show(IElement anchor = null) => this.Open = true;

    public void ShowModal(IElement anchor = null) => this.Open = true;

    public void Close(string returnValue = null)
    {
      this.Open = false;
      this.ReturnValue = returnValue;
    }
  }
}
