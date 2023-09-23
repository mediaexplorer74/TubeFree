// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.PayloadSentEventArgs
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974073)]
  [CompilerGenerated]
  public sealed class PayloadSentEventArgs : IPayloadSentEventArgsClass, IStringable
  {
    public extern Payload Payload { [MethodImpl] get; }

    public extern string Response { [MethodImpl] get; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
