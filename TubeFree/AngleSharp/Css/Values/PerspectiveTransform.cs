// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.PerspectiveTransform
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  internal sealed class PerspectiveTransform : ITransform
  {
    private readonly Length _distance;

    internal PerspectiveTransform(Length distance) => this._distance = distance;

    public TransformMatrix ComputeMatrix() => new TransformMatrix(1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, -1f / this._distance.ToPixel());
  }
}
