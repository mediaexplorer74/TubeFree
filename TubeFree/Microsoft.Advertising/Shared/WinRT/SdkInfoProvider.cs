// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.SdkInfoProvider
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [MarshalingBehavior]
  [Activatable(1)]
  [Threading]
  [Static(typeof (__ISdkInfoProviderStatics), 1)]
  [Version(1)]
  public sealed class SdkInfoProvider : __ISdkInfoProviderPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern SdkInfo GetSdkInfo();

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern SdkInfoProvider();
  }
}
