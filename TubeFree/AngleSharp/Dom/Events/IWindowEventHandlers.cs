// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.Events.IWindowEventHandlers
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;

namespace AngleSharp.Dom.Events
{
  [DomName("WindowEventHandlers")]
  [DomNoInterfaceObject]
  public interface IWindowEventHandlers
  {
    [DomName("onafterprint")]
    event DomEventHandler Printed;

    [DomName("onbeforeprint")]
    event DomEventHandler Printing;

    [DomName("onbeforeunload")]
    event DomEventHandler Unloading;

    [DomName("onhashchange")]
    event DomEventHandler HashChanged;

    [DomName("onmessage")]
    event DomEventHandler MessageReceived;

    [DomName("onoffline")]
    event DomEventHandler WentOffline;

    [DomName("ononline")]
    event DomEventHandler WentOnline;

    [DomName("onpagehide")]
    event DomEventHandler PageHidden;

    [DomName("onpageshow")]
    event DomEventHandler PageShown;

    [DomName("onpopstate")]
    event DomEventHandler PopState;

    [DomName("onstorage")]
    event DomEventHandler Storage;

    [DomName("onunload")]
    event DomEventHandler Unloaded;
  }
}
