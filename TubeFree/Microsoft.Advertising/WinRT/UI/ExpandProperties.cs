// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.ExpandProperties
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Activatable(typeof (__IExpandPropertiesFactory), 1)]
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  [Static(typeof (__IExpandPropertiesStatics), 1)]
  public sealed class ExpandProperties : __IExpandPropertiesPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern ExpandProperties(
      [In] int width,
      [In] int height,
      [In] bool useCustomClose,
      [In] bool lockOrientation);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern ExpandProperties GetDefault();

    public extern int Width { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern int Height { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern bool UseCustomClose { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern bool IsModal { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool LockOrientation { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
  }
}
