// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.AdPlacement
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Activatable(typeof (__IAdPlacementFactory), 1)]
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  public sealed class AdPlacement : __IAdPlacementPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdPlacement([In] SdkType sdkType, [In] string applicationId, [In] string adUnitId);

    [Overload("CreateInstance2")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdPlacement([In] SdkType sdkType, [In] string serviceUrl);

    [Overload("CreateInstance3")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdPlacement([In] SdkType sdkType);

    public extern string ApplicationId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string AdUnitId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string ServiceUrl { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern AdTagCollection AdTags { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern AdErrorEventArgs LastError { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string LastAsId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int LastHttpStatusCode { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string LastArcDebug { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int Width { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern int Height { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern float Latitude { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern float Longitude { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string Keywords { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string CountryOrRegion { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string PostalCode { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern SdkType SdkType { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [Overload("GetAdAsync1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<Advertisement> GetAdAsync([In] uint timeoutInMilliseconds);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void ReportEvent([In] string eventName);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void ClearLastError();
  }
}
