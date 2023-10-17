// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.SkewTransform
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css.Values
{
  internal sealed class SkewTransform : ITransform
  {
    private readonly float _alpha;
    private readonly float _beta;

    internal SkewTransform(float alpha, float beta)
    {
      this._alpha = alpha;
      this._beta = beta;
    }

    public float Alpha => this._alpha;

    public float Beta => this._beta;

    public TransformMatrix ComputeMatrix() => new TransformMatrix(1f, (float) Math.Tan((double) this._alpha), 0.0f, (float) Math.Tan((double) this._beta), 1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
  }
}
