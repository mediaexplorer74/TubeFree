// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Collections.MediaList
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Collections
{
  internal sealed class MediaList : 
    CssNode,
    IMediaList,
    ICssNode,
    IStyleFormattable,
    IEnumerable<ICssMedium>,
    IEnumerable
  {
    private readonly CssParser _parser;

    internal MediaList(CssParser parser) => this._parser = parser;

    public string this[int index] => this.Media.GetItemByIndex<CssMedium>(index).ToCss();

    public IEnumerable<CssMedium> Media => this.Children.OfType<CssMedium>();

    public int Length => this.Media.Count<CssMedium>();

    public string MediaText
    {
      get => this.ToCss();
      set
      {
        this.Clear();
        foreach (CssMedium media in this._parser.ParseMediaList(value))
        {
          if (media == null)
            throw new DomException(DomError.Syntax);
          this.AppendChild((ICssNode) media);
        }
      }
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      CssMedium[] array = this.Media.ToArray<CssMedium>();
      if (array.Length == 0)
        return;
      array[0].ToCss(writer, formatter);
      for (int index = 1; index < array.Length; ++index)
      {
        writer.Write(", ");
        array[index].ToCss(writer, formatter);
      }
    }

    public bool Validate(RenderDevice device) => !this.Media.Any<CssMedium>((Func<CssMedium, bool>) (m => !m.Validate(device)));

    public void Add(string newMedium) => this.AppendChild((ICssNode) (this._parser.ParseMedium(newMedium) ?? throw new DomException(DomError.Syntax)));

    public void Remove(string oldMedium)
    {
      CssMedium medium1 = this._parser.ParseMedium(oldMedium);
      if (medium1 == null)
        throw new DomException(DomError.Syntax);
      foreach (CssMedium medium2 in this.Media)
      {
        if (medium2.Equals((object) medium1))
        {
          this.RemoveChild((ICssNode) medium2);
          return;
        }
      }
      throw new DomException(DomError.NotFound);
    }

    public IEnumerator<ICssMedium> GetEnumerator() => (IEnumerator<ICssMedium>) this.Media.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
