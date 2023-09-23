// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.PrettyMarkupFormatter
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using System.Linq;

namespace AngleSharp.Html
{
  public class PrettyMarkupFormatter : IMarkupFormatter
  {
    private string _intendString;
    private string _newLineString;
    private int _intendCount;

    public PrettyMarkupFormatter()
    {
      this._intendCount = 0;
      this._intendString = "\t";
      this._newLineString = "\n";
    }

    public string Indentation
    {
      get => this._intendString;
      set => this._intendString = value;
    }

    public string NewLine
    {
      get => this._newLineString;
      set => this._newLineString = value;
    }

    string IMarkupFormatter.Comment(IComment comment) => this.IntendBefore(comment.PreviousSibling) + HtmlMarkupFormatter.Instance.Comment(comment) + this.NewLineAfter(comment.NextSibling);

    string IMarkupFormatter.Doctype(IDocumentType doctype) => this.IntendBefore(doctype.PreviousSibling) + HtmlMarkupFormatter.Instance.Doctype(doctype) + this.NewLineAfter(doctype.NextSibling);

    string IMarkupFormatter.Processing(IProcessingInstruction processing) => this.IntendBefore(processing.PreviousSibling) + HtmlMarkupFormatter.Instance.Processing(processing) + this.NewLineAfter(processing.NextSibling);

    string IMarkupFormatter.Text(string text)
    {
      string text1 = text.Replace('\n', ' ');
      return HtmlMarkupFormatter.Instance.Text(text1);
    }

    string IMarkupFormatter.OpenTag(IElement element, bool selfClosing)
    {
      string str1 = this.IntendBefore(element.PreviousSibling ?? element.Parent);
      ++this._intendCount;
      string str2 = HtmlMarkupFormatter.Instance.OpenTag(element, selfClosing);
      string str3 = this.NewLineAfter(element.FirstChild ?? element.NextSibling);
      return str1 + str2 + str3;
    }

    string IMarkupFormatter.CloseTag(IElement element, bool selfClosing)
    {
      --this._intendCount;
      return this.IntendBefore(element.LastChild ?? element.Parent) + HtmlMarkupFormatter.Instance.CloseTag(element, selfClosing) + this.NewLineAfter(element.NextSibling ?? element.Parent);
    }

    string IMarkupFormatter.Attribute(IAttr attribute) => HtmlMarkupFormatter.Instance.Attribute(attribute);

    private string NewLineAfter(INode node) => node != null && node.NodeType != NodeType.Text ? this._newLineString : string.Empty;

    private string IntendBefore(INode node) => node != null && node.NodeType != NodeType.Text ? string.Join(string.Empty, Enumerable.Repeat<string>(this._intendString, this._intendCount)) : string.Empty;
  }
}
