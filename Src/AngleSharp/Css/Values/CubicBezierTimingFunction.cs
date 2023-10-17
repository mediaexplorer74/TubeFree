// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.CubicBezierTimingFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  public sealed class CubicBezierTimingFunction : ITimingFunction
  {
    private readonly float _x1;
    private readonly float _y1;
    private readonly float _x2;
    private readonly float _y2;

    public CubicBezierTimingFunction(float x1, float y1, float x2, float y2)
    {
      this._x1 = x1;
      this._y1 = y1;
      this._x2 = x2;
      this._y2 = y2;
    }

    public float X1 => this._x1;

    public float Y1 => this._y1;

    public float X2 => this._x2;

    public float Y2 => this._y2;
  }
}
