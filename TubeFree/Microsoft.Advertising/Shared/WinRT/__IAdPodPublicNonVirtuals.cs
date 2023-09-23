// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdPodPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (AdPod))]
  [Guid(892892370, 59732, 12399, 183, 176, 204, 85, 12, 182, 239, 253)]
  [Version(1)]
  internal interface __IAdPodPublicNonVirtuals
  {
    string Time { get; }

    string Id { get; }

    string RepeatAfter { get; }

    IVectorView<AdPackage> Packages { get; }

    [Overload("ReportAsync3")]
    IAsyncOperation<uint> ReportAsync([In] string activity);

    [Overload("ReportAsync2")]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, string> macros);

    [DefaultOverload]
    [Overload("ReportAsync1")]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, object> macros);
  }
}
