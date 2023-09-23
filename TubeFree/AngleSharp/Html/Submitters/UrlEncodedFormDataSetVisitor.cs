// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.UrlEncodedFormDataSetVisitor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Io;
using AngleSharp.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AngleSharp.Html.Submitters
{
  internal sealed class UrlEncodedFormDataSetVisitor : IFormSubmitter, IFormDataSetVisitor
  {
    private readonly Encoding _encoding;
    private readonly List<string> _lines;
    private bool _first;
    private string _index;

    public UrlEncodedFormDataSetVisitor(Encoding encoding)
    {
      this._encoding = encoding;
      this._lines = new List<string>();
      this._first = true;
      this._index = string.Empty;
    }

    public void Text(FormDataSetEntry entry, string value)
    {
      if (this._first && entry.HasName && entry.Name.Is(TagNames.IsIndex) && entry.Type.Isi(InputTypeNames.Text))
        this._index = value ?? string.Empty;
      else if (entry.HasName && value != null)
        this.Add(this._encoding.GetBytes(entry.Name), this._encoding.GetBytes(value));
      this._first = false;
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile content)
    {
      if (entry.HasName && content != null && content.Name != null)
        this.Add(this._encoding.GetBytes(entry.Name), this._encoding.GetBytes(content.Name));
      this._first = false;
    }

    public void Serialize(StreamWriter stream)
    {
      string str = string.Join("&", (IEnumerable<string>) this._lines);
      stream.Write(this._index);
      stream.Write(str);
    }

    private void Add(byte[] name, byte[] value) => this._lines.Add(name.UrlEncode() + "=" + value.UrlEncode());
  }
}
