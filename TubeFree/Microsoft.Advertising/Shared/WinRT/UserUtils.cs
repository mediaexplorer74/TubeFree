// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.UserUtils
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Static(typeof (__IUserUtilsStatics), 1)]
  [Threading]
  [Activatable(1)]
  [Version(1)]
  [MarshalingBehavior]
  public sealed class UserUtils : __IUserUtilsPublicNonVirtuals
  {
    [Overload("GetCurrentUserInfo1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern IAsyncOperation<string> GetCurrentUserInfo();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern string GetCurrentUserInfoBasic();

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern UserUtils();
  }
}
