// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Default.HttpRequester
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.Default
{
  public sealed class HttpRequester : IRequester
  {
    private const int BufferSize = 4096;
    private static readonly string Version = typeof (HttpRequester).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
    private static readonly string AgentName = "AngleSharp/" + HttpRequester.Version;
    private static readonly Dictionary<string, PropertyInfo> PropCache = new Dictionary<string, PropertyInfo>();
    private static readonly List<string> Restricted = new List<string>();
    private TimeSpan _timeOut;
    private readonly Action<HttpWebRequest> _setup;
    private readonly Dictionary<string, string> _headers;

    public HttpRequester(string userAgent = null, Action<HttpWebRequest> setup = null)
    {
      this._timeOut = new TimeSpan(0, 0, 0, 45);
      this._setup = setup ?? (Action<HttpWebRequest>) (r => { });
      this._headers = new Dictionary<string, string>()
      {
        {
          HeaderNames.UserAgent,
          userAgent ?? HttpRequester.AgentName
        }
      };
    }

    public IDictionary<string, string> Headers => (IDictionary<string, string>) this._headers;

    public TimeSpan Timeout
    {
      get => this._timeOut;
      set => this._timeOut = value;
    }

    public bool SupportsProtocol(string protocol) => protocol.IsOneOf(ProtocolNames.Http, ProtocolNames.Https);

    public async Task<IResponse> RequestAsync(IRequest request, CancellationToken cancellationToken)
    {
      CancellationTokenSource timeoutToken = HttpRequester.CreateTimeoutToken(this._timeOut);
      HttpRequester.RequestState requestState = new HttpRequester.RequestState(request, (IDictionary<string, string>) this._headers, this._setup);
      IResponse response;
      using (cancellationToken.Register(new Action(timeoutToken.Cancel)))
        response = await requestState.RequestAsync(timeoutToken.Token).ConfigureAwait(false);
      return response;
    }

    private static CancellationTokenSource CreateTimeoutToken(TimeSpan elapsed) => new CancellationTokenSource(elapsed);

    private static void RaiseConnectionLimit(HttpWebRequest http)
    {
      object obj = typeof (HttpWebRequest).GetField("_ServicePoint")?.GetValue((object) http);
      if (obj == null)
        return;
      obj.GetType().GetProperty("ConnectionLimit")?.SetValue(obj, (object) 1024, (object[]) null);
    }

    private sealed class RequestState
    {
      private readonly CookieContainer _cookies;
      private readonly IDictionary<string, string> _headers;
      private readonly HttpWebRequest _http;
      private readonly IRequest _request;
      private readonly byte[] _buffer;

      public RequestState(
        IRequest request,
        IDictionary<string, string> headers,
        Action<HttpWebRequest> setup)
      {
        this._cookies = new CookieContainer();
        this._headers = headers;
        this._request = request;
        this._http = WebRequest.Create((Uri) request.Address) as HttpWebRequest;
        this._http.CookieContainer = this._cookies;
        this._http.Method = request.Method.ToString().ToUpperInvariant();
        this._buffer = new byte[4096];
        this.SetHeaders();
        this.SetCookies();
        this.AllowCompression();
        this.DisableAutoRedirect();
        setup(this._http);
      }

      public async Task<IResponse> RequestAsync(CancellationToken cancellationToken)
      {
        cancellationToken.Register(new Action(((WebRequest) this._http).Abort));
        if (this._request.Method == HttpMethod.Post || this._request.Method == HttpMethod.Put)
          this.SendRequest(await Task.Factory.FromAsync<Stream>(new Func<AsyncCallback, object, IAsyncResult>(((WebRequest) this._http).BeginGetRequestStream), new Func<IAsyncResult, Stream>(((WebRequest) this._http).EndGetRequestStream), (object) null).ConfigureAwait(false));
        WebResponse response;
        try
        {
          response = await Task.Factory.FromAsync<WebResponse>(new Func<AsyncCallback, object, IAsyncResult>(((WebRequest) this._http).BeginGetResponse), new Func<IAsyncResult, WebResponse>(((WebRequest) this._http).EndGetResponse), (object) null).ConfigureAwait(false);
        }
        catch (WebException ex)
        {
          response = ex.Response;
        }
        HttpRequester.RaiseConnectionLimit(this._http);
        return (IResponse) this.GetResponse(response as HttpWebResponse);
      }

      private void SendRequest(Stream target)
      {
        Stream content = this._request.Content;
        while (content != null)
        {
          int count = content.Read(this._buffer, 0, 4096);
          if (count == 0)
            break;
          target.Write(this._buffer, 0, count);
        }
      }

      private Response GetResponse(HttpWebResponse response)
      {
        if (response == null)
          return (Response) null;
        CookieCollection cookies = this._cookies.GetCookies(response.ResponseUri);
        IEnumerable<\u003C\u003Ef__AnonymousType2<string, string>> datas = ((IEnumerable<string>) response.Headers.AllKeys).Select(m => new
        {
          Key = m,
          Value = response.Headers[m]
        });
        Response response1 = new Response()
        {
          Content = response.GetResponseStream(),
          StatusCode = response.StatusCode,
          Address = Url.Convert(response.ResponseUri)
        };
        foreach (var data in datas)
          response1.Headers.Add(data.Key, data.Value);
        if (cookies.Count > 0)
        {
          IEnumerable<string> values = cookies.OfType<Cookie>().Select<Cookie, string>((Func<Cookie, string>) (m => m.ToString()));
          response1.Headers[HeaderNames.SetCookie] = string.Join(", ", values);
        }
        return response1;
      }

      private void AddHeader(string key, string value)
      {
        if (key.Is(HeaderNames.Accept))
          this._http.Accept = value;
        else if (key.Is(HeaderNames.ContentType))
          this._http.ContentType = value;
        else if (key.Is(HeaderNames.Expect))
          this.SetProperty(HeaderNames.Expect, (object) value);
        else if (key.Is(HeaderNames.Date))
          this.SetProperty(HeaderNames.Date, (object) DateTime.Parse(value));
        else if (key.Is(HeaderNames.Host))
          this.SetProperty(HeaderNames.Host, (object) value);
        else if (key.Is(HeaderNames.IfModifiedSince))
          this.SetProperty("IfModifiedSince", (object) DateTime.Parse(value));
        else if (key.Is(HeaderNames.Referer))
          this.SetProperty(HeaderNames.Referer, (object) value);
        else if (key.Is(HeaderNames.UserAgent))
        {
          this.SetProperty("UserAgent", (object) value);
        }
        else
        {
          if (key.Is(HeaderNames.Connection) || key.Is(HeaderNames.Range) || key.Is(HeaderNames.ContentLength) || key.Is(HeaderNames.TransferEncoding))
            return;
          this._http.Headers[key] = value;
        }
      }

      private void SetCookies() => this._cookies.SetCookies(this._http.RequestUri, this._request.Headers.GetOrDefault<string, string>(HeaderNames.Cookie, string.Empty).Replace(';', ','));

      private void SetHeaders()
      {
        foreach (KeyValuePair<string, string> header in (IEnumerable<KeyValuePair<string, string>>) this._headers)
          this.AddHeader(header.Key, header.Value);
        foreach (KeyValuePair<string, string> header in (IEnumerable<KeyValuePair<string, string>>) this._request.Headers)
          this.AddHeader(header.Key, header.Value);
      }

      private void AllowCompression() => this.SetProperty("AutomaticDecompression", (object) 3);

      private void DisableAutoRedirect() => this.SetProperty("AllowAutoRedirect", (object) false);

      private void SetProperty(string name, object value)
      {
        PropertyInfo propertyInfo = (PropertyInfo) null;
        if (!HttpRequester.PropCache.TryGetValue(name, out propertyInfo))
        {
          lock (HttpRequester.PropCache)
          {
            if (!HttpRequester.PropCache.TryGetValue(name, out propertyInfo))
            {
              propertyInfo = this._http.GetType().GetProperty(name);
              HttpRequester.PropCache.Add(name, propertyInfo);
            }
          }
        }
        if (HttpRequester.Restricted.Contains(name) || propertyInfo == null)
          return;
        if (!propertyInfo.CanWrite)
          return;
        try
        {
          propertyInfo.SetValue((object) this._http, value, (object[]) null);
        }
        catch
        {
          lock (HttpRequester.Restricted)
          {
            if (HttpRequester.Restricted.Contains(name))
              return;
            HttpRequester.Restricted.Add(name);
          }
        }
      }
    }
  }
}
