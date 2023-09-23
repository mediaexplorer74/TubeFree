// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.FocusEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("FocusEvent")]
  public class FocusEvent : UiEvent
  {
    public FocusEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public FocusEvent(
      string type,
      bool bubbles = false,
      bool cancelable = false,
      IWindow view = null,
      int detail = 0,
      IEventTarget target = null)
    {
      this.Init(type, bubbles, cancelable, view, detail, target);
    }

    [DomName("relatedTarget")]
    public IEventTarget Target { get; private set; }

    [DomName("initFocusEvent")]
    public void Init(
      string type,
      bool bubbles,
      bool cancelable,
      IWindow view,
      int detail,
      IEventTarget target)
    {
      this.Init(type, bubbles, cancelable, view, detail);
      this.Target = target;
    }
  }
}
