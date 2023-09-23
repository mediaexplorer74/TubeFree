// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFrameSetElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  [DomHistorical]
  internal sealed class HtmlFrameSetElement : HtmlElement
  {
    public HtmlFrameSetElement(Document owner, string prefix = null)
      : base(owner, TagNames.Frameset, prefix, NodeFlags.Special)
    {
    }

    public int Columns
    {
      get => this.GetOwnAttribute(AttributeNames.Cols).ToInteger(1);
      set => this.SetOwnAttribute(AttributeNames.Cols, value.ToString());
    }

    public int Rows
    {
      get => this.GetOwnAttribute(AttributeNames.Rows).ToInteger(1);
      set => this.SetOwnAttribute(AttributeNames.Rows, value.ToString());
    }
  }
}
