// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Shadow
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  public sealed class Shadow
  {
    private readonly bool _inset;
    private readonly Length _offsetX;
    private readonly Length _offsetY;
    private readonly Length _blurRadius;
    private readonly Length _spreadRadius;
    private readonly Color _color;

    public Shadow(
      bool inset,
      Length offsetX,
      Length offsetY,
      Length blurRadius,
      Length spreadRadius,
      Color color)
    {
      this._inset = inset;
      this._offsetX = offsetX;
      this._offsetY = offsetY;
      this._blurRadius = blurRadius;
      this._spreadRadius = spreadRadius;
      this._color = color;
    }

    public Color Color => this._color;

    public Length OffsetX => this._offsetX;

    public Length OffsetY => this._offsetY;

    public Length BlurRadius => this._blurRadius;

    public Length SpreadRadius => this._spreadRadius;

    public bool IsInset => this._inset;
  }
}
