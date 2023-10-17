// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.FileDataSetEntry
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Io;
using AngleSharp.Network;
using System.IO;
using System.Text;

namespace AngleSharp.Html
{
  internal sealed class FileDataSetEntry : FormDataSetEntry
  {
    private readonly IFile _value;

    public FileDataSetEntry(string name, IFile value, string type)
      : base(name, type)
    {
      this._value = value;
    }

    public string FileName => this._value?.Name ?? string.Empty;

    public string ContentType => this._value?.Type ?? MimeTypeNames.Binary;

    public override bool Contains(string boundary, Encoding encoding)
    {
      bool flag = false;
      Stream body = this._value?.Body;
      if (body != null && body.CanSeek)
      {
        using (StreamReader streamReader = new StreamReader(body, encoding, false, 4096, true))
        {
          while (streamReader.Peek() != -1)
          {
            if (streamReader.ReadLine().Contains(boundary))
            {
              flag = true;
              break;
            }
          }
        }
        body.Seek(0L, SeekOrigin.Begin);
      }
      return flag;
    }

    public override void Accept(IFormDataSetVisitor visitor) => visitor.File((FormDataSetEntry) this, this.FileName, this.ContentType, this._value);
  }
}
