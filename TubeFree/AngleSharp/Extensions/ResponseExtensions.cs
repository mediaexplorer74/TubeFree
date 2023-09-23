// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ResponseExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Network;

namespace AngleSharp.Extensions
{
  public static class ResponseExtensions
  {
    public static MimeType GetContentType(this IResponse response)
    {
      string path = response.Address.Path;
      int startIndex = path.LastIndexOf('.');
      string defaultValue = MimeTypeNames.FromExtension(startIndex >= 0 ? path.Substring(startIndex) : ".a");
      return new MimeType(response.Headers.GetOrDefault<string, string>(HeaderNames.ContentType, defaultValue));
    }

    public static MimeType GetContentType(this IResponse response, string defaultType)
    {
      string path = response.Address.Path;
      int startIndex = path.LastIndexOf('.');
      if (startIndex >= 0)
        defaultType = MimeTypeNames.FromExtension(path.Substring(startIndex));
      return new MimeType(response.Headers.GetOrDefault<string, string>(HeaderNames.ContentType, defaultType));
    }
  }
}
