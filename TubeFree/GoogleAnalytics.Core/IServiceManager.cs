// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.IServiceManager
// Assembly: GoogleAnalytics.Core, Version=1.3.0.31481, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 50A1198B-9AF1-4445-80B6-72A45A0328D9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.Core.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics.Core
{
  [Guid(1458123554, 53049, 21465, 85, 183, 249, 223, 133, 129, 56, 70)]
  [Version(16974073)]
  public interface IServiceManager
  {
    void SendPayload([In] Payload payload);

    string UserAgent { get; [param: In] set; }
  }
}
