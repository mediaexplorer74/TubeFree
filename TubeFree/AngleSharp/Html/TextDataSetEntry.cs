// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.TextDataSetEntry
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Text;

namespace AngleSharp.Html
{
  internal sealed class TextDataSetEntry : FormDataSetEntry
  {
    private readonly string _value;

    public TextDataSetEntry(string name, string value, string type)
      : base(name, type)
    {
      this._value = value;
    }

    public override bool Contains(string boundary, Encoding encoding) => this._value != null && this._value.Contains(boundary);

    public override void Accept(IFormDataSetVisitor visitor) => visitor.Text((FormDataSetEntry) this, this._value);
  }
}
