// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.HeightMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;

namespace AngleSharp.Dom.Css
{
  internal sealed class HeightMediaFeature : MediaFeature
  {
    public HeightMediaFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => Converters.LengthConverter;

    public override bool Validate(RenderDevice device)
    {
      float pixel = Length.Zero.ToPixel();
      float viewPortHeight = (float) device.ViewPortHeight;
      if (this.IsMaximum)
        return (double) viewPortHeight <= (double) pixel;
      return this.IsMinimum ? (double) viewPortHeight >= (double) pixel : (double) pixel == (double) viewPortHeight;
    }
  }
}
