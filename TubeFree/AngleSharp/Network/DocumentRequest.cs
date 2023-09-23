// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.DocumentRequest
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Html;
using System;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Network
{
  public class DocumentRequest
  {
    public DocumentRequest(Url target)
    {
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      this.Headers = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      this.Target = target;
      this.Method = HttpMethod.Get;
      this.Body = Stream.Null;
    }

    public static DocumentRequest Get(Url target, INode source = null, string referer = null) => new DocumentRequest(target)
    {
      Method = HttpMethod.Get,
      Referer = referer,
      Source = source
    };

    public static DocumentRequest Post(
      Url target,
      Stream body,
      string type,
      INode source = null,
      string referer = null)
    {
      if (body == null)
        throw new ArgumentNullException(nameof (body));
      if (type == null)
        throw new ArgumentNullException(nameof (type));
      return new DocumentRequest(target)
      {
        Method = HttpMethod.Post,
        Body = body,
        MimeType = type,
        Referer = referer,
        Source = source
      };
    }

    public static DocumentRequest PostAsPlaintext(Url target, IDictionary<string, string> fields)
    {
      if (fields == null)
        throw new ArgumentNullException(nameof (fields));
      FormDataSet formDataSet = new FormDataSet();
      foreach (KeyValuePair<string, string> field in (IEnumerable<KeyValuePair<string, string>>) fields)
        formDataSet.Append(field.Key, field.Value, InputTypeNames.Text);
      return DocumentRequest.Post(target, formDataSet.AsPlaintext(), MimeTypeNames.Plain);
    }

    public static DocumentRequest PostAsUrlencoded(Url target, IDictionary<string, string> fields)
    {
      if (fields == null)
        throw new ArgumentNullException(nameof (fields));
      FormDataSet formDataSet = new FormDataSet();
      foreach (KeyValuePair<string, string> field in (IEnumerable<KeyValuePair<string, string>>) fields)
        formDataSet.Append(field.Key, field.Value, InputTypeNames.Text);
      return DocumentRequest.Post(target, formDataSet.AsUrlEncoded(), MimeTypeNames.UrlencodedForm);
    }

    public INode Source { get; set; }

    public Url Target { get; }

    public string Referer
    {
      get => this.GetHeader(HeaderNames.Referer);
      set => this.SetHeader(HeaderNames.Referer, value);
    }

    public HttpMethod Method { get; set; }

    public Stream Body { get; set; }

    public string MimeType
    {
      get => this.GetHeader(HeaderNames.ContentType);
      set => this.SetHeader(HeaderNames.ContentType, value);
    }

    public Dictionary<string, string> Headers { get; }

    private void SetHeader(string name, string value) => this.Headers[name] = value;

    private string GetHeader(string name)
    {
      string header = (string) null;
      this.Headers.TryGetValue(name, out header);
      return header;
    }
  }
}
