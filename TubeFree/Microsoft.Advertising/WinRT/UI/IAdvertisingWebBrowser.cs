// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.WinRT.UI.IAdvertisingWebBrowser
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.WinRT.UI
{
  [Version(1)]
  [Guid(2935336617, 59175, 13190, 155, 224, 202, 176, 26, 100, 39, 180)]
  public interface IAdvertisingWebBrowser
  {
    double GetContainerWidth();

    double GetContainerHeight();

    [Overload("Expand1")]
    void Expand([In] Uri uri, [In] ExpandProperties expandProperties, [In] bool isLegacyAd);

    [Overload("Expand2")]
    void Expand([In] Uri uri, [In] ExpandProperties expandProperties);

    void Resize([In] double width, [In] double height);

    void UpdateExpandProperties([In] ExpandProperties expandProps);

    void SetUseCustomClose([In] bool useCustomClose);

    void RaiseAdLoadFailedEvent([In] string message);

    void CloseExpandedView();
  }
}
