// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising.MicrosoftAdvertisingAdAdapter
// Assembly: Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E5DA0355-9146-4692-8FC1-7265B05C19F2
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising.dll

using Microsoft.AdMediator.Core;
using Microsoft.AdMediator.Core.Display;
using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.AdMediator.WindowsPhone81.MicrosoftAdvertising
{
  internal sealed class MicrosoftAdvertisingAdAdapter : BaseAdAdapter, IAdAdapter, IDisposable
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (MicrosoftAdvertisingAdAdapter));
    private const string ApplicationIdKey = "ApplicationId";
    private const string AdUnitIdKey = "AdUnitId";
    private const string AdClickedEventName = "IsEngagedChanged";
    private const string IsHouseKey = "IsHouse";
    private static readonly ICollection<string> RequiredParameters = (ICollection<string>) new string[2]
    {
      "ApplicationId",
      "AdUnitId"
    };
    private static readonly ICollection<string> UserParameterExclusionList = (ICollection<string>) new string[8]
    {
      "ApplicationId",
      "AdUnitId",
      "Latitude",
      "Longitude",
      "IsAutoCollapseEnabled",
      "IsAutoRefreshEnabled",
      "IsEngaged",
      "IsSuspended"
    };
    private static readonly IDictionary<string, AdMediatorErrorCode> ErrorCodeMap;
    private static readonly TimeSpan MinimumRefreshRate;
    private AdRefreshTimer adRefreshTimer;
    private double height;
    private double width;
    private bool isHouse;

    public MicrosoftAdvertisingAdAdapter(
      IUIElementWrapperFactory controlFactory,
      IPanelWrapper hostPanel,
      IParameterDictionary<string, string> configurationParameters,
      IParameterDictionary<string, object> userParameters)
      : base(controlFactory, hostPanel, configurationParameters, userParameters)
    {
      this.isHouse = this.AdControlParameters.ContainsKey("IsHouse") && this.AdControlParameters["IsHouse"].Equals("true", StringComparison.OrdinalIgnoreCase);
    }

    protected override string ErrorEventName => "ErrorOccurred";

    protected override string LoadedEventName => "AdRefreshed";

    protected virtual ICollection<string> ParameterExclusionList => MicrosoftAdvertisingAdAdapter.UserParameterExclusionList;

    public override string Name => !this.isHouse ? "MicrosoftAdvertising" : "MicrosoftAdvertisingHouse";

    public virtual void Start(TimeSpan refreshInterval)
    {
      if (this.AdControl != null)
      {
        this.UpdateControlSize();
        this.ShowControl();
      }
      else
      {
        this.ValidateParameters(MicrosoftAdvertisingAdAdapter.RequiredParameters);
        this.LoadControl(typeof (Microsoft.Advertising.WinRT.UI.AdControl).AssemblyQualifiedName, refreshInterval);
        this.SetOptionalParameters();
        this.SetLocation();
        this.DisplayControl();
      }
    }

    public override void Pause()
    {
      if (this.adRefreshTimer == null)
        return;
      this.adRefreshTimer.Pause();
    }

    public override void Resume()
    {
      if (this.adRefreshTimer == null)
        return;
      this.adRefreshTimer.Resume();
    }

    protected override string ErrorCodeParameterName => "ErrorCode";

    protected override string ErrorMessageParameterName => "ErrorMessage";

    protected virtual IDictionary<string, AdMediatorErrorCode> InternalToGlobalErrorCodeMap => MicrosoftAdvertisingAdAdapter.ErrorCodeMap;

    protected override void HideControlPreAction() => this.Pause();

    protected override void ShowControlPostAction() => this.Resume();

    protected virtual object InstantiateControl(TimeSpan refreshInterval)
    {
      string controlParameter1 = this.AdControlParameters["ApplicationId"];
      string controlParameter2 = this.AdControlParameters["AdUnitId"];
      try
      {
        this.height = ((FrameworkElement) (this.HostPanel.Control as Panel)).ActualHeight;
        this.width = ((FrameworkElement) (this.HostPanel.Control as Panel)).ActualWidth;
      }
      catch (Exception ex)
      {
        throw new AdSdkException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Error while fetching height/width of the admediator control: {0}", (object) ex.Message));
      }
      MicrosoftAdvertisingAdAdapter.Log.Trace("Creating MSA adapter with width {0} height {1}", (object) this.width, (object) this.height);
      Microsoft.Advertising.WinRT.UI.AdControl adControl1 = new Microsoft.Advertising.WinRT.UI.AdControl()
      {
        ApplicationId = controlParameter1,
        AdUnitId = controlParameter2,
        IsAutoRefreshEnabled = false
      };
      ((FrameworkElement) adControl1).put_Width(this.width);
      ((FrameworkElement) adControl1).put_Height(this.height);
      ((FrameworkElement) adControl1).put_Width(this.width);
      ((FrameworkElement) adControl1).put_Height(this.height);
      double width1 = ((FrameworkElement) adControl1).Width;
      double width2 = ((FrameworkElement) adControl1).Width;
      double height1 = ((FrameworkElement) adControl1).Height;
      double height2 = ((FrameworkElement) adControl1).Height;
      if (width2 <= 0.0 || height2 <= 0.0)
        MicrosoftAdvertisingAdAdapter.Log.Error("Control dimensions {0}x{1} are not valid. Expected {2}x{3}", (object) width2, (object) height2, (object) this.width, (object) this.height);
      Microsoft.Advertising.WinRT.UI.AdControl adControl2 = adControl1;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<RoutedEventArgs>>(new Func<EventHandler<RoutedEventArgs>, EventRegistrationToken>(adControl2.add_AdRefreshed), new Action<EventRegistrationToken>(adControl2.remove_AdRefreshed), new EventHandler<RoutedEventArgs>(this.OnAdRefreshed));
      Microsoft.Advertising.WinRT.UI.AdControl adControl3 = adControl1;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<AdErrorEventArgs>>(new Func<EventHandler<AdErrorEventArgs>, EventRegistrationToken>(adControl3.add_ErrorOccurred), new Action<EventRegistrationToken>(adControl3.remove_ErrorOccurred), new EventHandler<AdErrorEventArgs>(this.OnErrorOccurred));
      Microsoft.Advertising.WinRT.UI.AdControl adControl4 = adControl1;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<RoutedEventArgs>>(new Func<EventHandler<RoutedEventArgs>, EventRegistrationToken>(adControl4.add_IsEngagedChanged), new Action<EventRegistrationToken>(adControl4.remove_IsEngagedChanged), (EventHandler<RoutedEventArgs>) ((sender, e) => this.OnSdkEvent("IsEngagedChanged", sender, (object) e)));
      if (this.isHouse)
        adControl1.AddAdTag("isHouse", "1");
      this.SetupTimer(refreshInterval);
      return (object) adControl1;
    }

    private void UpdateControlSize() => this.RunOnDispatcher((Action) (() =>
    {
      if (!(this.AdControl.Control is Microsoft.Advertising.WinRT.UI.AdControl control2) || ((FrameworkElement) control2).Height > 0.0 && ((FrameworkElement) control2).Width > 0.0)
        return;
      MicrosoftAdvertisingAdAdapter.Log.Warning("Control dimensions {0}x{1} are not valid. Updating to {2}x{3}", (object) ((FrameworkElement) control2).Width, (object) ((FrameworkElement) control2).Height, (object) this.width, (object) this.height);
      if (((FrameworkElement) control2).Width <= 0.0)
        ((FrameworkElement) control2).put_Width(this.width);
      if (((FrameworkElement) control2).Height > 0.0)
        return;
      ((FrameworkElement) control2).put_Height(this.height);
    }));

    protected virtual Type GetControlType(string typeName) => typeof (Microsoft.Advertising.WinRT.UI.AdControl);

    protected override void SetLocation() => this.RunOnDispatcher((Action) (() =>
    {
      if (!(this.AdControl.Control is Microsoft.Advertising.WinRT.UI.AdControl control2) || this.Location == null)
        return;
      control2.Latitude = this.Location.Latitude;
      control2.Longitude = this.Location.Longitude;
    }));

    private void RefreshAd()
    {
      MicrosoftAdvertisingAdAdapter.Log.Trace("About to refresh microsoft ads");
      Microsoft.Advertising.WinRT.UI.AdControl adControl = this.AdControl.Control as Microsoft.Advertising.WinRT.UI.AdControl;
      if (adControl == null)
        return;
      if (((DependencyObject) adControl).Dispatcher.HasThreadAccess)
        this.RefreshAd(adControl);
      else
        this.RunOnDispatcher((Action) (() => this.RefreshAd(adControl)));
    }

    private void RefreshAd(Microsoft.Advertising.WinRT.UI.AdControl adControl) => adControl?.Refresh();

    private void SetupTimer(TimeSpan adRefreshInterval) => this.adRefreshTimer = new AdRefreshTimer(adRefreshInterval, MicrosoftAdvertisingAdAdapter.MinimumRefreshRate, new Action(this.RefreshAd));

    protected override void AdControlCreated() => this.adRefreshTimer.Start();

    private void ResetTimerOnCallback() => this.adRefreshTimer.Reset();

    private void OnErrorOccurred(object sender, AdErrorEventArgs e)
    {
      if (this.AdControl.Control is Microsoft.Advertising.WinRT.UI.AdControl control)
        MicrosoftAdvertisingAdAdapter.Log.Information("Failed to load ad with size {0}x{1}. ErrorCode {2} ErrorMessage: {3}", (object) ((FrameworkElement) control).ActualWidth, (object) ((FrameworkElement) control).ActualHeight, (object) e.ErrorCode, (object) e.ErrorMessage);
      this.ResetTimerOnCallback();
      this.OnAdLoadingError(sender, (object) e);
    }

    private void OnAdRefreshed(object sender, RoutedEventArgs e)
    {
      if (this.AdControl.Control is Microsoft.Advertising.WinRT.UI.AdControl control)
        MicrosoftAdvertisingAdAdapter.Log.Information("Loaded ad with size {0}x{1}", (object) ((FrameworkElement) control).ActualWidth, (object) ((FrameworkElement) control).ActualHeight);
      this.ResetTimerOnCallback();
      this.OnAdLoaded(sender, (object) e);
    }

    public void Dispose()
    {
      if (this.adRefreshTimer == null)
        return;
      this.adRefreshTimer.Dispose();
      this.adRefreshTimer = (AdRefreshTimer) null;
    }

    static MicrosoftAdvertisingAdAdapter()
    {
      Dictionary<string, AdMediatorErrorCode> dictionary = new Dictionary<string, AdMediatorErrorCode>();
      dictionary.Add("Unknown", AdMediatorErrorCode.Unknown);
      dictionary.Add("NoAdAvailable", AdMediatorErrorCode.NoAdAvailable);
      dictionary.Add("NetworkConnectionFailure", AdMediatorErrorCode.NetworkFailure);
      dictionary.Add("ClientConfiguration", AdMediatorErrorCode.ClientConfiguration);
      dictionary.Add("ServerSideError", AdMediatorErrorCode.ServerSideError);
      dictionary.Add("InvalidServerResponse", AdMediatorErrorCode.InvalidServerResponse);
      dictionary.Add("Other", AdMediatorErrorCode.Unknown);
      dictionary.Add("RefreshNotAllowed", AdMediatorErrorCode.RefreshNotAllowed);
      dictionary.Add("CreativeError", AdMediatorErrorCode.CreativeError);
      dictionary.Add("MraidOperationFailure", AdMediatorErrorCode.MraidOperationFailure);
      dictionary.Add("Cancelled", AdMediatorErrorCode.Canceled);
      dictionary.Add("FileOperationFailure", AdMediatorErrorCode.FileOperationFailure);
      dictionary.Add("ParseToBOMFailure", AdMediatorErrorCode.ParseToBOMFailure);
      dictionary.Add("ValidationFailure", AdMediatorErrorCode.ValidationFailure);
      MicrosoftAdvertisingAdAdapter.ErrorCodeMap = (IDictionary<string, AdMediatorErrorCode>) dictionary;
      MicrosoftAdvertisingAdAdapter.MinimumRefreshRate = TimeSpan.FromSeconds(30.0);
    }
  }
}
