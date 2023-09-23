// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssRangeToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System.Collections.Generic;
using System.Globalization;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssRangeToken : CssToken
  {
    private readonly string[] _range;
    private readonly string _start;
    private readonly string _end;

    public CssRangeToken(string range, TextPosition position)
      : base(CssTokenType.Range, range, position)
    {
      this._start = range.Replace('?', '0');
      this._end = range.Replace('?', 'F');
      this._range = this.GetRange();
    }

    public CssRangeToken(string start, string end, TextPosition position)
      : base(CssTokenType.Range, start + "-" + end, position)
    {
      this._start = start;
      this._end = end;
      this._range = this.GetRange();
    }

    public bool IsEmpty => this._range == null || this._range.Length == 0;

    public string Start => this._start;

    public string End => this._end;

    public string[] SelectedRange => this._range;

    private string[] GetRange()
    {
      int utf32 = int.Parse(this._start, NumberStyles.HexNumber);
      if (utf32 > 1114111)
        return (string[]) null;
      if (this._end != null)
      {
        List<string> stringList = new List<string>();
        int num = int.Parse(this._end, NumberStyles.HexNumber);
        if (num > 1114111)
          num = 1114111;
        for (; utf32 <= num; ++utf32)
          stringList.Add(utf32.ConvertFromUtf32());
        return stringList.ToArray();
      }
      return new string[1]{ utf32.ConvertFromUtf32() };
    }
  }
}
