// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.ITouchPoint
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("Touch")]
  public interface ITouchPoint
  {
    [DomName("identifier")]
    int Id { get; }

    [DomName("target")]
    IEventTarget Target { get; }

    [DomName("screenX")]
    int ScreenX { get; }

    [DomName("screenY")]
    int ScreenY { get; }

    [DomName("clientX")]
    int ClientX { get; }

    [DomName("clientY")]
    int ClientY { get; }

    [DomName("pageX")]
    int PageX { get; }

    [DomName("pageY")]
    int PageY { get; }
  }
}
