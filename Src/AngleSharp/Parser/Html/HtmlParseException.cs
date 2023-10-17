// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlParseException
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Parser.Html
{
  public class HtmlParseException : Exception
  {
    public HtmlParseException(int code, string message, TextPosition position)
      : base(message)
    {
      this.Code = code;
      this.Position = position;
    }

    public TextPosition Position { get; private set; }

    public int Code { get; private set; }
  }
}
