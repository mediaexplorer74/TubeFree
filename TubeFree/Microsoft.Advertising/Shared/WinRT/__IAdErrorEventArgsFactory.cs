// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdErrorEventArgsFactory
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Version(1)]
  [Guid(3093914166, 37223, 13219, 128, 217, 220, 89, 253, 79, 51, 68)]
  [ExclusiveTo(typeof (AdErrorEventArgs))]
  internal interface __IAdErrorEventArgsFactory
  {
    [Overload("CreateInstance1")]
    AdErrorEventArgs CreateInstance([In] string msg, [In] string code);
  }
}
