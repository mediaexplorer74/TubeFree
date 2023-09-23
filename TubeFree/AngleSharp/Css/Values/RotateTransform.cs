// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.RotateTransform
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css.Values
{
  internal sealed class RotateTransform : ITransform
  {
    private readonly float _x;
    private readonly float _y;
    private readonly float _z;
    private readonly float _angle;

    internal RotateTransform(float x, float y, float z, float angle)
    {
      this._x = x;
      this._y = y;
      this._z = z;
      this._angle = angle;
    }

    public float X => this._x;

    public float Y => this._y;

    public float Z => this._z;

    public float Angle => this._angle;

    public static RotateTransform RotateX(float angle) => new RotateTransform(1f, 0.0f, 0.0f, angle);

    public static RotateTransform RotateY(float angle) => new RotateTransform(0.0f, 1f, 0.0f, angle);

    public static RotateTransform RotateZ(float angle) => new RotateTransform(0.0f, 0.0f, 1f, angle);

    public TransformMatrix ComputeMatrix()
    {
      float num1 = 1f / (float) Math.Sqrt((double) this._x * (double) this._x + (double) this._y * (double) this._y + (double) this._z * (double) this._z);
      float num2 = (float) Math.Sin((double) this._angle);
      float num3 = (float) Math.Cos((double) this._angle);
      float num4 = this._x * num1;
      float num5 = this._y * num1;
      float num6 = this._z * num1;
      float num7 = 1f - num3;
      return new TransformMatrix(num4 * num4 * num7 + num3, (float) ((double) num5 * (double) num4 * (double) num7 - (double) num6 * (double) num2), (float) ((double) num6 * (double) num4 * (double) num7 + (double) num5 * (double) num2), (float) ((double) num4 * (double) num5 * (double) num7 + (double) num6 * (double) num2), num5 * num5 * num7 + num3, (float) ((double) num6 * (double) num5 * (double) num7 - (double) num4 * (double) num2), (float) ((double) num4 * (double) num6 * (double) num7 - (double) num5 * (double) num2), (float) ((double) num5 * (double) num6 * (double) num7 + (double) num4 * (double) num2), num6 * num6 * num7 + num3, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    }
  }
}
