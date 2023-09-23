// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.KeyboardLocation
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("KeyboardEvent")]
  public enum KeyboardLocation : byte
  {
    [DomName("DOM_KEY_LOCATION_STANDARD")] Standard,
    [DomName("DOM_KEY_LOCATION_LEFT")] Left,
    [DomName("DOM_KEY_LOCATION_RIGHT")] Right,
    [DomName("DOM_KEY_LOCATION_NUMPAD")] NumPad,
  }
}
