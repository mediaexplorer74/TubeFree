// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Xml
{
  internal abstract class XmlToken
  {
    private readonly XmlTokenType _type;
    private readonly TextPosition _position;

    public XmlToken(XmlTokenType type, TextPosition position)
    {
      this._type = type;
      this._position = position;
    }

    public virtual bool IsIgnorable => false;

    public XmlTokenType Type => this._type;

    public TextPosition Position => this._position;
  }
}
