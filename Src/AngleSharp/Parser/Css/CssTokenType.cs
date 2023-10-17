// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssTokenType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Parser.Css
{
  internal enum CssTokenType : byte
  {
    String,
    Url,
    Color,
    Hash,
    Comment,
    AtKeyword,
    Ident,
    Function,
    Number,
    Percentage,
    Dimension,
    Range,
    Cdo,
    Cdc,
    Column,
    Delim,
    Match,
    RoundBracketOpen,
    RoundBracketClose,
    CurlyBracketOpen,
    CurlyBracketClose,
    SquareBracketOpen,
    SquareBracketClose,
    Colon,
    Comma,
    Semicolon,
    Whitespace,
    EndOfFile,
  }
}
