// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdPackagePublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Guid(3259459463, 1723, 15496, 147, 253, 141, 171, 110, 49, 134, 248)]
  [Version(1)]
  [ExclusiveTo(typeof (AdPackage))]
  internal interface __IAdPackagePublicNonVirtuals
  {
    IVectorView<VideoResource> Video { get; }

    IVectorView<AdExtension> AdExtensions { get; }

    string Duration { get; }

    string SkipOffset { get; }

    string ClickThroughUrl { get; }

    [Overload("ReportAsync3")]
    IAsyncOperation<uint> ReportAsync([In] string activity);

    [Overload("ReportAsync2")]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, string> macros);

    [Overload("ReportAsync1")]
    [DefaultOverload]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, object> macros);

    NUad NUad { get; [param: In] set; }
  }
}
