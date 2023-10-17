// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.Values.StepsTimingFunction
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css.Values
{
  public sealed class StepsTimingFunction : ITimingFunction
  {
    private readonly int _intervals;
    private readonly bool _start;

    public StepsTimingFunction(int intervals, bool start = false)
    {
      this._intervals = Math.Max(1, intervals);
      this._start = start;
    }

    public int Intervals => this._intervals;

    public bool IsStart => this._start;
  }
}
