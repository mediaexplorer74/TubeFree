// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.SvgElementFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Svg;
using AngleSharp.Html;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class SvgElementFactory : IElementFactory<SvgElement>
  {
    private readonly Dictionary<string, SvgElementFactory.Creator> creators = new Dictionary<string, SvgElementFactory.Creator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        TagNames.Svg,
        (SvgElementFactory.Creator) ((document, prefix) => (SvgElement) new SvgSvgElement(document, prefix))
      },
      {
        TagNames.Circle,
        (SvgElementFactory.Creator) ((document, prefix) => (SvgElement) new SvgCircleElement(document, prefix))
      },
      {
        TagNames.Desc,
        (SvgElementFactory.Creator) ((document, prefix) => (SvgElement) new SvgDescElement(document, prefix))
      },
      {
        TagNames.ForeignObject,
        (SvgElementFactory.Creator) ((document, prefix) => (SvgElement) new SvgForeignObjectElement(document, prefix))
      },
      {
        TagNames.Title,
        (SvgElementFactory.Creator) ((document, prefix) => (SvgElement) new SvgTitleElement(document, prefix))
      }
    };

    public SvgElement Create(Document document, string localName, string prefix = null)
    {
      SvgElementFactory.Creator creator = (SvgElementFactory.Creator) null;
      return this.creators.TryGetValue(localName, out creator) ? creator(document, prefix) : new SvgElement(document, localName);
    }

    private delegate SvgElement Creator(Document owner, string prefix);
  }
}
