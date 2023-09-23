// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Display.BaseUiElementWrapper
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Utilities;
using System;

namespace Microsoft.AdMediator.Core.Display
{
  internal abstract class BaseUiElementWrapper : IUIElementWrapper
  {
    protected Type ControlType { get; set; }

    public object Control { get; set; }

    public void AssignDelegate(
      string eventName,
      string eventHandlerName,
      Type eventHandlerClass,
      object eventHandler)
    {
      ReflectionHelper.AssignDelegate(this.ControlType, this.Control, eventName, eventHandlerName, eventHandlerClass, eventHandler);
    }

    public abstract void UpdateLayout();

    public abstract void RunOnDispatcher(Action action);

    public void SetParameter(string parameterName, object value) => ReflectionHelper.SetPropertyValue(this.ControlType, this.Control, parameterName, value);

    public abstract void SetVisibility(bool visible);

    public void CallMethod(string methodName, params object[] args) => ReflectionHelper.CallMethod(this.ControlType, this.Control, methodName, args);
  }
}
