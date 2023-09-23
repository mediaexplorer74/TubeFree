// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.FormDataSetExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;
using AngleSharp.Network;
using System.IO;
using System.Text;

namespace AngleSharp.Extensions
{
  internal static class FormDataSetExtensions
  {
    public static Stream CreateBody(this FormDataSet formDataSet, string enctype, string charset)
    {
      Encoding encoding = TextEncoding.Resolve(charset);
      return formDataSet.CreateBody(enctype, encoding);
    }

    public static Stream CreateBody(
      this FormDataSet formDataSet,
      string enctype,
      Encoding encoding)
    {
      if (enctype.Isi(MimeTypeNames.UrlencodedForm))
        return formDataSet.AsUrlEncoded(encoding);
      if (enctype.Isi(MimeTypeNames.MultipartForm))
        return formDataSet.AsMultipart(encoding);
      if (enctype.Isi(MimeTypeNames.Plain))
        return formDataSet.AsPlaintext(encoding);
      return enctype.Isi(MimeTypeNames.ApplicationJson) ? formDataSet.AsJson() : Stream.Null;
    }
  }
}
