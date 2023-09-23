// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.PrettyStyleFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AngleSharp.Css
{
  public class PrettyStyleFormatter : IStyleFormatter
  {
    private string _intendString;
    private string _newLineString;

    public PrettyStyleFormatter()
    {
      this._intendString = "\t";
      this._newLineString = "\n";
    }

    public string Indentation
    {
      get => this._intendString;
      set => this._intendString = value;
    }

    public string NewLine
    {
      get => this._newLineString;
      set => this._newLineString = value;
    }

    string IStyleFormatter.Sheet(IEnumerable<IStyleFormattable> rules)
    {
      StringBuilder sb = Pool.NewStringBuilder();
      bool flag = true;
      using (StringWriter stringWriter = new StringWriter(sb))
      {
        foreach (IStyleFormattable rule in rules)
        {
          if (flag)
          {
            flag = false;
          }
          else
          {
            stringWriter.Write(this._newLineString);
            stringWriter.Write(this._newLineString);
          }
          StringWriter writer = stringWriter;
          rule.ToCss((TextWriter) writer, (IStyleFormatter) this);
        }
      }
      return sb.ToPool();
    }

    string IStyleFormatter.Block(IEnumerable<IStyleFormattable> rules)
    {
      StringBuilder sb = Pool.NewStringBuilder().Append('{').Append(' ');
      using (StringWriter stringWriter = new StringWriter(sb))
      {
        foreach (IStyleFormattable rule in rules)
        {
          stringWriter.Write(this._newLineString);
          stringWriter.Write(this.Intend(rule.ToCss((IStyleFormatter) this)));
          stringWriter.Write(this._newLineString);
        }
      }
      return sb.Append('}').ToPool();
    }

    string IStyleFormatter.Declaration(string name, string value, bool important) => CssStyleFormatter.Instance.Declaration(name, value, important);

    string IStyleFormatter.Declarations(IEnumerable<string> declarations) => string.Join(this._newLineString, declarations.Select<string, string>((Func<string, string>) (m => m + ";")));

    string IStyleFormatter.Medium(
      bool exclusive,
      bool inverse,
      string type,
      IEnumerable<IStyleFormattable> constraints)
    {
      return CssStyleFormatter.Instance.Medium(exclusive, inverse, type, constraints);
    }

    string IStyleFormatter.Constraint(string name, string value) => CssStyleFormatter.Instance.Constraint(name, value);

    string IStyleFormatter.Rule(string name, string value) => CssStyleFormatter.Instance.Rule(name, value);

    string IStyleFormatter.Rule(string name, string prelude, string rules) => CssStyleFormatter.Instance.Rule(name, prelude, rules);

    string IStyleFormatter.Style(string selector, IStyleFormattable rules)
    {
      StringBuilder stringBuilder = Pool.NewStringBuilder().Append(selector).Append(" {");
      string css = rules.ToCss((IStyleFormatter) this);
      if (!string.IsNullOrEmpty(css))
      {
        stringBuilder.Append(this._newLineString);
        stringBuilder.Append(this.Intend(css));
        stringBuilder.Append(this._newLineString);
      }
      else
        stringBuilder.Append(' ');
      return stringBuilder.Append('}').ToPool();
    }

    string IStyleFormatter.Comment(string data) => CssStyleFormatter.Instance.Comment(data);

    private string Intend(string content) => this._intendString + content.Replace(this._newLineString, this._newLineString + this._intendString);
  }
}
