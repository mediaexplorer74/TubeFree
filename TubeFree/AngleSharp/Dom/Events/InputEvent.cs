// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.InputEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("InputEvent")]
  public class InputEvent : Event
  {
    public InputEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public InputEvent(string type, bool bubbles = false, bool cancelable = false, string data = null) => this.Init(type, bubbles, cancelable, data ?? string.Empty);

    [DomName("data")]
    public string Data { get; private set; }

    [DomName("initInputEvent")]
    public void Init(string type, bool bubbles, bool cancelable, string data)
    {
      this.Init(type, bubbles, cancelable);
      this.Data = data;
    }
  }
}
