// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdPlacementPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (AdPlacement))]
  [Guid(3840508553, 20576, 13681, 139, 206, 24, 3, 170, 68, 217, 60)]
  [Version(1)]
  internal interface __IAdPlacementPublicNonVirtuals
  {
    string ApplicationId { get; [param: In] set; }

    string AdUnitId { get; [param: In] set; }

    string ServiceUrl { get; [param: In] set; }

    AdTagCollection AdTags { get; [param: In] set; }

    AdErrorEventArgs LastError { get; }

    string LastAsId { get; }

    int LastHttpStatusCode { get; }

    string LastArcDebug { get; }

    int Width { get; [param: In] set; }

    int Height { get; [param: In] set; }

    float Latitude { get; [param: In] set; }

    float Longitude { get; [param: In] set; }

    string Keywords { get; [param: In] set; }

    string CountryOrRegion { get; [param: In] set; }

    string PostalCode { get; [param: In] set; }

    SdkType SdkType { get; }

    [Overload("GetAdAsync1")]
    IAsyncOperation<Advertisement> GetAdAsync([In] uint timeoutInMilliseconds);

    void ReportEvent([In] string eventName);

    void ClearLastError();
  }
}
