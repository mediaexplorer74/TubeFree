// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.UpdateFrequencyMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class UpdateFrequencyMediaFeature : MediaFeature
  {
    private static readonly IValueConverter TheConverter = Map.UpdateFrequencies.ToConverter<UpdateFrequency>();

    public UpdateFrequencyMediaFeature()
      : base(FeatureNames.UpdateFrequency)
    {
    }

    internal override IValueConverter Converter => UpdateFrequencyMediaFeature.TheConverter;

    public override bool Validate(RenderDevice device)
    {
      UpdateFrequency updateFrequency = UpdateFrequency.Normal;
      int frequency = device.Frequency;
      if (frequency >= 30)
        return updateFrequency == UpdateFrequency.Normal;
      return frequency > 0 ? updateFrequency == UpdateFrequency.Slow : updateFrequency == UpdateFrequency.None;
    }
  }
}
