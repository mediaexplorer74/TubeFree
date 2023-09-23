// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IExpandPropertiesFactory
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Version(1)]
  [ExclusiveTo(typeof (ExpandProperties))]
  [Guid(3951038205, 28582, 15224, 158, 4, 114, 132, 118, 208, 158, 215)]
  internal interface __IExpandPropertiesFactory
  {
    [Overload("CreateInstance1")]
    ExpandProperties CreateInstance(
      [In] int width,
      [In] int height,
      [In] bool useCustomClose,
      [In] bool lockOrientation);
  }
}
