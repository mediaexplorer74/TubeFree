// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.HtmlParseEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Html;

namespace AngleSharp.Dom.Events
{
  public class HtmlParseEvent : Event
  {
    public HtmlParseEvent(IDocument document, bool completed)
      : base(completed ? EventNames.ParseEnd : EventNames.ParseStart)
    {
      this.Document = document;
    }

    public IDocument Document { get; private set; }
  }
}
