// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CompoundSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class CompoundSelector : Selectors, ISelector, ICssNode, IStyleFormattable
  {
    public bool Match(IElement element)
    {
      for (int index = 0; index < this._selectors.Count; ++index)
      {
        if (!this._selectors[index].Match(element))
          return false;
      }
      return true;
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      for (int index = 0; index < this._selectors.Count; ++index)
        writer.Write(this._selectors[index].Text);
    }
  }
}
