// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.TimeoutProvider
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Models.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal static class TimeoutProvider
  {
    private static readonly TimeSpan MininumTimeout = TimeSpan.FromSeconds(2.0);
    private static readonly TimeSpan MaximumTimeout = TimeSpan.FromSeconds(120.0);

    public static TimeoutInformation GetOverrideSdkTimeouts(
      IList<AdAdapterRuntimeInfo> adAdapters,
      IDictionary<string, TimeSpan> adSdkTimeouts)
    {
      Dictionary<string, TimeSpan> dictionary = new Dictionary<string, TimeSpan>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      List<string> errors = new List<string>();
      foreach (AdAdapterRuntimeInfo adAdapter in (IEnumerable<AdAdapterRuntimeInfo>) adAdapters)
      {
        if (adAdapter.Timeout >= 0)
        {
          string str = TimeoutProvider.ApplyTimeoutOverride(TimeSpan.FromMilliseconds((double) adAdapter.Timeout), adAdapter.Name, dictionary);
          if (str != null)
            errors.Add(str);
        }
      }
      foreach (KeyValuePair<string, TimeSpan> adSdkTimeout in (IEnumerable<KeyValuePair<string, TimeSpan>>) adSdkTimeouts)
      {
        string str = TimeoutProvider.ApplyTimeoutOverride(adSdkTimeout.Value, adSdkTimeout.Key, dictionary);
        if (str != null)
          errors.Add(str);
      }
      return new TimeoutInformation(dictionary, errors);
    }

    private static string ApplyTimeoutOverride(
      TimeSpan timeout,
      string adapterName,
      Dictionary<string, TimeSpan> overrideTimeouts)
    {
      if (timeout < TimeoutProvider.MininumTimeout || timeout > TimeoutProvider.MaximumTimeout)
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Invalid timeout value {0} seconds for SDK {1}, expected value between {2} and {3} seconds", (object) timeout.TotalSeconds, (object) adapterName, (object) TimeoutProvider.MininumTimeout.TotalSeconds, (object) TimeoutProvider.MaximumTimeout.TotalSeconds);
      overrideTimeouts[adapterName] = timeout;
      return (string) null;
    }
  }
}
