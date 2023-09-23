// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Models.MediaStreams.Container
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System;

namespace YoutubeExplode.Models.MediaStreams
{
  public enum Container
  {
    [Obsolete("Use Mp4 instead.")] M4A = 0,
    Mp4 = 0,
    WebM = 1,
    Tgpp = 2,
    [Obsolete("Not available anymore.")] Flv = 3,
  }
}
