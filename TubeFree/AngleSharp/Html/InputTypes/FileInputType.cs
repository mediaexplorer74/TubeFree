// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.FileInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Html;
using AngleSharp.Dom.Io;

namespace AngleSharp.Html.InputTypes
{
  internal class FileInputType : BaseInputType
  {
    private readonly FileList _files;

    public FileInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
      this._files = new FileList();
    }

    public FileList Files => this._files;

    public override void ConstructDataSet(FormDataSet dataSet)
    {
      if (this._files.Length == 0)
        dataSet.Append(this.Input.Name, (IFile) null, this.Input.Type);
      foreach (IFile file in this._files)
        dataSet.Append(this.Input.Name, file, this.Input.Type);
    }
  }
}
