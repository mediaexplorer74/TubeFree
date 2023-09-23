// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.CssStyleFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AngleSharp.Css
{
  public sealed class CssStyleFormatter : IStyleFormatter
  {
    public static readonly IStyleFormatter Instance = (IStyleFormatter) new CssStyleFormatter();

    string IStyleFormatter.Sheet(IEnumerable<IStyleFormattable> rules)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      this.WriteJoined(sb, rules, Environment.NewLine);
      return sb.ToPool();
    }

    string IStyleFormatter.Block(IEnumerable<IStyleFormattable> rules)
    {
      StringBuilder sb = Pool.NewStringBuilder().Append('{');
      using (StringWriter stringWriter = new StringWriter(sb))
      {
        foreach (IStyleFormattable rule in rules)
        {
          stringWriter.Write(' ');
          StringWriter writer = stringWriter;
          rule.ToCss((TextWriter) writer, (IStyleFormatter) this);
        }
      }
      return sb.Append(' ').Append('}').ToPool();
    }

    string IStyleFormatter.Declaration(string name, string value, bool important)
    {
      string str = value + (important ? " !important" : string.Empty);
      return name + ": " + str;
    }

    string IStyleFormatter.Declarations(IEnumerable<string> declarations) => string.Join("; ", declarations);

    string IStyleFormatter.Medium(
      bool exclusive,
      bool inverse,
      string type,
      IEnumerable<IStyleFormattable> constraints)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      bool first = true;
      if (exclusive)
        sb.Append("only ");
      else if (inverse)
        sb.Append("not ");
      if (!string.IsNullOrEmpty(type))
      {
        sb.Append(type);
        first = false;
      }
      this.WriteJoined(sb, constraints, " and ", first);
      return sb.ToPool();
    }

    string IStyleFormatter.Constraint(string name, string value)
    {
      string str = value != null ? ": " + value : string.Empty;
      return "(" + name + str + ")";
    }

    string IStyleFormatter.Rule(string name, string value) => name + " " + value + ";";

    string IStyleFormatter.Rule(string name, string prelude, string rules)
    {
      string str = string.IsNullOrEmpty(prelude) ? string.Empty : prelude + " ";
      return name + " " + str + rules;
    }

    string IStyleFormatter.Style(string selector, IStyleFormattable rules)
    {
      StringBuilder sb = Pool.NewStringBuilder().Append(selector).Append(" { ");
      int length = sb.Length;
      using (StringWriter writer = new StringWriter(sb))
        rules.ToCss((TextWriter) writer, (IStyleFormatter) this);
      if (sb.Length > length)
        sb.Append(' ');
      return sb.Append('}').ToPool();
    }

    string IStyleFormatter.Comment(string data) => string.Join("/* ", new string[2]
    {
      data,
      " */"
    });

    private void WriteJoined(
      StringBuilder sb,
      IEnumerable<IStyleFormattable> elements,
      string separator,
      bool first = true)
    {
      using (StringWriter stringWriter = new StringWriter(sb))
      {
        foreach (IStyleFormattable element in elements)
        {
          if (first)
            first = false;
          else
            stringWriter.Write(separator);
          StringWriter writer = stringWriter;
          element.ToCss((TextWriter) writer, (IStyleFormatter) this);
        }
      }
    }
  }
}
