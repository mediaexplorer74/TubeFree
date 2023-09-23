// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IEventLoggingStatics
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Guid(2534843143, 49428, 13669, 151, 77, 17, 159, 96, 139, 109, 2)]
  [Version(1)]
  [ExclusiveTo(typeof (EventLogging))]
  internal interface __IEventLoggingStatics
  {
    uint AdRendererPageAction(
      [In] string UserId,
      [In] string ActionTypeId,
      [In] string ActionInputMethodId,
      [In] string PageUri,
      [In] string PageName,
      [In] string PageTypeId,
      [In] string TemplateId,
      [In] string DestPageUri,
      [In] string DestPageTypeId,
      [In] string CampaignId,
      [In] string GroupId,
      [In] string Content);

    uint AdRendererPageView(
      [In] string UserId,
      [In] string PageUri,
      [In] string PageName,
      [In] string RefererPageUri,
      [In] string PageTypeId,
      [In] string RefererPageTypeId,
      [In] string PageTags,
      [In] string PageParameters,
      [In] string ProductCatalogId,
      [In] string ProductId,
      [In] string TemplateId,
      [In] uint ResolutionWidth,
      [In] uint ResolutionHeight,
      [In] string ScreenState,
      [In] uint ColorDepth,
      [In] string SkinId,
      [In] string CampaignId,
      [In] string GroupId,
      [In] string Content);
  }
}
