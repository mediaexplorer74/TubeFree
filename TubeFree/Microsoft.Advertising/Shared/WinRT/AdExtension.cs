﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.AdExtension
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [MarshalingBehavior]
  [Activatable(typeof (__IAdExtensionFactory), 1)]
  [Version(1)]
  [Threading]
  public sealed class AdExtension : __IAdExtensionPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdExtension([In] string type, [In] string xmlData);

    public extern string Type { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string XmlData { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string JsonData { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}
