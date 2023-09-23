// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.RegexpFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using System.Text.RegularExpressions;

namespace AngleSharp.Dom.Css
{
  internal sealed class RegexpFunction : DocumentFunction
  {
    private readonly Regex _regex;

    public RegexpFunction(string url)
      : base(FunctionNames.Regexp, url)
    {
      this._regex = new Regex(url, RegexOptions.CultureInvariant | RegexOptions.ECMAScript);
    }

    public override bool Matches(Url url) => this._regex.IsMatch(url.Href);
  }
}
