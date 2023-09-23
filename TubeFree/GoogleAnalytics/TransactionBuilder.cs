// Decompiled with JetBrains decompiler
// Type: GoogleAnalytics.TransactionBuilder
// Assembly: GoogleAnalytics, Version=1.3.0.31484, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 5826606D-B825-4A3A-916A-607CEBE227E9
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\GoogleAnalytics.winmd

using GoogleAnalytics.Core;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace GoogleAnalytics
{
  [MarshalingBehavior]
  [Threading]
  [Version(16974076)]
  [CompilerGenerated]
  [Static(typeof (ITransactionBuilderStatic), 16974076)]
  public sealed class TransactionBuilder : ITransactionBuilderClass, IStringable
  {
    public static extern string StoreName { [MethodImpl] get; [MethodImpl] [param: In] set; }

    [MethodImpl]
    public static extern Transaction GetAppPurchaseTransaction(
      [In] ListingInformation listingInformation,
      [In] string receipt);

    [MethodImpl]
    public static extern Transaction GetProductPurchaseTransaction(
      [In] ListingInformation listingInformation,
      [In] string receipt);

    [MethodImpl]
    extern string IStringable.ToString();
  }
}
