// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IPointerMoveEventArgsPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Guid(2801205726, 53898, 15051, 131, 50, 110, 117, 80, 54, 243, 29)]
  [ExclusiveTo(typeof (PointerMoveEventArgs))]
  [Version(1)]
  internal interface __IPointerMoveEventArgsPublicNonVirtuals
  {
    Point MouseCoordinate { get; }
  }
}
