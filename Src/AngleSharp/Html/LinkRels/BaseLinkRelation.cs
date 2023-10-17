// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.LinkRels.BaseLinkRelation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Network.RequestProcessors;
using System.Threading.Tasks;

namespace AngleSharp.Html.LinkRels
{
  internal abstract class BaseLinkRelation
  {
    private readonly HtmlLinkElement _link;
    private readonly IRequestProcessor _processor;

    public BaseLinkRelation(HtmlLinkElement link, IRequestProcessor processor)
    {
      this._link = link;
      this._processor = processor;
    }

    public IRequestProcessor Processor => this._processor;

    public HtmlLinkElement Link => this._link;

    public Url Url => new Url(this._link.Href);

    public abstract Task LoadAsync();
  }
}
