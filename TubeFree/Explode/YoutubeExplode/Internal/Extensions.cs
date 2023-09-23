// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Extensions
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YoutubeExplode.Internal
{
  internal static class Extensions
  {
    public static bool IsBlank(this string str) => string.IsNullOrWhiteSpace(str);

    public static bool IsNotBlank(this string str) => !string.IsNullOrWhiteSpace(str);

    public static string SubstringUntil(this string str, string sub, StringComparison comparison = StringComparison.Ordinal)
    {
      int length = str.IndexOf(sub, comparison);
      return length >= 0 ? str.Substring(0, length) : str;
    }

    public static string SubstringAfter(this string str, string sub, StringComparison comparison = StringComparison.Ordinal)
    {
      int num = str.IndexOf(sub, comparison);
      return num >= 0 ? str.Substring(num + sub.Length, str.Length - num - sub.Length) : string.Empty;
    }

    public static string StripNonDigit(this string str) => Regex.Replace(str, "\\D", "");

    public static double ParseDouble(this string str)
    {
      NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
      return double.Parse(str, NumberStyles.Float | NumberStyles.AllowThousands, (IFormatProvider) invariantInfo);
    }

    public static double ParseDoubleOrDefault(this string str, double defaultValue = 0.0)
    {
      NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
      double result;
      return !double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, (IFormatProvider) invariantInfo, out result) ? defaultValue : result;
    }

    public static int ParseInt(this string str)
    {
      NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
      return int.Parse(str, NumberStyles.AllowThousands, (IFormatProvider) invariantInfo);
    }

    public static int ParseIntOrDefault(this string str, int defaultValue = 0)
    {
      NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
      int result;
      return !int.TryParse(str, NumberStyles.AllowThousands, (IFormatProvider) invariantInfo, out result) ? defaultValue : result;
    }

    public static long ParseLong(this string str)
    {
      NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
      return long.Parse(str, NumberStyles.AllowThousands, (IFormatProvider) invariantInfo);
    }

    public static long ParseLongOrDefault(this string str, long defaultValue = 0)
    {
      NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
      long result;
      return !long.TryParse(str, NumberStyles.AllowThousands, (IFormatProvider) invariantInfo, out result) ? defaultValue : result;
    }

    public static DateTimeOffset ParseDateTimeOffset(this string str) => DateTimeOffset.Parse(str, (IFormatProvider) DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeUniversal);

    public static DateTimeOffset ParseDateTimeOffset(this string str, string format) => DateTimeOffset.ParseExact(str, format, (IFormatProvider) DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeUniversal);

    public static string Reverse(this string str)
    {
      StringBuilder stringBuilder = new StringBuilder(str.Length);
      for (int index = str.Length - 1; index >= 0; --index)
        stringBuilder.Append(str[index]);
      return stringBuilder.ToString();
    }

    public static string UrlEncode(this string url) => WebUtility.UrlEncode(url);

    public static string UrlDecode(this string url) => WebUtility.UrlDecode(url);

    public static string HtmlEncode(this string url) => WebUtility.HtmlEncode(url);

    public static string HtmlDecode(this string url) => WebUtility.HtmlDecode(url);

    public static string JoinToString<T>(this IEnumerable<T> enumerable, string separator) => string.Join<T>(separator, enumerable);

    public static string[] Split(this string input, params string[] separators) => input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable) => enumerable ?? Enumerable.Empty<T>();

    public static IEnumerable<TSource> Distinct<TSource, TKey>(
      this IEnumerable<TSource> enumerable,
      Func<TSource, TKey> selector)
    {
      HashSet<TKey> existing = new HashSet<TKey>();
      foreach (TSource source in enumerable)
      {
        if (existing.Add(selector(source)))
          yield return source;
      }
    }

    public static TValue GetOrDefault<TKey, TValue>(
      this IReadOnlyDictionary<TKey, TValue> dic,
      TKey key,
      TValue defaultValue = null)
    {
      TValue obj;
      return !dic.TryGetValue(key, out obj) ? defaultValue : obj;
    }

    public static XElement StripNamespaces(this XElement element)
    {
      XElement xelement1 = new XElement(element);
      foreach (XElement xelement2 in xelement1.DescendantsAndSelf())
      {
        xelement2.Name = XNamespace.None.GetName(xelement2.Name.LocalName);
        IEnumerable<XAttribute> content = xelement2.Attributes().Where<XAttribute>((Func<XAttribute, bool>) (a => !a.IsNamespaceDeclaration)).Where<XAttribute>((Func<XAttribute, bool>) (a => a.Name.Namespace != XNamespace.Xml && a.Name.Namespace != XNamespace.Xmlns)).Select<XAttribute, XAttribute>((Func<XAttribute, XAttribute>) (a => new XAttribute(XNamespace.None.GetName(a.Name.LocalName), (object) a.Value)));
        xelement2.ReplaceAttributes((object) content);
      }
      return xelement1;
    }

    public static async Task CopyToAsync(
      this Stream source,
      Stream destination,
      IProgress<double> progress = null,
      CancellationToken cancellationToken = default (CancellationToken),
      int bufferSize = 81920)
    {
      byte[] buffer = new byte[bufferSize];
      long totalBytesCopied = 0;
      int bytesCopied;
      do
      {
        bytesCopied = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
        await destination.WriteAsync(buffer, 0, bytesCopied, cancellationToken).ConfigureAwait(false);
        totalBytesCopied += (long) bytesCopied;
        progress?.Report(1.0 * (double) totalBytesCopied / (double) source.Length);
      }
      while (bytesCopied > 0);
    }
  }
}
