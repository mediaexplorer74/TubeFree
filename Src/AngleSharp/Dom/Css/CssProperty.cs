// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using AngleSharp.Parser.Css;
using System.Collections.Generic;
using System.IO;

namespace AngleSharp.Dom.Css
{
  internal abstract class CssProperty : CssNode, ICssProperty, ICssNode, IStyleFormattable
  {
    private readonly PropertyFlags _flags;
    private readonly string _name;
    private bool _important;
    private IPropertyValue _value;

    internal CssProperty(string name, PropertyFlags flags = PropertyFlags.None)
    {
      this._name = name;
      this._flags = flags;
    }

    public string Value => this._value == null ? Keywords.Initial : this._value.CssText;

    public bool IsInherited
    {
      get
      {
        if ((this._flags & PropertyFlags.Inherited) == PropertyFlags.Inherited && this.IsInitial)
          return true;
        return this._value != null && this._value.CssText.Is(Keywords.Inherit);
      }
    }

    public bool IsAnimatable => (this._flags & PropertyFlags.Animatable) == PropertyFlags.Animatable;

    public bool IsInitial => this._value == null || this._value.CssText.Is(Keywords.Initial);

    public string Name => this._name;

    public bool IsImportant
    {
      get => this._important;
      set => this._important = value;
    }

    public string CssText => this.ToCss();

    internal bool HasValue => this._value != null;

    internal bool CanBeHashless => (this._flags & PropertyFlags.Hashless) == PropertyFlags.Hashless;

    internal bool CanBeUnitless => (this._flags & PropertyFlags.Unitless) == PropertyFlags.Unitless;

    internal bool CanBeInherited => (this._flags & PropertyFlags.Inherited) == PropertyFlags.Inherited;

    internal bool IsShorthand => (this._flags & PropertyFlags.Shorthand) == PropertyFlags.Shorthand;

    internal abstract IValueConverter Converter { get; }

    internal IPropertyValue DeclaredValue
    {
      get => this._value;
      set => this._value = value;
    }

    internal bool TrySetValue(CssValue newValue)
    {
      IPropertyValue propertyValue = this.Converter.Convert((IEnumerable<CssToken>) (newValue ?? CssValue.Initial));
      if (propertyValue == null)
        return false;
      this._value = propertyValue;
      return true;
    }

    public override void ToCss(TextWriter writer, IStyleFormatter formatter) => writer.Write(formatter.Declaration(this.Name, this.Value, this.IsImportant));
  }
}
