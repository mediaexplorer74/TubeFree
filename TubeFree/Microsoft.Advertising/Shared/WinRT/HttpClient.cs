// Decompiled with JetBrains decompiler
// Type: Microsoft.Advertising.Shared.WinRT.HttpClient
// Assembly: Microsoft.Advertising, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: AAA22BA4-D3C2-42EA-A2EC-4B10E0D720BD
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.Advertising.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Microsoft.Advertising.Shared.WinRT
{
  [MarshalingBehavior]
  [Activatable(1)]
  [Version(1)]
  [Threading]
  public sealed class HttpClient : __IHttpClientPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<string> SendRequest([In] string url);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Cancel();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void AddHeader([In] string name, [In] string value);

    public extern string LastErrorMessage { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern HttpClient();
  }
}
