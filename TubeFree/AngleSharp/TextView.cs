// Decompiled with JetBrains decompiler
// Type: AngleSharp.TextView
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp
{
  public class TextView
  {
    private readonly TextRange _range;
    private readonly TextSource _source;

    internal TextView(TextRange range, TextSource source)
    {
      this._range = range;
      this._source = source;
    }

    public TextRange Range => this._range;

    public string Text
    {
      get
      {
        int startIndex = Math.Max(this._range.Start.Position - 1, 0);
        TextPosition textPosition = this._range.End;
        int num = textPosition.Position + 1;
        textPosition = this._range.Start;
        int position = textPosition.Position;
        int length = num - position;
        string text = this._source.Text;
        if (startIndex + length > text.Length)
          length = text.Length - startIndex;
        return text.Substring(startIndex, length);
      }
    }
  }
}
