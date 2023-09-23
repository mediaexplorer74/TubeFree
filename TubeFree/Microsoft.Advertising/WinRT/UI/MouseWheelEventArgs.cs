// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.MouseWheelEventArgs
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [MarshalingBehavior]
  [Version(1)]
  [Threading]
  public sealed class MouseWheelEventArgs : __IMouseWheelEventArgsPublicNonVirtuals
  {
    public extern PointerMoveEventArgs PointerCoordinate { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool CtrlKeyPressed { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int WheelDelta { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}
