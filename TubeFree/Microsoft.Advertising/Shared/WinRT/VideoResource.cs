// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.VideoResource
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  public sealed class VideoResource : __IVideoResourcePublicNonVirtuals
  {
    public extern string Id { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Delivery { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Type { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string ApiFramework { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Uri { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Codec { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern uint Bitrate { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern uint MinBitrate { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern uint MaxBitrate { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern uint Width { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern uint Height { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool MaintainAspect { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool Scalable { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}
