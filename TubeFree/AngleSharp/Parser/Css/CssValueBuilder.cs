// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssValueBuilder
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Extensions;
using System.Collections.Generic;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssValueBuilder
  {
    private readonly List<CssToken> _values;
    private CssToken _buffer;
    private bool _valid;
    private bool _important;
    private int _open;

    public CssValueBuilder()
    {
      this._values = new List<CssToken>();
      this.Reset();
    }

    public bool IsReady => this._open == 0 && this._values.Count > 0;

    public bool IsValid => this._valid && this.IsReady;

    public bool IsImportant => this._important;

    public CssValue GetResult() => new CssValue((IEnumerable<CssToken>) this._values);

    public void Apply(CssToken token)
    {
      switch (token.Type)
      {
        case CssTokenType.String:
        case CssTokenType.Url:
        case CssTokenType.Color:
        case CssTokenType.Number:
        case CssTokenType.Percentage:
        case CssTokenType.Dimension:
        case CssTokenType.Delim:
        case CssTokenType.Comma:
          this.Add(token);
          break;
        case CssTokenType.Comment:
          break;
        case CssTokenType.Ident:
          this._important = this.CheckImportant(token);
          break;
        case CssTokenType.Function:
          this.Add(token);
          break;
        case CssTokenType.RoundBracketOpen:
          ++this._open;
          this.Add(token);
          break;
        case CssTokenType.RoundBracketClose:
          --this._open;
          this.Add(token);
          break;
        case CssTokenType.Whitespace:
          if (this._values.Count <= 0 || CssValueBuilder.IsSlash(this._values[this._values.Count - 1]))
            break;
          this._buffer = token;
          break;
        default:
          this._valid = false;
          this.Add(token);
          break;
      }
    }

    public CssValueBuilder Reset()
    {
      this._open = 0;
      this._valid = true;
      this._buffer = (CssToken) null;
      this._important = false;
      this._values.Clear();
      return this;
    }

    private bool CheckImportant(CssToken token)
    {
      if (this._values.Count != 0 && token.Data == Keywords.Important && CssValueBuilder.IsExclamationMark(this._values[this._values.Count - 1]))
      {
        do
        {
          this._values.RemoveAt(this._values.Count - 1);
        }
        while (this._values.Count > 0 && this._values[this._values.Count - 1].Type == CssTokenType.Whitespace);
        return true;
      }
      this.Add(token);
      return this._important;
    }

    private void Add(CssToken token)
    {
      if (this._buffer != null && !CssValueBuilder.IsCommaOrSlash(token))
        this._values.Add(this._buffer);
      else if (this._values.Count != 0 && !CssValueBuilder.IsComma(token) && CssValueBuilder.IsComma(this._values[this._values.Count - 1]))
        this._values.Add(CssToken.Whitespace);
      this._buffer = (CssToken) null;
      if (this._important)
        this._valid = false;
      this._values.Add(token);
    }

    private static bool IsCommaOrSlash(CssToken token) => CssValueBuilder.IsComma(token) || CssValueBuilder.IsSlash(token);

    private static bool IsComma(CssToken token) => token.Type == CssTokenType.Comma;

    private static bool IsExclamationMark(CssToken token) => token.Type == CssTokenType.Delim && token.Data.Has('!');

    private static bool IsSlash(CssToken token) => token.Type == CssTokenType.Delim && token.Data.Has('/');
  }
}
