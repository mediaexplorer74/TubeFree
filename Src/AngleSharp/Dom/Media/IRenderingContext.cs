// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.IRenderingContext
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Html;

namespace AngleSharp.Dom.Media
{
  [DomName("RenderingContext")]
  public interface IRenderingContext
  {
    string ContextId { get; }

    bool IsFixed { get; }

    IHtmlCanvasElement Host { get; }

    byte[] ToImage(string type);
  }
}
