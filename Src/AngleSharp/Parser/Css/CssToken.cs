// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Css
{
  internal class CssToken
  {
    private readonly CssTokenType _type;
    private readonly string _data;
    private readonly TextPosition _position;
    public static readonly CssToken Whitespace = new CssToken(CssTokenType.Whitespace, " ", TextPosition.Empty);
    public static readonly CssToken Comma = new CssToken(CssTokenType.Comma, ",", TextPosition.Empty);

    public CssToken(CssTokenType type, string data, TextPosition position)
    {
      this._type = type;
      this._data = data;
      this._position = position;
    }

    public TextPosition Position => this._position;

    public CssTokenType Type => this._type;

    public string Data => this._data;

    public virtual string ToValue() => this._data;
  }
}
