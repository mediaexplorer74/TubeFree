// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.KeyboardEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("KeyboardEvent")]
  public class KeyboardEvent : UiEvent
  {
    private string _modifiers;

    public KeyboardEvent()
    {
    }

    [DomConstructor]
    [DomInitDict(1, true)]
    public KeyboardEvent(
      string type,
      bool bubbles = false,
      bool cancelable = false,
      IWindow view = null,
      int detail = 0,
      string key = null,
      KeyboardLocation location = KeyboardLocation.Standard,
      string modifiersList = null,
      bool repeat = false)
    {
      this.Init(type, bubbles, cancelable, view, detail, key ?? string.Empty, location, modifiersList ?? string.Empty, repeat);
    }

    [DomName("key")]
    public string Key { get; private set; }

    [DomName("location")]
    public KeyboardLocation Location { get; private set; }

    [DomName("ctrlKey")]
    public bool IsCtrlPressed => this._modifiers.IsCtrlPressed();

    [DomName("shiftKey")]
    public bool IsShiftPressed => this._modifiers.IsShiftPressed();

    [DomName("altKey")]
    public bool IsAltPressed => this._modifiers.IsAltPressed();

    [DomName("metaKey")]
    public bool IsMetaPressed => this._modifiers.IsMetaPressed();

    [DomName("repeat")]
    public bool IsRepeated { get; private set; }

    [DomName("getModifierState")]
    public bool GetModifierState(string key) => this._modifiers.ContainsKey(key);

    [DomName("locale")]
    public string Locale => !this.IsTrusted ? (string) null : string.Empty;

    [DomName("initKeyboardEvent")]
    public void Init(
      string type,
      bool bubbles,
      bool cancelable,
      IWindow view,
      int detail,
      string key,
      KeyboardLocation location,
      string modifiersList,
      bool repeat)
    {
      this.Init(type, bubbles, cancelable, view, detail);
      this.Key = key;
      this.Location = location;
      this.IsRepeated = repeat;
      this._modifiers = modifiersList;
    }
  }
}
