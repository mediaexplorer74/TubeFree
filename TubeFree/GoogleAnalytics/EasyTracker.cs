// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.EasyTracker
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

using GoogleAnalytics.Core;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace GoogleAnalytics
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974076)]
  [CompilerGenerated]
  [Static(typeof (IEasyTrackerStatic), 16974076)]
  public sealed class EasyTracker : IEasyTrackerClass, IStringable
  {
    public static extern EasyTracker Current { [MethodImpl] get; }

    [MethodImpl]
    public static extern Tracker GetTracker();

    [MethodImpl]
    public extern IAsyncAction Dispatch();

    public extern EasyTrackerConfig Config { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern Uri ConfigPath { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    public extern void SetContext([In] Application ctx);

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
