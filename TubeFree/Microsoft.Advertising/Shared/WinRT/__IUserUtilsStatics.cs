// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IUserUtilsStatics
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Version(1)]
  [Guid(3327705921, 25232, 14110, 144, 253, 218, 52, 175, 185, 186, 104)]
  [ExclusiveTo(typeof (UserUtils))]
  internal interface __IUserUtilsStatics
  {
    [Overload("GetCurrentUserInfo1")]
    IAsyncOperation<string> GetCurrentUserInfo();

    string GetCurrentUserInfoBasic();
  }
}
