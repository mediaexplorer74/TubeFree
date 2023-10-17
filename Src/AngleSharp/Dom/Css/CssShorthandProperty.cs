// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssShorthandProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssShorthandProperty : CssProperty
  {
    public CssShorthandProperty(string name, PropertyFlags flags = PropertyFlags.None)
      : base(name, flags | PropertyFlags.Shorthand)
    {
    }

    public string Stringify(CssProperty[] properties) => this.Converter.Construct(properties)?.CssText;

    public void Export(CssProperty[] properties)
    {
      foreach (CssProperty property in properties)
      {
        CssValue newValue = this.DeclaredValue.ExtractFor(property.Name);
        property.TrySetValue(newValue);
      }
    }
  }
}
