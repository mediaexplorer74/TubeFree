// Decompiled with JetBrains decompiler
// Type: AngleSharp.Dom.IWindowTimers
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System;

namespace AngleSharp.Dom
{
  [DomName("WindowTimers")]
  [DomNoInterfaceObject]
  public interface IWindowTimers
  {
    [DomName("setTimeout")]
    int SetTimeout(Action<IWindow> handler, int timeout = 0);

    [DomName("clearTimeout")]
    void ClearTimeout(int handle = 0);

    [DomName("setInterval")]
    int SetInterval(Action<IWindow> handler, int timeout = 0);

    [DomName("clearInterval")]
    void ClearInterval(int handle = 0);
  }
}
