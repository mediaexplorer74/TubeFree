// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdTagCollectionPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Guid(1088977634, 17400, 15284, 160, 196, 251, 161, 151, 48, 58, 59)]
  [Version(1)]
  [ExclusiveTo(typeof (AdTagCollection))]
  internal interface __IAdTagCollectionPublicNonVirtuals
  {
    void AddAdTag([In] string tagName, [In] string tagValue);

    void RemoveAdTag([In] string tagName);

    void ClearAdTags();

    string GetAdTagsJson();

    IMap<string, string> GetAdTags();
  }
}
