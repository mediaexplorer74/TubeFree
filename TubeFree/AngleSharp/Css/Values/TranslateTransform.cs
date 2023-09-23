// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.TranslateTransform
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  internal sealed class TranslateTransform : ITransform
  {
    private readonly Length _x;
    private readonly Length _y;
    private readonly Length _z;

    internal TranslateTransform(Length x, Length y, Length z)
    {
      this._x = x;
      this._y = y;
      this._z = z;
    }

    public Length Dx => this._x;

    public Length Dy => this._y;

    public Length Dz => this._z;

    public TransformMatrix ComputeMatrix() => new TransformMatrix(1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 1f, this._x.ToPixel(), this._y.ToPixel(), this._z.ToPixel(), 0.0f, 0.0f, 0.0f);
  }
}
