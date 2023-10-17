// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.EventPhase
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("Event")]
  public enum EventPhase : byte
  {
    [DomName("NONE")] None,
    [DomName("CAPTURING_PHASE")] Capturing,
    [DomName("AT_TARGET")] AtTarget,
    [DomName("BUBBLING_PHASE")] Bubbling,
  }
}
