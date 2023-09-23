// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.__IAdControlPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace Microsoft.Advertising.WinRT.UI
{
  [WebHostHidden]
  [Guid(2931394582, 31404, 13768, 143, 13, 248, 79, 230, 220, 135, 13)]
  [ExclusiveTo(typeof (AdControl))]
  [Version(1)]
  internal interface __IAdControlPublicNonVirtuals
  {
    event EventHandler<AdErrorEventArgs> ErrorOccurred;

    event EventHandler<RoutedEventArgs> AdRefreshed;

    event EventHandler<RoutedEventArgs> IsEngagedChanged;

    event EventHandler<RoutedEventArgs> OnBeforeAdRender;

    event EventHandler<RoutedEventArgs> OnPointerUp;

    event EventHandler<PointerDownEventArgs> OnPointerDown;

    event EventHandler<MouseWheelEventArgs> OnMouseWheel;

    event EventHandler<PointerMoveEventArgs> OnPointerMove;

    event EventHandler<ManipulationStateChangedEventArgs> OnManipulationStateChanged;

    double Latitude { get; [param: In] set; }

    double Longitude { get; [param: In] set; }

    string AdUnitId { get; [param: In] set; }

    string ApplicationId { get; [param: In] set; }

    bool IsEngaged { get; }

    bool IsAutoRefreshEnabled { get; [param: In] set; }

    int AutoRefreshIntervalInSeconds { get; [param: In] set; }

    bool IsBackgroundTransparent { get; [param: In] set; }

    string Keywords { get; [param: In] set; }

    string CountryOrRegion { get; [param: In] set; }

    string PostalCode { get; [param: In] set; }

    bool IsSuspended { get; }

    bool HasAd { get; }

    [Overload("Refresh1")]
    void Refresh();

    void AddAdTag([In] string tagName, [In] string tagValue);

    void RemoveAdTag([In] string tagName);

    void Suspend();

    void Resume();
  }
}
