// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdExtensionFactory
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (AdExtension))]
  [Guid(261822785, 20555, 14760, 181, 23, 202, 65, 104, 73, 137, 185)]
  [Version(1)]
  internal interface __IAdExtensionFactory
  {
    [Overload("CreateInstance1")]
    AdExtension CreateInstance([In] string type, [In] string xmlData);
  }
}
