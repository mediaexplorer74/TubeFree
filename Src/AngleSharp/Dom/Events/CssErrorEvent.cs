// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.CssErrorEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Parser.Css;

namespace AngleSharp.Dom.Events
{
  public class CssErrorEvent : Event
  {
    private CssParseError _code;
    private TextPosition _position;

    public CssErrorEvent(CssParseError code, TextPosition position)
      : base(EventNames.ParseError)
    {
      this._code = code;
      this._position = position;
    }

    public TextPosition Position => this._position;

    public int Code => this._code.GetCode();

    public string Message => this._code.GetMessage<CssParseError>();
  }
}
