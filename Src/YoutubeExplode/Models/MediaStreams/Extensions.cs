// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.Extensions
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;
using System.Collections.Generic;
using System.Linq;
using YoutubeExplode.Internal;
using YoutubeExplode.Internal.Helpers;

namespace YoutubeExplode.Models.MediaStreams
{
  public static class Extensions
  {
    public static string GetFileExtension(this Container container) => ContainerHelper.ContainerToFileExtension(container);

    public static IEnumerable<MediaStreamInfo> GetAll(this MediaStreamInfoSet streamInfoSet)
    {
      streamInfoSet.GuardNotNull<MediaStreamInfoSet>(nameof (streamInfoSet));
      foreach (MediaStreamInfo mediaStreamInfo in (IEnumerable<MuxedStreamInfo>) streamInfoSet.Muxed)
        yield return mediaStreamInfo;
      foreach (MediaStreamInfo mediaStreamInfo in (IEnumerable<AudioStreamInfo>) streamInfoSet.Audio)
        yield return mediaStreamInfo;
      foreach (MediaStreamInfo mediaStreamInfo in (IEnumerable<VideoStreamInfo>) streamInfoSet.Video)
        yield return mediaStreamInfo;
    }

    public static IEnumerable<VideoQuality> GetAllVideoQualities(
      this MediaStreamInfoSet streamInfoSet)
    {
      streamInfoSet.GuardNotNull<MediaStreamInfoSet>(nameof (streamInfoSet));
      HashSet<VideoQuality> allVideoQualities = new HashSet<VideoQuality>();
      foreach (MuxedStreamInfo muxedStreamInfo in (IEnumerable<MuxedStreamInfo>) streamInfoSet.Muxed)
        allVideoQualities.Add(muxedStreamInfo.VideoQuality);
      foreach (VideoStreamInfo videoStreamInfo in (IEnumerable<VideoStreamInfo>) streamInfoSet.Video)
        allVideoQualities.Add(videoStreamInfo.VideoQuality);
      return (IEnumerable<VideoQuality>) allVideoQualities;
    }

    public static IEnumerable<string> GetAllVideoQualityLabels(this MediaStreamInfoSet streamInfoSet)
    {
      streamInfoSet.GuardNotNull<MediaStreamInfoSet>(nameof (streamInfoSet));
      HashSet<string> videoQualityLabels = new HashSet<string>();
      foreach (MuxedStreamInfo muxedStreamInfo in (IEnumerable<MuxedStreamInfo>) streamInfoSet.Muxed)
        videoQualityLabels.Add(muxedStreamInfo.VideoQualityLabel);
      foreach (VideoStreamInfo videoStreamInfo in (IEnumerable<VideoStreamInfo>) streamInfoSet.Video)
        videoQualityLabels.Add(videoStreamInfo.VideoQualityLabel);
      return (IEnumerable<string>) videoQualityLabels;
    }

    public static MuxedStreamInfo WithHighestVideoQuality(
      this IEnumerable<MuxedStreamInfo> streamInfos)
    {
      streamInfos.GuardNotNull<IEnumerable<MuxedStreamInfo>>(nameof (streamInfos));
      return streamInfos.OrderByDescending<MuxedStreamInfo, VideoQuality>((Func<MuxedStreamInfo, VideoQuality>) (s => s.VideoQuality)).FirstOrDefault<MuxedStreamInfo>();
    }

    public static VideoStreamInfo WithHighestVideoQuality(
      this IEnumerable<VideoStreamInfo> streamInfos)
    {
      streamInfos.GuardNotNull<IEnumerable<VideoStreamInfo>>(nameof (streamInfos));
      return streamInfos.OrderByDescending<VideoStreamInfo, VideoQuality>((Func<VideoStreamInfo, VideoQuality>) (s => s.VideoQuality)).FirstOrDefault<VideoStreamInfo>();
    }

    public static AudioStreamInfo WithHighestBitrate(this IEnumerable<AudioStreamInfo> streamInfos)
    {
      streamInfos.GuardNotNull<IEnumerable<AudioStreamInfo>>(nameof (streamInfos));
      return streamInfos.OrderByDescending<AudioStreamInfo, long>((Func<AudioStreamInfo, long>) (s => s.Bitrate)).FirstOrDefault<AudioStreamInfo>();
    }

    public static VideoStreamInfo WithHighestBitrate(this IEnumerable<VideoStreamInfo> streamInfos)
    {
      streamInfos.GuardNotNull<IEnumerable<VideoStreamInfo>>(nameof (streamInfos));
      return streamInfos.OrderByDescending<VideoStreamInfo, long>((Func<VideoStreamInfo, long>) (s => s.Bitrate)).FirstOrDefault<VideoStreamInfo>();
    }
  }
}
