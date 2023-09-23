// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssParseError
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Parser.Css
{
  public enum CssParseError : byte
  {
    [DomDescription("Unexpected end of the given file.")] EOF = 0,
    [DomDescription("The provided character is not valid at the given position.")] InvalidCharacter = 16, // 0x10
    [DomDescription("No block can start at the current position.")] InvalidBlockStart = 17, // 0x11
    [DomDescription("The given token is not valid at the current position.")] InvalidToken = 18, // 0x12
    [DomDescription("An expected colon is missing.")] ColonMissing = 19, // 0x13
    [DomDescription("An expected identifier could not be found.")] IdentExpected = 20, // 0x14
    [DomDescription("An given input has not been expected.")] InputUnexpected = 21, // 0x15
    [DomDescription("This position does not support a linebreak (LF, FF).")] LineBreakUnexpected = 22, // 0x16
    [DomDescription("The name of the @-rule is unknown.")] UnknownAtRule = 32, // 0x20
    [DomDescription("The provided selector is invalid.")] InvalidSelector = 48, // 0x30
    [DomDescription("The provided keyframe selector is invalid.")] InvalidKeyframe = 49, // 0x31
    [DomDescription("The value of the declaration could not be found.")] ValueMissing = 64, // 0x40
    [DomDescription("The value is invalid and cannot be used.")] InvalidValue = 65, // 0x41
    [DomDescription("The name of the declaration is unknown.")] UnknownDeclarationName = 80, // 0x50
  }
}
