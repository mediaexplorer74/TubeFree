// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XAttributeWrapper
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
  internal class XAttributeWrapper : XObjectWrapper
  {
    private XAttribute Attribute => (XAttribute) this.WrappedNode;

    public XAttributeWrapper(XAttribute attribute)
      : base((XObject) attribute)
    {
    }

    public override string Value
    {
      get => this.Attribute.Value;
      set => this.Attribute.Value = value;
    }

    public override string LocalName => this.Attribute.Name.LocalName;

    public override string NamespaceUri => this.Attribute.Name.NamespaceName;

    public override IXmlNode ParentNode => this.Attribute.Parent == null ? (IXmlNode) null : XContainerWrapper.WrapNode((XObject) this.Attribute.Parent);
  }
}
