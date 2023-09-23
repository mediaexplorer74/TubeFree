// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.UnknownSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class UnknownSelector : CssNode, ISelector, ICssNode, IStyleFormattable
  {
    public Priority Specifity => Priority.Zero;

    public bool Match(IElement element) => false;

    public string Text => this.ToCss();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(this.SourceCode?.Text);
  }
}
