// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Display.IUIElementWrapper
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using System;

namespace Microsoft.AdMediator.Core.Display
{
  internal interface IUIElementWrapper
  {
    object Control { get; }

    void SetVisibility(bool visible);

    void CallMethod(string methodName, params object[] args);

    void SetParameter(string parameterName, object value);

    void RunOnDispatcher(Action action);

    void AssignDelegate(
      string eventName,
      string eventHandlerName,
      Type eventHandlerClass,
      object eventHandler);

    void UpdateLayout();
  }
}
