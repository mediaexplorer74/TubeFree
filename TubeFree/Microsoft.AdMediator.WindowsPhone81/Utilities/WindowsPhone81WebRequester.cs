// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Utilities.WindowsPhone81WebRequester
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Utilities;
using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Microsoft.AdMediator.WindowsPhone81.Utilities
{
  internal class WindowsPhone81WebRequester : WebRequester
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (WindowsPhone81WebRequester));

    public virtual async Task<IWebResponse> GetWebResponse(Uri url, DateTime lastModified)
    {
      HttpClient httpClient = new HttpClient();
      if (lastModified != DateTime.MinValue)
        httpClient.DefaultRequestHeaders.put_IfModifiedSince(new DateTimeOffset?((DateTimeOffset) lastModified));
      try
      {
        return (IWebResponse) new WindowsPhone81WebResponse(await httpClient.GetAsync(url));
      }
      catch (Exception ex)
      {
        WindowsPhone81WebRequester.Log.Error(ex, "Error calling {0}", new object[1]
        {
          (object) url
        });
        return (IWebResponse) new WindowsPhone81WebResponse((HttpStatusCode) 500);
      }
    }
  }
}
