// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdvertisementPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [global::Windows.Foundation.Metadata.Guid(1084789008, 15921, 13352, 128, 102, 0, 167, 200, 206, 63, 32)]
  [Version(1)]
  [ExclusiveTo(typeof (Advertisement))]
  internal interface __IAdvertisementPublicNonVirtuals
  {
    string Guid { get; }

    string PayloadContent { get; }

    bool IsPoly { get; }
  }
}
