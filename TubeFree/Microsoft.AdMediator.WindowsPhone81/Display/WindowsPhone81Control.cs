// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.WindowsPhone81.Display.WindowsPhone81Control
// Assembly: Microsoft.AdMediator.WindowsPhone81, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C586D37-9142-43D0-8912-08FBC7AC3DDA
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.WindowsPhone81.dll

using Microsoft.AdMediator.Core.Display;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Microsoft.AdMediator.WindowsPhone81.Display
{
  internal class WindowsPhone81Control : BaseUiElementWrapper
  {
    private readonly UIElement element;

    public WindowsPhone81Control(UIElement control, Type controlType)
    {
      if (control == null)
        throw new ArgumentNullException(nameof (control));
      if (controlType == null)
        throw new ArgumentNullException(nameof (controlType));
      this.Control = (object) control;
      this.ControlType = controlType;
      this.element = control;
    }

    public override void SetVisibility(bool visible)
    {
      if (visible)
        this.element.put_Visibility((Visibility) 0);
      else
        this.element.put_Visibility((Visibility) 1);
    }

    public override void UpdateLayout() => this.element.UpdateLayout();

    public virtual void RunOnDispatcher(Action action)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      WindowsPhone81Control.\u003C\u003Ec__DisplayClass4_0 cDisplayClass40 = new WindowsPhone81Control.\u003C\u003Ec__DisplayClass4_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass40.action = action;
      // ISSUE: reference to a compiler-generated field
      if (cDisplayClass40.action == null)
        throw new ArgumentNullException(nameof (action));
      // ISSUE: method pointer
      ((DependencyObject) this.element).Dispatcher.RunAsync((CoreDispatcherPriority) -1, new DispatchedHandler((object) cDisplayClass40, __methodptr(\u003CRunOnDispatcher\u003Eb__0)));
    }
  }
}
