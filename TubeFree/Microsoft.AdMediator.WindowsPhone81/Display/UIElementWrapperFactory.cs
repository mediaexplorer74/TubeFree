// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Display.UIElementWrapperFactory
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Display;
using System;
using Windows.UI.Xaml;

namespace Microsoft.AdMediator.WindowsPhone81.Display
{
  internal class UIElementWrapperFactory : IUIElementWrapperFactory
  {
    public IUIElementWrapper CreateControl(object control, Type controlType)
    {
      if (!(control is UIElement control1))
        throw new ArgumentNullException(nameof (control));
      return controlType != null ? (IUIElementWrapper) new WindowsPhone81Control(control1, controlType) : throw new ArgumentNullException(nameof (controlType));
    }
  }
}
