// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__ISdkInfoProviderStatics
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (SdkInfoProvider))]
  [Guid(423475444, 45496, 13850, 177, 167, 212, 73, 103, 199, 13, 47)]
  [Version(1)]
  internal interface __ISdkInfoProviderStatics
  {
    SdkInfo GetSdkInfo();
  }
}
