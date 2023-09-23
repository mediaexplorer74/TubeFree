// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.EventLogging
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [MarshalingBehavior]
  [Version(1)]
  [Static(typeof (__IEventLoggingStatics), 1)]
  [Activatable(1)]
  [Threading]
  public sealed class EventLogging : __IEventLoggingPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern uint AdRendererPageAction(
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

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern uint AdRendererPageView(
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

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern EventLogging();
  }
}
