// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IWindow
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using AngleSharp.Dom.Css;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Navigator;

namespace AngleSharp.Dom
{
  [DomName("Window")]
  public interface IWindow : IEventTarget, IGlobalEventHandlers, IWindowEventHandlers, IWindowTimers
  {
    [DomName("getComputedStyle")]
    ICssStyleDeclaration GetComputedStyle(IElement element, string pseudo = null);

    [DomName("document")]
    IDocument Document { get; }

    [DomName("location")]
    [DomPutForwards("href")]
    ILocation Location { get; }

    [DomName("closed")]
    bool IsClosed { get; }

    [DomName("status")]
    string Status { get; set; }

    [DomName("name")]
    string Name { get; set; }

    [DomName("outerHeight")]
    int OuterHeight { get; }

    [DomName("outerWidth")]
    int OuterWidth { get; }

    [DomName("screenX")]
    int ScreenX { get; }

    [DomName("screenY")]
    int ScreenY { get; }

    [DomName("window")]
    [DomName("frames")]
    [DomName("self")]
    IWindow Proxy { get; }

    [DomName("navigator")]
    INavigator Navigator { get; }

    [DomName("close")]
    void Close();

    IWindow Open(string url = "about:blank", string name = null, string features = null, string replace = null);

    [DomName("stop")]
    void Stop();

    [DomName("focus")]
    void Focus();

    [DomName("blur")]
    void Blur();

    [DomName("alert")]
    void Alert(string message);

    [DomName("confirm")]
    bool Confirm(string message);

    [DomName("print")]
    void Print();

    [DomName("history")]
    IHistory History { get; }

    [DomName("matchMedia")]
    IMediaQueryList MatchMedia(string media);
  }
}
