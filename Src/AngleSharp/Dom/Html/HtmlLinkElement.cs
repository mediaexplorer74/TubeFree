// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlLinkElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Html.LinkRels;
using AngleSharp.Network;
using AngleSharp.Services;
using System;
using System.Collections.Generic;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlLinkElement : 
    HtmlElement,
    IHtmlLinkElement,
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
    ILinkStyle,
    ILinkImport,
    ILoadableElement
  {
    private BaseLinkRelation _relation;
    private TokenList _relList;
    private SettableTokenList _sizes;

    public HtmlLinkElement(Document owner, string prefix = null)
      : base(owner, TagNames.Link, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }

    internal bool IsVisited { get; set; }

    internal bool IsActive { get; set; }

    public IDownload CurrentDownload => this._relation?.Processor?.Download;

    public string Href
    {
      get => this.GetUrlAttribute(AttributeNames.Href);
      set => this.SetOwnAttribute(AttributeNames.Href, value);
    }

    public string TargetLanguage
    {
      get => this.GetOwnAttribute(AttributeNames.HrefLang);
      set => this.SetOwnAttribute(AttributeNames.HrefLang, value);
    }

    public string Charset
    {
      get => this.GetOwnAttribute(AttributeNames.Charset);
      set => this.SetOwnAttribute(AttributeNames.Charset, value);
    }

    public string Relation
    {
      get => this.GetOwnAttribute(AttributeNames.Rel);
      set => this.SetOwnAttribute(AttributeNames.Rel, value);
    }

    public ITokenList RelationList
    {
      get
      {
        if (this._relList == null)
        {
          this._relList = new TokenList(this.GetOwnAttribute(AttributeNames.Rel));
          this._relList.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.Rel, value));
        }
        return (ITokenList) this._relList;
      }
    }

    public ISettableTokenList Sizes
    {
      get
      {
        if (this._sizes == null)
        {
          this._sizes = new SettableTokenList(this.GetOwnAttribute(AttributeNames.Sizes));
          this._sizes.Changed += (Action<string>) (value => this.UpdateAttribute(AttributeNames.Sizes, value));
        }
        return (ISettableTokenList) this._sizes;
      }
    }

    public string Rev
    {
      get => this.GetOwnAttribute(AttributeNames.Rev);
      set => this.SetOwnAttribute(AttributeNames.Rev, value);
    }

    public bool IsDisabled
    {
      get => this.GetBoolAttribute(AttributeNames.Disabled);
      set => this.SetBoolAttribute(AttributeNames.Disabled, value);
    }

    public string Target
    {
      get => this.GetOwnAttribute(AttributeNames.Target);
      set => this.SetOwnAttribute(AttributeNames.Target, value);
    }

    public string Media
    {
      get => this.GetOwnAttribute(AttributeNames.Media);
      set => this.SetOwnAttribute(AttributeNames.Media, value);
    }

    public string Type
    {
      get => this.GetOwnAttribute(AttributeNames.Type);
      set => this.SetOwnAttribute(AttributeNames.Type, value);
    }

    public string Integrity
    {
      get => this.GetOwnAttribute(AttributeNames.Integrity);
      set => this.SetOwnAttribute(AttributeNames.Integrity, value);
    }

    public IStyleSheet Sheet => !(this._relation is StyleSheetLinkRelation relation) ? (IStyleSheet) null : relation.Sheet;

    public IDocument Import => !(this._relation is ImportLinkRelation relation) ? (IDocument) null : relation.Import;

    public string CrossOrigin
    {
      get => this.GetOwnAttribute(AttributeNames.CrossOrigin);
      set => this.SetOwnAttribute(AttributeNames.CrossOrigin, value);
    }

    internal override void SetupElement()
    {
      base.SetupElement();
      string ownAttribute = this.GetOwnAttribute(AttributeNames.Rel);
      if (ownAttribute == null)
        return;
      this.UpdateRelation(ownAttribute);
    }

    internal void UpdateSizes(string value) => this._sizes?.Update(value);

    internal void UpdateMedia(string value)
    {
      IStyleSheet sheet = this.Sheet;
      if (sheet == null)
        return;
      sheet.Media.MediaText = value;
    }

    internal void UpdateDisabled(string value)
    {
      IStyleSheet sheet = this.Sheet;
      if (sheet == null)
        return;
      sheet.IsDisabled = value != null;
    }

    internal void UpdateRelation(string value)
    {
      this._relList?.Update(value);
      this._relation = this.CreateFirstLegalRelation();
      this.UpdateSource(this.GetOwnAttribute(AttributeNames.Href));
    }

    internal void UpdateSource(string value) => this.Owner?.DelayLoad(this._relation?.LoadAsync());

    private BaseLinkRelation CreateFirstLegalRelation()
    {
      ITokenList relationList = this.RelationList;
      Document owner = this.Owner;
      ILinkRelationFactory factory = owner != null ? owner.Options.GetFactory<ILinkRelationFactory>() : (ILinkRelationFactory) null;
      foreach (string rel in (IEnumerable<string>) relationList)
      {
        BaseLinkRelation firstLegalRelation = factory.Create(this, rel);
        if (firstLegalRelation != null)
          return firstLegalRelation;
      }
      return (BaseLinkRelation) null;
    }
  }
}
