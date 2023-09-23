// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IMouseWheelEventArgsPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [ExclusiveTo(typeof (MouseWheelEventArgs))]
  [Version(1)]
  [Guid(1111719890, 31870, 14711, 189, 253, 199, 40, 2, 225, 152, 33)]
  internal interface __IMouseWheelEventArgsPublicNonVirtuals
  {
    PointerMoveEventArgs PointerCoordinate { get; }

    bool CtrlKeyPressed { get; }

    int WheelDelta { get; }
  }
}
