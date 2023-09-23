// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.InterstitialAd
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [MarshalingBehavior]
  [Threading]
  [Version(1)]
  [Activatable(1)]
  public sealed class InterstitialAd : 
    __IInterstitialAdPublicNonVirtuals,
    __IInterstitialAdProtectedNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern InterstitialAd();

    [Overload("RequestAd1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void RequestAd([In] AdType adType, [In] string applicationId, [In] string adUnitId);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Show();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Close();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void AddAdTag([In] string tagName, [In] string tagValue);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void RemoveAdTag([In] string tagName);

    public extern InterstitialAdState State { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern uint RequestTimeout { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern float Latitude { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern float Longitude { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string Keywords { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string CountryOrRegion { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string PostalCode { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern event EventHandler<object> AdReady;

    public extern event EventHandler<object> Completed;

    public extern event EventHandler<object> Cancelled;

    public extern event EventHandler<AdErrorEventArgs> ErrorOccurred;
  }
}
