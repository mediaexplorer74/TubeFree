// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.DocumentFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal abstract class DocumentFunction : CssNode, IDocumentFunction, ICssNode, IStyleFormattable
  {
    private readonly string _name;
    private readonly string _data;

    internal DocumentFunction(string name, string data)
    {
      this._name = name;
      this._data = data;
    }

    public string Name => this._name;

    public string Data => this._data;

    public abstract bool Matches(Url url);

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(this._name.CssFunction(this._data.CssString()));
  }
}
