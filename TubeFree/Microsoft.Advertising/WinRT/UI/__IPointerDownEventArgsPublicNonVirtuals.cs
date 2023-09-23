// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IPointerDownEventArgsPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [ExclusiveTo(typeof (PointerDownEventArgs))]
  [Version(1)]
  [Guid(2370425687, 60192, 16258, 153, 146, 5, 3, 40, 207, 10, 34)]
  internal interface __IPointerDownEventArgsPublicNonVirtuals
  {
    PointerMoveEventArgs PointerCoordinate { get; }

    string PointerType { get; }

    int KeyCode { get; }
  }
}
