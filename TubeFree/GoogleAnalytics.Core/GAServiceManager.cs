// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.GAServiceManager
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974073)]
  [CompilerGenerated]
  [Static(typeof (IGAServiceManagerStatic), 16974073)]
  public sealed class GAServiceManager : IServiceManager, IGAServiceManagerClass, IStringable
  {
    public static extern GAServiceManager Current { [MethodImpl] get; }

    [MethodImpl]
    extern void IServiceManager.SendPayload([In] Payload payload);

    public extern string UserAgent { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern event EventHandler<PayloadFailedEventArgs> PayloadFailed;

    public extern event EventHandler<PayloadMalformedEventArgs> PayloadMalformed;

    public extern event EventHandler<PayloadSentEventArgs> PayloadSent;

    [MethodImpl]
    public extern void Clear();

    [MethodImpl]
    public extern IAsyncAction Dispatch();

    public extern bool BustCache { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern TimeSpan DispatchPeriod { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool IsConnected { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern bool PostData { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
