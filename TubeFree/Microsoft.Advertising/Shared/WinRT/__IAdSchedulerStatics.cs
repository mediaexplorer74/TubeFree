// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdSchedulerStatics
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (AdScheduler))]
  [Version(1)]
  [Guid(2901004550, 46635, 12532, 139, 159, 32, 122, 204, 24, 60, 65)]
  internal interface __IAdSchedulerStatics
  {
    [Overload("GetScheduleAsync2")]
    IAsyncOperation<AdScheduleResult> GetScheduleAsync(
      [In] string appId,
      [In] string adId,
      [In] uint timeoutMS,
      [In] SdkType sdkType,
      [In] AdTagCollection adTags);

    [Overload("GetScheduleAsync1")]
    IAsyncOperation<AdScheduleResult> GetScheduleAsync([In] string serviceUrl, [In] uint timeoutMS);

    [Overload("GetScheduleStrictAsync2")]
    IAsyncOperation<AdScheduleResult> GetScheduleStrictAsync(
      [In] string appId,
      [In] string adId,
      [In] uint timeoutMS,
      [In] SdkType sdkType,
      [In] AdTagCollection adTags);

    [Overload("GetScheduleStrictAsync1")]
    IAsyncOperation<AdScheduleResult> GetScheduleStrictAsync([In] string serviceUrl, [In] uint timeoutMS);
  }
}
