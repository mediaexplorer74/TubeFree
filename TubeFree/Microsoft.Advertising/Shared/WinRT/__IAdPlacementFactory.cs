// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdPlacementFactory
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Version(1)]
  [ExclusiveTo(typeof (AdPlacement))]
  [Guid(276583555, 19955, 13709, 157, 201, 35, 111, 249, 62, 66, 213)]
  internal interface __IAdPlacementFactory
  {
    [Overload("CreateInstance3")]
    AdPlacement CreateInstance([In] SdkType sdkType);

    [Overload("CreateInstance2")]
    AdPlacement CreateInstance([In] SdkType sdkType, [In] string serviceUrl);

    [Overload("CreateInstance1")]
    AdPlacement CreateInstance([In] SdkType sdkType, [In] string applicationId, [In] string adUnitId);
  }
}
