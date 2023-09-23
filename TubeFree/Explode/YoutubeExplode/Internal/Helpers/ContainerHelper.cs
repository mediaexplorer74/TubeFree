// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Helpers.ContainerHelper
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeExplode.Internal.Helpers
{
  internal static class ContainerHelper
  {
    public static Container ContainerFromString(string str)
    {
      if (str.Equals("mp4", StringComparison.OrdinalIgnoreCase))
        return Container.Mp4;
      if (str.Equals("webm", StringComparison.OrdinalIgnoreCase))
        return Container.WebM;
      if (str.Equals("3gpp", StringComparison.OrdinalIgnoreCase))
        return Container.Tgpp;
      throw new ArgumentOutOfRangeException(nameof (str), string.Format("Unknown container [{0}].", new object[1]
      {
        (object) str
      }));
    }

    public static string ContainerToFileExtension(Container container) => container == Container.Tgpp ? "3gpp" : container.ToString().ToLowerInvariant();
  }
}
