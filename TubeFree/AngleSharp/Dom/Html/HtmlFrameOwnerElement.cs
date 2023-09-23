// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFrameOwnerElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal abstract class HtmlFrameOwnerElement : HtmlElement
  {
    public HtmlFrameOwnerElement(Document owner, string name, string prefix, NodeFlags flags = NodeFlags.None)
      : base(owner, name, prefix, flags)
    {
    }

    public bool CanContainRangeEndpoint { get; private set; }

    public int DisplayWidth
    {
      get => this.GetOwnAttribute(AttributeNames.Width).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.Width, value.ToString());
    }

    public int DisplayHeight
    {
      get => this.GetOwnAttribute(AttributeNames.Height).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.Height, value.ToString());
    }

    public int MarginWidth
    {
      get => this.GetOwnAttribute(AttributeNames.MarginWidth).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.MarginWidth, value.ToString());
    }

    public int MarginHeight
    {
      get => this.GetOwnAttribute(AttributeNames.MarginHeight).ToInteger(0);
      set => this.SetOwnAttribute(AttributeNames.MarginHeight, value.ToString());
    }
  }
}
