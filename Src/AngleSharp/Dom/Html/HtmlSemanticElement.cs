// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlSemanticElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlSemanticElement : HtmlElement
  {
    public HtmlSemanticElement(Document owner, string name, string prefix = null)
      : base(owner, name, prefix, NodeFlags.Special)
    {
    }
  }
}
