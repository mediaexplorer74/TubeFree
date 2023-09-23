// Decompiled with JetBrains decompiler
// Type: AngleSharp.AutoSelectedMarkupFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Html;
using AngleSharp.XHtml;
using AngleSharp.Xml;

namespace AngleSharp
{
  public sealed class AutoSelectedMarkupFormatter : IMarkupFormatter
  {
    private IMarkupFormatter childFormatter;
    private IDocumentType _docType;

    public AutoSelectedMarkupFormatter(IDocumentType docType = null) => this._docType = docType;

    private IMarkupFormatter ChildFormatter
    {
      get
      {
        if (this.childFormatter == null && this._docType != null)
        {
          if (this._docType.PublicIdentifier.Contains("XML"))
            this.childFormatter = XmlMarkupFormatter.Instance;
          else if (this._docType.PublicIdentifier.Contains("XHTML"))
            this.childFormatter = XhtmlMarkupFormatter.Instance;
        }
        return this.childFormatter ?? HtmlMarkupFormatter.Instance;
      }
      set => this.childFormatter = value;
    }

    public string Attribute(IAttr attribute) => this.ChildFormatter.Attribute(attribute);

    public string OpenTag(IElement element, bool selfClosing)
    {
      this.Confirm(element.Owner.Doctype);
      return this.ChildFormatter.OpenTag(element, selfClosing);
    }

    public string CloseTag(IElement element, bool selfClosing)
    {
      this.Confirm(element.Owner.Doctype);
      return this.ChildFormatter.CloseTag(element, selfClosing);
    }

    public string Comment(IComment comment)
    {
      this.Confirm(comment.Owner.Doctype);
      return this.ChildFormatter.Comment(comment);
    }

    public string Doctype(IDocumentType doctype)
    {
      this.Confirm(doctype);
      return this.ChildFormatter.Doctype(doctype);
    }

    public string Processing(IProcessingInstruction processing)
    {
      this.Confirm(processing.Owner.Doctype);
      return this.ChildFormatter.Processing(processing);
    }

    public string Text(string text) => this.ChildFormatter.Text(text);

    private void Confirm(IDocumentType docType)
    {
      if (this._docType != null)
        return;
      this._docType = docType;
    }
  }
}
