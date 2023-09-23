// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Managers.StateManager
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Handlers;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Managers
{
  internal class StateManager : IStateManager
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (StateManager));
    private const string TestModeVersion = "Test";
    private static readonly SemaphoreSlim LocalPersistentParametersUpdateSemaphore = new SemaphoreSlim(1, 1);
    private static readonly SemaphoreSlim LocalPersistentParametersInitializationSemaphore = new SemaphoreSlim(1, 1);
    private static readonly SemaphoreSlim AdMediatorAppVersionInitializationSemaphore = new SemaphoreSlim(1, 1);
    private static PersistentParameters localPersistentParameters;
    private static string singletonAdMediatorAppVersion;
    private readonly IFileHandler fileHandler;
    private readonly IContextHandler contextHandler;
    private string applicationId;
    private string deviceManufacturer;
    private string deviceName;
    private string framework;
    private bool? isTestMode;
    private string market;
    private string osVersion;
    private string coreVersion;

    public StateManager(
      IFileHandler fileHandler,
      IContextHandler contextHandler,
      string controlId,
      string controlName)
    {
      this.fileHandler = fileHandler;
      this.contextHandler = contextHandler;
      this.ControlId = controlId;
      this.ControlName = controlName;
    }

    public bool IsTestMode
    {
      get
      {
        if (!this.isTestMode.HasValue)
          this.isTestMode = new bool?(this.contextHandler.IsTestMode);
        return this.isTestMode.Value;
      }
    }

    public SdkEventContext Context => new SdkEventContext()
    {
      ApplicationId = this.ApplicationId,
      ConfigVersion = this.ConfigVersion,
      ConfigId = this.ConfigId,
      ControlId = this.ControlId,
      ControlName = this.ControlName,
      DeviceId = this.DeviceId,
      DeviceManufacturer = this.DeviceManufacturer,
      DeviceName = this.DeviceName,
      Framework = this.Framework,
      Market = this.Market,
      OsVersion = this.OsVersion,
      CoreVersion = this.CoreVersion
    };

    public string Framework => this.framework ?? (this.framework = this.contextHandler.Framework);

    public string CoreVersion
    {
      get
      {
        if (this.coreVersion == null)
          this.coreVersion = new AssemblyName(this.GetType().GetTypeInfo().Assembly.FullName).Version.ToString();
        return this.coreVersion;
      }
    }

    public string ConfigVersion { get; set; }

    public async Task<string> RetrieveAdMediatorAppVersionAsync()
    {
      if (!string.IsNullOrWhiteSpace(StateManager.singletonAdMediatorAppVersion))
        return StateManager.singletonAdMediatorAppVersion;
      await StateManager.AdMediatorAppVersionInitializationSemaphore.WaitAsync();
      try
      {
        if (!string.IsNullOrWhiteSpace(StateManager.singletonAdMediatorAppVersion))
          return StateManager.singletonAdMediatorAppVersion;
        if (this.IsTestMode)
        {
          StateManager.singletonAdMediatorAppVersion = "Test";
        }
        else
        {
          try
          {
            string fileVersion = (await this.fileHandler.ReadConfigurationFromAppInstallAsync()).FileVersion;
            if (!string.IsNullOrWhiteSpace(fileVersion))
            {
              string str = fileVersion.Split('.')[0];
              StateManager.singletonAdMediatorAppVersion = !string.IsNullOrWhiteSpace(str) ? str : throw new ArgumentException("AdMediatorAppVersion is not defined");
            }
            else
              StateManager.singletonAdMediatorAppVersion = "Test";
          }
          catch (FileNotFoundException ex)
          {
            StateManager.singletonAdMediatorAppVersion = "Test";
          }
        }
        return StateManager.singletonAdMediatorAppVersion;
      }
      finally
      {
        StateManager.AdMediatorAppVersionInitializationSemaphore.Release();
      }
    }

    public string ConfigId { get; set; }

    public string DeviceId => StateManager.localPersistentParameters != null ? StateManager.localPersistentParameters.AdMediatorDeviceId : (string) null;

    public string ControlId { get; private set; }

    public string ControlName { get; private set; }

    public string DeviceName => this.deviceName ?? (this.deviceName = this.contextHandler.DeviceName);

    public string DeviceManufacturer => this.deviceManufacturer ?? (this.deviceManufacturer = this.contextHandler.DeviceManufacturer);

    public string OsVersion => this.osVersion ?? (this.osVersion = this.contextHandler.OsVersion);

    public string Market => this.market ?? (this.market = this.contextHandler.Market);

    public string ApplicationId => this.applicationId ?? (this.applicationId = this.contextHandler.ApplicationId);

    public async Task<ConfigFileState> RetrieveConfigFileStateAsync()
    {
      PersistentParameters persistentParameters = await this.InitializePersistentParametersIfNeededAsync();
      return StateManager.localPersistentParameters.ConfigFileState;
    }

    public async Task UpdateConfigFileStateAsync(
      DateTime attemptTimestamp,
      bool wasAttemptSuccessful,
      bool wasFileDownloaded,
      string configStorageFolder)
    {
      PersistentParameters persistentParameters = await this.InitializePersistentParametersIfNeededAsync();
      DateTime? lastSuccessfulFetchTimestamp = new DateTime?();
      string activeConfigStorageFolder = (string) null;
      string lastKnownGoodConfigStorageFolder = (string) null;
      string adMediatorConfigFolderToDelete = (string) null;
      if (wasAttemptSuccessful & wasFileDownloaded)
      {
        lastSuccessfulFetchTimestamp = new DateTime?(attemptTimestamp);
        activeConfigStorageFolder = configStorageFolder;
        lastKnownGoodConfigStorageFolder = StateManager.localPersistentParameters.ConfigFileState != null ? StateManager.localPersistentParameters.ConfigFileState.ActiveConfigStorageFolder : (string) null;
        if (StateManager.localPersistentParameters.ConfigFileState != null && !string.IsNullOrWhiteSpace(StateManager.localPersistentParameters.ConfigFileState.LastKnownGoodConfigStorageFolder))
          adMediatorConfigFolderToDelete = StateManager.localPersistentParameters.ConfigFileState.LastKnownGoodConfigStorageFolder;
      }
      else if (StateManager.localPersistentParameters.ConfigFileState != null)
      {
        activeConfigStorageFolder = StateManager.localPersistentParameters.ConfigFileState.ActiveConfigStorageFolder;
        lastKnownGoodConfigStorageFolder = StateManager.localPersistentParameters.ConfigFileState.LastKnownGoodConfigStorageFolder;
        if (StateManager.localPersistentParameters.ConfigFileState.FileFetchInformation != null)
          lastSuccessfulFetchTimestamp = StateManager.localPersistentParameters.ConfigFileState.FileFetchInformation.LastSuccessfulFetch;
      }
      else if (wasAttemptSuccessful)
        lastSuccessfulFetchTimestamp = new DateTime?(attemptTimestamp);
      await this.SavePersistentParameters(new PersistentParameters(StateManager.localPersistentParameters.AdMediatorDeviceId, new ConfigFileState(attemptTimestamp, wasAttemptSuccessful, activeConfigStorageFolder, lastKnownGoodConfigStorageFolder, lastSuccessfulFetchTimestamp)));
      if (string.IsNullOrWhiteSpace(adMediatorConfigFolderToDelete))
        return;
      this.DeleteAdMediatorConfigInBackground(adMediatorConfigFolderToDelete);
    }

    private void DeleteAdMediatorConfigInBackground(string adMediatorConfigFolderToDelete) => Task.Run((Func<Task>) (async () =>
    {
      try
      {
        await this.fileHandler.DeleteConfigurationFromIsolatedStorageAsync(adMediatorConfigFolderToDelete);
        StateManager.Log.Trace("Successfully deleted ad mediator config folder {0}", (object) adMediatorConfigFolderToDelete);
      }
      catch (Exception ex)
      {
        StateManager.Log.Error(ex, "Failed to delete AdMediator folder {0}", (object) adMediatorConfigFolderToDelete);
      }
    }));

    private async Task<PersistentParameters> InitializePersistentParametersIfNeededAsync()
    {
      if (StateManager.localPersistentParameters != null)
        return StateManager.localPersistentParameters;
      await StateManager.LocalPersistentParametersInitializationSemaphore.WaitAsync();
      try
      {
        if (StateManager.localPersistentParameters != null)
          return StateManager.localPersistentParameters;
        try
        {
          StateManager.localPersistentParameters = await this.fileHandler.ReadPersistentStateAsync();
        }
        catch (Exception ex)
        {
          StateManager.Log.Error(ex, "Unable to fetch config from ini file.");
        }
        if (StateManager.localPersistentParameters == null)
          await this.SavePersistentParameters(new PersistentParameters(Guid.NewGuid().ToString(), (ConfigFileState) null));
        return StateManager.localPersistentParameters;
      }
      finally
      {
        StateManager.LocalPersistentParametersInitializationSemaphore.Release();
      }
    }

    private async Task SavePersistentParameters(PersistentParameters persistentParameters)
    {
      await StateManager.LocalPersistentParametersUpdateSemaphore.WaitAsync();
      try
      {
        await this.fileHandler.SavePersistentStateAsync(persistentParameters);
        StateManager.localPersistentParameters = await this.fileHandler.ReadPersistentStateAsync();
        StateManager.Log.Trace("Updated persistent state");
      }
      catch (Exception ex)
      {
        StateManager.Log.Error(ex, "Unable to write config to ini file.");
      }
      finally
      {
        StateManager.LocalPersistentParametersUpdateSemaphore.Release();
      }
    }
  }
}
