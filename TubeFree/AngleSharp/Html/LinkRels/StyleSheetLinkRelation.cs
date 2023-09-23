// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.LinkRels.StyleSheetLinkRelation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Network.RequestProcessors;
using System.Threading.Tasks;

namespace AngleSharp.Html.LinkRels
{
  internal class StyleSheetLinkRelation : BaseLinkRelation
  {
    public StyleSheetLinkRelation(HtmlLinkElement link)
      : base(link, (IRequestProcessor) StyleSheetRequestProcessor.Create(link))
    {
    }

    public IStyleSheet Sheet => !(this.Processor is StyleSheetRequestProcessor processor) ? (IStyleSheet) null : processor.Sheet;

    public override Task LoadAsync() => this.Processor?.ProcessAsync(this.Link.CreateRequestFor(this.Url));
  }
}
