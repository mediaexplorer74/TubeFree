// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Attr
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Collections;
using AngleSharp.Extensions;
using AngleSharp.Html;
using System;

namespace AngleSharp.Dom
{
  internal sealed class Attr : IAttr, IEquatable<IAttr>
  {
    private readonly string _localName;
    private readonly string _prefix;
    private readonly string _namespace;
    private string _value;

    internal Attr(string localName)
      : this(localName, string.Empty)
    {
    }

    internal Attr(string localName, string value)
    {
      this._localName = localName;
      this._value = value;
    }

    internal Attr(string prefix, string localName, string value, string namespaceUri)
    {
      this._prefix = prefix;
      this._localName = localName;
      this._value = value;
      this._namespace = namespaceUri;
    }

    internal NamedNodeMap Container { get; set; }

    public string Prefix => this._prefix;

    public bool IsId => this._prefix == null && this._localName.Isi(AttributeNames.Id);

    public bool Specified => !string.IsNullOrEmpty(this._value);

    public string Name => this._prefix != null ? this._prefix + ":" + this._localName : this._localName;

    public string Value
    {
      get => this._value;
      set
      {
        string oldValue = this._value;
        this._value = value;
        this.Container?.RaiseChangedEvent(this, value, oldValue);
      }
    }

    public string LocalName => this._localName;

    public string NamespaceUri => this._namespace;

    public bool Equals(IAttr other) => this.Prefix.Is(other.Prefix) && this.NamespaceUri.Is(other.NamespaceUri) && this.Value.Is(other.Value);

    public override int GetHashCode() => (((1 * 31 + this._localName.GetHashCode()) * 31 + (this._value ?? string.Empty).GetHashCode()) * 31 + (this._namespace ?? string.Empty).GetHashCode()) * 31 + (this._prefix ?? string.Empty).GetHashCode();
  }
}
