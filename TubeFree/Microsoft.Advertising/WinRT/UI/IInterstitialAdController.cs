// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.IInterstitialAdController
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using Microsoft.Advertising.Shared.WinRT;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Guid(687823193, 53439, 13967, 136, 31, 145, 134, 148, 211, 71, 0)]
  [Version(1)]
  public interface IInterstitialAdController
  {
    InterstitialAdState GetState();

    void Refresh();

    bool CanShow();

    bool CanClose();

    void SetErrorState();

    float Latitude { get; [param: In] set; }

    float Longitude { get; [param: In] set; }

    string AdUnitId { get; [param: In] set; }

    string ApplicationId { get; [param: In] set; }

    string Keywords { get; [param: In] set; }

    string CountryOrRegion { get; [param: In] set; }

    string PostalCode { get; [param: In] set; }

    event EventHandler<Advertisement> AdRefreshed;
  }
}
