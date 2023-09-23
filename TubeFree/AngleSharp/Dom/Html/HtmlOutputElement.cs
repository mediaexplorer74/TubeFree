// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlOutputElement
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
  internal sealed class HtmlOutputElement : 
    HtmlFormControlElement,
    IHtmlOutputElement,
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
    IValidation
  {
    private string _defaultValue;
    private string _value;
    private SettableTokenList _for;

    public HtmlOutputElement(Document owner, string prefix = null)
      : base(owner, TagNames.Output, prefix)
    {
    }

    public string DefaultValue
    {
      get => this._defaultValue ?? this.TextContent;
      set => this._defaultValue = value;
    }

    public override string TextContent
    {
      get => this._value ?? this._defaultValue ?? base.TextContent;
      set => base.TextContent = value;
    }

    public string Value
    {
      get => this.TextContent;
      set => this._value = value;
    }

    public ISettableTokenList HtmlFor
    {
      get
      {
        if (this._for == null)
        {
          this._for = new SettableTokenList(this.GetOwnAttribute(AttributeNames.For));
          this._for.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.For, value));
        }
        return (ISettableTokenList) this._for;
      }
    }

    public string Type => TagNames.Output;

    internal override void Reset() => this._value = (string) null;

    internal void UpdateFor(string value) => this._for?.Update(value);

    protected override bool CanBeValidated() => true;
  }
}
