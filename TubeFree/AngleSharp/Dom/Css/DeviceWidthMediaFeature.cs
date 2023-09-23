// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.DeviceWidthMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Css.Values;

namespace AngleSharp.Dom.Css
{
  internal sealed class DeviceWidthMediaFeature : MediaFeature
  {
    public DeviceWidthMediaFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => Converters.LengthConverter;

    public override bool Validate(RenderDevice device)
    {
      float pixel = Length.Zero.ToPixel();
      float deviceWidth = (float) device.DeviceWidth;
      if (this.IsMaximum)
        return (double) deviceWidth <= (double) pixel;
      return this.IsMinimum ? (double) deviceWidth >= (double) pixel : (double) pixel == (double) deviceWidth;
    }
  }
}
