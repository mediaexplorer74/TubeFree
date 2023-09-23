// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.FilterResult
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("NodeFilter")]
  public enum FilterResult : byte
  {
    [DomName("FILTER_ACCEPT")] Accept = 1,
    [DomName("FILTER_REJECT")] Reject = 2,
    [DomName("FILTER_SKIP")] Skip = 3,
  }
}
