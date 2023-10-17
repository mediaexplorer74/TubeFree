// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Default.BaseLoader
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.Default
{
  public abstract class BaseLoader : ILoader
  {
    private readonly IBrowsingContext _context;
    private readonly Predicate<IRequest> _filter;
    private readonly List<IDownload> _downloads;

    public BaseLoader(IBrowsingContext context, Predicate<IRequest> filter)
    {
      this._context = context;
      this._filter = filter ?? (Predicate<IRequest>) (_ => true);
      this._downloads = new List<IDownload>();
      this.MaxRedirects = 50;
    }

    public int MaxRedirects { get; protected set; }

    protected virtual void Add(IDownload download)
    {
      lock (this)
        this._downloads.Add(download);
    }

    protected virtual void Remove(IDownload download)
    {
      lock (this)
        this._downloads.Remove(download);
    }

    protected virtual string GetCookie(Url url) => this._context.Configuration.GetCookie(url.Origin);

    protected virtual void SetCookie(Url url, string value) => this._context.Configuration.SetCookie(url.Origin, value);

    protected virtual IDownload DownloadAsync(Request request, INode originator)
    {
      CancellationTokenSource cts = new CancellationTokenSource();
      if (!this._filter((IRequest) request))
        return (IDownload) new Download(TaskEx.FromResult<IResponse>((IResponse) null), cts, request.Address, originator);
      Task<IResponse> task = this.LoadAsync(request, cts.Token);
      Download download = new Download(task, cts, request.Address, originator);
      this.Add((IDownload) download);
      task.ContinueWith((Action<Task<IResponse>>) (m => this.Remove((IDownload) download)));
      return (IDownload) download;
    }

    public IEnumerable<IDownload> GetDownloads()
    {
      lock (this)
        return (IEnumerable<IDownload>) this._downloads.ToArray();
    }

    protected async Task<IResponse> LoadAsync(Request request, CancellationToken cancel)
    {
      IEnumerable<IRequester> requesters = this._context.Configuration.GetServices<IRequester>();
      IResponse response = (IResponse) null;
      int redirectCount = 0;
      this.AppendCookieTo(request);
      do
      {
        if (response != null)
        {
          ++redirectCount;
          this.ExtractCookieFrom(response);
          request = BaseLoader.CreateNewRequest((IRequest) request, response);
          this.AppendCookieTo(request);
        }
        foreach (IRequester requester in requesters)
        {
          if (requester.SupportsProtocol(request.Address.Scheme))
          {
            this._context.Fire((Event) new RequestEvent((IRequest) request, (IResponse) null));
            response = await requester.RequestAsync((IRequest) request, cancel).ConfigureAwait(false);
            this._context.Fire((Event) new RequestEvent((IRequest) request, response));
            break;
          }
        }
      }
      while (response != null && response.StatusCode.IsRedirected() && redirectCount < this.MaxRedirects);
      return response;
    }

    protected static Request CreateNewRequest(IRequest request, IResponse response)
    {
      HttpMethod httpMethod = request.Method;
      Stream content = request.Content;
      Dictionary<string, string> dictionary = new Dictionary<string, string>(request.Headers);
      string header = response.Headers[HeaderNames.Location];
      if (response.StatusCode == HttpStatusCode.Found || response.StatusCode == HttpStatusCode.RedirectMethod)
      {
        httpMethod = HttpMethod.Get;
        content = Stream.Null;
      }
      else if (content.Length > 0L)
        content.Position = 0L;
      dictionary.Remove(HeaderNames.Cookie);
      return new Request()
      {
        Address = new Url(request.Address, header),
        Method = httpMethod,
        Content = content,
        Headers = (IDictionary<string, string>) dictionary
      };
    }

    private void AppendCookieTo(Request request)
    {
      string cookie = this.GetCookie(request.Address);
      if (cookie == null)
        return;
      request.Headers[HeaderNames.Cookie] = cookie;
    }

    private void ExtractCookieFrom(IResponse response)
    {
      string orDefault = response.Headers.GetOrDefault<string, string>(HeaderNames.SetCookie, (string) null);
      if (orDefault == null)
        return;
      this.SetCookie(response.Address, orDefault);
    }
  }
}
