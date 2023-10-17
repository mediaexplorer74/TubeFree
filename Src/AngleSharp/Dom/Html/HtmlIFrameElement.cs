// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlIFrameElement
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
  internal sealed class HtmlIFrameElement : 
    HtmlFrameElementBase,
    IHtmlInlineFrameElement,
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
    ILoadableElement
  {
    private SettableTokenList _sandbox;

    public HtmlIFrameElement(Document owner, string prefix = null)
      : base(owner, TagNames.Iframe, prefix, NodeFlags.LiteralText)
    {
    }

    public Alignment Align
    {
      get => this.GetOwnAttribute(AttributeNames.Align).ToEnum<Alignment>(Alignment.Bottom);
      set => this.SetOwnAttribute(AttributeNames.Align, value.ToString());
    }

    public string ContentHtml
    {
      get => this.GetOwnAttribute(AttributeNames.SrcDoc);
      set => this.SetOwnAttribute(AttributeNames.SrcDoc, value);
    }

    public ISettableTokenList Sandbox
    {
      get
      {
        if (this._sandbox == null)
        {
          this._sandbox = new SettableTokenList(this.GetOwnAttribute(AttributeNames.Sandbox));
          this._sandbox.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.Sandbox, value));
        }
        return (ISettableTokenList) this._sandbox;
      }
    }

    public bool IsSeamless
    {
      get => this.GetBoolAttribute(AttributeNames.SrcDoc);
      set => this.SetBoolAttribute(AttributeNames.SrcDoc, value);
    }

    public bool IsFullscreenAllowed
    {
      get => this.GetBoolAttribute(AttributeNames.AllowFullscreen);
      set => this.SetBoolAttribute(AttributeNames.AllowFullscreen, value);
    }

    public IWindow ContentWindow => this.NestedContext.Current;

    internal override string GetContentHtml() => this.ContentHtml;

    internal override void SetupElement()
    {
      base.SetupElement();
      if (this.GetOwnAttribute(AttributeNames.SrcDoc) == null)
        return;
      this.UpdateSource();
    }

    internal void UpdateSandbox(string value) => this._sandbox?.Update(value);
  }
}
