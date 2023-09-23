// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Css.ScriptingMediaFeature
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Css;
using AngleSharp.Extensions;

namespace AngleSharp.Dom.Css
{
  internal sealed class ScriptingMediaFeature : MediaFeature
  {
    private static readonly IValueConverter TheConverter = Map.ScriptingStates.ToConverter<ScriptingState>();

    public ScriptingMediaFeature()
      : base(FeatureNames.Scripting)
    {
    }

    internal override IValueConverter Converter => ScriptingMediaFeature.TheConverter;

    public override bool Validate(RenderDevice device)
    {
      IConfiguration options = device.Options;
      ScriptingState scriptingState = ScriptingState.None;
      if (options != null && options.IsScripting())
        scriptingState = device.DeviceType == RenderDevice.Kind.Screen ? ScriptingState.Enabled : ScriptingState.InitialOnly;
      return 0 == (int) scriptingState;
    }
  }
}
