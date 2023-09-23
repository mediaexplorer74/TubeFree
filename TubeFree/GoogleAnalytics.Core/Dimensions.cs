// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.Dimensions
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
  [Activatable(typeof (IDimensionsFactory), 16974073)]
  public sealed class Dimensions : IDimensionsClass, IStringable
  {
    [MethodImpl]
    public extern Dimensions([In] int width, [In] int height);

    public extern int Height { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern int Width { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
