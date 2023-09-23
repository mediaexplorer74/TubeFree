// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.XmlExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Extensions
{
  internal static class XmlExtensions
  {
    public static bool IsPubidChar(this char c) => c.IsAlphanumericAscii() || c == '-' || c == '\'' || c == '+' || c == ',' || c == '.' || c == '/' || c == ':' || c == '?' || c == '=' || c == '!' || c == '*' || c == '#' || c == '@' || c == '$' || c == '_' || c == '(' || c == ')' || c == ';' || c == '%' || c.IsSpaceCharacter();

    public static bool IsXmlNameStart(this char c) => c.IsLetter() || c == ':' || c == '_' || c.IsInRange(192, 214) || c.IsInRange(216, 246) || c.IsInRange(248, 767) || c.IsInRange(880, 893) || c.IsInRange(895, 8191) || c.IsInRange(8204, 8205) || c.IsInRange(8304, 8591) || c.IsInRange(11264, 12271) || c.IsInRange(12289, 55295) || c.IsInRange(63744, 64975) || c.IsInRange(65008, 65533) || c.IsInRange(65536, 983039);

    public static bool IsXmlName(this char c) => c.IsXmlNameStart() || c.IsDigit() || c == '-' || c == '.' || c == '·' || c.IsInRange(768, 879) || c.IsInRange(8255, 8256);

    public static bool IsXmlName(this string str)
    {
      if (str.Length <= 0 || !str[0].IsXmlNameStart())
        return false;
      for (int index = 1; index < str.Length; ++index)
      {
        if (!str[index].IsXmlName())
          return false;
      }
      return true;
    }

    public static bool IsQualifiedName(this string str)
    {
      int num1 = str.IndexOf(':');
      if (num1 == -1)
        return str.IsXmlName();
      if (num1 > 0 && str[0].IsXmlNameStart())
      {
        for (int index = 1; index < num1; ++index)
        {
          if (!str[index].IsXmlName())
            return false;
        }
        ++num1;
      }
      if (str.Length > num1)
      {
        string str1 = str;
        int index1 = num1;
        int num2 = index1 + 1;
        if (str1[index1].IsXmlNameStart())
        {
          for (int index2 = num2; index2 < str.Length; ++index2)
          {
            if (str[index2] == ':' || !str[index2].IsXmlName())
              return false;
          }
          return true;
        }
      }
      return false;
    }

    public static bool IsXmlChar(this char chr)
    {
      if (chr == '\t' || chr == '\n' || chr == '\r' || chr >= ' ' && chr <= '\uD7FF')
        return true;
      return chr >= '\uE000' && chr <= '�';
    }

    public static bool IsValidAsCharRef(this int chr)
    {
      if (chr == 9 || chr == 10 || chr == 13 || chr >= 32 && chr <= 55295 || chr >= 57344 && chr <= 65533)
        return true;
      return chr >= 65536 && chr <= 1114111;
    }
  }
}
