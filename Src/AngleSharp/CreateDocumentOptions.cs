// Decompiled with JetBrains decompiler
// Type: AngleSharp.CreateDocumentOptions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;

namespace AngleSharp
{
  public sealed class CreateDocumentOptions
  {
    private readonly IResponse _response;
    private readonly MimeType _contentType;
    private readonly TextSource _source;
    private readonly IDocument _ancestor;

    public CreateDocumentOptions(
      IResponse response,
      IConfiguration configuration,
      IDocument ancestor = null)
    {
      MimeType contentType = response.GetContentType(MimeTypeNames.Html);
      string parameter = contentType.GetParameter(AttributeNames.Charset);
      TextSource textSource = new TextSource(response.Content, configuration.DefaultEncoding());
      if (!string.IsNullOrEmpty(parameter) && TextEncoding.IsSupported(parameter))
        textSource.CurrentEncoding = TextEncoding.Resolve(parameter);
      this._source = textSource;
      this._contentType = contentType;
      this._response = response;
      this._ancestor = ancestor;
    }

    public IResponse Response => this._response;

    public MimeType ContentType => this._contentType;

    public TextSource Source => this._source;

    public IDocument ImportAncestor => this._ancestor;
  }
}
