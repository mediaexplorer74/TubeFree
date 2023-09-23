// Decompiled with JetBrains decompiler
// Type: AngleSharp.Foundation.Punycode
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Text;

namespace AngleSharp.Foundation
{
  internal static class Punycode
  {
    private const int PunycodeBase = 36;
    private const int Tmin = 1;
    private const int Tmax = 26;
    private static readonly string acePrefix = "xn--";
    private static readonly char[] possibleDots = new char[4]
    {
      '.',
      '。',
      '．',
      '｡'
    };

    public static string Encode(string text)
    {
      if (text.Length == 0)
        return text;
      StringBuilder stringBuilder = new StringBuilder(text.Length);
      int num1 = 0;
      int startIndex1 = 0;
      int startIndex2 = 0;
      while (num1 < text.Length)
      {
        num1 = text.IndexOfAny(Punycode.possibleDots, startIndex1);
        if (num1 < 0)
          num1 = text.Length;
        if (num1 != startIndex1)
        {
          stringBuilder.Append(Punycode.acePrefix);
          int num2 = 0;
          for (int index = startIndex1; index < num1; ++index)
          {
            if (text[index] < '\u0080')
            {
              stringBuilder.Append(Punycode.EncodeBasic(text[index]));
              ++num2;
            }
            else if (char.IsSurrogatePair(text, index))
              ++index;
          }
          int num3 = num2;
          if (num3 == num1 - startIndex1)
            stringBuilder.Remove(startIndex2, Punycode.acePrefix.Length);
          else if (text.Length - startIndex1 < Punycode.acePrefix.Length || !text.Substring(startIndex1, Punycode.acePrefix.Length).Equals(Punycode.acePrefix, StringComparison.OrdinalIgnoreCase))
          {
            int num4 = 0;
            if (num3 > 0)
              stringBuilder.Append('-');
            int num5 = 128;
            int num6 = 0;
            int num7 = 72;
            while (num2 < num1 - startIndex1)
            {
              int test = 134217727;
              int utf32_1;
              for (int index = startIndex1; index < num1; index += Punycode.IsSupplementary(utf32_1) ? 2 : 1)
              {
                utf32_1 = text.ConvertToUtf32(index);
                if (utf32_1 >= num5 && utf32_1 < test)
                  test = utf32_1;
              }
              int delta = num6 + (test - num5) * (num2 - num4 + 1);
              int num8 = test;
              int utf32_2;
              for (int index = startIndex1; index < num1; index += Punycode.IsSupplementary(utf32_2) ? 2 : 1)
              {
                utf32_2 = text.ConvertToUtf32(index);
                if (utf32_2 < num8)
                  ++delta;
                else if (utf32_2 == num8)
                {
                  int digit = delta;
                  int num9 = 36;
                  while (true)
                  {
                    int num10 = num9 <= num7 ? 1 : (num9 >= num7 + 26 ? 26 : num9 - num7);
                    if (digit >= num10)
                    {
                      stringBuilder.Append(Punycode.EncodeDigit(num10 + (digit - num10) % (36 - num10)));
                      digit = (digit - num10) / (36 - num10);
                      num9 += 36;
                    }
                    else
                      break;
                  }
                  stringBuilder.Append(Punycode.EncodeDigit(digit));
                  num7 = Punycode.AdaptChar(delta, num2 - num4 + 1, num2 == num3);
                  delta = 0;
                  ++num2;
                  if (Punycode.IsSupplementary(test))
                  {
                    ++num2;
                    ++num4;
                  }
                }
              }
              num6 = delta + 1;
              num5 = num8 + 1;
            }
          }
          else
            break;
          if (stringBuilder.Length - startIndex2 > 63)
            throw new ArgumentException();
          if (num1 != text.Length)
            stringBuilder.Append(Punycode.possibleDots[0]);
          startIndex1 = num1 + 1;
          startIndex2 = stringBuilder.Length;
        }
        else
          break;
      }
      int startIndex3 = (int) byte.MaxValue - (Punycode.IsDot(text[text.Length - 1]) ? 0 : 1);
      if (stringBuilder.Length > startIndex3)
        stringBuilder.Remove(startIndex3, stringBuilder.Length - startIndex3);
      return stringBuilder.ToString();
    }

    private static bool IsSupplementary(int test) => test >= 65536;

    private static bool IsDot(char c)
    {
      for (int index = 0; index < Punycode.possibleDots.Length; ++index)
      {
        if ((int) Punycode.possibleDots[index] == (int) c)
          return true;
      }
      return false;
    }

    private static char EncodeDigit(int digit) => digit > 25 ? (char) (digit + 22) : (char) (digit + 97);

    private static char EncodeBasic(char character)
    {
      if (char.IsUpper(character))
        character += ' ';
      return character;
    }

    private static int AdaptChar(int delta, int numPoints, bool firstTime)
    {
      delta = firstTime ? delta / 700 : delta / 2;
      delta += delta / numPoints;
      uint num = 0;
      while (delta > 455)
      {
        delta /= 35;
        num += 36U;
      }
      return (int) ((long) num + (long) (36 * delta / (delta + 38)));
    }
  }
}
