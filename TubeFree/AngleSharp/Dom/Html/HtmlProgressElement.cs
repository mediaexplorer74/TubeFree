// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlProgressElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;
using System.Globalization;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlProgressElement : 
    HtmlElement,
    IHtmlProgressElement,
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
    ILabelabelElement
  {
    private readonly NodeList _labels;

    public HtmlProgressElement(Document owner, string prefix = null)
      : base(owner, TagNames.Progress, prefix)
    {
      this._labels = new NodeList();
    }

    public INodeList Labels => (INodeList) this._labels;

    public bool IsDeterminate => !string.IsNullOrEmpty(this.GetOwnAttribute(AttributeNames.Value));

    public double Value
    {
      get => this.GetOwnAttribute(AttributeNames.Value).ToDouble();
      set => this.SetOwnAttribute(AttributeNames.Value, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double Maximum
    {
      get => this.GetOwnAttribute(AttributeNames.Max).ToDouble(1.0);
      set => this.SetOwnAttribute(AttributeNames.Max, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double Position => !this.IsDeterminate ? -1.0 : Math.Max(Math.Min(this.Value / this.Maximum, 1.0), 0.0);
  }
}
