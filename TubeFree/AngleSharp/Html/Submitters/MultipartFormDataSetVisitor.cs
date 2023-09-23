// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.Submitters.MultipartFormDataSetVisitor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Io;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AngleSharp.Html.Submitters
{
  internal sealed class MultipartFormDataSetVisitor : IFormSubmitter, IFormDataSetVisitor
  {
    private static readonly string DashDash = "--";
    private readonly Encoding _encoding;
    private readonly List<Action<StreamWriter>> _writers;
    private readonly string _boundary;

    public MultipartFormDataSetVisitor(Encoding encoding, string boundary)
    {
      this._encoding = encoding;
      this._writers = new List<Action<StreamWriter>>();
      this._boundary = boundary;
    }

    public void Text(FormDataSetEntry entry, string value)
    {
      if (!entry.HasName || value == null)
        return;
      this._writers.Add((Action<StreamWriter>) (stream =>
      {
        stream.WriteLine("Content-Disposition: form-data; name=\"{0}\"", (object) entry.Name.HtmlEncode(this._encoding));
        stream.WriteLine();
        stream.WriteLine(value.HtmlEncode(this._encoding));
      }));
    }

    public void File(FormDataSetEntry entry, string fileName, string contentType, IFile content)
    {
      if (!entry.HasName)
        return;
      this._writers.Add((Action<StreamWriter>) (stream =>
      {
        bool flag = content != null && content?.Name != null && content.Type != null && content.Body != null;
        stream.WriteLine("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", (object) entry.Name.HtmlEncode(this._encoding), (object) fileName.HtmlEncode(this._encoding));
        stream.WriteLine("Content-Type: {0}", (object) contentType);
        stream.WriteLine();
        if (flag)
        {
          stream.Flush();
          content.Body.CopyTo(stream.BaseStream);
        }
        stream.WriteLine();
      }));
    }

    public void Serialize(StreamWriter stream)
    {
      foreach (Action<StreamWriter> writer in this._writers)
      {
        stream.Write(MultipartFormDataSetVisitor.DashDash);
        stream.WriteLine(this._boundary);
        StreamWriter streamWriter = stream;
        writer(streamWriter);
      }
      stream.Write(MultipartFormDataSetVisitor.DashDash);
      stream.Write(this._boundary);
      stream.Write(MultipartFormDataSetVisitor.DashDash);
    }
  }
}
