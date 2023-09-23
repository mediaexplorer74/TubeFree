// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.Payload
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974073)]
  [CompilerGenerated]
  [Activatable(typeof (IPayloadFactory), 16974073)]
  public sealed class Payload : IPayloadClass, IStringable
  {
    [MethodImpl]
    public extern Payload([In] IMap<string, string> data);

    public extern IMap<string, string> Data { [MethodImpl] get; }

    public extern bool IsDebug { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsUseSecure { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern DateTime TimeStamp { [MethodImpl] get; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
