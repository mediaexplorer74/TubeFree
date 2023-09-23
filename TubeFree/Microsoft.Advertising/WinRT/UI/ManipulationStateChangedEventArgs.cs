// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.ManipulationStateChangedEventArgs
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Activatable(typeof (__IManipulationStateChangedEventArgsFactory), 1)]
  [MarshalingBehavior]
  [Version(1)]
  [Threading]
  public sealed class ManipulationStateChangedEventArgs : 
    __IManipulationStateChangedEventArgsPublicNonVirtuals
  {
    public extern int CurrentState { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int LastState { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern ManipulationStateChangedEventArgs([In] int current, [In] int last);
  }
}
