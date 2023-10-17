// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.SourceSet
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css.Values;
using AngleSharp.Dom;
using AngleSharp.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AngleSharp.Html
{
  public sealed class SourceSet
  {
    private static readonly string FullWidth = "100vw";
    private static readonly Regex SizeParser = SourceSet.CreateRegex();
    private readonly IDocument _document;

    private static Regex CreateRegex()
    {
      string pattern = "(\\([^)]+\\))?\\s*(.+)";
      try
      {
        return new Regex(pattern, RegexOptions.CultureInvariant | RegexOptions.ECMAScript);
      }
      catch
      {
        return new Regex(pattern, RegexOptions.ECMAScript);
      }
    }

    public SourceSet(IDocument document) => this._document = document;

    public static IEnumerable<SourceSet.ImageCandidate> Parse(string srcset)
    {
      string[] sources = srcset.Trim().SplitSpaces();
      for (int i = 0; i < sources.Length; ++i)
      {
        string str1 = sources[i];
        string str2 = (string) null;
        if (str1.Length != 0)
        {
          if (str1[str1.Length - 1] == ',')
          {
            str1 = str1.Remove(str1.Length - 1);
            str2 = string.Empty;
          }
          else if (++i < sources.Length)
          {
            str2 = sources[i];
            int length = str2.IndexOf(',');
            if (length != -1)
            {
              sources[i] = str2.Substring(length + 1);
              str2 = str2.Substring(0, length);
              --i;
            }
          }
          yield return new SourceSet.ImageCandidate()
          {
            Url = str1,
            Descriptor = str2
          };
        }
      }
    }

    private static SourceSet.MediaSize ParseSize(string sourceSizeStr)
    {
      Match match = SourceSet.SizeParser.Match(sourceSizeStr);
      return new SourceSet.MediaSize()
      {
        Media = !match.Success || !match.Groups[1].Success ? string.Empty : match.Groups[1].Value,
        Length = !match.Success || !match.Groups[2].Success ? string.Empty : match.Groups[2].Value
      };
    }

    private double ParseDescriptor(string descriptor, string sizesattr = null)
    {
      string sourceSizes = sizesattr ?? SourceSet.FullWidth;
      string str1 = descriptor.Trim();
      double widthFromSourceSize = this.GetWidthFromSourceSize(sourceSizes);
      double descriptor1 = 1.0;
      char[] chArray = new char[1]{ ' ' };
      string[] strArray = str1.Split(chArray);
      for (int index = strArray.Length - 1; index >= 0; --index)
      {
        string str2 = strArray[index];
        char ch = str2.Length > 0 ? str2[str2.Length - 1] : char.MinValue;
        if ((ch == 'h' || ch == 'w') && str2.Length > 2 && str2[str2.Length] == 'v')
          descriptor1 = (double) str2.Substring(0, str2.Length - 2).ToInteger(0) / widthFromSourceSize;
        else if (ch == 'x' && str2.Length > 0)
          descriptor1 = str2.Substring(0, str2.Length - 1).ToDouble(1.0);
      }
      return descriptor1;
    }

    private double GetWidthFromLength(string length)
    {
      Length result = new Length();
      Length.TryParse(length, out result);
      return 0.0;
    }

    private double GetWidthFromSourceSize(string sourceSizes)
    {
      string str = sourceSizes.Trim();
      char[] chArray = new char[1]{ ',' };
      foreach (string sourceSizeStr in str.Split(chArray))
      {
        SourceSet.MediaSize size = SourceSet.ParseSize(sourceSizeStr);
        string length = size.Length;
        string media = size.Media;
        if (!string.IsNullOrEmpty(length) && (string.IsNullOrEmpty(media) || this._document.DefaultView.MatchMedia(media).IsMatched))
          return this.GetWidthFromLength(length);
      }
      return this.GetWidthFromLength(SourceSet.FullWidth);
    }

    public IEnumerable<string> GetCandidates(string srcset, string sizes)
    {
      if (!string.IsNullOrEmpty(srcset))
      {
        foreach (SourceSet.ImageCandidate imageCandidate in SourceSet.Parse(srcset))
          yield return imageCandidate.Url;
      }
    }

    private sealed class MediaSize
    {
      public string Media { get; set; }

      public string Length { get; set; }
    }

    public sealed class ImageCandidate
    {
      public string Url { get; set; }

      public string Descriptor { get; set; }
    }
  }
}
