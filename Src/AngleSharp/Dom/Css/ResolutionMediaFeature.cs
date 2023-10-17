// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ResolutionMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;

namespace AngleSharp.Dom.Css
{
  internal sealed class ResolutionMediaFeature : MediaFeature
  {
    public ResolutionMediaFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => Converters.ResolutionConverter;

    public override bool Validate(RenderDevice device)
    {
      float num = new Resolution(72f, Resolution.Unit.Dpi).To(Resolution.Unit.Dpi);
      float resolution = (float) device.Resolution;
      if (this.IsMaximum)
        return (double) resolution <= (double) num;
      return this.IsMinimum ? (double) resolution >= (double) num : (double) num == (double) resolution;
    }
  }
}
