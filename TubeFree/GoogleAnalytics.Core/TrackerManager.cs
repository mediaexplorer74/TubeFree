// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.TrackerManager
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974073)]
  [CompilerGenerated]
  [Activatable(typeof (ITrackerManagerFactory), 16974073)]
  public sealed class TrackerManager : IServiceManager, ITrackerManagerClass, IStringable
  {
    [MethodImpl]
    public extern TrackerManager([In] IPlatformInfoProvider platformTrackingInfo);

    [MethodImpl]
    extern void IServiceManager.SendPayload([In] Payload payload);

    extern string IServiceManager.UserAgent { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    public extern void CloseTracker([In] Tracker tracker);

    public extern bool AppOptOut { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern Tracker DefaultTracker { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsDebugEnabled { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern IPlatformInfoProvider PlatformTrackingInfo { [MethodImpl] get; }

    [MethodImpl]
    public extern Tracker GetTracker([In] string propertyId);

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
