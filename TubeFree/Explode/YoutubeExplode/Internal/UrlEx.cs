// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.UrlEx
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YoutubeExplode.Internal
{
  internal static class UrlEx
  {
    public static string SetQueryParameter(string url, string key, string value)
    {
      value = value ?? string.Empty;
      Match match = Regex.Match(url, string.Format("[?&]({0}=?.*?)(?:&|/|$)", new object[1]
      {
        (object) Regex.Escape(key)
      }));
      if (match.Success)
      {
        Group group = match.Groups[1];
        url = url.Remove(group.Index, group.Length);
        url = url.Insert(group.Index, string.Format("{0}={1}", new object[2]
        {
          (object) key,
          (object) value
        }));
        return url;
      }
      char ch = url.IndexOf('?') >= 0 ? '&' : '?';
      return url + ch.ToString() + key + "=" + value;
    }

    public static string SetRouteParameter(string url, string key, string value)
    {
      value = value ?? string.Empty;
      Match match = Regex.Match(url, string.Format("/({0}/?.*?)(?:/|$)", new object[1]
      {
        (object) Regex.Escape(key)
      }));
      if (match.Success)
      {
        Group group = match.Groups[1];
        url = url.Remove(group.Index, group.Length);
        url = url.Insert(group.Index, string.Format("{0}/{1}", new object[2]
        {
          (object) key,
          (object) value
        }));
        return url;
      }
      return url + "/" + key + "/" + value;
    }

    public static Dictionary<string, string> SplitQuery(string query)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      string input = query.TrimStart('?');
      string[] strArray = new string[1]{ "&" };
      foreach (string url in input.Split(strArray))
      {
        string str1 = url.UrlDecode();
        int length = str1.IndexOf('=');
        if (length > 0)
        {
          string key = str1.Substring(0, length);
          string str2 = length < str1.Length ? str1.Substring(length + 1) : string.Empty;
          dictionary[key] = str2;
        }
      }
      return dictionary;
    }
  }
}
