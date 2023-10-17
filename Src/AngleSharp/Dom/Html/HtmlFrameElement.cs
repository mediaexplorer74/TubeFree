// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFrameElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlFrameElement : HtmlFrameElementBase
  {
    public HtmlFrameElement(Document owner, string prefix = null)
      : base(owner, TagNames.Frame, prefix, NodeFlags.SelfClosing)
    {
    }

    public bool NoResize
    {
      get => this.GetOwnAttribute(AttributeNames.NoResize).ToBoolean();
      set => this.SetOwnAttribute(AttributeNames.NoResize, value.ToString());
    }
  }
}
