// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.InputTypes.ImageInputType
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Network.RequestProcessors;

namespace AngleSharp.Html.InputTypes
{
  internal class ImageInputType : BaseInputType
  {
    private readonly ImageRequestProcessor _request;

    public ImageInputType(IHtmlInputElement input, string name)
      : base(input, name, true)
    {
      HtmlInputElement htmlInputElement = input as HtmlInputElement;
      string source = input.Source;
      if (source == null || htmlInputElement == null)
        return;
      Url url = htmlInputElement.HyperReference(source);
      this._request = ImageRequestProcessor.Create((Element) htmlInputElement);
      htmlInputElement.Process((IRequestProcessor) this._request, url);
    }

    public int Width => this._request == null ? 0 : this._request.Width;

    public int Height => this._request == null ? 0 : this._request.Height;

    public override bool IsAppendingData(IHtmlElement submitter) => submitter == this.Input && !string.IsNullOrEmpty(this.Input.Name);

    public override void ConstructDataSet(FormDataSet dataSet)
    {
      string name = this.Input.Name;
      string str = this.Input.Value;
      dataSet.Append(name + ".x", "0", this.Input.Type);
      dataSet.Append(name + ".y", "0", this.Input.Type);
      if (string.IsNullOrEmpty(str))
        return;
      dataSet.Append(name, str, this.Input.Type);
    }
  }
}
