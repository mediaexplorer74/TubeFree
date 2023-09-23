// Decompiled with JetBrains decompiler
// Type: AngleSharp.Network.Default.DataRequester
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Network.Default
{
  public sealed class DataRequester : IRequester
  {
    private static readonly string Base64Section = ";base64";

    public bool SupportsProtocol(string protocol) => protocol.Is(ProtocolNames.Data);

    public Task<IResponse> RequestAsync(IRequest request, CancellationToken cancel)
    {
      MemoryStream memoryStream = new MemoryStream();
      string str1 = request.Address.Data;
      if (str1.StartsWith(","))
        str1 = MimeTypeNames.Plain + str1;
      string[] strArray = str1.SplitCommas();
      Response result = new Response()
      {
        Address = request.Address,
        Content = (Stream) memoryStream,
        StatusCode = HttpStatusCode.BadRequest
      };
      if (strArray.Length == 2)
      {
        int startIndex = strArray[0].IndexOf(DataRequester.Base64Section);
        bool flag = startIndex >= 0;
        string str2 = flag ? strArray[0].Remove(startIndex, DataRequester.Base64Section.Length) : strArray[0];
        try
        {
          byte[] buffer = flag ? Convert.FromBase64String(strArray[1]) : strArray[1].UrlDecode();
          memoryStream.Write(buffer, 0, buffer.Length);
          memoryStream.Position = 0L;
          result.Headers.Add(HeaderNames.ContentType, str2);
          result.StatusCode = HttpStatusCode.OK;
        }
        catch (FormatException ex)
        {
        }
      }
      return TaskEx.FromResult<IResponse>((IResponse) result);
    }
  }
}
