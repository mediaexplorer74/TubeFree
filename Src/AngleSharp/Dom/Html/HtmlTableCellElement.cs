// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlTableCellElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;

namespace AngleSharp.Dom.Html
{
  internal abstract class HtmlTableCellElement : 
    HtmlElement,
    IHtmlTableCellElement,
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
    private SettableTokenList _headers;

    public HtmlTableCellElement(Document owner, string name, string prefix)
      : base(owner, name, prefix, NodeFlags.Special | NodeFlags.ImplicitelyClosed | NodeFlags.Scoped)
    {
    }

    public int Index
    {
      get
      {
        IElement parentElement = this.ParentElement;
        while (true)
        {
          switch (parentElement)
          {
            case null:
            case IHtmlTableRowElement _:
              goto label_3;
            default:
              parentElement = parentElement.ParentElement;
              continue;
          }
        }
label_3:
        return !(parentElement is HtmlTableRowElement parent) ? -1 : parent.IndexOf((INode) this);
      }
    }

    public HorizontalAlignment Align
    {
      get => this.GetOwnAttribute(AttributeNames.Align).ToEnum<HorizontalAlignment>(HorizontalAlignment.Left);
      set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public VerticalAlignment VAlign
    {
      get => this.GetOwnAttribute(AttributeNames.Valign).ToEnum<VerticalAlignment>(VerticalAlignment.Middle);
      set => this.SetOwnAttribute(AttributeNames.Valign, value.ToString());
    }

    public string BgColor
    {
      get => this.GetOwnAttribute(AttributeNames.BgColor);
      set => this.SetOwnAttribute(AttributeNames.BgColor, value);
    }

    public string Width
    {
      get => this.GetOwnAttribute(AttributeNames.Width);
      set => this.SetOwnAttribute(AttributeNames.Width, value);
    }

    public string Height
    {
      get => this.GetOwnAttribute(AttributeNames.Height);
      set => this.SetOwnAttribute(AttributeNames.Height, value);
    }

    public int ColumnSpan
    {
      get => HtmlTableCellElement.LimitColSpan(this.GetOwnAttribute(AttributeNames.ColSpan).ToInteger(1));
      set => this.SetOwnAttribute(AttributeNames.ColSpan, value.ToString());
    }

    public int RowSpan
    {
      get => HtmlTableCellElement.LimitRowSpan(this.GetOwnAttribute(AttributeNames.RowSpan).ToInteger(1));
      set => this.SetOwnAttribute(AttributeNames.RowSpan, value.ToString());
    }

    public bool NoWrap
    {
      get => this.GetOwnAttribute(AttributeNames.NoWrap).ToBoolean();
      set => this.SetOwnAttribute(AttributeNames.NoWrap, value.ToString());
    }

    public string Abbr
    {
      get => this.GetOwnAttribute(AttributeNames.Abbr);
      set => this.SetOwnAttribute(AttributeNames.Abbr, value);
    }

    public string Scope
    {
      get => this.GetOwnAttribute(AttributeNames.Scope);
      set => this.SetOwnAttribute(AttributeNames.Scope, value);
    }

    public ISettableTokenList Headers
    {
      get
      {
        if (this._headers == null)
        {
          this._headers = new SettableTokenList(this.GetOwnAttribute(AttributeNames.Headers));
          this._headers.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.Headers, value));
        }
        return (ISettableTokenList) this._headers;
      }
    }

    public string Axis
    {
      get => this.GetOwnAttribute(AttributeNames.Axis);
      set => this.SetOwnAttribute(AttributeNames.Axis, value);
    }

    internal void UpdateHeaders(string value) => this._headers?.Update(value);

    private static int LimitColSpan(int value) => value < 1 || value > 1000 ? 1 : value;

    private static int LimitRowSpan(int value) => value < 0 ? 1 : Math.Min(value, 65534);
  }
}
