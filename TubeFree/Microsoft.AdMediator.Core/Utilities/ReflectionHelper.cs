// Decompiled with JetBrains decompiler
// Type: Microsoft.AdMediator.Core.Utilities.ReflectionHelper
// Assembly: Microsoft.AdMediator.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DB70E93F-CF3F-46EC-9B00-17C400B010D8
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Microsoft.AdMediator.Core.dll

using Microsoft.AdMediator.Core.Utilities.Log;
using System;
using System.Globalization;
using System.Reflection;

namespace Microsoft.AdMediator.Core.Utilities
{
  internal static class ReflectionHelper
  {
    private static readonly ILogger Log = (ILogger) new Logger(typeof (ReflectionHelper));

    public static object ConstructType(string typeName, params object[] args) => Activator.CreateInstance(Type.GetType(typeName) ?? throw new ArgumentNullException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unable to load type {0}", (object) typeName)), args);

    public static void AssignDelegate(
      Type eventSourceType,
      object eventSource,
      string eventName,
      string eventHandlerName,
      Type eventHandlerClass,
      object eventHandler)
    {
      if (eventSourceType == null)
        throw new ArgumentNullException(nameof (eventSourceType));
      if (eventSource == null)
        throw new ArgumentNullException(nameof (eventSource));
      if (eventHandlerClass == null)
        throw new ArgumentNullException(nameof (eventHandlerClass));
      if (eventHandler == null)
        throw new ArgumentNullException(nameof (eventHandler));
      ReflectionHelper.Log.Trace("Binding event {0} to {1}", (object) eventName, (object) eventHandlerName);
      EventInfo declaredEvent = eventSourceType.GetTypeInfo().GetDeclaredEvent(eventName);
      Type delegateType = declaredEvent != null ? declaredEvent.EventHandlerType : throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Event {0} not found on {1}", (object) eventName, (object) eventSourceType));
      Delegate handler = (eventHandlerClass.GetTypeInfo().GetDeclaredMethod(eventHandlerName) ?? throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Event handler {0} not found on {1}", (object) eventHandlerName, (object) eventHandlerClass))).CreateDelegate(delegateType, eventHandler);
      declaredEvent.AddEventHandler(eventSource, handler);
    }

    public static void SetPropertyValue(
      Type objectType,
      object target,
      string propertyName,
      object propertyValue)
    {
      if (objectType == null)
        throw new ArgumentNullException(nameof (objectType));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      (objectType.GetRuntimeProperty(propertyName) ?? throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Property {0} not found", (object) propertyName))).SetValue(target, propertyValue);
    }

    public static object GetPropertyValue(Type objectType, object target, string propertyName)
    {
      if (objectType == null)
        throw new ArgumentNullException(nameof (objectType));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      return (objectType.GetRuntimeProperty(propertyName) ?? throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Property {0} not found", (object) propertyName))).GetValue(target);
    }

    public static void CallMethod(
      Type objectType,
      object target,
      string methodName,
      object[] parameters)
    {
      ReflectionHelper.CallMethod(objectType, target, methodName, parameters, false);
    }

    public static void CallStaticMethod(Type objectType, string methodName, object[] parameters) => ReflectionHelper.CallMethod(objectType, (object) null, methodName, parameters, true);

    private static void CallMethod(
      Type objectType,
      object target,
      string methodName,
      object[] parameters,
      bool isStatic)
    {
      if (objectType == null)
        throw new ArgumentNullException(nameof (objectType));
      if (target == null && !isStatic)
        throw new ArgumentNullException(nameof (target));
      MethodInfo declaredMethod = objectType.GetTypeInfo().GetDeclaredMethod(methodName);
      if (declaredMethod == null)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Method {0} not found", (object) methodName));
      if (declaredMethod.IsStatic != isStatic)
      {
        string str = isStatic ? "" : "not ";
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Method {0} must {1}be static", (object) methodName, (object) str));
      }
      declaredMethod.Invoke(target, parameters);
    }
  }
}
