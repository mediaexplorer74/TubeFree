// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.LinearGradient
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.Values
{
  public sealed class LinearGradient : IGradient, IImageSource
  {
    private readonly GradientStop[] _stops;
    private readonly Angle _angle;
    private readonly bool _repeating;

    public LinearGradient(Angle angle, GradientStop[] stops, bool repeating = false)
    {
      this._stops = stops;
      this._angle = angle;
      this._repeating = repeating;
    }

    public Angle Angle => this._angle;

    public IEnumerable<GradientStop> Stops => ((IEnumerable<GradientStop>) this._stops).AsEnumerable<GradientStop>();

    public bool IsRepeating => this._repeating;
  }
}
