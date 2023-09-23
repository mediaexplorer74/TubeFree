// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.UiEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("UIEvent")]
  public class UiEvent : Event
  {
    public UiEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public UiEvent(string type, bool bubbles = false, bool cancelable = false, IWindow view = null, int detail = 0) => this.Init(type, bubbles, cancelable, view, detail);

    [DomName("view")]
    public IWindow View { get; private set; }

    [DomName("detail")]
    public int Detail { get; private set; }

    [DomName("initUIEvent")]
    public void Init(string type, bool bubbles, bool cancelable, IWindow view, int detail)
    {
      this.Init(type, bubbles, cancelable);
      this.View = view;
      this.Detail = detail;
    }
  }
}
