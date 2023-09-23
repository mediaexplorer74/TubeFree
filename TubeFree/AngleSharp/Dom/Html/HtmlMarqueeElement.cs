// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlMarqueeElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  [DomHistorical]
  internal sealed class HtmlMarqueeElement : HtmlElement, IHtmlMarqueeElement
  {
    public HtmlMarqueeElement(Document owner, string prefix = null)
      : base(owner, TagNames.Marquee, prefix, NodeFlags.Special | NodeFlags.Scoped)
    {
    }

    public int MinimumDelay { get; private set; }

    public int ScrollAmount { get; set; }

    public int ScrollDelay { get; set; }

    public int Loop { get; set; }

    public void Start() => this.FireSimpleEvent(EventNames.Play);

    public void Stop() => this.FireSimpleEvent(EventNames.Pause);
  }
}
