// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Handlers.FileHandler
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models;
using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Handlers
{
  internal class FileHandler : IFileHandler
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (FileHandler));
    private static readonly SemaphoreSlim ConfigUpdateSemaphore = new SemaphoreSlim(1, 1);
    private static readonly SemaphoreSlim StateUpdateSemaphore = new SemaphoreSlim(1, 1);
    private readonly IPersistentStorage persistentStorage;
    private readonly ISerializer serializer;
    private readonly ISerializer stateSerializer;

    public FileHandler(
      IPersistentStorage persistentStorage,
      ISerializer configSerializer,
      ISerializer stateSerializer)
    {
      this.persistentStorage = persistentStorage;
      this.serializer = configSerializer;
      this.stateSerializer = stateSerializer;
    }

    public async Task<AdMediatorConfiguration> ReadConfigurationFromAppInstallAsync()
    {
      FileHandler.Log.Trace("Reading configuration from app install location");
      AdMediatorConfiguration mediatorConfiguration;
      using (Stream stream = await this.persistentStorage.OpenStreamFromAppInstallStorageForReadAsync("AdMediator.config"))
        mediatorConfiguration = (AdMediatorConfiguration) new DataContractSerializer(typeof (AdMediatorConfiguration)).ReadObject(stream);
      return mediatorConfiguration;
    }

    private async Task<string> GetConfigFilePath(string configStorageFolder)
    {
      await this.persistentStorage.CreateFolderInIsolatedStorageIfNotExistingAsync(configStorageFolder);
      return Path.Combine(configStorageFolder, "AdMediator.config");
    }

    public async Task<AdMediatorConfiguration> ReadConfigurationFromIsolatedStorageAsync(
      string configStorageFolder)
    {
      FileHandler.Log.Trace("Reading configuration from {0}", (object) configStorageFolder);
      await FileHandler.ConfigUpdateSemaphore.WaitAsync();
      AdMediatorConfiguration mediatorConfiguration;
      try
      {
        using (Stream stream = await this.persistentStorage.OpenStreamFromIsolatedStorageForReadAsync(await this.GetConfigFilePath(configStorageFolder)))
          mediatorConfiguration = (AdMediatorConfiguration) new DataContractSerializer(typeof (AdMediatorConfiguration)).ReadObject(stream);
      }
      finally
      {
        FileHandler.ConfigUpdateSemaphore.Release();
      }
      return mediatorConfiguration;
    }

    public async Task SaveConfigurationToIsolatedStorageAsync(
      AdMediatorConfiguration configuration,
      string configStorageFolder)
    {
      FileHandler.Log.Trace("Saving configuration to {0}", (object) configStorageFolder);
      await FileHandler.ConfigUpdateSemaphore.WaitAsync();
      try
      {
        using (Stream stream = await this.persistentStorage.OpenStreamFromIsolatedStorageForWriteAsync(await this.GetConfigFilePath(configStorageFolder)))
          new DataContractSerializer(typeof (AdMediatorConfiguration)).WriteObject(stream, (object) configuration);
      }
      finally
      {
        FileHandler.ConfigUpdateSemaphore.Release();
      }
    }

    public async Task DeleteConfigurationFromIsolatedStorageAsync(string configStorageFolder)
    {
      FileHandler.Log.Trace("Deleting configuration from {0}", (object) configStorageFolder);
      await FileHandler.ConfigUpdateSemaphore.WaitAsync();
      try
      {
        await this.persistentStorage.DeleteFileFromIsolatedStorageAsync(await this.GetConfigFilePath(configStorageFolder));
      }
      finally
      {
        FileHandler.ConfigUpdateSemaphore.Release();
      }
    }

    public async Task<PersistentParameters> ReadPersistentStateAsync()
    {
      FileHandler.Log.Trace("Loading state file");
      await FileHandler.StateUpdateSemaphore.WaitAsync();
      PersistentParameters persistentParameters;
      try
      {
        using (Stream stream = await this.persistentStorage.OpenStreamFromIsolatedStorageForReadAsync("AdMediatorState.json"))
          persistentParameters = (PersistentParameters) new DataContractSerializer(typeof (PersistentParameters)).ReadObject(stream);
      }
      finally
      {
        FileHandler.StateUpdateSemaphore.Release();
      }
      return persistentParameters;
    }

    public async Task SavePersistentStateAsync(PersistentParameters persistentParameters)
    {
      FileHandler.Log.Trace("Saving state file");
      await FileHandler.StateUpdateSemaphore.WaitAsync();
      try
      {
        using (Stream stream = await this.persistentStorage.OpenStreamFromIsolatedStorageForWriteAsync("AdMediatorState.json"))
          new DataContractSerializer(typeof (PersistentParameters)).WriteObject(stream, (object) persistentParameters);
      }
      finally
      {
        FileHandler.StateUpdateSemaphore.Release();
      }
    }
  }
}
