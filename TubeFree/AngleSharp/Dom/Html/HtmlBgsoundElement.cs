﻿// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlBgsoundElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Html;

namespace AngleSharp.Dom.Html
{
  [DomHistorical]
  internal sealed class HtmlBgsoundElement : HtmlElement
  {
    public HtmlBgsoundElement(Document owner, string prefix = null)
      : base(owner, TagNames.Bgsound, prefix, NodeFlags.SelfClosing | NodeFlags.Special)
    {
    }
  }
}
