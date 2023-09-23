// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Managers.ConfigurationManager
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Handlers;
using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Models.Runtime;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Managers
{
  internal class ConfigurationManager : IConfigurationManager
  {
    private const string BaseLineFileName = "baseline";
    private static readonly ILogger Log = (ILogger) new Logger(typeof (ConfigurationManager));
    private static readonly SemaphoreSlim SingletonConfigInitializationSemaphore = new SemaphoreSlim(1, 1);
    private static readonly SemaphoreSlim ConfigUpdateSemaphore = new SemaphoreSlim(1, 1);
    private static AdMediatorConfiguration singletonAdMediatorConfiguration;
    private readonly ISerializer configSerializer;
    private readonly IConfigurationParser configurationParser;
    private readonly IEventLogger eventLogger;
    private readonly AdMediatorConfiguration fallbackConfiguration;
    private readonly IFileHandler fileHandler;
    private readonly IStateManager stateManager;
    private readonly WebRequester webRequester;

    public ConfigurationManager(
      IFileHandler fileHandler,
      ISerializer configSerializer,
      IConfigurationParser configurationParser,
      IEventLogger eventLogger,
      IStateManager stateManager,
      WebRequester webRequester,
      AdMediatorConfiguration fallbackConfiguration = null)
    {
      this.fileHandler = fileHandler;
      this.configSerializer = configSerializer;
      this.configurationParser = configurationParser;
      this.eventLogger = eventLogger;
      this.stateManager = stateManager;
      this.webRequester = webRequester;
      this.fallbackConfiguration = fallbackConfiguration;
    }

    public async Task<AdMediatorRuntimeConfiguration> GetAdControlConfigurationAsync(
      string adControlId)
    {
      await this.InitializeSingletonAdMediatorConfigurationIfNeededAsync();
      AdMediatorRuntimeConfiguration configurationAsync = this.configurationParser.ConvertConfiguration(ConfigurationManager.singletonAdMediatorConfiguration, adControlId);
      ConfigurationManager.Log.Trace("Loaded configuration with {0} adapters. Refresh rate {1} seconds", (object) configurationAsync.AdAdapters.Count, (object) configurationAsync.RefreshRate);
      return configurationAsync;
    }

    public async Task<bool> DownloadAndSaveNewConfiguration()
    {
      try
      {
        await ConfigurationManager.ConfigUpdateSemaphore.WaitAsync();
        try
        {
          ConfigFileState configFileState = await this.stateManager.RetrieveConfigFileStateAsync();
          if (!this.webRequester.ShouldFetchFile(configFileState != null ? configFileState.FileFetchInformation : (FileFetchInformation) null))
            return false;
          await this.InitializeSingletonAdMediatorConfigurationIfNeededAsync();
          AdMediatorConfiguration mediatorConfiguration = ConfigurationManager.singletonAdMediatorConfiguration;
          if (string.IsNullOrEmpty(mediatorConfiguration.CdnUriFormat))
            throw new ArgumentException("CDN Uri format invalid");
          return await this.FetchConfigFileAsync(configFileState, mediatorConfiguration.CdnUriFormat, this.stateManager.Market, mediatorConfiguration.UpdatedDateTime, mediatorConfiguration.FileVersion);
        }
        finally
        {
          ConfigurationManager.ConfigUpdateSemaphore.Release();
        }
      }
      catch (Exception ex)
      {
        ConfigurationManager.Log.Error(ex, "Failed to get config");
        this.eventLogger.LogConfigurationFailure(ex, (string) null);
      }
      return false;
    }

    private async Task<bool> FetchConfigFileAsync(
      ConfigFileState configFileState,
      string cdnUrlFormat,
      string market,
      DateTime updatedDateTime,
      string currentConfigVersion)
    {
      Uri url = new Uri(string.Format((IFormatProvider) CultureInfo.InvariantCulture, cdnUrlFormat, (object) market));
      ConfigurationManager.Log.Trace("Loading config from url {0}", (object) url);
      IWebResponse configDownloadResponse = await this.webRequester.GetWebResponse(url, updatedDateTime);
      if (configDownloadResponse.IsNotModified)
      {
        await this.stateManager.UpdateConfigFileStateAsync(DateTime.Now, true, false, configFileState != null ? configFileState.ActiveConfigStorageFolder : (string) null);
        if (configFileState == null)
          this.eventLogger.LogConfigurationSuccess(currentConfigVersion, market);
      }
      else
      {
        if (configDownloadResponse.IsOk)
        {
          AdMediatorConfiguration newConfiguration = (AdMediatorConfiguration) null;
          using (Stream responseStream = await configDownloadResponse.GetResponseStream())
            newConfiguration = (AdMediatorConfiguration) new DataContractSerializer(typeof (AdMediatorConfiguration)).ReadObject(responseStream);
          this.configurationParser.ValidateAdMediatorConfiguration(newConfiguration);
          string newConfigStorageFolder = Guid.NewGuid().ToString();
          await this.fileHandler.SaveConfigurationToIsolatedStorageAsync(newConfiguration, newConfigStorageFolder);
          newConfiguration = await this.fileHandler.ReadConfigurationFromIsolatedStorageAsync(newConfigStorageFolder);
          this.configurationParser.ValidateAdMediatorConfiguration(newConfiguration);
          await this.stateManager.UpdateConfigFileStateAsync(DateTime.Now, true, true, newConfigStorageFolder);
          await ConfigurationManager.SingletonConfigInitializationSemaphore.WaitAsync();
          try
          {
            ConfigurationManager.singletonAdMediatorConfiguration = newConfiguration;
          }
          finally
          {
            ConfigurationManager.SingletonConfigInitializationSemaphore.Release();
          }
          this.eventLogger.LogConfigurationSuccess(newConfiguration.FileVersion, market);
          return true;
        }
        if (configDownloadResponse.IsNotFound && !"baseline".Equals(market))
          return await this.FetchConfigFileAsync(configFileState, cdnUrlFormat, "baseline", updatedDateTime, currentConfigVersion);
        await this.stateManager.UpdateConfigFileStateAsync(DateTime.Now, false, false, (string) null);
        this.eventLogger.LogConfigurationFailure(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Failed to download config with status code {0}", (object) configDownloadResponse.StatusCode), market);
      }
      return false;
    }

    private async Task InitializeSingletonAdMediatorConfigurationIfNeededAsync()
    {
      if (ConfigurationManager.singletonAdMediatorConfiguration != null)
        return;
      await ConfigurationManager.SingletonConfigInitializationSemaphore.WaitAsync();
      try
      {
        if (ConfigurationManager.singletonAdMediatorConfiguration != null)
          return;
        ConfigFileState configFileState = await this.stateManager.RetrieveConfigFileStateAsync();
        AdMediatorConfiguration configuration = (AdMediatorConfiguration) null;
        if (configFileState != null)
        {
          if (!string.IsNullOrWhiteSpace(configFileState.ActiveConfigStorageFolder))
            configuration = await this.ReadAdMediatorConfigurationFromIsolatedStorageFolder(configFileState.ActiveConfigStorageFolder);
          if (configuration == null && !string.IsNullOrWhiteSpace(configFileState.LastKnownGoodConfigStorageFolder))
            configuration = await this.ReadAdMediatorConfigurationFromIsolatedStorageFolder(configFileState.LastKnownGoodConfigStorageFolder);
        }
        if (configuration == null)
          configuration = await this.fileHandler.ReadConfigurationFromAppInstallAsync();
        this.configurationParser.ValidateAdMediatorConfiguration(configuration);
        ConfigurationManager.singletonAdMediatorConfiguration = configuration;
        try
        {
          this.stateManager.ConfigVersion = ConfigurationParser.GetConfigVersion(ConfigurationManager.singletonAdMediatorConfiguration, this.stateManager.Market, this.stateManager.IsTestMode);
          if (!string.IsNullOrWhiteSpace(configuration.ConfigId))
            this.stateManager.ConfigId = configuration.ConfigId;
          else if (!string.IsNullOrEmpty(configuration.CdnUriFormat))
          {
            Uri uri = new Uri(configuration.CdnUriFormat);
            if (((IEnumerable<string>) uri.Segments).Count<string>() >= 3)
              this.stateManager.ConfigId = uri.Segments[2].Trim('/');
          }
        }
        catch (Exception ex)
        {
          ConfigurationManager.Log.Error(ex, "Unable to update configuration state");
        }
        configFileState = (ConfigFileState) null;
      }
      catch (FileNotFoundException ex)
      {
        if (this.fallbackConfiguration != null)
        {
          ConfigurationManager.Log.Information((Exception) ex, "Failed to load configuration from local storage. Using fallback configuration.");
          ConfigurationManager.singletonAdMediatorConfiguration = this.fallbackConfiguration;
        }
        else
          throw;
      }
      finally
      {
        ConfigurationManager.SingletonConfigInitializationSemaphore.Release();
      }
    }

    private async Task<AdMediatorConfiguration> ReadAdMediatorConfigurationFromIsolatedStorageFolder(
      string configStorageFolder)
    {
      try
      {
        return await this.fileHandler.ReadConfigurationFromIsolatedStorageAsync(configStorageFolder);
      }
      catch (Exception ex)
      {
        ConfigurationManager.Log.Error(ex, "Failed to read config file from isolated storaget folder {0}", (object) configStorageFolder);
        return (AdMediatorConfiguration) null;
      }
    }
  }
}
