// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Media.ITextTrackCue
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Media
{
  [DomName("TextTrackCue")]
  public interface ITextTrackCue : IEventTarget
  {
    [DomName("id")]
    string Id { get; set; }

    [DomName("track")]
    ITextTrack Track { get; }

    [DomName("startTime")]
    double StartTime { get; set; }

    [DomName("endTime")]
    double EndTime { get; set; }

    [DomName("pauseOnExit")]
    bool IsPausedOnExit { get; set; }

    [DomName("vertical")]
    string Vertical { get; set; }

    [DomName("snapToLines")]
    bool IsSnappedToLines { get; set; }

    [DomName("line")]
    int Line { get; set; }

    [DomName("position")]
    int Position { get; set; }

    [DomName("size")]
    int Size { get; set; }

    [DomName("align")]
    string Alignment { get; set; }

    [DomName("text")]
    string Text { get; set; }

    [DomName("getCueAsHTML")]
    IDocumentFragment AsHtml();

    [DomName("onenter")]
    DomEventHandler Entered { get; set; }

    [DomName("onexit")]
    DomEventHandler Exited { get; set; }
  }
}
