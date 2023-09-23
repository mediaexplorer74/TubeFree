// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdErrorReportPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Version(1)]
  [Guid(2592161348, 56668, 13497, 150, 154, 224, 154, 172, 91, 214, 15)]
  [ExclusiveTo(typeof (AdErrorReport))]
  internal interface __IAdErrorReportPublicNonVirtuals
  {
    string ApplicationId { get; [param: In] set; }

    string AdUnitId { get; [param: In] set; }

    string AsId { get; [param: In] set; }

    string ArcDebug { get; [param: In] set; }

    ErrorCode ErrorCode { get; [param: In] set; }

    int HttpStatus { get; [param: In] set; }

    SdkType SdkTypeCode { get; [param: In] set; }

    IAsyncAction ReportAsync();
  }
}
