// Decompiled with JetBrains decompiler
// Type: YoutubeExplode.Internal.HttpClientEx
// Assembly: Explode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D9BD94EC-1F8A-4D23-A0FC-F2CF6230133A
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Explode.dll

using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace YoutubeExplode.Internal
{
  internal static class HttpClientEx
  {
    private static HttpClient _singleton;

    public static HttpClient GetSingleton()
    {
      if (HttpClientEx._singleton != null)
        return HttpClientEx._singleton;
      HttpClientHandler handler = new HttpClientHandler();
      if (handler.SupportsAutomaticDecompression)
        handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
      handler.UseCookies = false;
      return HttpClientEx._singleton = new HttpClient((HttpMessageHandler) handler, true);
    }

    public static async Task<HttpResponseMessage> HeadAsync(
      this HttpClient client,
      string requestUri)
    {
      HttpResponseMessage httpResponseMessage;
      using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, requestUri))
        httpResponseMessage = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
      return httpResponseMessage;
    }

    public static async Task<string> GetStringAsync(
      this HttpClient client,
      string requestUri,
      bool ensureSuccess = true)
    {
      string stringAsync;
      using (HttpResponseMessage response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
      {
        if (ensureSuccess)
          response.EnsureSuccessStatusCode();
        stringAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
      }
      return stringAsync;
    }

    public static async Task<Stream> GetStreamAsync(
      this HttpClient client,
      string requestUri,
      long? from = null,
      long? to = null,
      bool ensureSuccess = true)
    {
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
      request.Headers.Range = new RangeHeaderValue(from, to);
      Stream streamAsync;
      using (request)
      {
        HttpResponseMessage httpResponseMessage = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        if (ensureSuccess)
          httpResponseMessage.EnsureSuccessStatusCode();
        streamAsync = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
      }
      return streamAsync;
    }

    public static async Task<long?> GetContentLengthAsync(
      this HttpClient client,
      string requestUri,
      bool ensureSuccess = true)
    {
      long? contentLength;
      using (HttpResponseMessage httpResponseMessage = await client.HeadAsync(requestUri).ConfigureAwait(false))
      {
        if (ensureSuccess)
          httpResponseMessage.EnsureSuccessStatusCode();
        contentLength = httpResponseMessage.Content.Headers.ContentLength;
      }
      return contentLength;
    }

    public static SegmentedHttpStream CreateSegmentedStream(
      this HttpClient httpClient,
      string url,
      long length,
      long segmentSize)
    {
      return new SegmentedHttpStream(httpClient, url, length, segmentSize);
    }
  }
}
