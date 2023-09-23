// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.ProductReceipt
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974076)]
  [CompilerGenerated]
  [Activatable(16974076)]
  [Static(typeof (IProductReceiptStatic), 16974076)]
  public sealed class ProductReceipt : IProductReceiptClass, IStringable
  {
    [MethodImpl]
    public extern ProductReceipt();

    [MethodImpl]
    public static extern ProductReceipt Load([In] string receipt);

    public extern string Id { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string ProductId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string ProductType { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
