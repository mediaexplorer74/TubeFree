// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.AdScheduler
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Static(typeof (__IAdSchedulerStatics), 1)]
  [Activatable(1)]
  [Version(1)]
  [MarshalingBehavior]
  [Threading]
  public sealed class AdScheduler : __IAdSchedulerPublicNonVirtuals
  {
    [Overload("GetScheduleAsync1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern IAsyncOperation<AdScheduleResult> GetScheduleAsync(
      [In] string serviceUrl,
      [In] uint timeoutMS);

    [Overload("GetScheduleAsync2")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern IAsyncOperation<AdScheduleResult> GetScheduleAsync(
      [In] string appId,
      [In] string adId,
      [In] uint timeoutMS,
      [In] SdkType sdkType,
      [In] AdTagCollection adTags);

    [Overload("GetScheduleStrictAsync1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern IAsyncOperation<AdScheduleResult> GetScheduleStrictAsync(
      [In] string serviceUrl,
      [In] uint timeoutMS);

    [Overload("GetScheduleStrictAsync2")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern IAsyncOperation<AdScheduleResult> GetScheduleStrictAsync(
      [In] string appId,
      [In] string adId,
      [In] uint timeoutMS,
      [In] SdkType sdkType,
      [In] AdTagCollection adTags);

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdScheduler();
  }
}
