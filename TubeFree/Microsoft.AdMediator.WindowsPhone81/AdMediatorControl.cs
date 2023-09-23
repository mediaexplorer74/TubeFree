// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.AdMediatorControl
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core;
using Microsoft.AdMediator.Core.Display;
using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Exceptions;
using Microsoft.AdMediator.Core.Handlers;
using Microsoft.AdMediator.Core.Managers;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using Microsoft.AdMediator.WindowsPhone81.Display;
using Microsoft.AdMediator.WindowsPhone81.Handlers;
using Microsoft.AdMediator.WindowsPhone81.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.AdMediator.WindowsPhone81
{
  public class AdMediatorControl : Control, IAdMediatorControl, IDisposable
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (AdMediatorControl));
    private const string AdControlGridName = "AdMediatorLayoutRoot";
    private readonly Dictionary<string, string> assemblyNameMapping;
    private readonly CoreManager coreManager;
    private readonly AdMediatorConfiguration fallbackConfiguration;
    private bool disposed;

    public AdMediatorControl()
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      dictionary.Add("AdDuplex", "Microsoft.AdMediator.WindowsPhone81.AdDuplex.AdDuplexAdAdapter, Microsoft.AdMediator.WindowsPhone81.AdDuplex");
      dictionary.Add("MicrosoftAdvertising", "Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising.MicrosoftAdvertisingAdAdapter, Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising");
      dictionary.Add("Smaato", "Microsoft.AdMediator.WindowsPhone81.Smaato.SmaatoAdAdapter, Microsoft.AdMediator.WindowsPhone81.Smaato");
      dictionary.Add("MicrosoftAdvertisingHouse", "Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising.MicrosoftAdvertisingAdAdapter, Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising");
      dictionary.Add("Vserv", "Microsoft.AdMediator.WindowsPhone81.Vserv.VservAdAdapter, Microsoft.AdMediator.WindowsPhone81.Vserv");
      this.assemblyNameMapping = dictionary;
      AdMediatorConfiguration mediatorConfiguration = new AdMediatorConfiguration();
      mediatorConfiguration.RefreshRate = new int?(30);
      BaseConfiguration baseConfiguration = new BaseConfiguration();
      List<AdAdapterInfo> adAdapterInfoList = new List<AdAdapterInfo>();
      AdAdapterInfo adAdapterInfo = new AdAdapterInfo();
      adAdapterInfo.Name = "MicrosoftAdvertising";
      adAdapterInfo.Weight = new int?(1);
      List<AdAdapterProperty> adAdapterPropertyList = new List<AdAdapterProperty>();
      adAdapterPropertyList.Add(new AdAdapterProperty()
      {
        Key = "ApplicationId",
        Value = "3f83fe91-d6be-434d-a0ae-7351c5a997f1"
      });
      adAdapterPropertyList.Add(new AdAdapterProperty()
      {
        Key = "AdUnitId",
        Value = "10865270"
      });
      adAdapterInfo.Metadata = (IList<AdAdapterProperty>) adAdapterPropertyList;
      adAdapterInfoList.Add(adAdapterInfo);
      baseConfiguration.AdAdapters = (IList<AdAdapterInfo>) adAdapterInfoList;
      mediatorConfiguration.BaseConfiguration = baseConfiguration;
      this.fallbackConfiguration = mediatorConfiguration;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      this.put_DefaultStyleKey((object) typeof (AdMediatorControl));
      this.AdSdkOptionalParameters = new AdSdkParameters();
      this.AdSdkTimeouts = (IDictionary<string, TimeSpan>) new Dictionary<string, TimeSpan>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      this.coreManager = new CoreManager(new Func<IAdMediatorCore>(this.InitializeAdMediatorCore));
    }

    public string Id { get; set; }

    public AdSdkParameters AdSdkOptionalParameters { get; private set; }

    public IDictionary<string, TimeSpan> AdSdkTimeouts { get; private set; }

    public event EventHandler<AdSdkEventArgs> AdMediatorFilled;

    public event EventHandler<AdSdkEventArgs> AdSdkEvent;

    public event EventHandler<AdFailedEventArgs> AdSdkError;

    public event EventHandler<AdMediatorFailedEventArgs> AdMediatorError;

    public event EventHandler<AdSdkEventArgs> PauseForInterstitialEvent;

    public event EventHandler<AdSdkEventArgs> ResumeForInterstitialEvent;

    public void Disable() => this.coreManager.Disable();

    public void Pause() => this.coreManager.Pause();

    public void Resume() => this.coreManager.Resume();

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    internal void Load() => this.coreManager.Start();

    internal void Unload() => this.coreManager.Unload();

    private void HandleAdMediatorExceptions(Exception exception)
    {
      AdMediatorErrorCode mediatorErrorCode = AdMediatorErrorCode.Unknown;
      switch (exception)
      {
        case AdMediatorNotStartedException _:
          mediatorErrorCode = AdMediatorErrorCode.AdMediatorNotStarted;
          break;
        case AdMediatorNotLoadedException _:
          mediatorErrorCode = AdMediatorErrorCode.AdMediatorNotLoaded;
          break;
      }
      this.OnAdMediatorFailed((object) this, new AdMediatorFailedEventArgs()
      {
        Error = exception,
        ErrorCode = mediatorErrorCode
      });
    }

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      if (DesignMode.DesignModeEnabled)
        return;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Loaded), new RoutedEventHandler(this.OnLoaded));
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Unloaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Unloaded), new RoutedEventHandler(this.OnUnloaded));
      try
      {
        this.Load();
      }
      catch (Exception ex)
      {
        this.HandleAdMediatorExceptions(ex);
      }
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      try
      {
        this.Load();
      }
      catch (Exception ex)
      {
        this.HandleAdMediatorExceptions(ex);
      }
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
      try
      {
        this.Unload();
      }
      catch (Exception ex)
      {
        this.HandleAdMediatorExceptions(ex);
      }
    }

    private IAdMediatorCore InitializeAdMediatorCore()
    {
      AdMediatorControl.Log.Information("Ad Mediator starting Id: {0} Name: {1} Width: {2}, Height {3}", (object) this.Id, (object) ((FrameworkElement) this).Name, (object) ((FrameworkElement) this).Width, (object) ((FrameworkElement) this).Height);
      if (!(this.GetTemplateChild("AdMediatorLayoutRoot") is Panel templateChild))
        throw new AdMediatorNotLoadedException("AdMediator is not loaded, cannot start.");
      Window current = Window.Current;
      WindowsRuntimeMarshal.AddEventHandler<WindowVisibilityChangedEventHandler>(new Func<WindowVisibilityChangedEventHandler, EventRegistrationToken>(current.add_VisibilityChanged), new Action<EventRegistrationToken>(current.remove_VisibilityChanged), new WindowVisibilityChangedEventHandler(this.VisibilityChanged));
      IsolatedStoragePathBuilder isolatedStoragePathBuilder = new IsolatedStoragePathBuilder();
      PersistentStorage persistentStorage = new PersistentStorage((IIsolatedStoragePathBuilder) isolatedStoragePathBuilder);
      DataContractSerializerHelper configSerializer1 = new DataContractSerializerHelper();
      JsonDataContractSerializerHelper serializerHelper1 = new JsonDataContractSerializerHelper();
      WindowsPhone81WebRequester phone81WebRequester = new WindowsPhone81WebRequester();
      DataContractSerializerHelper configSerializer2 = configSerializer1;
      JsonDataContractSerializerHelper stateSerializer = serializerHelper1;
      FileHandler fileHandler = new FileHandler((IPersistentStorage) persistentStorage, (ISerializer) configSerializer2, (ISerializer) stateSerializer);
      JsonDataContractSerializerHelper serializerHelper2 = new JsonDataContractSerializerHelper();
      IContextHandler contextHandler = (IContextHandler) new ContextHandler();
      IStateManager stateManager = (IStateManager) new StateManager((IFileHandler) fileHandler, contextHandler, this.Id, ((FrameworkElement) this).Name);
      isolatedStoragePathBuilder.StateManager = stateManager;
      IEventLogger eventLogger = (IEventLogger) new JsllEventLogger((IBrowserFactory) new BrowserFactory(), (ISerializer) serializerHelper2, stateManager);
      IConfigurationParser configurationParser = (IConfigurationParser) new ConfigurationParser(contextHandler.Market);
      ConfigurationManager aConfigurationManager = new ConfigurationManager((IFileHandler) fileHandler, (ISerializer) configSerializer1, configurationParser, eventLogger, stateManager, (WebRequester) phone81WebRequester, this.fallbackConfiguration);
      ReflectionAdAdapterProvider adAdapterProvider = new ReflectionAdAdapterProvider((IPanelWrapper) new WindowsPhone81Panel(templateChild), (IDictionary<string, string>) this.assemblyNameMapping, (IUIElementWrapperFactory) new UIElementWrapperFactory());
      LocationHandler locationHandler = new LocationHandler();
      ConfigurationUpdater instance = ConfigurationUpdater.GetInstance((IConfigurationManager) aConfigurationManager);
      AdMediatorCore adMediatorCore = new AdMediatorCore(this.Id, (IAdAdapterProvider) adAdapterProvider, (IConfigurationManager) aConfigurationManager, stateManager, this.AdSdkOptionalParameters, (ILocationHandler) locationHandler, eventLogger, this.AdSdkTimeouts, (IConfigurationUpdater) instance);
      adMediatorCore.AdSdkError += new EventHandler<AdFailedEventArgs>(this.OnAdFailed);
      adMediatorCore.AdFilled += new EventHandler<AdSdkEventArgs>(this.OnAdFilled);
      adMediatorCore.AdMediatorError += new EventHandler<AdMediatorFailedEventArgs>(this.OnAdMediatorFailed);
      adMediatorCore.AdSdkEvent += new EventHandler<AdSdkEventArgs>(this.OnAdClicked);
      adMediatorCore.PauseForInterstitialEvent += new EventHandler<AdSdkEventArgs>(this.OnPauseForInterstitial);
      adMediatorCore.ResumeForInterstitialEvent += new EventHandler<AdSdkEventArgs>(this.OnResumeForInterstitial);
      return (IAdMediatorCore) adMediatorCore;
    }

    private void VisibilityChanged(object sender, VisibilityChangedEventArgs e)
    {
      if (e.Visible)
        this.coreManager.Resume();
      else
        this.coreManager.Pause();
    }

    private void OnAdFilled(object sender, AdSdkEventArgs adControlEventArgs)
    {
      AdMediatorControl.Log.Information("Ad filled by adapter {0}", (object) adControlEventArgs.Name);
      this.OnEvent<AdSdkEventArgs>(this.AdMediatorFilled, adControlEventArgs);
    }

    private void OnAdMediatorFailed(object sender, AdMediatorFailedEventArgs adControlEventArgs)
    {
      AdMediatorControl.Log.Error(adControlEventArgs.Error, "Ad mediator failed", new object[0]);
      this.OnEvent<AdMediatorFailedEventArgs>(this.AdMediatorError, adControlEventArgs);
    }

    private void OnAdFailed(object sender, AdFailedEventArgs adControlEventArgs)
    {
      AdMediatorControl.Log.Warning(adControlEventArgs.Error, "Ad failed by adapter {0}", new object[1]
      {
        (object) adControlEventArgs.Name
      });
      this.OnEvent<AdFailedEventArgs>(this.AdSdkError, adControlEventArgs);
    }

    private void OnAdClicked(object sender, AdSdkEventArgs adControlEventArgs)
    {
      AdMediatorControl.Log.Information("Ad clicked on adapter {0}", (object) adControlEventArgs.Name);
      this.OnEvent<AdSdkEventArgs>(this.AdSdkEvent, adControlEventArgs);
    }

    private void OnPauseForInterstitial(object sender, AdSdkEventArgs adControlEventArgs)
    {
      AdMediatorControl.Log.Information("Pause for interstitial event on adapter {0}", (object) adControlEventArgs.Name);
      this.OnEvent<AdSdkEventArgs>(this.PauseForInterstitialEvent, adControlEventArgs);
    }

    private void OnResumeForInterstitial(object sender, AdSdkEventArgs adControlEventArgs)
    {
      AdMediatorControl.Log.Information("Resume for interstitial event on adapter {0}", (object) adControlEventArgs.Name);
      this.OnEvent<AdSdkEventArgs>(this.ResumeForInterstitialEvent, adControlEventArgs);
    }

    private void OnEvent<T>(EventHandler<T> handler, T adControlEventArgs)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      AdMediatorControl.\u003C\u003Ec__DisplayClass55_0<T> cDisplayClass550 = new AdMediatorControl.\u003C\u003Ec__DisplayClass55_0<T>();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass550.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass550.handler = handler;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass550.adControlEventArgs = adControlEventArgs;
      if (((DependencyObject) this).Dispatcher.HasThreadAccess)
      {
        // ISSUE: reference to a compiler-generated field
        if (cDisplayClass550.handler == null)
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass550.handler((object) this, cDisplayClass550.adControlEventArgs);
      }
      else
      {
        // ISSUE: method pointer
        ((DependencyObject) this).Dispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) cDisplayClass550, __methodptr(\u003COnEvent\u003Eb__0)));
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
      {
        WindowsRuntimeMarshal.RemoveEventHandler<WindowVisibilityChangedEventHandler>(new Action<EventRegistrationToken>(Window.Current.remove_VisibilityChanged), new WindowVisibilityChangedEventHandler(this.VisibilityChanged));
        this.coreManager.Dispose();
      }
      this.disposed = true;
    }

    ~AdMediatorControl()
    {
      try
      {
        this.Dispose(false);
      }
      finally
      {
        // ISSUE: explicit finalizer call
        // ISSUE: explicit non-virtual call
        __nonvirtual (((object) this).Finalize());
      }
    }
  }
}
