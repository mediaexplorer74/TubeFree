// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.AdPackage
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [MarshalingBehavior]
  [Version(1)]
  [Threading]
  public sealed class AdPackage : __IAdPackagePublicNonVirtuals
  {
    public extern IVectorView<VideoResource> Video { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern IVectorView<AdExtension> AdExtensions { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Duration { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string SkipOffset { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string ClickThroughUrl { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [DefaultOverload]
    [Overload("ReportAsync1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<uint> ReportAsync(
      [In] string activity,
      [In] IMapView<string, object> macros);

    [Overload("ReportAsync2")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<uint> ReportAsync(
      [In] string activity,
      [In] IMapView<string, string> macros);

    [Overload("ReportAsync3")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<uint> ReportAsync([In] string activity);

    public extern NUad NUad { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
  }
}
