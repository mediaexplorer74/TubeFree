// Decompiled with JetBrains decompiler
// Type: AngleSharp.Symbols
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;

namespace AngleSharp
{
  internal static class Symbols
  {
    public const char EndOfFile = '\uFFFF';
    public const char Tilde = '~';
    public const char Pipe = '|';
    public const char Null = '\0';
    public const char Ampersand = '&';
    public const char Num = '#';
    public const char Dollar = '$';
    public const char Semicolon = ';';
    public const char Asterisk = '*';
    public const char Equality = '=';
    public const char Plus = '+';
    public const char Minus = '-';
    public const char Comma = ',';
    public const char Dot = '.';
    public const char Accent = '^';
    public const char At = '@';
    public const char LessThan = '<';
    public const char GreaterThan = '>';
    public const char SingleQuote = '\'';
    public const char DoubleQuote = '"';
    public const char CurvedQuote = '`';
    public const char QuestionMark = '?';
    public const char Tab = '\t';
    public const char LineFeed = '\n';
    public const char CarriageReturn = '\r';
    public const char FormFeed = '\f';
    public const char Space = ' ';
    public const char Solidus = '/';
    public const char NoBreakSpace = ' ';
    public const char ReverseSolidus = '\\';
    public const char Colon = ':';
    public const char ExclamationMark = '!';
    public const char Replacement = '�';
    public const char Underscore = '_';
    public const char RoundBracketOpen = '(';
    public const char RoundBracketClose = ')';
    public const char SquareBracketOpen = '[';
    public const char SquareBracketClose = ']';
    public const char CurlyBracketOpen = '{';
    public const char CurlyBracketClose = '}';
    public const char Percent = '%';
    public const int MaximumCodepoint = 1114111;
    public static Dictionary<char, char> Punycode = new Dictionary<char, char>()
    {
      {
        '。',
        '.'
      },
      {
        '．',
        '.'
      },
      {
        'Ｇ',
        'g'
      },
      {
        'ｏ',
        'o'
      },
      {
        'ｃ',
        'c'
      },
      {
        'Ｘ',
        'x'
      },
      {
        '０',
        '0'
      },
      {
        '１',
        '1'
      },
      {
        '２',
        '2'
      },
      {
        '５',
        '5'
      }
    };
    public static readonly string[] NewLines = new string[3]
    {
      "\r\n",
      "\r",
      "\n"
    };
  }
}
