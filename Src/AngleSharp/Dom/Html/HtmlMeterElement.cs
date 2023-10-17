// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlMeterElement
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
  internal sealed class HtmlMeterElement : 
    HtmlElement,
    IHtmlMeterElement,
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

    public HtmlMeterElement(Document owner, string prefix = null)
      : base(owner, TagNames.Meter, prefix)
    {
      this._labels = new NodeList();
    }

    public INodeList Labels => (INodeList) this._labels;

    public double Value
    {
      get => this.GetOwnAttribute(AttributeNames.Value).ToDouble().Constraint(this.Minimum, this.Maximum);
      set => this.SetOwnAttribute(AttributeNames.Value, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double Maximum
    {
      get => this.GetOwnAttribute(AttributeNames.Max).ToDouble(1.0).Constraint(this.Minimum, double.PositiveInfinity);
      set => this.SetOwnAttribute(AttributeNames.Max, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double Minimum
    {
      get => this.GetOwnAttribute(AttributeNames.Min).ToDouble();
      set => this.SetOwnAttribute(AttributeNames.Min, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double Low
    {
      get => this.GetOwnAttribute(AttributeNames.Low).ToDouble(this.Minimum).Constraint(this.Minimum, this.Maximum);
      set => this.SetOwnAttribute(AttributeNames.Low, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double High
    {
      get => this.GetOwnAttribute(AttributeNames.High).ToDouble(this.Maximum).Constraint(this.Low, this.Maximum);
      set => this.SetOwnAttribute(AttributeNames.High, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }

    public double Optimum
    {
      get => this.GetOwnAttribute(AttributeNames.Optimum).ToDouble((this.Maximum + this.Minimum) * 0.5).Constraint(this.Minimum, this.Maximum);
      set => this.SetOwnAttribute(AttributeNames.Optimum, value.ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
    }
  }
}
