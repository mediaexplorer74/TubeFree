// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssComment
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssComment : CssNode, ICssComment, ICssNode, IStyleFormattable
  {
    private readonly string _data;

    public CssComment(string data) => this._data = data;

    public string Data => this._data;

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Comment(this._data));
  }
}
