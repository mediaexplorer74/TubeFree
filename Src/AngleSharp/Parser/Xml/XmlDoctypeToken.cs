// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlDoctypeToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlDoctypeToken : XmlToken
  {
    private string _name;
    private string _publicIdentifier;
    private string _systemIdentifier;

    public XmlDoctypeToken(TextPosition position)
      : base(XmlTokenType.Doctype, position)
    {
      this._name = (string) null;
      this._publicIdentifier = (string) null;
      this._systemIdentifier = (string) null;
    }

    public bool IsNameMissing => this._name == null;

    public bool IsPublicIdentifierMissing => this._publicIdentifier == null;

    public bool IsSystemIdentifierMissing => this._systemIdentifier == null;

    public string Name
    {
      get => this._name ?? string.Empty;
      set => this._name = value;
    }

    public string PublicIdentifier
    {
      get => this._publicIdentifier ?? string.Empty;
      set => this._publicIdentifier = value;
    }

    public string SystemIdentifier
    {
      get => this._systemIdentifier ?? string.Empty;
      set => this._systemIdentifier = value;
    }

    public string InternalSubset { get; set; }
  }
}
