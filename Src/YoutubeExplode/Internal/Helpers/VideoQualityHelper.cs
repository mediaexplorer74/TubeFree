// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.Helpers.VideoQualityHelper
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.Linq;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeExplode.Internal.Helpers
{
  internal static class VideoQualityHelper
  {
    private static readonly Dictionary<int, VideoQuality> HeightToVideoQualityMap = Enum.GetValues(typeof (VideoQuality)).Cast<VideoQuality>().ToDictionary<VideoQuality, int, VideoQuality>((Func<VideoQuality, int>) (v => v.ToString().StripNonDigit().ParseInt()), (Func<VideoQuality, VideoQuality>) (v => v));

    public static VideoQuality VideoQualityFromHeight(int height)
    {
      int key = VideoQualityHelper.HeightToVideoQualityMap.Keys.LastOrDefault<int>((Func<int, bool>) (h => h <= height));
      return key <= 0 ? VideoQualityHelper.HeightToVideoQualityMap.Values.First<VideoQuality>() : VideoQualityHelper.HeightToVideoQualityMap[key];
    }

    public static VideoQuality VideoQualityFromLabel(string label) => VideoQualityHelper.VideoQualityFromHeight(label.SubstringUntil("p").ParseInt());

    public static string VideoQualityToLabel(VideoQuality quality) => quality.ToString().StripNonDigit() + "p";

    public static string VideoQualityToLabel(VideoQuality quality, int framerate)
    {
      if (framerate <= 30)
        return VideoQualityHelper.VideoQualityToLabel(quality);
      int num = (int) Math.Ceiling((double) framerate / 10.0) * 10;
      return VideoQualityHelper.VideoQualityToLabel(quality) + (object) num;
    }
  }
}
