// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.LocaleEncodingProvider
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngleSharp.Services.Default
{
  public class LocaleEncodingProvider : IEncodingProvider
  {
    private static readonly Dictionary<string, Encoding> suggestions = new Dictionary<string, Encoding>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        "ar",
        TextEncoding.Utf8
      },
      {
        "cy",
        TextEncoding.Utf8
      },
      {
        "fa",
        TextEncoding.Utf8
      },
      {
        "hr",
        TextEncoding.Utf8
      },
      {
        "kk",
        TextEncoding.Utf8
      },
      {
        "mk",
        TextEncoding.Utf8
      },
      {
        "or",
        TextEncoding.Utf8
      },
      {
        "ro",
        TextEncoding.Utf8
      },
      {
        "sr",
        TextEncoding.Utf8
      },
      {
        "vi",
        TextEncoding.Utf8
      },
      {
        "be",
        TextEncoding.Latin5
      },
      {
        "bg",
        TextEncoding.Windows1251
      },
      {
        "ru",
        TextEncoding.Windows1251
      },
      {
        "uk",
        TextEncoding.Windows1251
      },
      {
        "cs",
        TextEncoding.Latin2
      },
      {
        "hu",
        TextEncoding.Latin2
      },
      {
        "pl",
        TextEncoding.Latin2
      },
      {
        "sl",
        TextEncoding.Latin2
      },
      {
        "tr",
        TextEncoding.Windows1254
      },
      {
        "ku",
        TextEncoding.Windows1254
      },
      {
        "he",
        TextEncoding.Windows1255
      },
      {
        "lv",
        TextEncoding.Latin13
      },
      {
        "ja",
        TextEncoding.Utf8
      },
      {
        "ko",
        TextEncoding.Korean
      },
      {
        "lt",
        TextEncoding.Windows1257
      },
      {
        "sk",
        TextEncoding.Windows1250
      },
      {
        "th",
        TextEncoding.Windows874
      }
    };

    public virtual Encoding Suggest(string locale)
    {
      if (!string.IsNullOrEmpty(locale) && locale.Length > 1)
      {
        string key = locale.Substring(0, 2);
        Encoding encoding = (Encoding) null;
        if (LocaleEncodingProvider.suggestions.TryGetValue(key, out encoding))
          return encoding;
        if (locale.Isi("zh-cn"))
          return TextEncoding.Gb18030;
        if (locale.Isi("zh-tw"))
          return TextEncoding.Big5;
      }
      return TextEncoding.Windows1252;
    }
  }
}
