// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.MonochromeMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class MonochromeMediaFeature : MediaFeature
  {
    public MonochromeMediaFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => !this.IsMinimum && !this.IsMaximum ? Converters.NaturalIntegerConverter.Option<int>(1) : Converters.NaturalIntegerConverter;

    public override bool Validate(RenderDevice device)
    {
      int num = 0;
      int monochromeBits = device.MonochromeBits;
      if (this.IsMaximum)
        return monochromeBits <= num;
      return this.IsMinimum ? monochromeBits >= num : num == monochromeBits;
    }
  }
}
