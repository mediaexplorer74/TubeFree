// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IInterstitialAdPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Guid(1240427483, 7819, 14816, 155, 114, 239, 74, 14, 245, 229, 131)]
  [Version(1)]
  [ExclusiveTo(typeof (InterstitialAd))]
  internal interface __IInterstitialAdPublicNonVirtuals
  {
    [Overload("RequestAd1")]
    void RequestAd([In] AdType adType, [In] string applicationId, [In] string adUnitId);

    void Show();

    void Close();

    void AddAdTag([In] string tagName, [In] string tagValue);

    void RemoveAdTag([In] string tagName);

    InterstitialAdState State { get; }

    uint RequestTimeout { get; [param: In] set; }

    float Latitude { get; [param: In] set; }

    float Longitude { get; [param: In] set; }

    string Keywords { get; [param: In] set; }

    string CountryOrRegion { get; [param: In] set; }

    string PostalCode { get; [param: In] set; }

    event EventHandler<object> AdReady;

    event EventHandler<object> Completed;

    event EventHandler<object> Cancelled;

    event EventHandler<AdErrorEventArgs> ErrorOccurred;
  }
}
