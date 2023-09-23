// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.TrackedException
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

using System;

namespace GoogleAnalytics
{
  internal sealed class TrackedException : Exception
  {
    public TrackedException(Exception ex)
      : base("Exception rethrown after tracked by Google Analytics", ex)
    {
    }
  }
}
