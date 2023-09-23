// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Utilities.Browser
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.AdMediator.WindowsPhone81.Utilities
{
  internal class Browser : IBrowser
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (Browser));
    private readonly WebView webView;

    public Browser(WebView webView) => this.webView = webView;

    public void Navigate(Uri uri)
    {
      DispatchedHandler dispatchedHandler;
      // ISSUE: method pointer
      Task.Run<IAsyncAction>((Func<IAsyncAction>) (() => ((DependencyObject) this.webView).Dispatcher.RunAsync((CoreDispatcherPriority) -1, dispatchedHandler ?? (dispatchedHandler = new DispatchedHandler((object) this, __methodptr(\u003CNavigate\u003Eb__1))))));
      // ISSUE: method pointer
      Task.Run<IAsyncAction>((Func<IAsyncAction>) (() => ((DependencyObject) this.webView).Dispatcher.RunAsync((CoreDispatcherPriority) -1, new DispatchedHandler((object) this, __methodptr(\u003CNavigate\u003Eb__3_3)))));
    }

    public void InvokeScript(string scriptName, params string[] args)
    {
      DispatchedHandler dispatchedHandler;
      // ISSUE: method pointer
      Task.Run<IAsyncAction>((Func<IAsyncAction>) (() => ((DependencyObject) this.webView).Dispatcher.RunAsync((CoreDispatcherPriority) -1, dispatchedHandler ?? (dispatchedHandler = new DispatchedHandler((object) this, __methodptr(\u003CInvokeScript\u003Eb__1))))));
    }

    public event EventHandler LoadCompleted;

    private void webBrowser_NavigationCompleted(
      WebView sender,
      WebViewNavigationCompletedEventArgs args)
    {
      this.IsNavigateSuccessful = true;
      if (this.LoadCompleted == null)
        return;
      this.LoadCompleted((object) sender, (EventArgs) null);
    }

    public bool IsNavigateSuccessful { get; private set; }
  }
}
