// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.KeyframeSelector
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css.Values;
using AngleSharp.Extensions;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class KeyframeSelector : CssNode, IKeyframeSelector, ICssNode, IStyleFormattable
  {
    private readonly List<Percent> _stops;

    public KeyframeSelector(IEnumerable<Percent> stops) => this._stops = new List<Percent>(stops);

    public IEnumerable<Percent> Stops => (IEnumerable<Percent>) this._stops;

    public string Text => this.ToCss();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      if (this._stops.Count <= 0)
        return;
      writer.Write(this._stops[0].ToString());
      for (int index = 1; index < this._stops.Count; ++index)
      {
        writer.Write(", ");
        writer.Write(this._stops[index].ToString());
      }
    }
  }
}
