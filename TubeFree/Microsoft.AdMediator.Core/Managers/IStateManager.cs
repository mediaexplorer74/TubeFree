// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Managers.IStateManager
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Events;
using Microsoft.AdMediator.Core.Utilities;
using System;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Managers
{
  internal interface IStateManager
  {
    SdkEventContext Context { get; }

    Task<ConfigFileState> RetrieveConfigFileStateAsync();

    Task UpdateConfigFileStateAsync(
      DateTime attemptTimestamp,
      bool wasAttemptSuccessful,
      bool wasFileDownloaded,
      string configStorageFolder);

    string DeviceId { get; }

    string ControlId { get; }

    string DeviceName { get; }

    string DeviceManufacturer { get; }

    string OsVersion { get; }

    string Market { get; }

    string ApplicationId { get; }

    string Framework { get; }

    string ConfigVersion { get; set; }

    string ConfigId { get; set; }

    bool IsTestMode { get; }

    Task<string> RetrieveAdMediatorAppVersionAsync();
  }
}
