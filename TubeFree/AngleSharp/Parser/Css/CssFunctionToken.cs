// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssFunctionToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssFunctionToken : CssToken, IEnumerable<CssToken>, IEnumerable
  {
    private readonly List<CssToken> _arguments;

    public CssFunctionToken(string data, TextPosition position)
      : base(CssTokenType.Function, data, position)
    {
      this._arguments = new List<CssToken>();
    }

    public IEnumerable<CssToken> ArgumentTokens
    {
      get
      {
        int index = this._arguments.Count - 1;
        if (index >= 0 && this._arguments[index].Type == CssTokenType.RoundBracketClose)
          --index;
        return this._arguments.Take<CssToken>(1 + index);
      }
    }

    public void AddArgumentToken(CssToken token) => this._arguments.Add(token);

    public IEnumerator<CssToken> GetEnumerator() => (IEnumerator<CssToken>) this._arguments.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public override string ToValue() => this.Data + "(" + this._arguments.ToText();
  }
}
