// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.LinkRelationFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Html;
using AngleSharp.Html.LinkRels;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class LinkRelationFactory : ILinkRelationFactory
  {
    private readonly Dictionary<string, LinkRelationFactory.Creator> creators = new Dictionary<string, LinkRelationFactory.Creator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        LinkRelNames.StyleSheet,
        (LinkRelationFactory.Creator) (link => (BaseLinkRelation) new StyleSheetLinkRelation(link))
      },
      {
        LinkRelNames.Import,
        (LinkRelationFactory.Creator) (link => (BaseLinkRelation) new ImportLinkRelation(link))
      }
    };

    public BaseLinkRelation Create(HtmlLinkElement link, string rel)
    {
      LinkRelationFactory.Creator creator = (LinkRelationFactory.Creator) null;
      return rel != null && this.creators.TryGetValue(rel, out creator) ? creator(link) : (BaseLinkRelation) null;
    }

    private delegate BaseLinkRelation Creator(HtmlLinkElement link);
  }
}
