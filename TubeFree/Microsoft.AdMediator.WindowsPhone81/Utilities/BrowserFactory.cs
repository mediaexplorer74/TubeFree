// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Utilities.BrowserFactory
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Microsoft.AdMediator.WindowsPhone81.Utilities
{
  internal class BrowserFactory : IBrowserFactory
  {
    public async Task<IBrowser> CreateBrowser()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      BrowserFactory.\u003C\u003Ec__DisplayClass0_0 cDisplayClass00 = new BrowserFactory.\u003C\u003Ec__DisplayClass0_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass00.webView = (WebView) null;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      BrowserFactory.\u003C\u003Ec__DisplayClass0_1 cDisplayClass01 = new BrowserFactory.\u003C\u003Ec__DisplayClass0_1();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass01.CS\u0024\u003C\u003E8__locals1 = cDisplayClass00;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass01.browserInitializationSemaphore = new SemaphoreSlim(0, 1);
      IBrowser browser;
      try
      {
        // ISSUE: method pointer
        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority) -1, new DispatchedHandler((object) cDisplayClass01, __methodptr(\u003CCreateBrowser\u003Eb__0)));
        // ISSUE: reference to a compiler-generated field
        await cDisplayClass01.browserInitializationSemaphore.WaitAsync();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        browser = (IBrowser) new Browser(cDisplayClass01.CS\u0024\u003C\u003E8__locals1.webView);
      }
      finally
      {
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass01.browserInitializationSemaphore != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((IDisposable) cDisplayClass01.browserInitializationSemaphore).Dispose();
        }
      }
      return browser;
    }
  }
}
