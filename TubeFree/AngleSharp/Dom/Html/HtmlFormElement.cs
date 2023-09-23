// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Html.HtmlFormElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Extensions;
using AngleSharp.Html;
using AngleSharp.Network;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AngleSharp.Dom.Html
{
  internal sealed class HtmlFormElement : 
    HtmlElement,
    IHtmlFormElement,
    IHtmlElement,
    IElement,
    INode,
    IEventTarget,
    IMarkupFormattable,
    IParentNode,
    IChildNode,
    INonDocumentTypeChildNode,
    IElementCssInlineStyle,
    IGlobalEventHandlers
  {
    private HtmlFormControlsCollection _elements;

    public HtmlFormElement(Document owner, string prefix = null)
      : base(owner, TagNames.Form, prefix, NodeFlags.Special)
    {
    }

    public IElement this[int index] => (IElement) this.Elements[index];

    public IElement this[string name] => (IElement) this.Elements[name];

    public string Name
    {
      get => this.GetOwnAttribute(AttributeNames.Name);
      set => this.SetOwnAttribute(AttributeNames.Name, value);
    }

    public int Length => this.Elements.Length;

    public HtmlFormControlsCollection Elements => this._elements ?? (this._elements = new HtmlFormControlsCollection((IElement) this));

    IHtmlFormControlsCollection IHtmlFormElement.Elements => (IHtmlFormControlsCollection) this.Elements;

    public string AcceptCharset
    {
      get => this.GetOwnAttribute(AttributeNames.AcceptCharset);
      set => this.SetOwnAttribute(AttributeNames.AcceptCharset, value);
    }

    public string Action
    {
      get => this.GetOwnAttribute(AttributeNames.Action);
      set => this.SetOwnAttribute(AttributeNames.Action, value);
    }

    public string Autocomplete
    {
      get => this.GetOwnAttribute(AttributeNames.AutoComplete);
      set => this.SetOwnAttribute(AttributeNames.AutoComplete, value);
    }

    public string Enctype
    {
      get => this.GetOwnAttribute(AttributeNames.Enctype).ToEncodingType();
      set => this.SetOwnAttribute(AttributeNames.Enctype, value.ToEncodingType());
    }

    public string Encoding
    {
      get => this.Enctype;
      set => this.Enctype = value;
    }

    public string Method
    {
      get => this.GetOwnAttribute(AttributeNames.Method) ?? string.Empty;
      set => this.SetOwnAttribute(AttributeNames.Method, value);
    }

    public bool NoValidate
    {
      get => this.GetBoolAttribute(AttributeNames.NoValidate);
      set => this.SetBoolAttribute(AttributeNames.NoValidate, value);
    }

    public string Target
    {
      get => this.GetOwnAttribute(AttributeNames.Target);
      set => this.SetOwnAttribute(AttributeNames.Target, value);
    }

    public Task<IDocument> SubmitAsync() => this.NavigateToAsync(this.GetSubmission());

    public Task<IDocument> SubmitAsync(IHtmlElement sourceElement) => this.NavigateToAsync(this.GetSubmission(sourceElement));

    public DocumentRequest GetSubmission() => this.SubmitForm((IHtmlElement) this, true);

    public DocumentRequest GetSubmission(IHtmlElement sourceElement) => this.SubmitForm(sourceElement ?? (IHtmlElement) this, false);

    public void Reset()
    {
      foreach (HtmlFormControlElement element in this.Elements)
        element.Reset();
    }

    public bool CheckValidity()
    {
      IEnumerable<HtmlFormControlElement> invalidControls = this.GetInvalidControls();
      bool flag = true;
      foreach (IEventTarget target in invalidControls)
      {
        if (!target.FireSimpleEvent(EventNames.Invalid, cancelable: true))
          flag = false;
      }
      return flag;
    }

    private IEnumerable<HtmlFormControlElement> GetInvalidControls()
    {
      foreach (HtmlFormControlElement element in this.Elements)
      {
        if (element.WillValidate && !element.CheckValidity())
          yield return element;
      }
    }

    public bool ReportValidity()
    {
      IEnumerable<HtmlFormControlElement> invalidControls = this.GetInvalidControls();
      bool flag1 = true;
      bool flag2 = false;
      foreach (HtmlFormControlElement target in invalidControls)
      {
        if (!target.FireSimpleEvent(EventNames.Invalid, cancelable: true))
        {
          if (!flag2)
          {
            target.DoFocus();
            flag2 = true;
          }
          flag1 = false;
        }
      }
      return flag1;
    }

    public void RequestAutocomplete()
    {
    }

    private DocumentRequest SubmitForm(IHtmlElement from, bool submittedFromSubmitMethod)
    {
      Document owner = this.Owner;
      if ((owner.ActiveSandboxing & Sandboxes.Forms) != Sandboxes.Forms)
      {
        if (!submittedFromSubmitMethod && !from.HasAttribute(AttributeNames.FormNoValidate) && !this.NoValidate && !this.CheckValidity())
        {
          this.FireSimpleEvent(EventNames.Invalid);
        }
        else
        {
          Url action = string.IsNullOrEmpty(this.Action) ? new Url(owner.DocumentUri) : this.HyperReference(this.Action);
          bool flag = false;
          IBrowsingContext context = owner.Context;
          string target = this.Target;
          int readyState = (int) owner.ReadyState;
          if (!string.IsNullOrEmpty(target))
            flag = owner.GetTarget(target) == null;
          if (flag)
            owner.CreateTarget(target);
          string scheme = action.Scheme;
          return this.SubmitForm(this.Method.ToEnum<HttpMethod>(HttpMethod.Get), scheme, action, from);
        }
      }
      return (DocumentRequest) null;
    }

    private DocumentRequest SubmitForm(
      HttpMethod method,
      string scheme,
      Url action,
      IHtmlElement submitter)
    {
      if (scheme.IsOneOf(ProtocolNames.Http, ProtocolNames.Https))
        return method == HttpMethod.Get || method != HttpMethod.Post ? this.MutateActionUrl(action, submitter) : this.SubmitAsEntityBody(action, submitter);
      if (scheme.Is(ProtocolNames.Data))
      {
        if (method == HttpMethod.Get)
          return this.GetActionUrl(action);
        if (method == HttpMethod.Post)
          return this.PostToData(action, submitter);
      }
      else if (scheme.Is(ProtocolNames.Mailto))
      {
        if (method == HttpMethod.Get)
          return this.MailWithHeaders(action, submitter);
        if (method == HttpMethod.Post)
          return this.MailAsBody(action, submitter);
      }
      else if (scheme.IsOneOf(ProtocolNames.Ftp, ProtocolNames.JavaScript))
        return this.GetActionUrl(action);
      return this.MutateActionUrl(action, submitter);
    }

    private DocumentRequest PostToData(Url action, IHtmlElement submitter)
    {
      string str = string.IsNullOrEmpty(this.AcceptCharset) ? this.Owner.CharacterSet : this.AcceptCharset;
      FormDataSet formDataSet = this.ConstructDataSet(submitter);
      string enctype1 = this.Enctype;
      string s = string.Empty;
      string enctype2 = enctype1;
      string charset = str;
      using (StreamReader streamReader = new StreamReader(formDataSet.CreateBody(enctype2, charset)))
        s = streamReader.ReadToEnd();
      if (action.Href.Contains("%%%%"))
      {
        string replace = TextEncoding.UsAscii.GetBytes(s).UrlEncode();
        action.Href = action.Href.ReplaceFirst("%%%%", replace);
      }
      else if (action.Href.Contains("%%"))
      {
        string replace = TextEncoding.Utf8.GetBytes(s).UrlEncode();
        action.Href = action.Href.ReplaceFirst("%%", replace);
      }
      return this.GetActionUrl(action);
    }

    private DocumentRequest MailWithHeaders(Url action, IHtmlElement submitter)
    {
      Stream stream = this.ConstructDataSet(submitter).AsUrlEncoded(TextEncoding.UsAscii);
      string str = string.Empty;
      using (StreamReader streamReader = new StreamReader(stream))
        str = streamReader.ReadToEnd();
      action.Query = str.Replace("+", "%20");
      return this.GetActionUrl(action);
    }

    private DocumentRequest MailAsBody(Url action, IHtmlElement submitter)
    {
      FormDataSet formDataSet = this.ConstructDataSet(submitter);
      string enctype1 = this.Enctype;
      System.Text.Encoding usAscii = TextEncoding.UsAscii;
      string enctype2 = enctype1;
      System.Text.Encoding encoding = usAscii;
      Stream body = formDataSet.CreateBody(enctype2, encoding);
      string s = string.Empty;
      using (StreamReader streamReader = new StreamReader(body))
        s = streamReader.ReadToEnd();
      action.Query = "body=" + usAscii.GetBytes(s).UrlEncode();
      return this.GetActionUrl(action);
    }

    private DocumentRequest GetActionUrl(Url action) => DocumentRequest.Get(action, (INode) this, this.Owner.DocumentUri);

    private DocumentRequest SubmitAsEntityBody(Url target, IHtmlElement submitter)
    {
      string charset = string.IsNullOrEmpty(this.AcceptCharset) ? this.Owner.CharacterSet : this.AcceptCharset;
      FormDataSet formDataSet = this.ConstructDataSet(submitter);
      string str = this.Enctype;
      Stream body = formDataSet.CreateBody(str, charset);
      if (str.Isi(MimeTypeNames.MultipartForm))
        str = MimeTypeNames.MultipartForm + "; boundary=" + formDataSet.Boundary;
      return DocumentRequest.Post(target, body, str, (INode) this, this.Owner.DocumentUri);
    }

    private DocumentRequest MutateActionUrl(Url action, IHtmlElement submitter)
    {
      string charset = string.IsNullOrEmpty(this.AcceptCharset) ? this.Owner.CharacterSet : this.AcceptCharset;
      using (StreamReader streamReader = new StreamReader(this.ConstructDataSet(submitter).AsUrlEncoded(TextEncoding.Resolve(charset))))
        action.Query = streamReader.ReadToEnd();
      return this.GetActionUrl(action);
    }

    private FormDataSet ConstructDataSet(IHtmlElement submitter)
    {
      FormDataSet dataSet = new FormDataSet();
      foreach (HtmlFormControlElement element in this.GetElements<HtmlFormControlElement>())
      {
        if (!element.IsDisabled && !(element.ParentElement is IHtmlDataListElement) && element.Form == this)
          element.ConstructDataSet(dataSet, submitter);
      }
      return dataSet;
    }
  }
}
