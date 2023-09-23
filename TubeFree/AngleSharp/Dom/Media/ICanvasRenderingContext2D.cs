// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.ICanvasRenderingContext2D
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Html;

namespace AngleSharp.Dom.Media
{
  [DomName("CanvasRenderingContext2D")]
  public interface ICanvasRenderingContext2D : IRenderingContext
  {
    [DomName("canvas")]
    IHtmlCanvasElement Canvas { get; }

    [DomName("width")]
    int Width { get; set; }

    [DomName("height")]
    int Height { get; set; }

    [DomName("save")]
    void SaveState();

    [DomName("restore")]
    void RestoreState();
  }
}
