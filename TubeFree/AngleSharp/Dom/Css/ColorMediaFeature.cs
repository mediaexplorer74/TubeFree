// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ColorMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;
using System;

namespace AngleSharp.Dom.Css
{
  internal sealed class ColorMediaFeature : MediaFeature
  {
    public ColorMediaFeature(string name)
      : base(name)
    {
    }

    internal override IValueConverter Converter => !this.IsMinimum && !this.IsMaximum ? Converters.PositiveIntegerConverter.Option<int>(1) : Converters.PositiveIntegerConverter;

    public override bool Validate(RenderDevice device)
    {
      int num1 = 1;
      double num2 = Math.Pow((double) device.ColorBits, 2.0);
      if (this.IsMaximum)
        return num2 <= (double) num1;
      return this.IsMinimum ? num2 >= (double) num1 : (double) num1 == num2;
    }
  }
}
