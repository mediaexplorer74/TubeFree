// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.TokenizerExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using AngleSharp.Html;
using AngleSharp.Parser.Html;
using AngleSharp.Services;
using System;
using System.Collections.Generic;

namespace AngleSharp.Extensions
{
  public static class TokenizerExtensions
  {
    public static IEnumerable<HtmlToken> Tokenize(
      this TextSource source,
      IEntityProvider provider = null,
      EventHandler<HtmlErrorEvent> errorHandler = null)
    {
      HtmlTokenizer htmlTokenizer = new HtmlTokenizer(source, provider ?? HtmlEntityService.Resolver);
      HtmlToken token = (HtmlToken) null;
      if (errorHandler != null)
        htmlTokenizer.Error += errorHandler;
      do
      {
        token = htmlTokenizer.Get();
        yield return token;
      }
      while (token.Type != HtmlTokenType.EndOfFile);
    }
  }
}
