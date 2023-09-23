// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IAdErrorEventArgsPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [ExclusiveTo(typeof (AdErrorEventArgs))]
  [Version(1)]
  [Guid(4238418923, 38265, 16324, 179, 208, 76, 80, 21, 80, 102, 74)]
  internal interface __IAdErrorEventArgsPublicNonVirtuals
  {
    ErrorCode ErrorCode { get; }

    string ErrorMessage { get; }
  }
}
