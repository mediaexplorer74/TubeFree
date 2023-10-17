// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.NotCondition
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class NotCondition : CssNode, IConditionFunction, ICssNode, IStyleFormattable
  {
    private IConditionFunction _content;

    public IConditionFunction Content
    {
      get => this._content ?? (IConditionFunction) new EmptyCondition();
      set
      {
        if (this._content != null)
          this.RemoveChild((ICssNode) this._content);
        this._content = value;
        if (value == null)
          return;
        this.AppendChild((ICssNode) this._content);
      }
    }

    public bool Check() => !this.Content.Check();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      writer.Write("not ");
      this.Content.ToCss(writer, formatter);
    }
  }
}
