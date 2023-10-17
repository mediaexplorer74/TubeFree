// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.FormatExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Html;
using System.IO;
using System.Text;

namespace AngleSharp.Extensions
{
  public static class FormatExtensions
  {
    public static string ToCss(this IStyleFormattable style) => style.ToCss(CssStyleFormatter.Instance);

    public static string ToCss(this IStyleFormattable style, IStyleFormatter formatter)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      using (StringWriter writer = new StringWriter(sb))
        style.ToCss((TextWriter) writer, formatter);
      return sb.ToPool();
    }

    public static void ToCss(this IStyleFormattable style, TextWriter writer) => style.ToCss(writer, CssStyleFormatter.Instance);

    public static string ToHtml(this IMarkupFormattable markup) => markup.ToHtml(HtmlMarkupFormatter.Instance);

    public static string ToHtml(this IMarkupFormattable markup, IMarkupFormatter formatter)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      using (StringWriter writer = new StringWriter(sb))
        markup.ToHtml((TextWriter) writer, formatter);
      return sb.ToPool();
    }

    public static void ToHtml(this IMarkupFormattable markup, TextWriter writer) => markup.ToHtml(writer, HtmlMarkupFormatter.Instance);
  }
}
