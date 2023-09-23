// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Xml.XmlElement
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;

namespace AngleSharp.Dom.Xml
{
  internal sealed class XmlElement : Element
  {
    public XmlElement(Document owner, string name, string prefix = null)
      : base(owner, name, prefix, NamespaceNames.XmlUri)
    {
    }

    internal string IdAttribute { get; set; }

    public override INode Clone(bool deep = true)
    {
      XmlElement xmlElement = new XmlElement(this.Owner, this.LocalName, this.Prefix);
      this.CloneElement((Element) xmlElement, deep);
      xmlElement.IdAttribute = this.IdAttribute;
      return (INode) xmlElement;
    }
  }
}
