// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.DeclarationCondition
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.IO;

namespace AngleSharp.Dom.Css
{
  internal sealed class DeclarationCondition : 
    CssNode,
    IConditionFunction,
    ICssNode,
    IStyleFormattable
  {
    private readonly CssProperty _property;
    private readonly CssValue _value;

    public DeclarationCondition(CssProperty property, CssValue value)
    {
      this._property = property;
      this._value = value;
    }

    public bool Check() => !(this._property is CssUnknownProperty) && this._property.TrySetValue(this._value);

    public override void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
      writer.Write("(");
      writer.Write(formatter.Declaration(this._property.Name, this._value.CssText, this._property.IsImportant));
      writer.Write(")");
    }
  }
}
