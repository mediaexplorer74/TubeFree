// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.MathElementFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Mathml;
using AngleSharp.Html;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class MathElementFactory : IElementFactory<MathElement>
  {
    private readonly Dictionary<string, MathElementFactory.Creator> creators = new Dictionary<string, MathElementFactory.Creator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        TagNames.Mn,
        (MathElementFactory.Creator) ((document, prefix) => (MathElement) new MathNumberElement(document, prefix))
      },
      {
        TagNames.Mo,
        (MathElementFactory.Creator) ((document, prefix) => (MathElement) new MathOperatorElement(document, prefix))
      },
      {
        TagNames.Mi,
        (MathElementFactory.Creator) ((document, prefix) => (MathElement) new MathIdentifierElement(document, prefix))
      },
      {
        TagNames.Ms,
        (MathElementFactory.Creator) ((document, prefix) => (MathElement) new MathStringElement(document, prefix))
      },
      {
        TagNames.Mtext,
        (MathElementFactory.Creator) ((document, prefix) => (MathElement) new MathTextElement(document, prefix))
      },
      {
        TagNames.AnnotationXml,
        (MathElementFactory.Creator) ((document, prefix) => (MathElement) new MathAnnotationXmlElement(document, prefix))
      }
    };

    public MathElement Create(Document document, string localName, string prefix = null)
    {
      MathElementFactory.Creator creator = (MathElementFactory.Creator) null;
      return this.creators.TryGetValue(localName, out creator) ? creator(document, prefix) : new MathElement(document, localName, prefix);
    }

    private delegate MathElement Creator(Document owner, string prefix);
  }
}
