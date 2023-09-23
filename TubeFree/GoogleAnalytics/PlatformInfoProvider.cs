// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.PlatformInfoProvider
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

using GoogleAnalytics.Core;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974076)]
  [CompilerGenerated]
  [Activatable(16974076)]
  public sealed class PlatformInfoProvider : IPlatformInfoProvider, IStringable
  {
    [MethodImpl]
    public extern PlatformInfoProvider();

    public extern event EventHandler<object> ViewPortResolutionChanged;

    public extern event EventHandler<object> ScreenResolutionChanged;

    [MethodImpl]
    public extern void OnTracking();

    public extern string AnonymousClientId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern Dimensions ViewPortResolution { [MethodImpl] get; }

    public extern Dimensions ScreenResolution { [MethodImpl] get; }

    public extern string UserLanguage { [MethodImpl] get; }

    public extern IReference<int> ScreenColorDepthBits { [MethodImpl] get; }

    [MethodImpl]
    public extern string GetUserAgent();

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
