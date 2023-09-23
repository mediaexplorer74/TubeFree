// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.Core.Transaction
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
  [Activatable(16974073)]
  [Activatable(typeof (ITransactionFactory), 16974073)]
  public sealed class Transaction : ITransactionClass, IStringable
  {
    [MethodImpl]
    public extern Transaction();

    [MethodImpl]
    public extern Transaction([In] string transactionId, [In] long totalCostInMicros);

    public extern string Affiliation { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string CurrencyCode { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern IVector<TransactionItem> Items { [MethodImpl] get; }

    public extern long ShippingCostInMicros { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern long TotalCostInMicros { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern long TotalTaxInMicros { [MethodImpl] get; [MethodImpl] [param: In] set; }

    public extern string TransactionId { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
