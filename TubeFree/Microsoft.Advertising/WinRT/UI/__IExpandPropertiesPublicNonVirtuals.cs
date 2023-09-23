// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IExpandPropertiesPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Guid(2661821942, 25918, 16261, 135, 91, 185, 206, 241, 90, 220, 202)]
  [Version(1)]
  [ExclusiveTo(typeof (ExpandProperties))]
  internal interface __IExpandPropertiesPublicNonVirtuals
  {
    int Width { get; [param: In] set; }

    int Height { get; [param: In] set; }

    bool UseCustomClose { get; [param: In] set; }

    bool IsModal { get; }

    bool LockOrientation { get; [param: In] set; }
  }
}
