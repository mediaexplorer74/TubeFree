// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IHistory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom
{
  [DomName("History")]
  public interface IHistory
  {
    [DomName("length")]
    int Length { get; }

    int Index { get; }

    IDocument this[int index] { get; }

    [DomName("state")]
    object State { get; }

    [DomName("go")]
    void Go(int delta = 0);

    [DomName("back")]
    void Back();

    [DomName("forward")]
    void Forward();

    [DomName("pushState")]
    void PushState(object data, string title, string url = null);

    [DomName("replaceState")]
    void ReplaceState(object data, string title, string url = null);
  }
}
