// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.IPlatformInfoProvider
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [Guid(3286120909, 2410, 21339, 105, 170, 98, 240, 184, 42, 74, 243)]
  [Version(16974073)]
  public interface IPlatformInfoProvider
  {
    string AnonymousClientId { get; [param: In] set; }

    void OnTracking();

    IReference<int> ScreenColorDepthBits { get; }

    Dimensions ScreenResolution { get; }

    string UserLanguage { get; }

    Dimensions ViewPortResolution { get; }

    string GetUserAgent();

    event EventHandler<object> ViewPortResolutionChanged;

    event EventHandler<object> ScreenResolutionChanged;
  }
}
