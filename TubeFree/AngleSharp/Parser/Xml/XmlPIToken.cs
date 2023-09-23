// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlPIToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlPIToken : XmlToken
  {
    private string _target;
    private string _content;

    public XmlPIToken(TextPosition position)
      : base(XmlTokenType.ProcessingInstruction, position)
    {
      this._target = string.Empty;
      this._content = string.Empty;
    }

    public string Target
    {
      get => this._target;
      set => this._target = value;
    }

    public string Content
    {
      get => this._content;
      set => this._content = value;
    }
  }
}
