// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.CssParseEvent
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Css;
using AngleSharp.Html;

namespace AngleSharp.Dom.Events
{
  public class CssParseEvent : Event
  {
    public CssParseEvent(ICssStyleSheet styleSheet, bool completed)
      : base(completed ? EventNames.ParseEnd : EventNames.ParseStart)
    {
      this.StyleSheet = styleSheet;
    }

    public ICssStyleSheet StyleSheet { get; private set; }
  }
}
