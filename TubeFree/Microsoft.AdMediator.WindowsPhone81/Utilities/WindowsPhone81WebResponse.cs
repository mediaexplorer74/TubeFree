// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Utilities.WindowsPhone81WebResponse
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Utilities;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Microsoft.AdMediator.WindowsPhone81.Utilities
{
  internal class WindowsPhone81WebResponse : IWebResponse
  {
    private readonly HttpResponseMessage responseMessage;
    private readonly HttpStatusCode statusCode;

    public WindowsPhone81WebResponse(HttpResponseMessage responseMessage)
    {
      this.responseMessage = responseMessage != null ? responseMessage : throw new ArgumentNullException(nameof (responseMessage));
      this.statusCode = responseMessage.StatusCode;
    }

    public WindowsPhone81WebResponse(HttpStatusCode statusCode) => this.statusCode = statusCode;

    public bool IsNotModified => this.statusCode == 304;

    public bool IsOk => this.statusCode == 200;

    public bool IsNotFound => this.statusCode == 404;

    public int StatusCode => (int) this.statusCode;

    public async Task<Stream> GetResponseStream() => this.responseMessage != null ? (await this.responseMessage.Content.ReadAsInputStreamAsync()).AsStreamForRead() : throw new ArgumentException("Cannot get response stream since responseMessage is null");
  }
}
