// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.WebRequester
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal abstract class WebRequester
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (WebRequester));
    private const int MinRefetchHoursForSuccess = 24;
    private const int MinRefetchHoursForFailure = 6;

    public bool ShouldFetchFile(FileFetchInformation currentFileFetchInformation)
    {
      if (currentFileFetchInformation == null)
        return true;
      TimeSpan timeSpan = DateTime.Now - currentFileFetchInformation.LastAttemptedFetch;
      if (currentFileFetchInformation.WasLastAttemptSuccessful)
      {
        if (timeSpan < new TimeSpan(24, 0, 0))
        {
          WebRequester.Log.Trace("Time since last fetch ({0}) was less than {1} hours (last fetch was a success).", (object) timeSpan, (object) 24);
          return false;
        }
      }
      else if (timeSpan < new TimeSpan(6, 0, 0))
      {
        WebRequester.Log.Trace("Time since last fetch ({0}) was less than {1} hours (last fetch was a failure).", (object) timeSpan, (object) 6);
        return false;
      }
      return true;
    }

    public abstract Task<IWebResponse> GetWebResponse(Uri url, DateTime lastModified);
  }
}
