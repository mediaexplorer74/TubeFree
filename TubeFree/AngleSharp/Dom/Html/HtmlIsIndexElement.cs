// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlIsIndexElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlIsIndexElement : HtmlElement
  {
    public HtmlIsIndexElement(Document owner, string prefix = null)
      : base(owner, TagNames.IsIndex, prefix, NodeFlags.Special)
    {
    }

    public IHtmlFormElement Form { get; internal set; }

    public string Prompt
    {
      get => this.GetOwnAttribute(AttributeNames.Prompt);
      set => this.SetOwnAttribute(AttributeNames.Prompt, value);
    }
  }
}
