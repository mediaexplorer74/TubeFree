// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlDeclarationToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlDeclarationToken : XmlToken
  {
    private string _version;
    private string _encoding;
    private bool _standalone;

    public XmlDeclarationToken(TextPosition position)
      : base(XmlTokenType.Declaration, position)
    {
      this._version = string.Empty;
      this._encoding = (string) null;
      this._standalone = false;
    }

    public string Version
    {
      get => this._version;
      set => this._version = value;
    }

    public bool IsEncodingMissing => this._encoding == null;

    public string Encoding
    {
      get => this._encoding ?? string.Empty;
      set => this._encoding = value;
    }

    public bool Standalone
    {
      get => this._standalone;
      set => this._standalone = value;
    }
  }
}
