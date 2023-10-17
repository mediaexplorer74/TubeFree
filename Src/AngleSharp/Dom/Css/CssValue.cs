// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssValue
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssValue : CssNode, IEnumerable<CssToken>, IEnumerable
  {
    private readonly List<CssToken> _tokens;
    public static CssValue Initial = CssValue.FromString(Keywords.Initial);
    public static CssValue Empty = new CssValue(Enumerable.Empty<CssToken>());

    private CssValue(CssToken token) => this._tokens = new List<CssToken>()
    {
      token
    };

    public CssValue(IEnumerable<CssToken> tokens) => this._tokens = new List<CssToken>(tokens);

    public static CssValue FromString(string text) => new CssValue(new CssToken(CssTokenType.Ident, text, TextPosition.Empty));

    public CssToken this[int index] => this._tokens[index];

    public int Count => this._tokens.Count;

    public string CssText => this.ToCss();

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(this._tokens.ToText());

    public IEnumerator<CssToken> GetEnumerator() => (IEnumerator<CssToken>) this._tokens.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
