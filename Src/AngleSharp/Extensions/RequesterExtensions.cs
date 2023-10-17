// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.RequesterExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Html;
using AngleSharp.Network;
using AngleSharp.Network.Default;
using AngleSharp.Services;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Extensions
{
  internal static class RequesterExtensions
  {
    public static bool IsRedirected(this HttpStatusCode status) => status == HttpStatusCode.Found || status == HttpStatusCode.RedirectKeepVerb || status == HttpStatusCode.RedirectMethod || status == HttpStatusCode.RedirectKeepVerb || status == HttpStatusCode.Moved || status == HttpStatusCode.Ambiguous;

    public static IDownload FetchWithCors(this IResourceLoader loader, CorsRequest cors)
    {
      ResourceRequest request = cors.Request;
      CorsSetting setting = cors.Setting;
      Url target = request.Target;
      if (request.Origin == target.Origin || target.Scheme == ProtocolNames.Data || target.Href == "about:blank")
        return loader.FetchFromSameOrigin(target, cors);
      if (setting == CorsSetting.Anonymous || setting == CorsSetting.UseCredentials)
        return loader.FetchFromDifferentOrigin(cors);
      if (setting == CorsSetting.None)
        return loader.FetchWithoutCors(request, cors.Behavior);
      throw new DomException(DomError.Network);
    }

    private static IDownload FetchFromSameOrigin(
      this IResourceLoader loader,
      Url url,
      CorsRequest cors)
    {
      ResourceRequest request = cors.Request;
      IDownload download = loader.DownloadAsync(new ResourceRequest(request.Source, url)
      {
        Origin = request.Origin,
        IsManualRedirectDesired = true
      });
      return download.Wrap((Func<IResponse, IDownload>) (response =>
      {
        if (!response.IsRedirected())
          return cors.CheckIntegrity(download);
        url.Href = response.Headers.GetOrDefault<string, string>(HeaderNames.Location, url.Href);
        return !request.Origin.Is(url.Origin) ? loader.FetchFromSameOrigin(url, cors) : loader.FetchWithCors(cors.RedirectTo(url));
      }));
    }

    private static IDownload FetchFromDifferentOrigin(this IResourceLoader loader, CorsRequest cors)
    {
      ResourceRequest request = cors.Request;
      request.IsCredentialOmitted = cors.IsAnonymous();
      IDownload download = loader.DownloadAsync(request);
      return download.Wrap((Func<IResponse, IDownload>) (response =>
      {
        if ((response != null ? (response.StatusCode != HttpStatusCode.OK ? 1 : 0) : 1) != 0)
        {
          response?.Dispose();
          throw new DomException(DomError.Network);
        }
        return cors.CheckIntegrity(download);
      }));
    }

    private static IDownload FetchWithoutCors(
      this IResourceLoader loader,
      ResourceRequest request,
      OriginBehavior behavior)
    {
      if (behavior == OriginBehavior.Fail)
        throw new DomException(DomError.Network);
      return loader.DownloadAsync(request);
    }

    private static bool IsAnonymous(this CorsRequest cors) => cors.Setting == CorsSetting.Anonymous;

    private static IDownload Wrap(this IDownload download, Func<IResponse, IDownload> callback)
    {
      CancellationTokenSource cts = new CancellationTokenSource();
      return (IDownload) new Download(download.Task.Wrap(callback), cts, download.Target, download.Originator);
    }

    private static IDownload Wrap(this IDownload download, IResponse response)
    {
      CancellationTokenSource cts = new CancellationTokenSource();
      return (IDownload) new Download(TaskEx.FromResult<IResponse>(response), cts, download.Target, download.Originator);
    }

    private static async Task<IResponse> Wrap(
      this Task<IResponse> task,
      Func<IResponse, IDownload> callback)
    {
      IResponse response = await task.ConfigureAwait(false);
      return await callback(response).Task.ConfigureAwait(false);
    }

    private static bool IsRedirected(this IResponse response) => (response != null ? response.StatusCode : HttpStatusCode.NotFound).IsRedirected();

    private static CorsRequest RedirectTo(this CorsRequest cors, Url url)
    {
      ResourceRequest request = cors.Request;
      return new CorsRequest(new ResourceRequest(request.Source, url)
      {
        IsCookieBlocked = request.IsCookieBlocked,
        IsSameOriginForced = request.IsSameOriginForced,
        Origin = request.Origin
      })
      {
        Setting = cors.Setting,
        Behavior = cors.Behavior,
        Integrity = cors.Integrity
      };
    }

    private static IDownload CheckIntegrity(this CorsRequest cors, IDownload download)
    {
      IResponse result = download.Task.Result;
      string attribute = cors.Request.Source?.GetAttribute(AttributeNames.Integrity);
      IIntegrityProvider integrity = cors.Integrity;
      if (string.IsNullOrEmpty(attribute) || integrity == null || result == null)
        return download;
      MemoryStream destination = new MemoryStream();
      result.Content.CopyTo((Stream) destination);
      destination.Position = 0L;
      if (!integrity.IsSatisfied(destination.ToArray(), attribute))
      {
        result.Dispose();
        throw new DomException(DomError.Security);
      }
      return download.Wrap((IResponse) new Response()
      {
        Address = result.Address,
        Content = (Stream) destination,
        Headers = result.Headers,
        StatusCode = result.StatusCode
      });
    }
  }
}
