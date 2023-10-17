// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFrameElementBase
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Network.RequestProcessors;

namespace AngleSharp.Dom.Html
{
  internal abstract class HtmlFrameElementBase : HtmlFrameOwnerElement
  {
    private IBrowsingContext _context;
    private FrameRequestProcessor _request;

    public HtmlFrameElementBase(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, flags | NodeFlags.Special)
    {
      this._request = FrameRequestProcessor.Create(this);
    }

    public IDownload CurrentDownload => this._request?.Download;

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public string Source
    {
      get => this.GetUrlAttribute(AttributeNames.Src);
      set => this.SetOwnAttribute(AttributeNames.Src, value);
    }

    public string Scrolling
    {
      get => this.GetOwnAttribute(AttributeNames.Scrolling);
      set => this.SetOwnAttribute(AttributeNames.Scrolling, value);
    }

    public IDocument ContentDocument => this._request?.Document;

    public string LongDesc
    {
      get => this.GetOwnAttribute(AttributeNames.LongDesc);
      set => this.SetOwnAttribute(AttributeNames.LongDesc, value);
    }

    public string FrameBorder
    {
      get => this.GetOwnAttribute(AttributeNames.FrameBorder);
      set => this.SetOwnAttribute(AttributeNames.FrameBorder, value);
    }

    public IBrowsingContext NestedContext => this._context ?? (this._context = this.Owner.NewChildContext(Sandboxes.None));

    internal virtual string GetContentHtml() => (string) null;

    internal override void SetupElement()
    {
      base.SetupElement();
      if (this.GetOwnAttribute(AttributeNames.Src) == null)
        return;
      this.UpdateSource();
    }

    internal void UpdateSource()
    {
      string contentHtml = this.GetContentHtml();
      string source = this.Source;
      if ((source == null || !(source != this.Owner.DocumentUri)) && contentHtml == null)
        return;
      this.Process((IRequestProcessor) this._request, this.HyperReference(source));
    }
  }
}
