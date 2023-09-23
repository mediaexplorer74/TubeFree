// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IAdScheduleResultPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (AdScheduleResult))]
  [Guid(1834189080, 1784, 15933, 141, 18, 133, 236, 99, 202, 169, 96)]
  [Version(1)]
  internal interface __IAdScheduleResultPublicNonVirtuals
  {
    AdErrorEventArgs Error { get; }

    AdSchedule Value { get; }
  }
}
