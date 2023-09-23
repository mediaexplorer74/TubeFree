// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IActivityReporterPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Guid(3560922817, 29575, 14461, 181, 111, 147, 188, 103, 179, 129, 245)]
  [ExclusiveTo(typeof (ActivityReporter))]
  [Version(1)]
  internal interface __IActivityReporterPublicNonVirtuals
  {
    [Overload("ReportAsync2")]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, string> macros);

    [DefaultOverload]
    [Overload("ReportAsync1")]
    IAsyncOperation<uint> ReportAsync([In] string activity, [In] IMapView<string, object> macros);
  }
}
