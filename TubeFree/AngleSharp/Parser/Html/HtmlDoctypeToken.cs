// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlDoctypeToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using System;

namespace AngleSharp.Parser.Html
{
  public sealed class HtmlDoctypeToken : HtmlToken
  {
    private bool _quirks;
    private string _publicIdentifier;
    private string _systemIdentifier;

    public HtmlDoctypeToken(bool quirksForced, TextPosition position)
      : base(HtmlTokenType.Doctype, position)
    {
      this._publicIdentifier = (string) null;
      this._systemIdentifier = (string) null;
      this._quirks = quirksForced;
    }

    public bool IsQuirksForced
    {
      get => this._quirks;
      set => this._quirks = value;
    }

    public bool IsPublicIdentifierMissing => this._publicIdentifier == null;

    public bool IsSystemIdentifierMissing => this._systemIdentifier == null;

    public string PublicIdentifier
    {
      get => this._publicIdentifier ?? string.Empty;
      set => this._publicIdentifier = value;
    }

    public string SystemIdentifier
    {
      get => this._systemIdentifier ?? string.Empty;
      set => this._systemIdentifier = value;
    }

    public bool IsLimitedQuirks => this.PublicIdentifier.StartsWith("-//W3C//DTD XHTML 1.0 Frameset//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD XHTML 1.0 Transitional//", StringComparison.OrdinalIgnoreCase) || this.SystemIdentifier.StartsWith("-//W3C//DTD HTML 4.01 Frameset//", StringComparison.OrdinalIgnoreCase) || this.SystemIdentifier.StartsWith("-//W3C//DTD HTML 4.01 Transitional//", StringComparison.OrdinalIgnoreCase);

    public bool IsFullQuirks => this.IsQuirksForced || !this.Name.Is("html") || this.PublicIdentifier.StartsWith("+//Silmaril//dtd html Pro v0r11 19970101//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//AdvaSoft Ltd//DTD HTML 3.0 asWedit + extensions//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//AS//DTD HTML 3.0 asWedit + extensions//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.0 Level 1//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.0 Level 2//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.0 Strict Level 1//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.0 Strict Level 2//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.0 Strict//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 2.1E//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 3.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 3.2 Final//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 3.2//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML 3//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Level 0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Level 1//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Level 2//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Level 3//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Strict Level 0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Strict Level 1//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Strict Level 2//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Strict Level 3//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML Strict//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//IETF//DTD HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Metrius//DTD Metrius Presentational//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Microsoft//DTD Internet Explorer 2.0 HTML Strict//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Microsoft//DTD Internet Explorer 2.0 HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Microsoft//DTD Internet Explorer 2.0 Tables//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Microsoft//DTD Internet Explorer 3.0 HTML Strict//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Microsoft//DTD Internet Explorer 3.0 HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Microsoft//DTD Internet Explorer 3.0 Tables//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Netscape Comm. Corp.//DTD HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Netscape Comm. Corp.//DTD Strict HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//O'Reilly and Associates//DTD HTML 2.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//O'Reilly and Associates//DTD HTML Extended 1.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//O'Reilly and Associates//DTD HTML Extended Relaxed 1.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//SoftQuad Software//DTD HoTMetaL PRO 6.0::19990601::extensions to HTML 4.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//SoftQuad//DTD HoTMetaL PRO 4.0::19971010::extensions to HTML 4.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Spyglass//DTD HTML 2.0 Extended//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//SQ//DTD HTML 2.0 HoTMetaL + extensions//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Sun Microsystems Corp.//DTD HotJava HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//Sun Microsystems Corp.//DTD HotJava Strict HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 3 1995-03-24//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 3.2 Draft//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 3.2 Final//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 3.2//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 3.2S Draft//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 4.0 Frameset//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 4.0 Transitional//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML Experimental 19960712//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD HTML Experimental 970421//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3C//DTD W3 HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//W3O//DTD W3 HTML 3.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.Isi("-//W3O//DTD W3 HTML Strict 3.0//EN//") || this.PublicIdentifier.StartsWith("-//WebTechs//DTD Mozilla HTML 2.0//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.StartsWith("-//WebTechs//DTD Mozilla HTML//", StringComparison.OrdinalIgnoreCase) || this.PublicIdentifier.Isi("-/W3C/DTD HTML 4.0 Transitional/EN") || this.PublicIdentifier.Isi("HTML") || this.SystemIdentifier.Equals("http://www.ibm.com/data/dtd/v11/ibmxhtml1-transitional.dtd", StringComparison.OrdinalIgnoreCase) || this.IsSystemIdentifierMissing && this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 4.01 Frameset//", StringComparison.OrdinalIgnoreCase) || this.IsSystemIdentifierMissing && this.PublicIdentifier.StartsWith("-//W3C//DTD HTML 4.01 Transitional//", StringComparison.OrdinalIgnoreCase);

    public bool IsValid
    {
      get
      {
        if (!this.Name.Is("html"))
          return false;
        if (this.IsPublicIdentifierMissing)
          return this.IsSystemIdentifierMissing || this.SystemIdentifier.Is("about:legacy-compat");
        if (this.PublicIdentifier.Is("-//W3C//DTD HTML 4.0//EN"))
          return this.IsSystemIdentifierMissing || this.SystemIdentifier.Is("http://www.w3.org/TR/REC-html40/strict.dtd");
        if (this.PublicIdentifier.Is("-//W3C//DTD HTML 4.01//EN"))
          return this.IsSystemIdentifierMissing || this.SystemIdentifier.Is("http://www.w3.org/TR/html4/strict.dtd");
        if (this.PublicIdentifier.Is("-//W3C//DTD XHTML 1.0 Strict//EN"))
          return this.SystemIdentifier.Is("http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd");
        return this.PublicIdentifier.Is("-//W3C//DTD XHTML 1.1//EN") && this.SystemIdentifier.Is("http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd");
      }
    }
  }
}
