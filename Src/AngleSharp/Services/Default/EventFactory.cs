// Decompiled with JetBrains decompiler
// Type: AngleSharp.Services.Default.EventFactory
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Dom.Events;
using System;
using System.Collections.Generic;

namespace AngleSharp.Services.Default
{
  internal sealed class EventFactory : IEventFactory
  {
    private readonly Dictionary<string, EventFactory.Creator> creators = new Dictionary<string, EventFactory.Creator>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        "event",
        (EventFactory.Creator) (() => new Event())
      },
      {
        "uievent",
        (EventFactory.Creator) (() => (Event) new UiEvent())
      },
      {
        "focusevent",
        (EventFactory.Creator) (() => (Event) new FocusEvent())
      },
      {
        "keyboardevent",
        (EventFactory.Creator) (() => (Event) new KeyboardEvent())
      },
      {
        "mouseevent",
        (EventFactory.Creator) (() => (Event) new MouseEvent())
      },
      {
        "wheelevent",
        (EventFactory.Creator) (() => (Event) new WheelEvent())
      },
      {
        "customevent",
        (EventFactory.Creator) (() => (Event) new CustomEvent())
      }
    };

    public EventFactory()
    {
      this.AddEventAlias("events", "event");
      this.AddEventAlias("htmlevents", "event");
      this.AddEventAlias("uievents", "uievent");
      this.AddEventAlias("keyevents", "keyboardevent");
      this.AddEventAlias("mouseevents", "mouseevent");
    }

    private void AddEventAlias(string aliasName, string aliasFor) => this.creators.Add(aliasName, this.creators[aliasFor]);

    public Event Create(string name)
    {
      EventFactory.Creator creator = (EventFactory.Creator) null;
      return name != null && this.creators.TryGetValue(name, out creator) ? creator() : (Event) null;
    }

    private delegate Event Creator();
  }
}
