// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.Advertisement
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Activatable(1)]
  [MarshalingBehavior]
  [Threading]
  [Version(1)]
  public sealed class Advertisement : __IAdvertisementPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern Advertisement();

    public extern string Guid { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string PayloadContent { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool IsPoly { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}
