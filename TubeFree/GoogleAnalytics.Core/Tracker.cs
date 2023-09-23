// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.Tracker
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
  [Activatable(typeof (ITrackerFactory), 16974073)]
  public sealed class Tracker : ITrackerClass, IStringable
  {
    [MethodImpl]
    public extern Tracker(
      [In] string propertyId,
      [In] IPlatformInfoProvider platformInfoProvider,
      [In] IServiceManager serviceManager);

    public extern string AppId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppInstallerId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppName { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern Dimensions AppScreen { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string AppVersion { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CampaignContent { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CampaignId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CampaignKeyword { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CampaignMedium { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CampaignName { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CampaignSource { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string DataSource { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string DocumentEncoding { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string DocumentHostName { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string DocumentLocationUrl { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string DocumentPath { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string DocumentTitle { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string ExperimentId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string ExperimentVariant { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string GeographicalId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string GoogleAdWordsId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string GoogleDisplayAdsId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string IpOverride { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsAnonymizeIpEnabled { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsDebug { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsUseSecure { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string LinkId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string Referrer { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern float SampleRate { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool ThrottlingEnabled { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string TrackingId { [MethodImpl] get; }

    public extern string UserAgentOverride { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string UserId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    public extern void SendEvent([In] string category, [In] string action, [In] string label, [In] long value);

    [MethodImpl]
    public extern void SendException([In] string description, [In] bool isFatal);

    [MethodImpl]
    public extern void SendSocial([In] string network, [In] string action, [In] string target);

    [MethodImpl]
    public extern void SendTiming([In] TimeSpan time, [In] string category, [In] string variable, [In] string label);

    [MethodImpl]
    public extern void SendTransaction([In] Transaction transaction);

    [MethodImpl]
    public extern void SendTransactionItem([In] TransactionItem transactionItem);

    [MethodImpl]
    public extern void SendView([In] string screenName);

    [MethodImpl]
    public extern void SetCustomDimension([In] int index, [In] string value);

    [MethodImpl]
    public extern void SetCustomMetric([In] int index, [In] long value);

    [MethodImpl]
    public extern void SetEndSession([In] bool value);

    [MethodImpl]
    public extern void SetStartSession([In] bool value);

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
