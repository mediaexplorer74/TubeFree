// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IManipulationStateChangedEventArgsFactory
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Version(1)]
  [ExclusiveTo(typeof (ManipulationStateChangedEventArgs))]
  [Guid(1127545983, 39293, 14455, 144, 240, 161, 201, 135, 109, 104, 43)]
  internal interface __IManipulationStateChangedEventArgsFactory
  {
    [Overload("CreateInstance1")]
    ManipulationStateChangedEventArgs CreateInstance([In] int current, [In] int last);
  }
}
