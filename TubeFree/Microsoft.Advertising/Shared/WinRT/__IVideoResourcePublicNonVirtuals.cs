// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IVideoResourcePublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [ExclusiveTo(typeof (VideoResource))]
  [Version(1)]
  [Guid(2380302044, 22631, 14931, 174, 14, 63, 154, 46, 210, 37, 198)]
  internal interface __IVideoResourcePublicNonVirtuals
  {
    string Id { get; }

    string Delivery { get; }

    string Type { get; }

    string ApiFramework { get; }

    string Uri { get; }

    string Codec { get; }

    uint Bitrate { get; }

    uint MinBitrate { get; }

    uint MaxBitrate { get; }

    uint Width { get; }

    uint Height { get; }

    bool MaintainAspect { get; }

    bool Scalable { get; }
  }
}
