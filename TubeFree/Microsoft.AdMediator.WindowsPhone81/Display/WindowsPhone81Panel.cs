// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Display.WindowsPhone81Panel
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Display;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.AdMediator.WindowsPhone81.Display
{
  internal class WindowsPhone81Panel : WindowsPhone81Control, IPanelWrapper, IUIElementWrapper
  {
    private readonly Panel panel;

    public WindowsPhone81Panel(Panel panel)
      : base((UIElement) panel, typeof (Panel))
    {
      this.panel = panel != null ? panel : throw new ArgumentNullException(nameof (panel));
    }

    public void AddChild(IUIElementWrapper element)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      if (!(element.Control is UIElement control))
        throw new ArgumentException("Control");
      ((ICollection<UIElement>) this.panel.Children).Add(control);
    }

    public void RemoveChild(IUIElementWrapper element)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      if (!(element.Control is UIElement control))
        throw new ArgumentException("Control");
      ((ICollection<UIElement>) this.panel.Children).Remove(control);
    }
  }
}
