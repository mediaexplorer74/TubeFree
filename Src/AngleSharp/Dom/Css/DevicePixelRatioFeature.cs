// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.DevicePixelRatioFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;

namespace AngleSharp.Dom.Css
{
  internal sealed class DevicePixelRatioFeature : MediaFeature
  {
    public DevicePixelRatioFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => Converters.NaturalNumberConverter;

    public override bool Validate(RenderDevice device)
    {
      float num1 = 1f;
      float num2 = (float) device.Resolution / 96f;
      if (this.IsMaximum)
        return (double) num2 <= (double) num1;
      return this.IsMinimum ? (double) num2 >= (double) num1 : (double) num1 == (double) num2;
    }
  }
}
