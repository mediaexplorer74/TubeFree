// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.ConfigFileState
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.AdMediator.Core.Utilities
{
  [DataContract]
  internal class ConfigFileState
  {
    [DataMember]
    public FileFetchInformation FileFetchInformation { get; private set; }

    [DataMember]
    public string ActiveConfigStorageFolder { get; private set; }

    [DataMember]
    public string LastKnownGoodConfigStorageFolder { get; private set; }

    public ConfigFileState(
      DateTime attemptTimestamp,
      bool wasAttemptSuccessful,
      string activeConfigStorageFolder,
      string lastKnownGoodConfigStorageFolder,
      DateTime? lastSuccessfulFetchTimestamp)
    {
      this.FileFetchInformation = new FileFetchInformation(attemptTimestamp, wasAttemptSuccessful, lastSuccessfulFetchTimestamp);
      this.ActiveConfigStorageFolder = activeConfigStorageFolder;
      this.LastKnownGoodConfigStorageFolder = lastKnownGoodConfigStorageFolder;
    }
  }
}
