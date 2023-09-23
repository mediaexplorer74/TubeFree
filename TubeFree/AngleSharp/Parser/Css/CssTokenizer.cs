// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Css.CssTokenizer
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using System;
using System.Globalization;

namespace AngleSharp.Parser.Css
{
  internal sealed class CssTokenizer : BaseTokenizer
  {
    private bool _valueMode;
    private TextPosition _position;

    public event EventHandler<CssErrorEvent> Error;

    public CssTokenizer(TextSource source)
      : base(source)
    {
      this._valueMode = false;
    }

    public bool IsInValue
    {
      get => this._valueMode;
      set => this._valueMode = value;
    }

    public CssToken Get()
    {
      char next = this.GetNext();
      this._position = this.GetCurrentPosition();
      return this.Data(next);
    }

    internal void RaiseErrorOccurred(CssParseError error, TextPosition position)
    {
      EventHandler<CssErrorEvent> error1 = this.Error;
      if (error1 == null)
        return;
      CssErrorEvent e = new CssErrorEvent(error, position);
      error1((object) this, e);
    }

    private CssToken Data(char current)
    {
      this._position = this.GetCurrentPosition();
      switch (current)
      {
        case '\t':
        case '\n':
        case '\f':
        case '\r':
        case ' ':
          return this.NewWhitespace(current);
        case '!':
          current = this.GetNext();
          return current == '=' ? this.NewMatch(CombinatorSymbols.Unlike) : this.NewDelimiter(this.GetPrevious());
        case '"':
          return this.StringDQ();
        case '#':
          return !this._valueMode ? this.HashStart() : this.ColorLiteral();
        case '$':
          current = this.GetNext();
          return current == '=' ? this.NewMatch(CombinatorSymbols.Ends) : this.NewDelimiter(this.GetPrevious());
        case '\'':
          return this.StringSQ();
        case '(':
          return this.NewOpenRound();
        case ')':
          return this.NewCloseRound();
        case '*':
          current = this.GetNext();
          return current == '=' ? this.NewMatch(CombinatorSymbols.InText) : this.NewDelimiter(this.GetPrevious());
        case '+':
          char next1 = this.GetNext();
          if (next1 != char.MaxValue)
          {
            char next2 = this.GetNext();
            this.Back(2);
            if (next1.IsDigit() || next1 == '.' && next2.IsDigit())
              return this.NumberStart(current);
          }
          else
            this.Back();
          return this.NewDelimiter(current);
        case ',':
          return this.NewComma();
        case '-':
          char next3 = this.GetNext();
          if (next3 != char.MaxValue)
          {
            char next4 = this.GetNext();
            this.Back(2);
            if (next3.IsDigit() || next3 == '.' && next4.IsDigit())
              return this.NumberStart(current);
            if (next3.IsNameStart() || next3 == '\\' && !next4.IsLineBreak() && next4 != char.MaxValue)
              return this.IdentStart(current);
            if (next3 == '-' && next4 == '>')
            {
              this.Advance(2);
              return this.NewCloseComment();
            }
          }
          else
            this.Back();
          return this.NewDelimiter(current);
        case '.':
          return this.GetNext().IsDigit() ? this.NumberStart(this.GetPrevious()) : this.NewDelimiter(this.GetPrevious());
        case '/':
          current = this.GetNext();
          return current == '*' ? this.Comment() : this.NewDelimiter(this.GetPrevious());
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
          return this.NumberStart(current);
        case ':':
          return this.NewColon();
        case ';':
          return this.NewSemicolon();
        case '<':
          current = this.GetNext();
          if (current == '!')
          {
            current = this.GetNext();
            if (current == '-')
            {
              current = this.GetNext();
              if (current == '-')
                return this.NewOpenComment();
              current = this.GetPrevious();
            }
            current = this.GetPrevious();
          }
          return this.NewDelimiter(this.GetPrevious());
        case '@':
          return this.AtKeywordStart();
        case 'U':
        case 'u':
          current = this.GetNext();
          if (current == '+')
          {
            current = this.GetNext();
            if (current.IsHex() || current == '?')
              return this.UnicodeRange(current);
            current = this.GetPrevious();
          }
          return this.IdentStart(this.GetPrevious());
        case '[':
          return this.NewOpenSquare();
        case '\\':
          current = this.GetNext();
          if (current.IsLineBreak())
          {
            this.RaiseErrorOccurred(CssParseError.LineBreakUnexpected);
            return this.NewDelimiter(this.GetPrevious());
          }
          if (current != char.MaxValue)
            return this.IdentStart(this.GetPrevious());
          this.RaiseErrorOccurred(CssParseError.EOF);
          return this.NewDelimiter(this.GetPrevious());
        case ']':
          return this.NewCloseSquare();
        case '^':
          current = this.GetNext();
          return current == '=' ? this.NewMatch(CombinatorSymbols.Begins) : this.NewDelimiter(this.GetPrevious());
        case '{':
          return this.NewOpenCurly();
        case '|':
          current = this.GetNext();
          if (current == '=')
            return this.NewMatch(CombinatorSymbols.InToken);
          return current == '|' ? this.NewColumn() : this.NewDelimiter(this.GetPrevious());
        case '}':
          return this.NewCloseCurly();
        case '~':
          current = this.GetNext();
          return current == '=' ? this.NewMatch(CombinatorSymbols.InList) : this.NewDelimiter(this.GetPrevious());
        case char.MaxValue:
          return this.NewEof();
        default:
          return current.IsNameStart() ? this.IdentStart(current) : this.NewDelimiter(current);
      }
    }

    private CssToken StringDQ()
    {
      while (true)
      {
        char next1 = this.GetNext();
        switch (next1)
        {
          case '\n':
          case '\f':
            goto label_2;
          case '"':
          case char.MaxValue:
            goto label_1;
          case '\\':
            char next2 = this.GetNext();
            if (next2.IsLineBreak())
            {
              this.StringBuffer.AppendLine();
              continue;
            }
            if (next2 != char.MaxValue)
            {
              this.StringBuffer.Append(this.ConsumeEscape(next2));
              continue;
            }
            goto label_7;
          default:
            this.StringBuffer.Append(next1);
            continue;
        }
      }
label_1:
      return this.NewString(this.FlushBuffer(), '"');
label_2:
      this.RaiseErrorOccurred(CssParseError.LineBreakUnexpected);
      this.Back();
      return this.NewString(this.FlushBuffer(), '"', true);
label_7:
      this.RaiseErrorOccurred(CssParseError.EOF);
      this.Back();
      return this.NewString(this.FlushBuffer(), '"', true);
    }

    private CssToken StringSQ()
    {
      while (true)
      {
        char next1 = this.GetNext();
        switch (next1)
        {
          case '\n':
          case '\f':
            goto label_2;
          case '\'':
          case char.MaxValue:
            goto label_1;
          case '\\':
            char next2 = this.GetNext();
            if (next2.IsLineBreak())
            {
              this.StringBuffer.AppendLine();
              continue;
            }
            if (next2 != char.MaxValue)
            {
              this.StringBuffer.Append(this.ConsumeEscape(next2));
              continue;
            }
            goto label_7;
          default:
            this.StringBuffer.Append(next1);
            continue;
        }
      }
label_1:
      return this.NewString(this.FlushBuffer(), '\'');
label_2:
      this.RaiseErrorOccurred(CssParseError.LineBreakUnexpected);
      this.Back();
      return this.NewString(this.FlushBuffer(), '\'', true);
label_7:
      this.RaiseErrorOccurred(CssParseError.EOF);
      this.Back();
      return this.NewString(this.FlushBuffer(), '\'', true);
    }

    private CssToken ColorLiteral()
    {
      for (char next = this.GetNext(); next.IsHex(); next = this.GetNext())
        this.StringBuffer.Append(next);
      this.Back();
      return this.NewColor(this.FlushBuffer());
    }

    private CssToken HashStart()
    {
      char next = this.GetNext();
      if (next.IsNameStart())
      {
        this.StringBuffer.Append(next);
        return this.HashRest();
      }
      if (this.IsValidEscape(next))
      {
        this.StringBuffer.Append(this.ConsumeEscape(this.GetNext()));
        return this.HashRest();
      }
      if (next == '\\')
      {
        this.RaiseErrorOccurred(CssParseError.InvalidCharacter);
        this.Back();
        return this.NewDelimiter('#');
      }
      this.Back();
      return this.NewDelimiter('#');
    }

    private CssToken HashRest()
    {
      char next;
      while (true)
      {
        next = this.GetNext();
        if (next.IsName())
          this.StringBuffer.Append(next);
        else if (this.IsValidEscape(next))
          this.StringBuffer.Append(this.ConsumeEscape(this.GetNext()));
        else
          break;
      }
      if (next == '\\')
      {
        this.RaiseErrorOccurred(CssParseError.InvalidCharacter);
        this.Back();
        return this.NewHash(this.FlushBuffer());
      }
      this.Back();
      return this.NewHash(this.FlushBuffer());
    }

    private CssToken Comment()
    {
      char next = this.GetNext();
      while (true)
      {
        switch (next)
        {
          case '*':
            next = this.GetNext();
            if (next != '/')
            {
              this.StringBuffer.Append('*');
              continue;
            }
            goto label_2;
          case char.MaxValue:
            goto label_6;
          default:
            this.StringBuffer.Append(next);
            next = this.GetNext();
            continue;
        }
      }
label_2:
      return this.NewComment(this.FlushBuffer());
label_6:
      this.RaiseErrorOccurred(CssParseError.EOF);
      return this.NewComment(this.FlushBuffer(), true);
    }

    private CssToken AtKeywordStart()
    {
      char next1 = this.GetNext();
      if (next1 == '-')
      {
        char next2 = this.GetNext();
        if (next2.IsNameStart() || this.IsValidEscape(next2))
        {
          this.StringBuffer.Append('-');
          return this.AtKeywordRest(next2);
        }
        this.Back(2);
        return this.NewDelimiter('@');
      }
      if (next1.IsNameStart())
      {
        this.StringBuffer.Append(next1);
        return this.AtKeywordRest(this.GetNext());
      }
      if (this.IsValidEscape(next1))
      {
        this.StringBuffer.Append(this.ConsumeEscape(this.GetNext()));
        return this.AtKeywordRest(this.GetNext());
      }
      this.Back();
      return this.NewDelimiter('@');
    }

    private CssToken AtKeywordRest(char current)
    {
      while (true)
      {
        if (current.IsName())
          this.StringBuffer.Append(current);
        else if (this.IsValidEscape(current))
        {
          current = this.GetNext();
          this.StringBuffer.Append(this.ConsumeEscape(current));
        }
        else
          break;
        current = this.GetNext();
      }
      this.Back();
      return this.NewAtKeyword(this.FlushBuffer());
    }

    private CssToken IdentStart(char current)
    {
      if (current == '-')
      {
        current = this.GetNext();
        if (current.IsNameStart() || this.IsValidEscape(current))
        {
          this.StringBuffer.Append('-');
          return this.IdentRest(current);
        }
        this.Back();
        return this.NewDelimiter('-');
      }
      if (current.IsNameStart())
      {
        this.StringBuffer.Append(current);
        return this.IdentRest(this.GetNext());
      }
      if (current != '\\' || !this.IsValidEscape(current))
        return this.Data(current);
      current = this.GetNext();
      this.StringBuffer.Append(this.ConsumeEscape(current));
      return this.IdentRest(this.GetNext());
    }

    private CssToken IdentRest(char current)
    {
      while (true)
      {
        if (current.IsName())
          this.StringBuffer.Append(current);
        else if (this.IsValidEscape(current))
        {
          current = this.GetNext();
          this.StringBuffer.Append(this.ConsumeEscape(current));
        }
        else
          break;
        current = this.GetNext();
      }
      if (current == '(')
      {
        string functionName = this.FlushBuffer();
        return functionName.GetTypeFromName() != CssTokenType.Function ? this.UrlStart(functionName) : this.NewFunction(functionName);
      }
      this.Back();
      return this.NewIdent(this.FlushBuffer());
    }

    private CssToken TransformFunctionWhitespace(char current)
    {
      do
      {
        current = this.GetNext();
        if (current == '(')
        {
          this.Back();
          return this.NewFunction(this.FlushBuffer());
        }
      }
      while (current.IsSpaceCharacter());
      this.Back(2);
      return this.NewIdent(this.FlushBuffer());
    }

    private CssToken NumberStart(char current)
    {
      for (; !current.IsOneOf('+', '-'); current = this.GetNext())
      {
        if (current == '.')
        {
          this.StringBuffer.Append(current);
          this.StringBuffer.Append(this.GetNext());
          return this.NumberFraction();
        }
        if (current.IsDigit())
        {
          this.StringBuffer.Append(current);
          return this.NumberRest();
        }
      }
      this.StringBuffer.Append(current);
      current = this.GetNext();
      if (current == '.')
      {
        this.StringBuffer.Append(current);
        this.StringBuffer.Append(this.GetNext());
        return this.NumberFraction();
      }
      this.StringBuffer.Append(current);
      return this.NumberRest();
    }

    private CssToken NumberRest()
    {
      char next1;
      for (next1 = this.GetNext(); next1.IsDigit(); next1 = this.GetNext())
        this.StringBuffer.Append(next1);
      if (next1.IsNameStart())
      {
        string number = this.FlushBuffer();
        this.StringBuffer.Append(next1);
        return this.Dimension(number);
      }
      if (this.IsValidEscape(next1))
      {
        char next2 = this.GetNext();
        string number = this.FlushBuffer();
        this.StringBuffer.Append(this.ConsumeEscape(next2));
        return this.Dimension(number);
      }
      switch (next1)
      {
        case '%':
          return this.NewPercentage(this.FlushBuffer());
        case '-':
          return this.NumberDash();
        case '.':
          char next3 = this.GetNext();
          if (next3.IsDigit())
          {
            this.StringBuffer.Append('.').Append(next3);
            return this.NumberFraction();
          }
          this.Back();
          return this.NewNumber(this.FlushBuffer());
        case 'E':
        case 'e':
          return this.NumberExponential(next1);
        default:
          this.Back();
          return this.NewNumber(this.FlushBuffer());
      }
    }

    private CssToken NumberFraction()
    {
      char next1;
      for (next1 = this.GetNext(); next1.IsDigit(); next1 = this.GetNext())
        this.StringBuffer.Append(next1);
      if (next1.IsNameStart())
      {
        string number = this.FlushBuffer();
        this.StringBuffer.Append(next1);
        return this.Dimension(number);
      }
      if (this.IsValidEscape(next1))
      {
        char next2 = this.GetNext();
        string number = this.FlushBuffer();
        this.StringBuffer.Append(this.ConsumeEscape(next2));
        return this.Dimension(number);
      }
      switch (next1)
      {
        case '%':
          return this.NewPercentage(this.FlushBuffer());
        case '-':
          return this.NumberDash();
        case 'E':
        case 'e':
          return this.NumberExponential(next1);
        default:
          this.Back();
          return this.NewNumber(this.FlushBuffer());
      }
    }

    private CssToken Dimension(string number)
    {
      while (true)
      {
        char next = this.GetNext();
        if (next.IsLetter())
          this.StringBuffer.Append(next);
        else if (this.IsValidEscape(next))
          this.StringBuffer.Append(this.ConsumeEscape(this.GetNext()));
        else
          break;
      }
      this.Back();
      return this.NewDimension(number, this.FlushBuffer());
    }

    private CssToken SciNotation()
    {
      while (true)
      {
        char next = this.GetNext();
        if (next.IsDigit())
          this.StringBuffer.Append(next);
        else
          break;
      }
      this.Back();
      return this.NewNumber(this.FlushBuffer());
    }

    private CssToken UrlStart(string functionName)
    {
      char current = this.SkipSpaces();
      switch (current)
      {
        case '"':
          return this.UrlDQ(functionName);
        case '\'':
          return this.UrlSQ(functionName);
        case ')':
          return this.NewUrl(functionName, string.Empty);
        case char.MaxValue:
          this.RaiseErrorOccurred(CssParseError.EOF);
          return this.NewUrl(functionName, string.Empty, true);
        default:
          return this.UrlUQ(current, functionName);
      }
    }

    private CssToken UrlDQ(string functionName)
    {
      while (true)
      {
        char next1 = this.GetNext();
        if (!next1.IsLineBreak())
        {
          if (char.MaxValue != next1)
          {
            switch (next1)
            {
              case '"':
                goto label_5;
              case '\\':
                char next2 = this.GetNext();
                if (next2 != char.MaxValue)
                {
                  if (next2.IsLineBreak())
                  {
                    this.StringBuffer.AppendLine();
                    continue;
                  }
                  this.StringBuffer.Append(this.ConsumeEscape(next2));
                  continue;
                }
                goto label_8;
              default:
                this.StringBuffer.Append(next1);
                continue;
            }
          }
          else
            goto label_3;
        }
        else
          break;
      }
      this.RaiseErrorOccurred(CssParseError.LineBreakUnexpected);
      return this.UrlBad(functionName);
label_3:
      return this.NewUrl(functionName, this.FlushBuffer());
label_5:
      return this.UrlEnd(functionName);
label_8:
      this.Back(2);
      this.RaiseErrorOccurred(CssParseError.EOF);
      return this.NewUrl(functionName, this.FlushBuffer(), true);
    }

    private CssToken UrlSQ(string functionName)
    {
      while (true)
      {
        char next1 = this.GetNext();
        if (!next1.IsLineBreak())
        {
          switch (next1)
          {
            case '\'':
              goto label_4;
            case '\\':
              char next2 = this.GetNext();
              if (next2 != char.MaxValue)
              {
                if (next2.IsLineBreak())
                {
                  this.StringBuffer.AppendLine();
                  continue;
                }
                this.StringBuffer.Append(this.ConsumeEscape(next2));
                continue;
              }
              goto label_7;
            case char.MaxValue:
              goto label_3;
            default:
              this.StringBuffer.Append(next1);
              continue;
          }
        }
        else
          break;
      }
      this.RaiseErrorOccurred(CssParseError.LineBreakUnexpected);
      return this.UrlBad(functionName);
label_3:
      return this.NewUrl(functionName, this.FlushBuffer());
label_4:
      return this.UrlEnd(functionName);
label_7:
      this.Back(2);
      this.RaiseErrorOccurred(CssParseError.EOF);
      return this.NewUrl(functionName, this.FlushBuffer(), true);
    }

    private CssToken UrlUQ(char current, string functionName)
    {
      for (; !current.IsSpaceCharacter(); current = this.GetNext())
      {
        if (current.IsOneOf(')', char.MaxValue))
          return this.NewUrl(functionName, this.FlushBuffer());
        if (current.IsOneOf('"', '\'', '(') || current.IsNonPrintable())
        {
          this.RaiseErrorOccurred(CssParseError.InvalidCharacter);
          return this.UrlBad(functionName);
        }
        if (current != '\\')
          this.StringBuffer.Append(current);
        else if (this.IsValidEscape(current))
        {
          current = this.GetNext();
          this.StringBuffer.Append(this.ConsumeEscape(current));
        }
        else
        {
          this.RaiseErrorOccurred(CssParseError.InvalidCharacter);
          return this.UrlBad(functionName);
        }
      }
      return this.UrlEnd(functionName);
    }

    private CssToken UrlEnd(string functionName)
    {
      char next;
      do
      {
        next = this.GetNext();
        if (next == ')')
          return this.NewUrl(functionName, this.FlushBuffer());
      }
      while (next.IsSpaceCharacter());
      this.RaiseErrorOccurred(CssParseError.InvalidCharacter);
      this.Back();
      return this.UrlBad(functionName);
    }

    private CssToken UrlBad(string functionName)
    {
      char current = this.Current;
      int num1 = 0;
      int num2 = 1;
      for (; current != char.MaxValue; current = this.GetNext())
      {
        if (current == ';')
        {
          this.Back();
          return this.NewUrl(functionName, this.FlushBuffer(), true);
        }
        if (current == '}' && --num1 == -1)
        {
          this.Back();
          return this.NewUrl(functionName, this.FlushBuffer(), true);
        }
        if (current == ')' && --num2 == 0)
          return this.NewUrl(functionName, this.FlushBuffer(), true);
        if (this.IsValidEscape(current))
        {
          this.StringBuffer.Append(this.ConsumeEscape(this.GetNext()));
        }
        else
        {
          if (current == '(')
            ++num2;
          else if (num1 == 123)
            ++num1;
          this.StringBuffer.Append(current);
        }
      }
      this.RaiseErrorOccurred(CssParseError.EOF);
      return this.NewUrl(functionName, this.FlushBuffer(), true);
    }

    private CssToken UnicodeRange(char current)
    {
      for (int index = 0; index < 6 && current.IsHex(); ++index)
      {
        this.StringBuffer.Append(current);
        current = this.GetNext();
      }
      if (this.StringBuffer.Length != 6)
      {
        for (int index = 0; index < 6 - this.StringBuffer.Length; ++index)
        {
          if (current != '?')
          {
            current = this.GetPrevious();
            break;
          }
          this.StringBuffer.Append(current);
          current = this.GetNext();
        }
        return this.NewRange(this.FlushBuffer());
      }
      if (current == '-')
      {
        current = this.GetNext();
        if (current.IsHex())
        {
          string start = this.FlushBuffer();
          for (int index = 0; index < 6; ++index)
          {
            if (!current.IsHex())
            {
              current = this.GetPrevious();
              break;
            }
            this.StringBuffer.Append(current);
            current = this.GetNext();
          }
          string end = this.FlushBuffer();
          return this.NewRange(start, end);
        }
        this.Back(2);
        return this.NewRange(this.FlushBuffer());
      }
      this.Back();
      return this.NewRange(this.FlushBuffer());
    }

    private CssToken NewMatch(string match) => new CssToken(CssTokenType.Match, match, this._position);

    private CssToken NewColumn() => new CssToken(CssTokenType.Column, CombinatorSymbols.Column, this._position);

    private CssToken NewCloseCurly() => new CssToken(CssTokenType.CurlyBracketClose, "}", this._position);

    private CssToken NewOpenCurly() => new CssToken(CssTokenType.CurlyBracketOpen, "{", this._position);

    private CssToken NewCloseSquare() => new CssToken(CssTokenType.SquareBracketClose, "]", this._position);

    private CssToken NewOpenSquare() => new CssToken(CssTokenType.SquareBracketOpen, "[", this._position);

    private CssToken NewOpenComment() => new CssToken(CssTokenType.Cdo, "<!--", this._position);

    private CssToken NewSemicolon() => new CssToken(CssTokenType.Semicolon, ";", this._position);

    private CssToken NewColon() => new CssToken(CssTokenType.Colon, ":", this._position);

    private CssToken NewCloseComment() => new CssToken(CssTokenType.Cdc, "-->", this._position);

    private CssToken NewComma() => new CssToken(CssTokenType.Comma, ",", this._position);

    private CssToken NewCloseRound() => new CssToken(CssTokenType.RoundBracketClose, ")", this._position);

    private CssToken NewOpenRound() => new CssToken(CssTokenType.RoundBracketOpen, "(", this._position);

    private CssToken NewString(string value, char quote, bool bad = false) => (CssToken) new CssStringToken(value, bad, quote, this._position);

    private CssToken NewHash(string value) => (CssToken) new CssKeywordToken(CssTokenType.Hash, value, this._position);

    private CssToken NewComment(string value, bool bad = false) => (CssToken) new CssCommentToken(value, bad, this._position);

    private CssToken NewAtKeyword(string value) => (CssToken) new CssKeywordToken(CssTokenType.AtKeyword, value, this._position);

    private CssToken NewIdent(string value) => (CssToken) new CssKeywordToken(CssTokenType.Ident, value, this._position);

    private CssToken NewFunction(string value)
    {
      CssFunctionToken cssFunctionToken = new CssFunctionToken(value, this._position);
      for (CssToken token = this.Get(); token.Type != CssTokenType.EndOfFile; token = this.Get())
      {
        cssFunctionToken.AddArgumentToken(token);
        if (token.Type == CssTokenType.RoundBracketClose)
          break;
      }
      return (CssToken) cssFunctionToken;
    }

    private CssToken NewPercentage(string value) => (CssToken) new CssUnitToken(CssTokenType.Percentage, value, "%", this._position);

    private CssToken NewDimension(string value, string unit) => (CssToken) new CssUnitToken(CssTokenType.Dimension, value, unit, this._position);

    private CssToken NewUrl(string functionName, string data, bool bad = false) => (CssToken) new CssUrlToken(functionName, data, bad, this._position);

    private CssToken NewRange(string range) => (CssToken) new CssRangeToken(range, this._position);

    private CssToken NewRange(string start, string end) => (CssToken) new CssRangeToken(start, end, this._position);

    private CssToken NewWhitespace(char c) => new CssToken(CssTokenType.Whitespace, c.ToString(), this._position);

    private CssToken NewNumber(string number) => (CssToken) new CssNumberToken(number, this._position);

    private CssToken NewDelimiter(char c) => new CssToken(CssTokenType.Delim, c.ToString(), this._position);

    private CssToken NewColor(string text) => (CssToken) new CssColorToken(text, this._position);

    private CssToken NewEof() => new CssToken(CssTokenType.EndOfFile, string.Empty, this._position);

    private CssToken NumberExponential(char letter)
    {
      char next1 = this.GetNext();
      if (next1.IsDigit())
      {
        this.StringBuffer.Append(letter).Append(next1);
        return this.SciNotation();
      }
      if (next1 == '+' || next1 == '-')
      {
        char ch = next1;
        char next2 = this.GetNext();
        if (next2.IsDigit())
        {
          this.StringBuffer.Append(letter).Append(ch).Append(next2);
          return this.SciNotation();
        }
        this.Back();
      }
      string number = this.FlushBuffer();
      this.StringBuffer.Append(letter);
      this.Back();
      return this.Dimension(number);
    }

    private CssToken NumberDash()
    {
      char next1 = this.GetNext();
      if (next1.IsNameStart())
      {
        string number = this.FlushBuffer();
        this.StringBuffer.Append('-').Append(next1);
        return this.Dimension(number);
      }
      if (this.IsValidEscape(next1))
      {
        char next2 = this.GetNext();
        string number = this.FlushBuffer();
        this.StringBuffer.Append('-').Append(this.ConsumeEscape(next2));
        return this.Dimension(number);
      }
      this.Back(2);
      return this.NewNumber(this.FlushBuffer());
    }

    private string ConsumeEscape(char current)
    {
      if (current.IsHex())
      {
        bool flag = true;
        char[] chArray = new char[6];
        int length;
        for (length = 0; flag && length < chArray.Length; flag = current.IsHex())
        {
          chArray[length++] = current;
          current = this.GetNext();
        }
        if (!current.IsSpaceCharacter())
          this.Back();
        int num = int.Parse(new string(chArray, 0, length), NumberStyles.HexNumber);
        if (!num.IsInvalid())
          return num.ConvertFromUtf32();
        current = '�';
      }
      return current.ToString();
    }

    private bool IsValidEscape(char current)
    {
      if (current != '\\')
        return false;
      current = this.GetNext();
      this.Back();
      return current != char.MaxValue && !current.IsLineBreak();
    }

    private void RaiseErrorOccurred(CssParseError code) => this.RaiseErrorOccurred(code, this.GetCurrentPosition());
  }
}
