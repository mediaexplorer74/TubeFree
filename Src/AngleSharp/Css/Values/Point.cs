// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.Point
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

namespace AngleSharp.Css.Values
{
  public struct Point
  {
    public static readonly Point Center = new Point(Length.Half, Length.Half);
    public static readonly Point LeftTop = new Point(Length.Zero, Length.Zero);
    public static readonly Point RightTop = new Point(Length.Full, Length.Zero);
    public static readonly Point RightBottom = new Point(Length.Full, Length.Full);
    public static readonly Point LeftBottom = new Point(Length.Zero, Length.Full);
    private readonly Length _x;
    private readonly Length _y;

    public Point(Length x, Length y)
    {
      this._x = x;
      this._y = y;
    }

    public Length X => this._x;

    public Length Y => this._y;
  }
}
