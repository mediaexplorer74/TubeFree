// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.AspectRatioMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using System;

namespace AngleSharp.Dom.Css
{
  internal sealed class AspectRatioMediaFeature : MediaFeature
  {
    public AspectRatioMediaFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => Converters.RatioConverter;

    public override bool Validate(RenderDevice device)
    {
      Tuple<float, float> tuple = Tuple.Create<float, float>(1f, 1f);
      float num1 = tuple.Item1 / tuple.Item2;
      float num2 = (float) device.ViewPortWidth / (float) device.ViewPortHeight;
      if (this.IsMaximum)
        return (double) num2 <= (double) num1;
      return this.IsMinimum ? (double) num2 >= (double) num1 : (double) num1 == (double) num2;
    }
  }
}
