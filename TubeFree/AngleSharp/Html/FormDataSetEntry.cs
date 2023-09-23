// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.FormDataSetEntry
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Text;

namespace AngleSharp.Html
{
  public abstract class FormDataSetEntry
  {
    private readonly string _name;
    private readonly string _type;

    public FormDataSetEntry(string name, string type)
    {
      this._name = name;
      this._type = type;
    }

    public bool HasName => this._name != null;

    public string Name => this._name ?? string.Empty;

    public string Type => this._type ?? InputTypeNames.Text;

    public abstract void Accept(IFormDataSetVisitor visitor);

    public abstract bool Contains(string boundary, Encoding encoding);
  }
}
