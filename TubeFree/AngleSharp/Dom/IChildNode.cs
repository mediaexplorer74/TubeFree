// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IChildNode
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("ChildNode")]
  [DomNoInterfaceObject]
  public interface IChildNode
  {
    [DomName("before")]
    void Before(params INode[] nodes);

    [DomName("after")]
    void After(params INode[] nodes);

    [DomName("replace")]
    void Replace(params INode[] nodes);

    [DomName("remove")]
    void Remove();
  }
}
