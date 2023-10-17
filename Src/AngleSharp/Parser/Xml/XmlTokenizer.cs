// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlTokenizer
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Services;

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlTokenizer : BaseTokenizer
  {
    private readonly IEntityProvider _resolver;
    private TextPosition _position;

    public XmlTokenizer(TextSource source, IEntityProvider resolver)
      : base(source)
    {
      this._resolver = resolver;
    }

    public bool IsSuppressingErrors { get; set; }

    public XmlToken Get()
    {
      char next = this.GetNext();
      if (next == char.MaxValue)
        return (XmlToken) this.NewEof();
      this._position = this.GetCurrentPosition();
      return this.Data(next);
    }

    private XmlToken Data(char c)
    {
      if (c == '<')
        return this.TagOpen();
      return c == char.MaxValue ? (XmlToken) this.NewEof() : this.DataText(c);
    }

    private XmlToken DataText(char c)
    {
      while (true)
      {
        switch (c)
        {
          case '&':
            this.StringBuffer.Append(this.CharacterReference());
            c = this.GetNext();
            continue;
          case '<':
          case char.MaxValue:
            goto label_1;
          case ']':
            this.StringBuffer.Append(c);
            c = this.CheckNextCharacter();
            continue;
          default:
            this.StringBuffer.Append(c);
            c = this.GetNext();
            continue;
        }
      }
label_1:
      this.Back();
      return (XmlToken) this.NewCharacters();
    }

    private char CheckNextCharacter()
    {
      int next = (int) this.GetNext();
      if (next != 93)
        return (char) next;
      if (this.GetNext() == '>')
        throw XmlParseError.XmlInvalidCharData.At(this.GetCurrentPosition());
      this.Back();
      return (char) next;
    }

    private XmlCDataToken CData()
    {
      for (char next = this.GetNext(); next != char.MaxValue; next = this.GetNext())
      {
        if (next == ']' && this.ContinuesWithSensitive("]]>"))
        {
          this.Advance(2);
          return this.NewCharacterData();
        }
        this.StringBuffer.Append(next);
      }
      throw XmlParseError.EOF.At(this.GetCurrentPosition());
    }

    private string CharacterReference()
    {
      char next = this.GetNext();
      int length1 = this.StringBuffer.Length;
      bool flag = next == '#';
      if (flag)
      {
        next = this.GetNext();
        if ((next == 'x' ? 1 : (next == 'X' ? 1 : 0)) != 0)
        {
          for (next = this.GetNext(); next.IsHex(); next = this.GetNext())
            this.StringBuffer.Append(next);
        }
        else
        {
          for (; next.IsDigit(); next = this.GetNext())
            this.StringBuffer.Append(next);
        }
      }
      else if (next.IsXmlNameStart())
      {
        do
        {
          this.StringBuffer.Append(next);
          next = this.GetNext();
        }
        while (next.IsXmlName());
      }
      if (next == ';' && this.StringBuffer.Length > length1)
      {
        int length2 = this.StringBuffer.Length - length1;
        string str = this.StringBuffer.ToString(length1, length2);
        if (flag)
        {
          int num = flag ? str.FromHex() : str.FromDec();
          if (num.IsValidAsCharRef())
          {
            this.StringBuffer.Remove(length1, length2);
            return num.ConvertFromUtf32();
          }
        }
        else
        {
          string symbol = this._resolver.GetSymbol(str);
          if (!string.IsNullOrEmpty(symbol))
          {
            this.StringBuffer.Remove(length1, length2);
            return symbol;
          }
        }
        if (!this.IsSuppressingErrors)
          throw XmlParseError.CharacterReferenceInvalidCode.At(this._position);
        this.StringBuffer.Append(next);
      }
      if (!this.IsSuppressingErrors)
        throw XmlParseError.CharacterReferenceNotTerminated.At(this.GetCurrentPosition());
      this.StringBuffer.Insert(length1, '&');
      return string.Empty;
    }

    private XmlToken TagOpen()
    {
      char next1 = this.GetNext();
      switch (next1)
      {
        case '!':
          return this.MarkupDeclaration();
        case '/':
          return this.TagEnd();
        case '?':
          char next2 = this.GetNext();
          if (!this.ContinuesWithSensitive(TagNames.Xml))
            return this.ProcessingStart(next2);
          this.Advance(2);
          return this.DeclarationStart();
        default:
          if (!next1.IsXmlNameStart())
            throw XmlParseError.XmlInvalidStartTag.At(this.GetCurrentPosition());
          this.StringBuffer.Append(next1);
          return this.TagName(this.NewOpenTag());
      }
    }

    private XmlToken TagEnd()
    {
      char next = this.GetNext();
      if (next.IsXmlNameStart())
      {
        do
        {
          this.StringBuffer.Append(next);
          next = this.GetNext();
        }
        while (next.IsXmlName());
        while (next.IsSpaceCharacter())
          next = this.GetNext();
        if (next == '>')
        {
          XmlTagToken xmlTagToken = this.NewCloseTag();
          xmlTagToken.Name = this.FlushBuffer();
          return (XmlToken) xmlTagToken;
        }
      }
      if (next == char.MaxValue)
        throw XmlParseError.EOF.At(this.GetCurrentPosition());
      throw XmlParseError.XmlInvalidEndTag.At(this.GetCurrentPosition());
    }

    private XmlToken TagName(XmlTagToken tag)
    {
      char next;
      for (next = this.GetNext(); next.IsXmlName(); next = this.GetNext())
        this.StringBuffer.Append(next);
      tag.Name = this.FlushBuffer();
      if (next == char.MaxValue)
        throw XmlParseError.EOF.At(this.GetCurrentPosition());
      if (next == '>')
        return (XmlToken) tag;
      if (next.IsSpaceCharacter())
        return this.AttributeBeforeName(tag);
      if (next == '/')
        return this.TagSelfClosing(tag);
      throw XmlParseError.XmlInvalidName.At(this.GetCurrentPosition());
    }

    private XmlToken TagSelfClosing(XmlTagToken tag)
    {
      char next = this.GetNext();
      tag.IsSelfClosing = true;
      if (next == '>')
        return (XmlToken) tag;
      if (next == char.MaxValue)
        throw XmlParseError.EOF.At(this.GetCurrentPosition());
      throw XmlParseError.XmlInvalidName.At(this.GetCurrentPosition());
    }

    private XmlToken MarkupDeclaration()
    {
      int next = (int) this.GetNext();
      if (this.ContinuesWithSensitive("--"))
      {
        this.Advance();
        return this.CommentStart();
      }
      if (this.ContinuesWithSensitive(TagNames.Doctype))
      {
        this.Advance(6);
        return this.Doctype();
      }
      if (!this.ContinuesWithSensitive(Keywords.CData))
        throw XmlParseError.UndefinedMarkupDeclaration.At(this.GetCurrentPosition());
      this.Advance(6);
      return (XmlToken) this.CData();
    }

    private XmlToken DeclarationStart()
    {
      char next = this.GetNext();
      if (!next.IsSpaceCharacter())
      {
        this.StringBuffer.Append(TagNames.Xml);
        return this.ProcessingTarget(next, this.NewProcessing());
      }
      do
        ;
      while (this.GetNext().IsSpaceCharacter());
      if (!this.ContinuesWithSensitive(AttributeNames.Version))
        throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      this.Advance(6);
      return this.DeclarationVersionAfterName(this.NewDeclaration());
    }

    private XmlToken DeclarationVersionAfterName(XmlDeclarationToken decl)
    {
      if (this.SkipSpaces() != '=')
        throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      return this.DeclarationVersionBeforeValue(decl);
    }

    private XmlToken DeclarationVersionBeforeValue(XmlDeclarationToken decl)
    {
      char quote = this.SkipSpaces();
      switch (quote)
      {
        case '"':
        case '\'':
          return this.DeclarationVersionValue(decl, quote);
        default:
          throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      }
    }

    private XmlToken DeclarationVersionValue(XmlDeclarationToken decl, char quote)
    {
      for (char next = this.GetNext(); (int) next != (int) quote; next = this.GetNext())
      {
        if (next == char.MaxValue)
          throw XmlParseError.EOF.At(this.GetCurrentPosition());
        this.StringBuffer.Append(next);
      }
      decl.Version = this.FlushBuffer();
      char next1 = this.GetNext();
      return next1.IsSpaceCharacter() ? this.DeclarationAfterVersion(decl) : (XmlToken) this.DeclarationEnd(next1, decl);
    }

    private XmlToken DeclarationAfterVersion(XmlDeclarationToken decl)
    {
      char c = this.SkipSpaces();
      if (this.ContinuesWithSensitive(AttributeNames.Encoding))
      {
        this.Advance(7);
        return this.DeclarationEncodingAfterName(decl);
      }
      if (!this.ContinuesWithSensitive(AttributeNames.Standalone))
        return (XmlToken) this.DeclarationEnd(c, decl);
      this.Advance(9);
      return this.DeclarationStandaloneAfterName(decl);
    }

    private XmlToken DeclarationEncodingAfterName(XmlDeclarationToken decl)
    {
      if (this.SkipSpaces() != '=')
        throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      return this.DeclarationEncodingBeforeValue(decl);
    }

    private XmlToken DeclarationEncodingBeforeValue(XmlDeclarationToken decl)
    {
      char ch = this.SkipSpaces();
      switch (ch)
      {
        case '"':
        case '\'':
          char quote = ch;
          char next = this.GetNext();
          if (next.IsLetter())
          {
            this.StringBuffer.Append(next);
            return this.DeclarationEncodingValue(decl, quote);
          }
          break;
      }
      throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken DeclarationEncodingValue(XmlDeclarationToken decl, char quote)
    {
      for (char next = this.GetNext(); (int) next != (int) quote; next = this.GetNext())
      {
        if (!next.IsAlphanumericAscii() && next != '.' && next != '_' && next != '-')
          throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
        this.StringBuffer.Append(next);
      }
      decl.Encoding = this.FlushBuffer();
      char next1 = this.GetNext();
      return next1.IsSpaceCharacter() ? this.DeclarationAfterEncoding(decl) : (XmlToken) this.DeclarationEnd(next1, decl);
    }

    private XmlToken DeclarationAfterEncoding(XmlDeclarationToken decl)
    {
      char c = this.SkipSpaces();
      if (!this.ContinuesWithSensitive(AttributeNames.Standalone))
        return (XmlToken) this.DeclarationEnd(c, decl);
      this.Advance(9);
      return this.DeclarationStandaloneAfterName(decl);
    }

    private XmlToken DeclarationStandaloneAfterName(XmlDeclarationToken decl)
    {
      if (this.SkipSpaces() != '=')
        throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      return this.DeclarationStandaloneBeforeValue(decl);
    }

    private XmlToken DeclarationStandaloneBeforeValue(XmlDeclarationToken decl)
    {
      char quote = this.SkipSpaces();
      switch (quote)
      {
        case '"':
        case '\'':
          return this.DeclarationStandaloneValue(decl, quote);
        default:
          throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      }
    }

    private XmlToken DeclarationStandaloneValue(XmlDeclarationToken decl, char quote)
    {
      for (char next = this.GetNext(); (int) next != (int) quote; next = this.GetNext())
      {
        if (next == char.MaxValue)
          throw XmlParseError.EOF.At(this.GetCurrentPosition());
        this.StringBuffer.Append(next);
      }
      string current = this.FlushBuffer();
      if (current.Is(Keywords.Yes))
      {
        decl.Standalone = true;
      }
      else
      {
        if (!current.Is(Keywords.No))
          throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
        decl.Standalone = false;
      }
      return (XmlToken) this.DeclarationEnd(this.GetNext(), decl);
    }

    private XmlDeclarationToken DeclarationEnd(char c, XmlDeclarationToken decl)
    {
      while (c.IsSpaceCharacter())
        c = this.GetNext();
      if (c != '?' || this.GetNext() != '>')
        throw XmlParseError.XmlDeclarationInvalid.At(this.GetCurrentPosition());
      return decl;
    }

    private XmlToken Doctype()
    {
      if (this.GetNext().IsSpaceCharacter())
        return this.DoctypeNameBefore();
      throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken DoctypeNameBefore()
    {
      char c = this.SkipSpaces();
      if (!c.IsXmlNameStart())
        throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
      this.StringBuffer.Append(c);
      return this.DoctypeName(this.NewDoctype());
    }

    private XmlToken DoctypeName(XmlDoctypeToken doctype)
    {
      char next;
      for (next = this.GetNext(); next.IsXmlName(); next = this.GetNext())
        this.StringBuffer.Append(next);
      doctype.Name = this.FlushBuffer();
      if (next == '>')
        return (XmlToken) doctype;
      if (next.IsSpaceCharacter())
        return this.DoctypeNameAfter(doctype);
      throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken DoctypeNameAfter(XmlDoctypeToken doctype)
    {
      char ch = this.SkipSpaces();
      if (ch == '>')
        return (XmlToken) doctype;
      if (this.ContinuesWithSensitive(Keywords.Public))
      {
        this.Advance(5);
        return this.DoctypePublic(doctype);
      }
      if (this.ContinuesWithSensitive(Keywords.System))
      {
        this.Advance(5);
        return this.DoctypeSystem(doctype);
      }
      if (ch != '[')
        throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
      this.Advance();
      return this.DoctypeAfter(this.GetNext(), doctype);
    }

    private XmlToken DoctypePublic(XmlDoctypeToken doctype)
    {
      if (this.GetNext().IsSpaceCharacter())
      {
        char quote = this.SkipSpaces();
        switch (quote)
        {
          case '"':
          case '\'':
            doctype.PublicIdentifier = string.Empty;
            return this.DoctypePublicIdentifierValue(doctype, quote);
        }
      }
      throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken DoctypePublicIdentifierValue(XmlDoctypeToken doctype, char quote)
    {
      for (char next = this.GetNext(); (int) next != (int) quote; next = this.GetNext())
      {
        if (!next.IsPubidChar())
          throw XmlParseError.XmlInvalidPubId.At(this.GetCurrentPosition());
        this.StringBuffer.Append(next);
      }
      doctype.PublicIdentifier = this.FlushBuffer();
      return this.DoctypePublicIdentifierAfter(doctype);
    }

    private XmlToken DoctypePublicIdentifierAfter(XmlDoctypeToken doctype)
    {
      char next = this.GetNext();
      if (next == '>')
        return (XmlToken) doctype;
      if (next.IsSpaceCharacter())
        return this.DoctypeBetween(doctype);
      throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken DoctypeBetween(XmlDoctypeToken doctype)
    {
      char quote = this.SkipSpaces();
      switch (quote)
      {
        case '"':
        case '\'':
          doctype.SystemIdentifier = string.Empty;
          return this.DoctypeSystemIdentifierValue(doctype, quote);
        case '>':
          return (XmlToken) doctype;
        default:
          throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
      }
    }

    private XmlToken DoctypeSystem(XmlDoctypeToken doctype)
    {
      if (this.GetNext().IsSpaceCharacter())
      {
        char quote = this.SkipSpaces();
        switch (quote)
        {
          case '"':
          case '\'':
            doctype.SystemIdentifier = string.Empty;
            return this.DoctypeSystemIdentifierValue(doctype, quote);
        }
      }
      throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken DoctypeSystemIdentifierValue(XmlDoctypeToken doctype, char quote)
    {
      for (char next = this.GetNext(); (int) next != (int) quote; next = this.GetNext())
      {
        if (next == char.MaxValue)
          throw XmlParseError.EOF.At(this.GetCurrentPosition());
        this.StringBuffer.Append(next);
      }
      doctype.SystemIdentifier = this.FlushBuffer();
      return this.DoctypeSystemIdentifierAfter(doctype);
    }

    private XmlToken DoctypeSystemIdentifierAfter(XmlDoctypeToken doctype)
    {
      char c = this.SkipSpaces();
      if (c == '[')
      {
        this.Advance();
        c = this.GetNext();
      }
      return this.DoctypeAfter(c, doctype);
    }

    private XmlToken DoctypeAfter(char c, XmlDoctypeToken doctype)
    {
      while (c.IsSpaceCharacter())
        c = this.GetNext();
      if (c == '>')
        return (XmlToken) doctype;
      throw XmlParseError.DoctypeInvalid.At(this.GetCurrentPosition());
    }

    private XmlToken AttributeBeforeName(XmlTagToken tag)
    {
      char c = this.SkipSpaces();
      switch (c)
      {
        case '/':
          return this.TagSelfClosing(tag);
        case '>':
          return (XmlToken) tag;
        case char.MaxValue:
          throw XmlParseError.EOF.At(this.GetCurrentPosition());
        default:
          if (!c.IsXmlNameStart())
            throw XmlParseError.XmlInvalidAttribute.At(this.GetCurrentPosition());
          this.StringBuffer.Append(c);
          return this.AttributeName(tag);
      }
    }

    private XmlToken AttributeName(XmlTagToken tag)
    {
      char next;
      for (next = this.GetNext(); next.IsXmlName(); next = this.GetNext())
        this.StringBuffer.Append(next);
      string name = this.FlushBuffer();
      if (!string.IsNullOrEmpty(tag.GetAttribute(name)))
        throw XmlParseError.XmlUniqueAttribute.At(this.GetCurrentPosition());
      tag.AddAttribute(name);
      if (next.IsSpaceCharacter())
      {
        do
        {
          next = this.GetNext();
        }
        while (next.IsSpaceCharacter());
      }
      if (next != '=')
        throw XmlParseError.XmlInvalidAttribute.At(this.GetCurrentPosition());
      return this.AttributeBeforeValue(tag);
    }

    private XmlToken AttributeBeforeValue(XmlTagToken tag)
    {
      char quote = this.SkipSpaces();
      switch (quote)
      {
        case '"':
        case '\'':
          return this.AttributeValue(tag, quote);
        default:
          throw XmlParseError.XmlInvalidAttribute.At(this.GetCurrentPosition());
      }
    }

    private XmlToken AttributeValue(XmlTagToken tag, char quote)
    {
      for (char next = this.GetNext(); (int) next != (int) quote; next = this.GetNext())
      {
        if (next == char.MaxValue)
          throw XmlParseError.EOF.At(this.GetCurrentPosition());
        if (next == '<')
          throw XmlParseError.XmlLtInAttributeValue.At(this.GetCurrentPosition());
        if (next == '&')
          this.StringBuffer.Append(this.CharacterReference());
        else
          this.StringBuffer.Append(next);
      }
      tag.SetAttributeValue(this.FlushBuffer());
      return this.AttributeAfterValue(tag);
    }

    private XmlToken AttributeAfterValue(XmlTagToken tag)
    {
      char next = this.GetNext();
      if (next.IsSpaceCharacter())
        return this.AttributeBeforeName(tag);
      if (next == '/')
        return this.TagSelfClosing(tag);
      if (next == '>')
        return (XmlToken) tag;
      throw XmlParseError.XmlInvalidAttribute.At(this.GetCurrentPosition());
    }

    private XmlToken ProcessingStart(char c)
    {
      if (!c.IsXmlNameStart())
        throw XmlParseError.XmlInvalidPI.At(this.GetCurrentPosition());
      this.StringBuffer.Append(c);
      return this.ProcessingTarget(this.GetNext(), this.NewProcessing());
    }

    private XmlToken ProcessingTarget(char c, XmlPIToken pi)
    {
      for (; c.IsXmlName(); c = this.GetNext())
        this.StringBuffer.Append(c);
      pi.Target = this.FlushBuffer();
      if (pi.Target.Isi(TagNames.Xml))
        throw XmlParseError.XmlInvalidPI.At(this.GetCurrentPosition());
      if (c == '?')
      {
        c = this.GetNext();
        if (c == '>')
          return (XmlToken) pi;
      }
      else if (c.IsSpaceCharacter())
        return this.ProcessingContent(pi);
      throw XmlParseError.XmlInvalidPI.At(this.GetCurrentPosition());
    }

    private XmlToken ProcessingContent(XmlPIToken pi)
    {
      char next = this.GetNext();
      while (next != char.MaxValue)
      {
        if (next == '?')
        {
          next = this.GetNext();
          if (next == '>')
          {
            pi.Content = this.FlushBuffer();
            return (XmlToken) pi;
          }
          this.StringBuffer.Append('?');
        }
        else
        {
          this.StringBuffer.Append(next);
          next = this.GetNext();
        }
      }
      throw XmlParseError.EOF.At(this.GetCurrentPosition());
    }

    private XmlToken CommentStart() => this.Comment(this.GetNext());

    private XmlToken Comment(char c)
    {
      for (; c.IsXmlChar(); c = this.GetNext())
      {
        if (c == '-')
          return this.CommentDash();
        this.StringBuffer.Append(c);
      }
      throw XmlParseError.XmlInvalidComment.At(this.GetCurrentPosition());
    }

    private XmlToken CommentDash()
    {
      char next = this.GetNext();
      return next == '-' ? this.CommentEnd() : this.Comment(next);
    }

    private XmlToken CommentEnd()
    {
      if (this.GetNext() == '>')
        return (XmlToken) this.NewComment();
      throw XmlParseError.XmlInvalidComment.At(this.GetCurrentPosition());
    }

    private XmlEndOfFileToken NewEof() => new XmlEndOfFileToken(this.GetCurrentPosition());

    private XmlCharacterToken NewCharacters() => new XmlCharacterToken(this._position, this.FlushBuffer());

    private XmlCommentToken NewComment() => new XmlCommentToken(this._position, this.FlushBuffer());

    private XmlPIToken NewProcessing() => new XmlPIToken(this._position);

    private XmlDoctypeToken NewDoctype() => new XmlDoctypeToken(this._position);

    private XmlDeclarationToken NewDeclaration() => new XmlDeclarationToken(this._position);

    private XmlTagToken NewOpenTag() => new XmlTagToken(XmlTokenType.StartTag, this._position);

    private XmlTagToken NewCloseTag() => new XmlTagToken(XmlTokenType.EndTag, this._position);

    private XmlCDataToken NewCharacterData() => new XmlCDataToken(this._position, this.FlushBuffer());
  }
}
