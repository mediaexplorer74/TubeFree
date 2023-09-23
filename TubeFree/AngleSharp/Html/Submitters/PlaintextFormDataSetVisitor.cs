// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.PlaintextFormDataSetVisitor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Io;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Html.Submitters
{
  internal sealed class PlaintextFormDataSetVisitor : IFormSubmitter, IFormDataSetVisitor
  {
    private readonly List<string> _lines;

    public PlaintextFormDataSetVisitor() => this._lines = new List<string>();

    public void Text(FormDataSetEntry entry, string value)
    {
      if (!entry.HasName || value == null)
        return;
      this.Add(entry.Name, value);
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile content)
    {
      if (!entry.HasName || content == null || content.Name == null)
        return;
      this.Add(entry.Name, content.Name);
    }

    public void Serialize(StreamWriter stream)
    {
      string str = string.Join(Symbols.NewLines[0], (IEnumerable<string>) this._lines);
      stream.Write(str);
    }

    private void Add(string name, string value) => this._lines.Add(name + "=" + value);
  }
}
