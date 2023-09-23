// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Events.IEventLogger
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Events
{
  internal interface IEventLogger
  {
    Task Initialize();

    void AdMediatorError(
      AdMediatorFailedEventArgs adMediatorError,
      IEnumerable<AdFailedEventArgs> failedSdks);

    void AdFilled(AdSdkEventArgs sucesssEventArgs, IEnumerable<AdFailedEventArgs> failedSdks);

    void LogConfigurationSuccess(string newConfigVersion, string newConfigMarket);

    void LogConfigurationFailure(Exception exception, string newConfigMarket);

    void LogConfigurationFailure(string message, string newConfigMarket);
  }
}
