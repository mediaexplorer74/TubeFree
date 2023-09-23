// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlLabelElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlLabelElement : 
    HtmlElement,
    IHtmlLabelElement,
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
    public HtmlLabelElement(Document owner, string prefix = null)
      : base(owner, TagNames.Label, prefix)
    {
    }

    public IHtmlElement Control
    {
      get
      {
        string htmlFor = this.HtmlFor;
        if (!string.IsNullOrEmpty(htmlFor))
        {
          IHtmlElement elementById = this.Owner.GetElementById(htmlFor) as IHtmlElement;
          if (elementById is ILabelabelElement)
            return elementById;
        }
        return (IHtmlElement) null;
      }
    }

    public string HtmlFor
    {
      get => this.GetOwnAttribute(AttributeNames.For);
      set => this.SetOwnAttribute(AttributeNames.For, value);
    }

    public IHtmlFormElement Form => this.GetAssignedForm();
  }
}
