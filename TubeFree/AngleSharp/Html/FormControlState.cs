// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.FormControlState
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Html
{
  internal sealed class FormControlState
  {
    private readonly string _name;
    private readonly string _type;
    private readonly string _value;

    public FormControlState(string name, string type, string value)
    {
      this._name = name;
      this._type = type;
      this._value = value;
    }

    public string Name => this._name;

    public string Value => this._value;

    public string Type => this._type;
  }
}
