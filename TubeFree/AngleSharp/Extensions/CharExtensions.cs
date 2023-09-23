// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.CharExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Runtime.CompilerServices;

namespace AngleSharp.Extensions
{
  internal static class CharExtensions
  {
    public static int FromHex(this char c) => !c.IsDigit() ? (int) c - (c.IsLowercaseAscii() ? 87 : 55) : (int) c - 48;

    public static string ToHex(this byte num)
    {
      char[] chArray = new char[2];
      int num1 = (int) num >> 4;
      chArray[0] = (char) (num1 + (num1 < 10 ? 48 : 55));
      int num2 = (int) num - 16 * num1;
      chArray[1] = (char) (num2 + (num2 < 10 ? 48 : 55));
      return new string(chArray);
    }

    public static string ToHex(this char character) => ((int) character).ToString("x");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInRange(this char c, int lower, int upper) => (int) c >= lower && (int) c <= upper;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNormalQueryCharacter(this char c) => c.IsInRange(33, 126) && c != '"' && c != '`' && c != '#' && c != '<' && c != '>';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNormalPathCharacter(this char c) => c.IsInRange(32, 126) && c != '"' && c != '`' && c != '#' && c != '<' && c != '>' && c != ' ' && c != '?';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUppercaseAscii(this char c) => c >= 'A' && c <= 'Z';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowercaseAscii(this char c) => c >= 'a' && c <= 'z';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAlphanumericAscii(this char c) => c.IsDigit() || c.IsUppercaseAscii() || c.IsLowercaseAscii();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsHex(this char c)
    {
      if (c.IsDigit() || c >= 'A' && c <= 'F')
        return true;
      return c >= 'a' && c <= 'f';
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNonAscii(this char c) => c != char.MaxValue && c >= '\u0080';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNonPrintable(this char c)
    {
      if (c >= char.MinValue && c <= '\b' || c >= '\u000E' && c <= '\u001F')
        return true;
      return c >= '\u007F' && c <= '\u009F';
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c) => c.IsUppercaseAscii() || c.IsLowercaseAscii();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsName(this char c) => c.IsNonAscii() || c.IsLetter() || c == '_' || c == '-' || c.IsDigit();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNameStart(this char c) => c.IsNonAscii() || c.IsUppercaseAscii() || c.IsLowercaseAscii() || c == '_';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLineBreak(this char c) => c == '\n' || c == '\r';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSpaceCharacter(this char c) => c == ' ' || c == '\t' || c == '\n' || c == '\r' || c == '\f';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpaceCharacter(this char c) => c.IsInRange(9, 13) || c == ' ' || c == '\u0085' || c == ' ' || c == ' ' || c == '\u180E' || c.IsInRange(8192, 8202) || c == '\u2028' || c == '\u2029' || c == ' ' || c == ' ' || c == '　';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c) => c >= '0' && c <= '9';

    public static bool IsUrlCodePoint(this char c) => c.IsAlphanumericAscii() || c == '!' || c == '$' || c == '&' || c == '\'' || c == '(' || c == ')' || c == '*' || c == '+' || c == '-' || c == ',' || c == '.' || c == '/' || c == ':' || c == ';' || c == '=' || c == '?' || c == '@' || c == '_' || c == '~' || c.IsInRange(160, 55295) || c.IsInRange(57344, 64975) || c.IsInRange(65008, 65533) || c.IsInRange(65536, 131069) || c.IsInRange(131072, 196605) || c.IsInRange(196608, 262141) || c.IsInRange(262144, 327677) || c.IsInRange(327680, 393213) || c.IsInRange(393216, 458749) || c.IsInRange(458752, 524285) || c.IsInRange(524288, 589821) || c.IsInRange(589824, 655357) || c.IsInRange(655360, 720893) || c.IsInRange(720896, 786429) || c.IsInRange(786432, 851965) || c.IsInRange(851968, 917501) || c.IsInRange(917504, 983037) || c.IsInRange(983040, 1048573) || c.IsInRange(1048576, 1114109);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInvalid(this int c)
    {
      if (c == 0 || c > 1114111)
        return true;
      return c > 55296 && c < 57343;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOneOf(this char c, char a, char b) => (int) a == (int) c || (int) b == (int) c;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOneOf(this char c, char o1, char o2, char o3) => (int) c == (int) o1 || (int) c == (int) o2 || (int) c == (int) o3;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOneOf(this char c, char o1, char o2, char o3, char o4) => (int) c == (int) o1 || (int) c == (int) o2 || (int) c == (int) o3 || (int) c == (int) o4;
  }
}
