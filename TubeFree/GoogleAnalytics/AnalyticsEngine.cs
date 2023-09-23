// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.AnalyticsEngine
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

using GoogleAnalytics.Core;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974076)]
  [CompilerGenerated]
  [Static(typeof (IAnalyticsEngineStatic), 16974076)]
  public sealed class AnalyticsEngine : IAnalyticsEngineClass, IStringable
  {
    public static extern AnalyticsEngine Current { [MethodImpl] get; }

    [MethodImpl]
    public extern void CloseTracker([In] Tracker tracker);

    public extern bool AppOptOut { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern Tracker DefaultTracker { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsDebugEnabled { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern IPlatformInfoProvider PlatformInfoProvider { [MethodImpl] get; }

    [MethodImpl]
    public extern Tracker GetTracker([In] string propertyId);

    [MethodImpl]
    public extern IAsyncOperation<bool> RequestAppOptOutAsync();

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
