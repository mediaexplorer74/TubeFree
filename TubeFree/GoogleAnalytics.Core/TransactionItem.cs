// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.TransactionItem
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
  [Activatable(16974073)]
  [Activatable(typeof (ITransactionItemFactory), 16974073)]
  public sealed class TransactionItem : ITransactionItemClass, IStringable
  {
    [MethodImpl]
    public extern TransactionItem();

    [MethodImpl]
    public extern TransactionItem([In] string sku, [In] string name, [In] long priceInMicros, [In] long quantity);

    [MethodImpl]
    public extern TransactionItem(
      [In] string transactionId,
      [In] string sku,
      [In] string name,
      [In] long priceInMicros,
      [In] long quantity);

    public extern string Category { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CurrencyCode { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string Name { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern long PriceInMicros { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern long Quantity { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string SKU { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string TransactionId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
