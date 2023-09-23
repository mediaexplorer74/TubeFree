// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Html.HtmlTagToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;

namespace AngleSharp.Parser.Html
{
  public sealed class HtmlTagToken : HtmlToken
  {
    private readonly List<KeyValuePair<string, string>> _attributes;
    private bool _selfClosing;

    public HtmlTagToken(HtmlTokenType type, TextPosition position)
      : this(type, position, string.Empty)
    {
    }

    public HtmlTagToken(HtmlTokenType type, TextPosition position, string name)
      : base(type, position, name)
    {
      this._attributes = new List<KeyValuePair<string, string>>();
    }

    public static HtmlTagToken Open(string name) => new HtmlTagToken(HtmlTokenType.StartTag, TextPosition.Empty, name);

    public static HtmlTagToken Close(string name) => new HtmlTagToken(HtmlTokenType.EndTag, TextPosition.Empty, name);

    public bool IsSelfClosing
    {
      get => this._selfClosing;
      set => this._selfClosing = value;
    }

    public List<KeyValuePair<string, string>> Attributes => this._attributes;

    public void AddAttribute(string name) => this._attributes.Add(new KeyValuePair<string, string>(name, string.Empty));

    public void AddAttribute(string name, string value) => this._attributes.Add(new KeyValuePair<string, string>(name, value));

    public void SetAttributeValue(string value) => this._attributes[this._attributes.Count - 1] = new KeyValuePair<string, string>(this._attributes[this._attributes.Count - 1].Key, value);

    public string GetAttribute(string name)
    {
      for (int index = 0; index != this._attributes.Count; ++index)
      {
        if (this._attributes[index].Key == name)
          return this._attributes[index].Value;
      }
      return string.Empty;
    }
  }
}
