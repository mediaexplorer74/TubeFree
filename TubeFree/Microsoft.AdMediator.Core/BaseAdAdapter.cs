// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.BaseAdAdapter
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Display;
using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace Microsoft.AdMediator.Core
{
  internal abstract class BaseAdAdapter : IAdAdapter
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (BaseAdAdapter));

    protected BaseAdAdapter(
      IUIElementWrapperFactory controlFactory,
      IPanelWrapper hostPanel,
      IParameterDictionary<string, string> configurationParameters,
      IParameterDictionary<string, object> userParameters)
    {
      if (configurationParameters == null)
        throw new ArgumentNullException(nameof (configurationParameters));
      if (userParameters == null)
        throw new ArgumentNullException(nameof (userParameters));
      this.AdControlParameters = configurationParameters;
      this.UserParameters = userParameters;
      this.UserParameters.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnParametersChanged);
      this.HostPanel = hostPanel;
      this.ParameterExclusionList = (ICollection<string>) new List<string>();
      this.ControlFactory = controlFactory;
    }

    protected abstract string ErrorEventName { get; }

    protected abstract string LoadedEventName { get; }

    protected virtual string ErrorCodeParameterName => (string) null;

    protected virtual string ExceptionParameterName => (string) null;

    protected virtual string ErrorMessageParameterName => (string) null;

    protected virtual IDictionary<string, AdMediatorErrorCode> InternalToGlobalErrorCodeMap => (IDictionary<string, AdMediatorErrorCode>) null;

    protected virtual ICollection<string> ParameterExclusionList { get; private set; }

    protected Type AdControlType { get; private set; }

    protected virtual string OnErrorEventName => "OnAdLoadingError";

    protected virtual string OnLoadedEventName => "OnAdLoaded";

    protected IUIElementWrapper AdControl { get; private set; }

    protected IPanelWrapper HostPanel { get; private set; }

    private IUIElementWrapperFactory ControlFactory { get; set; }

    public IParameterDictionary<string, object> UserParameters { get; private set; }

    public IParameterDictionary<string, string> AdControlParameters { get; private set; }

    public event EventHandler<AdSdkEventArgs> AdFilled;

    public event EventHandler<AdFailedEventArgs> AdError;

    public event EventHandler<AdSdkEventArgs> AdSdkEvent;

    public event EventHandler<AdSdkEventArgs> PauseForInterstitialEvent;

    public event EventHandler<AdSdkEventArgs> ResumeForInterstitialEvent;

    public Location Location { get; set; }

    public abstract string Name { get; }

    public virtual void StopExecution() => this.HideControl();

    public abstract void Start(TimeSpan refreshInterval);

    protected virtual void SetOptionalParameters()
    {
      foreach (string key in (IEnumerable<string>) this.UserParameters.Keys)
      {
        if (!this.ParameterExclusionList.Contains(key))
          this.SetParameter(key, this.UserParameters[key]);
      }
    }

    protected virtual void SetLocation()
    {
    }

    protected virtual void ValidateParameters(ICollection<string> requiredParameters)
    {
      if (requiredParameters == null)
        throw new ArgumentNullException(nameof (requiredParameters));
      List<string> values = new List<string>();
      foreach (string requiredParameter in (IEnumerable<string>) requiredParameters)
      {
        if (!this.AdControlParameters.ContainsKey(requiredParameter))
          values.Add(requiredParameter);
      }
      if (values.Count <= 0)
        return;
      this.OnParameterException((Exception) new AdSdkException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Missing required parameters: {0}", (object) string.Join(", ", (IEnumerable<string>) values))));
    }

    protected void LoadControl(string typeName, TimeSpan refreshInterval)
    {
      this.AdControlType = this.GetControlType(typeName);
      this.RunOnDispatcher((Action) (() =>
      {
        this.AdControl = this.ControlFactory.CreateControl(this.InstantiateControl(refreshInterval), this.AdControlType);
        this.AdControlCreated();
      }));
    }

    protected virtual void AdControlCreated()
    {
    }

    protected virtual object InstantiateControl(TimeSpan refreshInterval)
    {
      BaseAdAdapter.Log.Trace("About to instantiate control for adapter {0}", (object) this.Name);
      return Activator.CreateInstance(this.AdControlType);
    }

    protected virtual Type GetControlType(string typeName)
    {
      try
      {
        return BaseAdAdapter.LoadType(typeName);
      }
      catch (Exception ex)
      {
        throw new AdSdkException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Type {0} not found for adapter {1}", (object) typeName, (object) this.Name));
      }
    }

    protected static Type LoadType(string typeName) => Type.GetType(typeName) ?? throw new AdSdkException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Type {0} not found", (object) typeName));

    protected void RunOnDispatcher(Action action) => this.HostPanel.RunOnDispatcher((Action) (() =>
    {
      try
      {
        action();
      }
      catch (Exception ex)
      {
        this.OnException(ex);
      }
    }));

    protected virtual void DisplayControl() => this.RunOnDispatcher((Action) (() =>
    {
      if (this.AdControl == null)
      {
        BaseAdAdapter.Log.Information("Control null for adapter {0}", (object) this.Name);
      }
      else
      {
        BaseAdAdapter.Log.Trace("About to display adapter {0}", (object) this.Name);
        this.HostPanel.AddChild(this.AdControl);
      }
    }));

    protected void RemoveControl() => this.RunOnDispatcher((Action) (() =>
    {
      if (this.AdControl == null)
      {
        BaseAdAdapter.Log.Information("Control null for adapter {0}", (object) this.Name);
      }
      else
      {
        BaseAdAdapter.Log.Trace("About to remove adapter {0}", (object) this.Name);
        this.RemoveControlPreAction();
        this.HostPanel.RemoveChild(this.AdControl);
      }
    }));

    protected void HideControl() => this.RunOnDispatcher((Action) (() =>
    {
      if (this.AdControl == null)
      {
        BaseAdAdapter.Log.Information("Control null for adapter {0}", (object) this.Name);
      }
      else
      {
        BaseAdAdapter.Log.Trace("About to hide adapter {0}", (object) this.Name);
        this.HideControlPreAction();
        this.AdControl.SetVisibility(false);
      }
    }));

    protected void ShowControl() => this.RunOnDispatcher((Action) (() =>
    {
      if (this.AdControl == null)
      {
        BaseAdAdapter.Log.Information("Control null for adapter {0}", (object) this.Name);
      }
      else
      {
        BaseAdAdapter.Log.Trace("About to show adapter {0}", (object) this.Name);
        this.AdControl.SetVisibility(true);
        this.ShowControlPostAction();
      }
    }));

    public virtual bool CanBeGarbageCollected() => true;

    public virtual void Release() => this.RemoveControl();

    public virtual void Pause()
    {
    }

    public virtual void Resume()
    {
    }

    protected virtual void ShowControlPostAction()
    {
    }

    protected virtual void HideControlPreAction()
    {
    }

    protected virtual void RemoveControlPreAction()
    {
    }

    protected void SetParameter(string parameterName, object value) => this.HostPanel.RunOnDispatcher((Action) (() =>
    {
      try
      {
        this.AdControl.SetParameter(parameterName, value);
      }
      catch (Exception ex)
      {
        this.OnParameterException(ex);
      }
    }));

    protected void CallMethod(string methodName, object[] args) => this.RunOnDispatcher((Action) (() => this.AdControl.CallMethod(methodName, args)));

    protected void AssignDelegate(
      string eventName,
      string eventHandlerName,
      Type eventHandlerClass,
      object eventHandler)
    {
      this.RunOnDispatcher((Action) (() => this.AdControl.AssignDelegate(eventName, eventHandlerName, eventHandlerClass, eventHandler)));
    }

    private void OnException(Exception exception)
    {
      if (this.AdError == null)
        return;
      EventHandler<AdFailedEventArgs> adError = this.AdError;
      AdFailedEventArgs e = new AdFailedEventArgs();
      e.Error = exception;
      e.Name = this.Name;
      e.ErrorCode = AdMediatorErrorCode.AdAdapterError;
      adError((object) this, e);
    }

    private void OnParameterException(Exception exception)
    {
      if (this.AdError == null)
        return;
      EventHandler<AdFailedEventArgs> adError = this.AdError;
      AdFailedEventArgs e = new AdFailedEventArgs();
      e.Error = exception;
      e.Name = this.Name;
      e.ErrorCode = AdMediatorErrorCode.AdSdkConfigurationError;
      adError((object) this, e);
    }

    protected void OnCustomAdLoadingError(string eventName, object sender, object eventArgs)
    {
      try
      {
        if (this.AdError == null)
          return;
        Type eventArgsType = (Type) null;
        if (eventArgs != null)
          eventArgsType = eventArgs.GetType();
        AdMediatorErrorCode adSdkErrorCode = this.GetAdSdkErrorCode(eventArgsType, eventArgs);
        Exception adSdkException = this.GetAdSdkException(eventArgsType, eventArgs);
        string description = this.GetAdSdkErrorMessage(eventArgsType, eventArgs);
        if (string.IsNullOrEmpty(description) && adSdkException != null)
          description = adSdkException.Message;
        this.OnCustomAdLoadingError(eventName, sender, eventArgs, adSdkErrorCode, adSdkException, description);
      }
      catch (Exception ex)
      {
        BaseAdAdapter.Log.Error(ex, "Failed to handle custom ad loading error");
      }
    }

    protected void OnCustomAdLoadingError(
      string eventName,
      object sender,
      object eventArgs,
      AdMediatorErrorCode adSdkErrorCode,
      Exception error,
      string description)
    {
      try
      {
        if (this.AdError == null)
          return;
        AdFailedEventArgs adFailedEventArgs = new AdFailedEventArgs();
        adFailedEventArgs.Name = this.Name;
        adFailedEventArgs.EventName = eventName;
        adFailedEventArgs.SdkEventArgs = eventArgs;
        adFailedEventArgs.ErrorCode = adSdkErrorCode;
        adFailedEventArgs.Error = error;
        adFailedEventArgs.ErrorDescription = description;
        AdFailedEventArgs e = adFailedEventArgs;
        this.AdError(sender, e);
      }
      catch (Exception ex)
      {
        BaseAdAdapter.Log.Error(ex, "Failed to fire custom ad loading error");
      }
    }

    protected AdMediatorErrorCode GetAdSdkErrorCode(Type eventArgsType, object eventArgs)
    {
      if (eventArgsType == null || string.IsNullOrEmpty(this.ErrorCodeParameterName) || this.InternalToGlobalErrorCodeMap == null)
        return AdMediatorErrorCode.Unknown;
      object propertyValue = ReflectionHelper.GetPropertyValue(eventArgsType, eventArgs, this.ErrorCodeParameterName);
      if (propertyValue == null)
      {
        BaseAdAdapter.Log.Error("Unable to obtain mapped error code because property with name {0} was null.", (object) this.ErrorCodeParameterName);
        return AdMediatorErrorCode.Unknown;
      }
      string key = propertyValue.ToString();
      if (this.InternalToGlobalErrorCodeMap.ContainsKey(key))
        return this.InternalToGlobalErrorCodeMap[key];
      BaseAdAdapter.Log.Error("No mapped error code value for property {0} from eventArgsType {1} and ErrorCodeParameterName {2}.", (object) key, (object) eventArgsType, (object) this.ErrorCodeParameterName);
      return AdMediatorErrorCode.Unknown;
    }

    private Exception GetAdSdkException(Type eventArgsType, object eventArgs)
    {
      if (eventArgsType == null || string.IsNullOrEmpty(this.ExceptionParameterName))
        return (Exception) null;
      object propertyValue = ReflectionHelper.GetPropertyValue(eventArgsType, eventArgs, this.ExceptionParameterName);
      if (propertyValue == null)
      {
        BaseAdAdapter.Log.Error("Property for exception was null (name): {0}", (object) this.ExceptionParameterName);
        return (Exception) null;
      }
      if (!(propertyValue is Exception adSdkException))
        BaseAdAdapter.Log.Error("Property for exception was not an exception: {0}", (object) this.ExceptionParameterName);
      return adSdkException;
    }

    private string GetAdSdkErrorMessage(Type eventArgsType, object eventArgs)
    {
      if (eventArgsType == null || string.IsNullOrEmpty(this.ErrorMessageParameterName))
        return string.Empty;
      object propertyValue = ReflectionHelper.GetPropertyValue(eventArgsType, eventArgs, this.ErrorMessageParameterName);
      if (propertyValue == null)
      {
        BaseAdAdapter.Log.Error("Property for description was null (name): {0}", (object) this.ErrorMessageParameterName);
        return (string) null;
      }
      if (!(propertyValue is string adSdkErrorMessage))
        BaseAdAdapter.Log.Error("Property for descritpion was not a string: {0}", (object) this.ErrorMessageParameterName);
      return adSdkErrorMessage;
    }

    protected void OnCustomAdLoaded(string eventName, object sender, object eventArgs)
    {
      try
      {
        if (this.AdFilled == null)
          return;
        this.AdFilled(sender, new AdSdkEventArgs()
        {
          Name = this.Name,
          EventName = eventName,
          SdkEventArgs = eventArgs
        });
      }
      catch (Exception ex)
      {
        BaseAdAdapter.Log.Error(ex, "Failed to fire ad-loaded event");
      }
    }

    protected void OnAdLoadingError(object sender, object eventArgs) => this.OnCustomAdLoadingError(this.ErrorEventName, sender, eventArgs);

    protected void OnAdLoaded(object sender, object eventArgs) => this.OnCustomAdLoaded(this.LoadedEventName, sender, eventArgs);

    protected void OnSdkEvent(string eventName, object sender, object eventArgs)
    {
      if (this.AdSdkEvent == null)
        return;
      this.AdSdkEvent(sender, new AdSdkEventArgs()
      {
        Name = this.Name,
        EventName = eventName,
        SdkEventArgs = eventArgs
      });
    }

    protected void OnPauseForInterstitial(string eventName, object sender, object eventArgs)
    {
      if (this.PauseForInterstitialEvent == null)
        return;
      this.PauseForInterstitialEvent(sender, new AdSdkEventArgs()
      {
        Name = this.Name,
        EventName = eventName,
        SdkEventArgs = eventArgs
      });
    }

    protected void OnResumeForInterstitial(string eventName, object sender, object eventArgs)
    {
      if (this.ResumeForInterstitialEvent == null)
        return;
      this.ResumeForInterstitialEvent(sender, new AdSdkEventArgs()
      {
        Name = this.Name,
        EventName = eventName,
        SdkEventArgs = eventArgs
      });
    }

    private void OnParametersChanged(
      object sender,
      NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      if (notifyCollectionChangedEventArgs.Action != NotifyCollectionChangedAction.Add && notifyCollectionChangedEventArgs.Action != NotifyCollectionChangedAction.Replace || this.AdControl == null)
        return;
      foreach (KeyValuePair<string, object> newItem in (IEnumerable) notifyCollectionChangedEventArgs.NewItems)
      {
        if (!this.ParameterExclusionList.Contains(newItem.Key))
          this.SetParameter(newItem.Key, newItem.Value);
      }
    }
  }
}
