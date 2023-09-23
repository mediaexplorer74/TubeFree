// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.EasyTrackerConfig
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

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
  [Activatable(16974076)]
  public sealed class EasyTrackerConfig : IEasyTrackerConfigClass, IStringable
  {
    [MethodImpl]
    public extern EasyTrackerConfig();

    public extern bool AnonymizeIp { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppInstallerId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppName { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppVersion { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool AutoAppLifetimeMonitoring { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool AutoAppLifetimeTracking { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool AutoTrackNetworkConnectivity { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool Debug { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern TimeSpan DispatchPeriod { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool ReportUncaughtExceptions { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern float SampleFrequency { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern IReference<TimeSpan> SessionTimeout { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string TrackingId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool UseSecure { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
