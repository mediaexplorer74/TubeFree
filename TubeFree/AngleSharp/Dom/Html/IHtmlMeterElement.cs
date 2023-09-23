// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.IHtmlMeterElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;

namespace AngleSharp.Dom.Html
{
  [DomName("HTMLMeterElement")]
  public interface IHtmlMeterElement : 
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
    [DomName("value")]
    double Value { get; set; }

    [DomName("min")]
    double Minimum { get; set; }

    [DomName("max")]
    double Maximum { get; set; }

    [DomName("low")]
    double Low { get; set; }

    [DomName("high")]
    double High { get; set; }

    [DomName("optimum")]
    double Optimum { get; set; }
  }
}
