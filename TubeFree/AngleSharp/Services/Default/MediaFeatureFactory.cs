// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.MediaFeatureFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Dom.Css;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class MediaFeatureFactory : IMediaFeatureFactory
  {
    private readonly Dictionary<string, MediaFeatureFactory.Creator> creators = new Dictionary<string, MediaFeatureFactory.Creator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        FeatureNames.MinWidth,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new WidthMediaFeature(FeatureNames.MinWidth))
      },
      {
        FeatureNames.MaxWidth,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new WidthMediaFeature(FeatureNames.MaxWidth))
      },
      {
        FeatureNames.Width,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new WidthMediaFeature(FeatureNames.Width))
      },
      {
        FeatureNames.MinHeight,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new HeightMediaFeature(FeatureNames.MinHeight))
      },
      {
        FeatureNames.MaxHeight,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new HeightMediaFeature(FeatureNames.MaxHeight))
      },
      {
        FeatureNames.Height,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new HeightMediaFeature(FeatureNames.Height))
      },
      {
        FeatureNames.MinDeviceWidth,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceWidthMediaFeature(FeatureNames.MinDeviceWidth))
      },
      {
        FeatureNames.MaxDeviceWidth,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceWidthMediaFeature(FeatureNames.MaxDeviceWidth))
      },
      {
        FeatureNames.DeviceWidth,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceWidthMediaFeature(FeatureNames.DeviceWidth))
      },
      {
        FeatureNames.MinDevicePixelRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DevicePixelRatioFeature(FeatureNames.MinDevicePixelRatio))
      },
      {
        FeatureNames.MaxDevicePixelRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DevicePixelRatioFeature(FeatureNames.MaxDevicePixelRatio))
      },
      {
        FeatureNames.DevicePixelRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DevicePixelRatioFeature(FeatureNames.DevicePixelRatio))
      },
      {
        FeatureNames.MinDeviceHeight,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceHeightMediaFeature(FeatureNames.MinDeviceHeight))
      },
      {
        FeatureNames.MaxDeviceHeight,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceHeightMediaFeature(FeatureNames.MaxDeviceHeight))
      },
      {
        FeatureNames.DeviceHeight,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceHeightMediaFeature(FeatureNames.DeviceHeight))
      },
      {
        FeatureNames.MinAspectRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new AspectRatioMediaFeature(FeatureNames.MinAspectRatio))
      },
      {
        FeatureNames.MaxAspectRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new AspectRatioMediaFeature(FeatureNames.MaxAspectRatio))
      },
      {
        FeatureNames.AspectRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new AspectRatioMediaFeature(FeatureNames.AspectRatio))
      },
      {
        FeatureNames.MinDeviceAspectRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceAspectRatioMediaFeature(FeatureNames.MinDeviceAspectRatio))
      },
      {
        FeatureNames.MaxDeviceAspectRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceAspectRatioMediaFeature(FeatureNames.MaxDeviceAspectRatio))
      },
      {
        FeatureNames.DeviceAspectRatio,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new DeviceAspectRatioMediaFeature(FeatureNames.DeviceAspectRatio))
      },
      {
        FeatureNames.MinColor,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ColorMediaFeature(FeatureNames.MinColor))
      },
      {
        FeatureNames.MaxColor,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ColorMediaFeature(FeatureNames.MaxColor))
      },
      {
        FeatureNames.Color,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ColorMediaFeature(FeatureNames.Color))
      },
      {
        FeatureNames.MinColorIndex,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ColorIndexMediaFeature(FeatureNames.MinColorIndex))
      },
      {
        FeatureNames.MaxColorIndex,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ColorIndexMediaFeature(FeatureNames.MaxColorIndex))
      },
      {
        FeatureNames.ColorIndex,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ColorIndexMediaFeature(FeatureNames.ColorIndex))
      },
      {
        FeatureNames.MinMonochrome,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new MonochromeMediaFeature(FeatureNames.MinMonochrome))
      },
      {
        FeatureNames.MaxMonochrome,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new MonochromeMediaFeature(FeatureNames.MaxMonochrome))
      },
      {
        FeatureNames.Monochrome,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new MonochromeMediaFeature(FeatureNames.Monochrome))
      },
      {
        FeatureNames.MinResolution,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ResolutionMediaFeature(FeatureNames.MinResolution))
      },
      {
        FeatureNames.MaxResolution,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ResolutionMediaFeature(FeatureNames.MaxResolution))
      },
      {
        FeatureNames.Resolution,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ResolutionMediaFeature(FeatureNames.Resolution))
      },
      {
        FeatureNames.Orientation,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new OrientationMediaFeature())
      },
      {
        FeatureNames.Grid,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new GridMediaFeature())
      },
      {
        FeatureNames.Scan,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ScanMediaFeature())
      },
      {
        FeatureNames.UpdateFrequency,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new UpdateFrequencyMediaFeature())
      },
      {
        FeatureNames.Scripting,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new ScriptingMediaFeature())
      },
      {
        FeatureNames.Pointer,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new PointerMediaFeature())
      },
      {
        FeatureNames.Hover,
        (MediaFeatureFactory.Creator) (() => (MediaFeature) new HoverMediaFeature())
      }
    };

    public MediaFeature Create(string name)
    {
      MediaFeatureFactory.Creator creator = (MediaFeatureFactory.Creator) null;
      return this.creators.TryGetValue(name, out creator) ? creator() : (MediaFeature) null;
    }

    private delegate MediaFeature Creator();
  }
}
