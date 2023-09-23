// Decompiled with JetBrains decompiler
// Type: AngleSharp.IStyleFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;

namespace AngleSharp
{
  public interface IStyleFormatter
  {
    string Sheet(IEnumerable<IStyleFormattable> rules);

    string Block(IEnumerable<IStyleFormattable> rules);

    string Declaration(string name, string value, bool important);

    string Declarations(IEnumerable<string> declarations);

    string Medium(
      bool exclusive,
      bool inverse,
      string type,
      IEnumerable<IStyleFormattable> constraints);

    string Constraint(string name, string value);

    string Rule(string name, string value);

    string Rule(string name, string prelude, string rules);

    string Style(string selector, IStyleFormattable rules);

    string Comment(string data);
  }
}
