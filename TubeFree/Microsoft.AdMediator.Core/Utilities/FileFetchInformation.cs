// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.FileFetchInformation
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.AdMediator.Core.Utilities
{
  [DataContract]
  public class FileFetchInformation
  {
    [DataMember]
    public DateTime? LastSuccessfulFetch { get; private set; }

    [DataMember]
    public DateTime LastAttemptedFetch { get; private set; }

    [DataMember]
    public bool WasLastAttemptSuccessful { get; private set; }

    public FileFetchInformation(
      DateTime attemptTimestamp,
      bool wasAttemptSuccessful,
      DateTime? lastSuccessfulFetchTimestamp)
    {
      if (wasAttemptSuccessful && !lastSuccessfulFetchTimestamp.HasValue)
        throw new ArgumentException("SuccessfulFetchTimestamp has to be defined when the latest attempt was successful");
      this.LastAttemptedFetch = attemptTimestamp;
      this.LastSuccessfulFetch = lastSuccessfulFetchTimestamp;
      this.WasLastAttemptSuccessful = wasAttemptSuccessful;
    }
  }
}
