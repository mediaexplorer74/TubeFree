// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.ErrorEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("ErrorEvent")]
  public class ErrorEvent : Event
  {
    [DomName("message")]
    public string Message => this.Error.Message;

    [DomName("filename")]
    public string FileName { get; private set; }

    [DomName("lineno")]
    public int Line { get; private set; }

    [DomName("colno")]
    public int Column { get; private set; }

    [DomName("error")]
    public DomException Error { get; private set; }
  }
}
