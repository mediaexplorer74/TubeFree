// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlBodyElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlBodyElement : 
    HtmlElement,
    IHtmlBodyElement,
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
    IWindowEventHandlers
  {
    public event DomEventHandler Printed
    {
      add => this.AddEventListener(EventNames.AfterPrint, value, false);
      remove => this.RemoveEventListener(EventNames.AfterPrint, value, false);
    }

    public event DomEventHandler Printing
    {
      add => this.AddEventListener(EventNames.BeforePrint, value, false);
      remove => this.RemoveEventListener(EventNames.BeforePrint, value, false);
    }

    public event DomEventHandler Unloading
    {
      add => this.AddEventListener(EventNames.Unloading, value, false);
      remove => this.RemoveEventListener(EventNames.Unloading, value, false);
    }

    public event DomEventHandler HashChanged
    {
      add => this.AddEventListener(EventNames.HashChange, value, false);
      remove => this.RemoveEventListener(EventNames.HashChange, value, false);
    }

    public event DomEventHandler MessageReceived
    {
      add => this.AddEventListener(EventNames.Message, value, false);
      remove => this.RemoveEventListener(EventNames.Message, value, false);
    }

    public event DomEventHandler WentOffline
    {
      add => this.AddEventListener(EventNames.Offline, value, false);
      remove => this.RemoveEventListener(EventNames.Offline, value, false);
    }

    public event DomEventHandler WentOnline
    {
      add => this.AddEventListener(EventNames.Online, value, false);
      remove => this.RemoveEventListener(EventNames.Online, value, false);
    }

    public event DomEventHandler PageHidden
    {
      add => this.AddEventListener(EventNames.PageHide, value, false);
      remove => this.RemoveEventListener(EventNames.PageHide, value, false);
    }

    public event DomEventHandler PageShown
    {
      add => this.AddEventListener(EventNames.PageShow, value, false);
      remove => this.RemoveEventListener(EventNames.PageShow, value, false);
    }

    public event DomEventHandler PopState
    {
      add => this.AddEventListener(EventNames.PopState, value, false);
      remove => this.RemoveEventListener(EventNames.PopState, value, false);
    }

    public event DomEventHandler Storage
    {
      add => this.AddEventListener(EventNames.Storage, value, false);
      remove => this.RemoveEventListener(EventNames.Storage, value, false);
    }

    public event DomEventHandler Unloaded
    {
      add => this.AddEventListener(EventNames.Unload, value, false);
      remove => this.RemoveEventListener(EventNames.Unload, value, false);
    }

    public HtmlBodyElement(Document owner, string prefix = null)
      : base(owner, TagNames.Body, prefix, NodeFlags.Special | NodeFlags.ImplicitelyClosed)
    {
    }

    public string ALink
    {
      get => this.GetOwnAttribute(AttributeNames.Alink);
      set => this.SetOwnAttribute(AttributeNames.Alink, value);
    }

    public string Background
    {
      get => this.GetOwnAttribute(AttributeNames.Background);
      set => this.SetOwnAttribute(AttributeNames.Background, value);
    }

    public string BgColor
    {
      get => this.GetOwnAttribute(AttributeNames.BgColor);
      set => this.SetOwnAttribute(AttributeNames.BgColor, value);
    }

    public string Link
    {
      get => this.GetOwnAttribute(AttributeNames.Link);
      set => this.SetOwnAttribute(AttributeNames.Link, value);
    }

    public string Text
    {
      get => this.GetOwnAttribute(AttributeNames.Text);
      set => this.SetOwnAttribute(AttributeNames.Text, value);
    }

    public string VLink
    {
      get => this.GetOwnAttribute(AttributeNames.Vlink);
      set => this.SetOwnAttribute(AttributeNames.Vlink, value);
    }
  }
}
