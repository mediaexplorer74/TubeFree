// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IDocumentStyle
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("DocumentStyle")]
  [DomNoInterfaceObject]
  public interface IDocumentStyle
  {
    [DomName("styleSheets")]
    IStyleSheetList StyleSheets { get; }

    [DomName("selectedStyleSheetSet")]
    string SelectedStyleSheetSet { get; set; }

    [DomName("lastStyleSheetSet")]
    string LastStyleSheetSet { get; }

    [DomName("preferredStyleSheetSet")]
    string PreferredStyleSheetSet { get; }

    [DomName("styleSheetSets")]
    IStringList StyleSheetSets { get; }

    [DomName("enableStyleSheetsForSet")]
    void EnableStyleSheetsForSet(string name);
  }
}
