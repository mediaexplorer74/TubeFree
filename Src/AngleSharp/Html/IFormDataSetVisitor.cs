// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.IFormDataSetVisitor
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Io;

namespace AngleSharp.Html
{
  public interface IFormDataSetVisitor
  {
    void Text(FormDataSetEntry entry, string value);

    void File(FormDataSetEntry entry, string fileName, string contentType, IFile content);
  }
}
