// Decompiled with JetBrains decompiler
// Type: AngleSharp.Parser.Xml.XmlTagToken
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;

namespace AngleSharp.Parser.Xml
{
  internal sealed class XmlTagToken : XmlToken
  {
    private readonly List<KeyValuePair<string, string>> _attributes;
    private string _name;
    private bool _selfClosing;

    public XmlTagToken(XmlTokenType type, TextPosition position)
      : base(type, position)
    {
      this._name = string.Empty;
      this._attributes = new List<KeyValuePair<string, string>>();
    }

    public bool IsSelfClosing
    {
      get => this._selfClosing;
      set => this._selfClosing = value;
    }

    public string Name
    {
      get => this._name;
      set => this._name = value;
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
