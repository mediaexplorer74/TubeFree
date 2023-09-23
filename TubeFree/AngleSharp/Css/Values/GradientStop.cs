// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.GradientStop
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  public struct GradientStop
  {
    private readonly Color _color;
    private readonly Length _location;

    public GradientStop(Color color, Length location)
    {
      this._color = color;
      this._location = location;
    }

    public Color Color => this._color;

    public Length Location => this._location;
  }
}
