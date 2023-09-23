// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.RadialGradient
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System.Collections.Generic;
using System.Linq;

namespace AngleSharp.Css.Values
{
  public sealed class RadialGradient : IImageSource
  {
    private readonly GradientStop[] _stops;
    private readonly Point _pt;
    private readonly Length _width;
    private readonly Length _height;
    private readonly bool _repeating;
    private readonly bool _circle;
    private readonly RadialGradient.SizeMode _sizeMode;

    public RadialGradient(
      bool circle,
      Point pt,
      Length width,
      Length height,
      RadialGradient.SizeMode sizeMode,
      GradientStop[] stops,
      bool repeating = false)
    {
      this._stops = stops;
      this._pt = pt;
      this._width = width;
      this._height = height;
      this._repeating = repeating;
      this._circle = circle;
      this._sizeMode = sizeMode;
    }

    public bool IsCircle => this._circle;

    public RadialGradient.SizeMode Mode => this._sizeMode;

    public Point Position => this._pt;

    public Length MajorRadius => this._width;

    public Length MinorRadius => this._height;

    public IEnumerable<GradientStop> Stops => ((IEnumerable<GradientStop>) this._stops).AsEnumerable<GradientStop>();

    public bool IsRepeating => this._repeating;

    public enum SizeMode : byte
    {
      None,
      ClosestCorner,
      ClosestSide,
      FarthestCorner,
      FarthestSide,
    }
  }
}
