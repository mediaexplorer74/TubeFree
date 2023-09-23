// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.PointerMoveEventArgs
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Threading]
  [Version(1)]
  [MarshalingBehavior]
  public sealed class PointerMoveEventArgs : __IPointerMoveEventArgsPublicNonVirtuals
  {
    public extern Point MouseCoordinate { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}
