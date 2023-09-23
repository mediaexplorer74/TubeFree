// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.AdTagCollection
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Threading]
  [Version(1)]
  [Activatable(1)]
  [MarshalingBehavior]
  public sealed class AdTagCollection : __IAdTagCollectionPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdTagCollection();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void AddAdTag([In] string tagName, [In] string tagValue);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void RemoveAdTag([In] string tagName);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void ClearAdTags();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern string GetAdTagsJson();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IMap<string, string> GetAdTags();
  }
}
