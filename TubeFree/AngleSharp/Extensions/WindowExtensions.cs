// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.WindowExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  internal static class WindowExtensions
  {
    public static CssStyleDeclaration ComputeDefaultStyle(this IWindow window, IElement element) => throw new NotImplementedException();

    public static CssStyleDeclaration ComputeRawStyle(this IWindow window, IElement element) => throw new NotImplementedException();

    public static CssStyleDeclaration ComputeUsedStyle(this IWindow window, IElement element) => throw new NotImplementedException();

    public static CssStyleDeclaration ComputeCascadedStyle(
      this StyleCollection styleCollection,
      IElement element)
    {
      CssStyleDeclaration cascadedStyle = new CssStyleDeclaration();
      foreach (CssStyleRule cssStyleRule in styleCollection.SortBySpecifity(element))
      {
        CssStyleDeclaration style = cssStyleRule.Style;
        cascadedStyle.SetDeclarations(style.Declarations);
      }
      if (element is IHtmlElement)
      {
        IHtmlElement htmlElement = (IHtmlElement) element;
        if (htmlElement.Style != null)
        {
          IEnumerable<CssProperty> decls = htmlElement.Style.OfType<CssProperty>();
          cascadedStyle.SetDeclarations(decls);
        }
      }
      return cascadedStyle;
    }

    public static StyleCollection GetStyleCollection(this IWindow window)
    {
      RenderDevice device = new RenderDevice(window.OuterWidth, window.OuterHeight);
      return new StyleCollection(window.Document.GetStyleSheets().OfType<CssStyleSheet>(), device);
    }

    private static IEnumerable<CssStyleRule> SortBySpecifity(
      this IEnumerable<CssStyleRule> rules,
      IElement element)
    {
      return (IEnumerable<CssStyleRule>) rules.Where<CssStyleRule>((Func<CssStyleRule, bool>) (m => m.Selector.Match(element))).OrderBy<CssStyleRule, Priority>((Func<CssStyleRule, Priority>) (m => m.Selector.Specifity));
    }
  }
}
