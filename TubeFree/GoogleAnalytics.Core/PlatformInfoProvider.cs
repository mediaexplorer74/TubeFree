// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.PlatformInfoProvider
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974073)]
  [CompilerGenerated]
  [Activatable(16974073)]
  public sealed class PlatformInfoProvider : 
    IPlatformInfoProvider,
    IPlatformInfoProviderClass,
    IStringable
  {
    [MethodImpl]
    public extern PlatformInfoProvider();

    public extern event EventHandler<object> ViewPortResolutionChanged;

    public extern event EventHandler<object> ScreenResolutionChanged;

    public extern string AnonymousClientId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    public extern void OnTracking();

    public extern IReference<int> ScreenColorDepthBits { [MethodImpl] get; }

    public extern string UserLanguage { [MethodImpl] get; }

    public extern Dimensions ScreenResolution { [MethodImpl] get; }

    public extern Dimensions ViewPortResolution { [MethodImpl] get; }

    [MethodImpl]
    extern string IPlatformInfoProvider.GetUserAgent();

    public extern string UserAgent { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [CompilerGenerated]
    [SpecialName]
    [MethodImpl]
    public extern void put_ScreenColorDepthBits([In] IReference<int> value);

    [SpecialName]
    [MethodImpl]
    public extern void put_ScreenResolution([In] Dimensions value);

    [CompilerGenerated]
    [SpecialName]
    [MethodImpl]
    public extern void put_UserLanguage([In] string value);

    [SpecialName]
    [MethodImpl]
    public extern void put_ViewPortResolution([In] Dimensions value);

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
