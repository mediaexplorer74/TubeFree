// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Entity
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Dom
{
  internal sealed class Entity : Node
  {
    private string _publicId;
    private string _systemId;
    private string _notationName;
    private string _inputEncoding;
    private string _xmlVersion;
    private string _xmlEncoding;
    private string _value;

    internal Entity(Document owner)
      : this(owner, string.Empty)
    {
    }

    internal Entity(Document owner, string name)
      : base(owner, name, NodeType.Entity)
    {
    }

    public string PublicId => this._publicId;

    public string SystemId => this._systemId;

    public string NotationName
    {
      get => this._notationName;
      internal set => this._notationName = value;
    }

    public string InputEncoding => this._inputEncoding;

    public string XmlEncoding => this._xmlEncoding;

    public string XmlVersion => this._xmlVersion;

    public override string TextContent
    {
      get => this._value;
      set => this._value = value;
    }

    public override string NodeValue
    {
      get => this._value;
      set => this._value = value;
    }

    public override INode Clone(bool deep = true)
    {
      Entity target = new Entity(this.Owner, this.NodeName)
      {
        _xmlEncoding = this._xmlEncoding,
        _xmlVersion = this._xmlVersion,
        _systemId = this._systemId,
        _publicId = this._publicId,
        _inputEncoding = this._inputEncoding,
        _notationName = this._notationName
      };
      this.CloneNode((Node) target, deep);
      return (INode) target;
    }
  }
}
