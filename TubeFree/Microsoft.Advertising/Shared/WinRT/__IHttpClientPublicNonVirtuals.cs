// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.__IHttpClientPublicNonVirtuals
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [Version(1)]
  [Guid(2635365925, 62087, 13778, 185, 168, 224, 170, 190, 171, 126, 78)]
  [ExclusiveTo(typeof (HttpClient))]
  internal interface __IHttpClientPublicNonVirtuals
  {
    IAsyncOperation<string> SendRequest([In] string url);

    void Cancel();

    void AddHeader([In] string name, [In] string value);

    string LastErrorMessage { get; }
  }
}
