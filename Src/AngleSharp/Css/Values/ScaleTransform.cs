// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.ScaleTransform
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  internal sealed class ScaleTransform : ITransform
  {
    private readonly float _sx;
    private readonly float _sy;
    private readonly float _sz;

    internal ScaleTransform(float sx, float sy, float sz)
    {
      this._sx = sx;
      this._sy = sy;
      this._sz = sz;
    }

    public TransformMatrix ComputeMatrix() => new TransformMatrix(this._sx, 0.0f, 0.0f, 0.0f, this._sy, 0.0f, 0.0f, 0.0f, this._sz, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
  }
}
