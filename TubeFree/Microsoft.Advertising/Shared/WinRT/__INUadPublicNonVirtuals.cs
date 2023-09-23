// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__INUadPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Version(1)]
  [Guid(3281147735, 25915, 15805, 152, 78, 159, 134, 48, 141, 75, 98)]
  [ExclusiveTo(typeof (NUad))]
  internal interface __INUadPublicNonVirtuals
  {
    string Type { get; }

    string JsonData { get; }

    IAsyncOperation<string> GetRenderer();

    [Overload("ReportAsync3")]
    IAsyncOperation<uint> ReportAsync([In] string activity);

    [Overload("ReportAsync2")]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, string> macros);

    [Overload("ReportAsync1")]
    [DefaultOverload]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, object> macros);
  }
}
