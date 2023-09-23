// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IAdControlStatics
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [WebHostHidden]
  [Guid(2598133844, 48076, 14650, 183, 98, 165, 143, 143, 2, 215, 19)]
  [ExclusiveTo(typeof (AdControl))]
  [Version(1)]
  internal interface __IAdControlStatics
  {
    bool EnableWebViewPool { get; [param: In] set; }

    void ReleaseWebViewPool();
  }
}
