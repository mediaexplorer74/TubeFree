// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssUnknownRule
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Parser.Css;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssUnknownRule : CssRule
  {
    private readonly string _name;

    public CssUnknownRule(string name, CssParser parser)
      : base(CssRuleType.Unknown, parser)
    {
      this._name = name;
    }

    public string Name => this._name;

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(this.SourceCode?.Text);
  }
}
