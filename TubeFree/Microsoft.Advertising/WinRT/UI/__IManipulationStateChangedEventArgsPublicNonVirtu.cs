// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IManipulationStateChangedEventArgsPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [ExclusiveTo(typeof (ManipulationStateChangedEventArgs))]
  [Version(1)]
  [Guid(1539547233, 40317, 15906, 188, 143, 235, 159, 44, 175, 50, 59)]
  internal interface __IManipulationStateChangedEventArgsPublicNonVirtuals
  {
    int CurrentState { get; }

    int LastState { get; }
  }
}
