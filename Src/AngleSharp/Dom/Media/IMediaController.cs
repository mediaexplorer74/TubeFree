// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.IMediaController
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Media
{
  [DomName("MediaController")]
  public interface IMediaController
  {
    [DomName("buffered")]
    ITimeRanges BufferedTime { get; }

    [DomName("seekable")]
    ITimeRanges SeekableTime { get; }

    [DomName("played")]
    ITimeRanges PlayedTime { get; }

    [DomName("duration")]
    double Duration { get; }

    [DomName("currentTime")]
    double CurrentTime { get; set; }

    [DomName("defaultPlaybackRate")]
    double DefaultPlaybackRate { get; set; }

    [DomName("playbackRate")]
    double PlaybackRate { get; set; }

    [DomName("volume")]
    double Volume { get; set; }

    [DomName("muted")]
    bool IsMuted { get; set; }

    [DomName("paused")]
    bool IsPaused { get; }

    [DomName("play")]
    void Play();

    [DomName("pause")]
    void Pause();

    [DomName("readyState")]
    MediaReadyState ReadyState { get; }

    [DomName("playbackState")]
    MediaControllerPlaybackState PlaybackState { get; }

    [DomName("onemptied")]
    event DomEventHandler Emptied;

    [DomName("onloadedmetadata")]
    event DomEventHandler LoadedMetadata;

    [DomName("onloadeddata")]
    event DomEventHandler LoadedData;

    [DomName("oncanplay")]
    event DomEventHandler CanPlay;

    [DomName("oncanplaythrough")]
    event DomEventHandler CanPlayThrough;

    [DomName("onended")]
    event DomEventHandler Ended;

    [DomName("onwaiting")]
    event DomEventHandler Waiting;

    [DomName("ondurationchange")]
    event DomEventHandler DurationChanged;

    [DomName("ontimeupdate")]
    event DomEventHandler TimeUpdated;

    [DomName("onpause")]
    event DomEventHandler Paused;

    [DomName("onplay")]
    event DomEventHandler Played;

    [DomName("onplaying")]
    event DomEventHandler Playing;

    [DomName("onratechange")]
    event DomEventHandler RateChanged;

    [DomName("onvolumechange")]
    event DomEventHandler VolumeChanged;
  }
}
