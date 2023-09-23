// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Shape
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  public sealed class Shape
  {
    private readonly Length _top;
    private readonly Length _right;
    private readonly Length _bottom;
    private readonly Length _left;

    public Shape(Length top, Length right, Length bottom, Length left)
    {
      this._top = top;
      this._right = right;
      this._bottom = bottom;
      this._left = left;
    }

    public Length Top => this._top;

    public Length Right => this._right;

    public Length Bottom => this._bottom;

    public Length Left => this._left;
  }
}
