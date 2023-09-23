// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdErrorEventArgsPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (AdErrorEventArgs))]
  [Version(1)]
  [Guid(2246226781, 49417, 12337, 174, 74, 162, 210, 89, 178, 216, 57)]
  internal interface __IAdErrorEventArgsPublicNonVirtuals
  {
    string ErrorMessage { get; }

    string ErrorCode { get; }

    global::Microsoft.Advertising.ErrorCode ErrorCodeEnum { get; }
  }
}
