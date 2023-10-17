// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.CssFeatureProperty
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;

namespace AngleSharp.Dom.Css
{
  internal sealed class CssFeatureProperty : CssProperty
  {
    private readonly MediaFeature _feature;

    internal CssFeatureProperty(MediaFeature feature)
      : base(feature.Name)
    {
      this._feature = feature;
    }

    internal override IValueConverter Converter => this._feature.Converter;

    internal MediaFeature Feature => this._feature;
  }
}
