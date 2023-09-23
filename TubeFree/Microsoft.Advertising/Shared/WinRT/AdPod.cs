// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.AdPod
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
  [Threading]
  [Version(1)]
  public sealed class AdPod : __IAdPodPublicNonVirtuals
  {
    public extern string Time { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Id { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string RepeatAfter { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern IVectorView<AdPackage> Packages { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

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
  }
}
