// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Events.JsllEventLogger
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Managers;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Events
{
  internal class JsllEventLogger : IEventLogger
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (JsllEventLogger));
    private const int MaxErrorLength = 1000;
    private static readonly SemaphoreSlim JsllInitializationSemaphore = new SemaphoreSlim(1, 1);
    private static IBrowser jsllSingletonBrowser;
    private readonly IBrowserFactory browserFactory;
    private readonly ISerializer serializer;
    private readonly IStateManager stateManager;

    public JsllEventLogger(
      IBrowserFactory browserFactory,
      ISerializer serializer,
      IStateManager stateManager)
    {
      this.browserFactory = browserFactory;
      this.serializer = serializer;
      this.stateManager = stateManager;
    }

    public async Task Initialize() => await JsllEventLogger.InitializeSingletonJsllBrowser(this.browserFactory);

    private static async Task InitializeSingletonJsllBrowser(IBrowserFactory browserFactory)
    {
      if (JsllEventLogger.jsllSingletonBrowser != null)
        return;
      await JsllEventLogger.JsllInitializationSemaphore.WaitAsync();
      try
      {
        if (JsllEventLogger.jsllSingletonBrowser != null)
          return;
        IBrowser browser = await browserFactory.CreateBrowser();
        browser.Navigate(new Uri("https://admediatorcdn.windowsphone.com/jsll/index.html"));
        JsllEventLogger.jsllSingletonBrowser = browser;
      }
      finally
      {
        JsllEventLogger.JsllInitializationSemaphore.Release();
      }
    }

    public void AdFilled(AdSdkEventArgs sucesssEventArgs, IEnumerable<AdFailedEventArgs> failedSdks) => this.SendSdkEvent(nameof (AdFilled), sucesssEventArgs.Name, failedSdks.Select<AdFailedEventArgs, SdkError>(new Func<AdFailedEventArgs, SdkError>(this.Convert)), (string) null);

    public void AdMediatorError(
      AdMediatorFailedEventArgs adMediatorError,
      IEnumerable<AdFailedEventArgs> failedSdks)
    {
      this.SendSdkEvent(nameof (AdMediatorError), (string) null, failedSdks.Select<AdFailedEventArgs, SdkError>(new Func<AdFailedEventArgs, SdkError>(this.Convert)), JsllEventLogger.GetEventErrorText(adMediatorError.Error));
    }

    public void LogConfigurationSuccess(string newConfigVersion, string newConfigMarket)
    {
      string empty = string.Empty;
      this.LogConfigurationEvent(newConfigVersion, empty, newConfigMarket);
    }

    public void LogConfigurationFailure(Exception exception, string newConfigMarket) => this.LogConfigurationEvent(string.Empty, JsllEventLogger.GetEventErrorText(exception), newConfigMarket);

    public void LogConfigurationFailure(string message, string newConfigMarket) => this.LogConfigurationEvent(string.Empty, JsllEventLogger.GetEventErrorText(message), newConfigMarket);

    private SdkError Convert(AdFailedEventArgs args)
    {
      SdkError sdkError = new SdkError()
      {
        Name = args.Name,
        ErrorCode = args.ErrorCode.ToString(),
        ErrorText = args.ErrorDescription
      };
      if (args.Error != null)
        sdkError.ErrorText = JsllEventLogger.GetEventErrorText(args.Error);
      return sdkError;
    }

    private void InvokeScript(string scriptName, params string[] args)
    {
      if (JsllEventLogger.jsllSingletonBrowser == null)
        JsllEventLogger.Log.Error("Event logger needs to be initialized before event cen be sent");
      else if (!JsllEventLogger.jsllSingletonBrowser.IsNavigateSuccessful)
      {
        JsllEventLogger.Log.Trace("Skipping actual event logging since the navigation to the index page was not successful.");
      }
      else
      {
        for (int index = 0; index < ((IEnumerable<string>) args).Count<string>(); ++index)
        {
          if (args[index] == null)
            args[index] = string.Empty;
        }
        JsllEventLogger.jsllSingletonBrowser.InvokeScript(scriptName, args);
      }
    }

    private void LogConfigurationEvent(
      string newConfigVersion,
      string errorText,
      string newConfigMarket)
    {
      SdkEventContext context = this.stateManager.Context;
      this.InvokeScript("onAdMediatorConfigurationEvent", newConfigVersion, errorText, context.DeviceId, context.ApplicationId, context.Market, context.OsVersion, context.DeviceManufacturer, context.DeviceName, context.Framework, context.ConfigVersion, context.ConfigId, newConfigMarket, context.CoreVersion);
    }

    private void SendSdkEvent(
      string eventName,
      string sdkName,
      IEnumerable<SdkError> failedSdks,
      string adMediatorError)
    {
      string str1 = this.SerializeErrors(failedSdks);
      JsllEventLogger.Log.Information("Sending JSLL event Name {0}: Sdk: {1}, SdkErrors: {2}, AdMediatorError: {3}", (object) eventName, (object) sdkName, (object) str1, (object) adMediatorError);
      string str2 = string.Empty;
      if (adMediatorError != null)
        str2 = adMediatorError;
      SdkEventContext context = this.stateManager.Context;
      this.InvokeScript("onAdMediatorEvent", eventName, context.ControlId, sdkName, str1, str2, context.DeviceId, context.ApplicationId, context.Market, context.OsVersion, context.DeviceManufacturer, context.DeviceName, context.Framework, context.ConfigVersion, context.ConfigId, context.ControlName, context.CoreVersion);
    }

    private string SerializeErrors(IEnumerable<SdkError> error)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        new DataContractJsonSerializer(typeof (IEnumerable<SdkError>)).WriteObject((Stream) memoryStream, (object) error);
        return Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int) memoryStream.Length);
      }
    }

    private static string GetEventErrorText(Exception exception) => JsllEventLogger.GetEventErrorText(exception.ToString());

    private static string GetEventErrorText(string errorMessage) => errorMessage != null && errorMessage.Length > 1000 ? errorMessage.Substring(0, 1000) : errorMessage;
  }
}
