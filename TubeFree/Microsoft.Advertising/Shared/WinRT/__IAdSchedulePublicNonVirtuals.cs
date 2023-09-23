// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdSchedulePublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Guid(3271276652, 46734, 13927, 178, 45, 142, 239, 232, 123, 126, 222)]
  [ExclusiveTo(typeof (AdSchedule))]
  [Version(1)]
  internal interface __IAdSchedulePublicNonVirtuals
  {
    IVectorView<AdPod> Pods { get; }
  }
}
