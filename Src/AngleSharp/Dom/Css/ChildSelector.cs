// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ChildSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal abstract class ChildSelector : CssNode, ISelector, ICssNode, IStyleFormattable
  {
    private readonly string _name;
    protected int _step;
    protected int _offset;
    protected ISelector _kind;

    public ChildSelector(string name) => this._name = name;

    public Priority Specifity => Priority.OneClass;

    public string Text => this.ToCss();

    internal ChildSelector With(int step, int offset, ISelector kind)
    {
      this._step = step;
      this._offset = offset;
      this._kind = kind;
      return this;
    }

    public abstract bool Match(IElement element);

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      string str1 = this._step.ToString();
      string str2 = string.Empty;
      if (this._offset > 0)
        str2 = "+" + this._offset.ToString();
      else if (this._offset < 0)
        str2 = this._offset.ToString();
      writer.Write(":{0}({1}n{2})", (object) this._name, (object) str1, (object) str2);
    }
  }
}
