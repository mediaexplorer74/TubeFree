// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlCharacterToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlCharacterToken : XmlToken
  {
    private readonly string _data;

    public XmlCharacterToken(TextPosition position)
      : this(position, string.Empty)
    {
    }

    public XmlCharacterToken(TextPosition position, string data)
      : base(XmlTokenType.Character, position)
    {
      this._data = data;
    }

    public override bool IsIgnorable => this._data.StripLeadingTrailingSpaces().Length == 0;

    public string Data => this._data;
  }
}
