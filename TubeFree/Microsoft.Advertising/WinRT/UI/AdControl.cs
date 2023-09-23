// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.AdControl
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Advertising.WinRT.UI
{
  [WebHostHidden]
  [Activatable(1)]
  [Threading]
  [MarshalingBehavior]
  [TemplatePart(Name = "LayoutRoot", Type = typeof (StackPanel))]
  [Version(1)]
  [Static(typeof (__IAdControlStatics), 1)]
  public sealed class AdControl : 
    Control,
    IClosable,
    __IAdControlPublicNonVirtuals,
    __IAdControlProtectedNonVirtuals
  {
    public extern event EventHandler<AdErrorEventArgs> ErrorOccurred;

    public extern event EventHandler<RoutedEventArgs> AdRefreshed;

    public extern event EventHandler<RoutedEventArgs> IsEngagedChanged;

    public extern event EventHandler<RoutedEventArgs> OnBeforeAdRender;

    public extern event EventHandler<RoutedEventArgs> OnPointerUp;

    public extern event EventHandler<PointerDownEventArgs> OnPointerDown;

    public extern event EventHandler<MouseWheelEventArgs> OnMouseWheel;

    public extern event EventHandler<PointerMoveEventArgs> OnPointerMove;

    public extern event EventHandler<ManipulationStateChangedEventArgs> OnManipulationStateChanged;

    public extern double Latitude { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern double Longitude { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string AdUnitId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string ApplicationId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern bool IsEngaged { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool IsAutoRefreshEnabled { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern int AutoRefreshIntervalInSeconds { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern bool IsBackgroundTransparent { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string Keywords { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string CountryOrRegion { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string PostalCode { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern bool IsSuspended { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool HasAd { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public static extern bool EnableWebViewPool { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [Overload("Refresh1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Refresh();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void AddAdTag([In] string tagName, [In] string tagValue);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void RemoveAdTag([In] string tagName);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Suspend();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Resume();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern void ReleaseWebViewPool();

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern AdControl();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    protected extern void OnApplyTemplate();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Close();
  }
}
