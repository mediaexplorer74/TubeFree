// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.StyleExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Extensions
{
  internal static class StyleExtensions
  {
    public static CssStyleDeclaration ComputeDeclarations(
      this StyleCollection rules,
      IElement element,
      string pseudoSelector = null)
    {
      CssStyleDeclaration declarations = new CssStyleDeclaration();
      PseudoElement pseudoElement = PseudoElement.Create(element, pseudoSelector);
      if (pseudoElement != null)
        element = (IElement) pseudoElement;
      declarations.SetDeclarations(rules.ComputeCascadedStyle(element).Declarations);
      foreach (IElement element1 in element.GetAncestors().OfType<IElement>())
      {
        CssStyleDeclaration cascadedStyle = rules.ComputeCascadedStyle(element1);
        declarations.UpdateDeclarations(cascadedStyle.Declarations);
      }
      return declarations;
    }

    public static IEnumerable<string> GetAllStyleSheetSets(this IStyleSheetList sheets)
    {
      List<string> existing = new List<string>();
      foreach (IStyleSheet sheet in (IEnumerable<IStyleSheet>) sheets)
      {
        string title = sheet.Title;
        if (!string.IsNullOrEmpty(title) && !existing.Contains(title))
        {
          existing.Add(title);
          yield return title;
        }
      }
    }

    public static IEnumerable<string> GetEnabledStyleSheetSets(this IStyleSheetList sheets)
    {
      List<string> second = new List<string>();
      foreach (IStyleSheet sheet in (IEnumerable<IStyleSheet>) sheets)
      {
        string title = sheet.Title;
        if (!string.IsNullOrEmpty(title) && !second.Contains(title) && sheet.IsDisabled)
          second.Add(title);
      }
      return sheets.GetAllStyleSheetSets().Except<string>((IEnumerable<string>) second);
    }

    public static void EnableStyleSheetSet(this IStyleSheetList sheets, string name)
    {
      foreach (IStyleSheet sheet in (IEnumerable<IStyleSheet>) sheets)
      {
        string title = sheet.Title;
        if (!string.IsNullOrEmpty(title))
          sheet.IsDisabled = title != name;
      }
    }

    public static IStyleSheetList CreateStyleSheets(this INode parent) => (IStyleSheetList) new StyleSheetList(parent.GetStyleSheets());

    public static IStringList CreateStyleSheetSets(this INode parent) => (IStringList) new StringList(parent.GetStyleSheets().Select<IStyleSheet, string>((Func<IStyleSheet, string>) (m => m.Title)).Where<string>((Func<string, bool>) (m => m != null)));

    public static IEnumerable<IStyleSheet> GetStyleSheets(this INode parent)
    {
      foreach (INode child in (IEnumerable<INode>) parent.ChildNodes)
      {
        if (child.NodeType == NodeType.Element)
        {
          if (child is ILinkStyle linkStyle)
          {
            IStyleSheet sheet = linkStyle.Sheet;
            if (sheet != null && !sheet.IsDisabled)
              yield return sheet;
          }
          else
          {
            foreach (IStyleSheet styleSheet in child.GetStyleSheets())
              yield return styleSheet;
          }
        }
      }
    }

    public static string LocateNamespace(this IStyleSheetList sheets, string prefix)
    {
      foreach (IStyleSheet sheet in (IEnumerable<IStyleSheet>) sheets)
      {
        CssStyleSheet cssStyleSheet = sheet as CssStyleSheet;
        if (!sheet.IsDisabled && cssStyleSheet != null)
        {
          foreach (CssNamespaceRule cssNamespaceRule in cssStyleSheet.Rules.OfType<CssNamespaceRule>())
          {
            if (cssNamespaceRule.Prefix.Is(prefix))
              return cssNamespaceRule.NamespaceUri;
          }
        }
      }
      return (string) null;
    }
  }
}
