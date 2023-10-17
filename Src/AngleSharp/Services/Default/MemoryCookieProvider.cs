// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.MemoryCookieProvider
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Globalization;
using System.Net;

namespace AngleSharp.Services.Default
{
  public class MemoryCookieProvider : ICookieProvider
  {
    private readonly CookieContainer _container;

    public MemoryCookieProvider() => this._container = new CookieContainer();

    public CookieContainer Container => this._container;

    public string GetCookie(string origin) => this._container.GetCookieHeader(new Uri(origin));

    public void SetCookie(string origin, string value)
    {
      string cookieHeader = MemoryCookieProvider.Sanatize(value);
      this._container.SetCookies(new Uri(origin), cookieHeader);
    }

    private static string Sanatize(string cookie)
    {
      string str1 = "expires=";
      int startIndex1;
      for (int startIndex2 = 0; startIndex2 < cookie.Length; startIndex2 = startIndex1)
      {
        int num1 = cookie.IndexOf(str1, startIndex2, StringComparison.OrdinalIgnoreCase);
        if (num1 != -1)
        {
          int num2 = num1 + str1.Length;
          startIndex1 = cookie.IndexOfAny(new char[2]
          {
            ';',
            ','
          }, num2 + 4);
          if (startIndex1 == -1)
            startIndex1 = cookie.Length;
          string str2 = cookie.Substring(0, num2);
          string str3 = cookie.Substring(num2, startIndex1 - num2);
          string str4 = cookie.Substring(startIndex1);
          DateTime result = DateTime.Now;
          if (DateTime.TryParse(str3.Replace("UTC", "GMT"), out result))
          {
            string str5 = result.ToString("ddd, dd MMM yyyy HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture);
            cookie = string.Format("{0}{1}{2}", (object) str2, (object) str5, (object) str4);
          }
        }
        else
          break;
      }
      return cookie;
    }
  }
}
