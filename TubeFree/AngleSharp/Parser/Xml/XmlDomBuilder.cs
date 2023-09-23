// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlDomBuilder
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom;
using AngleSharp.Dom.Xml;
using AngleSharp.Extensions;
using AngleSharp.Services;
using AngleSharp.Xml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlDomBuilder
  {
    private readonly XmlTokenizer _tokenizer;
    private readonly Document _document;
    private readonly List<Element> _openElements;
    private readonly Func<Document, string, string, Element> _creator;
    private XmlParserOptions _options;
    private XmlTreeMode _currentMode;
    private bool _standalone;

    internal XmlDomBuilder(Document document, Func<Document, string, string, Element> creator = null)
    {
      IEntityProvider resolver = document.Options.GetProvider<IEntityProvider>() ?? XmlEntityService.Resolver;
      this._tokenizer = new XmlTokenizer(document.Source, resolver);
      this._document = document;
      this._standalone = false;
      this._openElements = new List<Element>();
      this._currentMode = XmlTreeMode.Initial;
      this._creator = creator ?? new Func<Document, string, string, Element>(XmlDomBuilder.CreateElement);
    }

    public Node CurrentNode => this._openElements.Count > 0 ? (Node) this._openElements[this._openElements.Count - 1] : (Node) this._document;

    public async Task<Document> ParseAsync(XmlParserOptions options, CancellationToken cancelToken)
    {
      TextSource source = this._document.Source;
      this._options = options;
      this._tokenizer.IsSuppressingErrors = options.IsSuppressingErrors;
      XmlToken token;
      do
      {
        if (source.Length - source.Index < 1024)
          await source.PrefetchAsync(8192, cancelToken).ConfigureAwait(false);
        token = this._tokenizer.Get();
        this.Consume(token);
      }
      while (token.Type != XmlTokenType.EndOfFile);
      return this._document;
    }

    public Document Parse(XmlParserOptions options)
    {
      this._options = options;
      this._tokenizer.IsSuppressingErrors = options.IsSuppressingErrors;
      XmlToken token;
      do
      {
        token = this._tokenizer.Get();
        this.Consume(token);
      }
      while (token.Type != XmlTokenType.EndOfFile);
      return this._document;
    }

    private void Consume(XmlToken token)
    {
      switch (this._currentMode)
      {
        case XmlTreeMode.Initial:
          this.Initial(token);
          break;
        case XmlTreeMode.Prolog:
          this.BeforeDoctype(token);
          break;
        case XmlTreeMode.Misc:
          this.InMisc(token);
          break;
        case XmlTreeMode.Body:
          this.InBody(token);
          break;
        case XmlTreeMode.After:
          this.AfterBody(token);
          break;
      }
    }

    private void Initial(XmlToken token)
    {
      if (token.Type == XmlTokenType.Declaration)
      {
        XmlDeclarationToken declarationToken = (XmlDeclarationToken) token;
        this._standalone = declarationToken.Standalone;
        if (!declarationToken.IsEncodingMissing)
          this.SetEncoding(declarationToken.Encoding);
        if (!this.CheckVersion(declarationToken.Version) && !this._options.IsSuppressingErrors)
          throw XmlParseError.XmlDeclarationVersionUnsupported.At(token.Position);
      }
      else
      {
        this._currentMode = XmlTreeMode.Prolog;
        this.BeforeDoctype(token);
      }
    }

    private void BeforeDoctype(XmlToken token)
    {
      if (token.Type == XmlTokenType.Doctype)
      {
        XmlDoctypeToken xmlDoctypeToken = (XmlDoctypeToken) token;
        this._document.AppendChild((INode) new DocumentType(this._document, xmlDoctypeToken.Name)
        {
          SystemIdentifier = xmlDoctypeToken.SystemIdentifier,
          PublicIdentifier = xmlDoctypeToken.PublicIdentifier
        });
        this._currentMode = XmlTreeMode.Misc;
      }
      else
        this.InMisc(token);
    }

    private void InMisc(XmlToken token)
    {
      switch (token.Type)
      {
        case XmlTokenType.StartTag:
          this._currentMode = XmlTreeMode.Body;
          this.InBody(token);
          break;
        case XmlTokenType.Comment:
          this.CurrentNode.AppendChild((INode) this._document.CreateComment(((XmlCommentToken) token).Data));
          break;
        case XmlTokenType.ProcessingInstruction:
          XmlPIToken xmlPiToken = (XmlPIToken) token;
          this.CurrentNode.AppendChild((INode) this._document.CreateProcessingInstruction(xmlPiToken.Target, xmlPiToken.Content));
          break;
        default:
          if (token.IsIgnorable || this._options.IsSuppressingErrors)
            break;
          throw XmlParseError.XmlMissingRoot.At(token.Position);
      }
    }

    private void InBody(XmlToken token)
    {
      switch (token.Type)
      {
        case XmlTokenType.Doctype:
          if (this._options.IsSuppressingErrors)
            break;
          throw XmlParseError.XmlDoctypeAfterContent.At(token.Position);
        case XmlTokenType.Declaration:
          if (this._options.IsSuppressingErrors)
            break;
          throw XmlParseError.XmlDeclarationMisplaced.At(token.Position);
        case XmlTokenType.StartTag:
          XmlTagToken xmlTagToken = (XmlTagToken) token;
          Element child = this._creator(this._document, xmlTagToken.Name, (string) null);
          this.CurrentNode.AppendChild((INode) child);
          if (!xmlTagToken.IsSelfClosing)
            this._openElements.Add(child);
          else if (this._openElements.Count == 0)
            this._currentMode = XmlTreeMode.After;
          for (int index = 0; index < xmlTagToken.Attributes.Count; ++index)
          {
            KeyValuePair<string, string> attribute = xmlTagToken.Attributes[index];
            string key = attribute.Key;
            attribute = xmlTagToken.Attributes[index];
            string str = attribute.Value.Trim();
            child.SetAttribute(key, str);
          }
          if (this._options.OnCreated == null)
            break;
          this._options.OnCreated((IElement) child, xmlTagToken.Position);
          break;
        case XmlTokenType.EndTag:
          if (!this.CurrentNode.NodeName.Is(((XmlTagToken) token).Name))
          {
            if (this._options.IsSuppressingErrors)
              break;
            throw XmlParseError.TagClosingMismatch.At(token.Position);
          }
          this._openElements.RemoveAt(this._openElements.Count - 1);
          if (this._openElements.Count != 0)
            break;
          this._currentMode = XmlTreeMode.After;
          break;
        case XmlTokenType.Comment:
        case XmlTokenType.ProcessingInstruction:
          this.InMisc(token);
          break;
        case XmlTokenType.CData:
          this.CurrentNode.AppendText(((XmlCDataToken) token).Data);
          break;
        case XmlTokenType.Character:
          this.CurrentNode.AppendText(((XmlCharacterToken) token).Data);
          break;
        case XmlTokenType.EndOfFile:
          if (this._options.IsSuppressingErrors)
            break;
          throw XmlParseError.EOF.At(token.Position);
      }
    }

    private void AfterBody(XmlToken token)
    {
      switch (token.Type)
      {
        case XmlTokenType.Comment:
        case XmlTokenType.ProcessingInstruction:
          this.InMisc(token);
          break;
        case XmlTokenType.EndOfFile:
          break;
        default:
          if (token.IsIgnorable || this._options.IsSuppressingErrors)
            break;
          throw XmlParseError.XmlMissingRoot.At(token.Position);
      }
    }

    private static Element CreateElement(Document document, string name, string prefix) => (Element) new XmlElement(document, name, prefix);

    private bool CheckVersion(string ver)
    {
      double num = ver.ToDouble();
      return num >= 1.0 && num < 2.0;
    }

    private void SetEncoding(string charSet)
    {
      if (!TextEncoding.IsSupported(charSet))
        return;
      Encoding encoding = TextEncoding.Resolve(charSet);
      if (encoding == null)
        return;
      try
      {
        this._document.Source.CurrentEncoding = encoding;
      }
      catch (NotSupportedException ex)
      {
        this._currentMode = XmlTreeMode.Initial;
        this._document.ReplaceAll((Node) null, true);
        this._openElements.Clear();
      }
    }
  }
}
