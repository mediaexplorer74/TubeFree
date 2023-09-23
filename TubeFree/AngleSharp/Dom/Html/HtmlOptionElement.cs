// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlOptionElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlOptionElement : 
    HtmlElement,
    IHtmlOptionElement,
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
    private bool? _selected;

    public HtmlOptionElement(Document owner, string prefix = null)
      : base(owner, TagNames.Option, prefix, NodeFlags.ImplicitelyClosed | NodeFlags.ImpliedEnd | NodeFlags.HtmlSelectScoped)
    {
    }

    public bool IsDisabled
    {
      get => this.GetBoolAttribute(AttributeNames.Disabled);
      set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public IHtmlFormElement Form => this.GetAssignedForm();

    public string Label
    {
      get => this.GetOwnAttribute(AttributeNames.Label) ?? this.Text;
      set => this.SetOwnAttribute(AttributeNames.Label, value);
    }

    public string Value
    {
      get => this.GetOwnAttribute(AttributeNames.Value) ?? this.Text;
      set => this.SetOwnAttribute(AttributeNames.Value, value);
    }

    public int Index
    {
      get
      {
        if (this.Parent is HtmlOptionsGroupElement parent)
        {
          int index = 0;
          foreach (INode childNode in parent.ChildNodes)
          {
            if (childNode == this)
              return index;
            ++index;
          }
        }
        return 0;
      }
    }

    public string Text
    {
      get => this.TextContent.CollapseAndStrip();
      set => this.TextContent = value;
    }

    public bool IsDefaultSelected
    {
      get => this.GetBoolAttribute(AttributeNames.Selected);
      set => this.SetBoolAttribute(AttributeNames.Selected, value);
    }

    public bool IsSelected
    {
      get => !this._selected.HasValue ? this.IsDefaultSelected : this._selected.Value;
      set => this._selected = new bool?(value);
    }
  }
}
