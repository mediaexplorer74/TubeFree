﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.LateBoundReflectionDelegateFactory
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Newtonsoft.Json.Utilities
{
  internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory
  {
    private static readonly LateBoundReflectionDelegateFactory _instance = new LateBoundReflectionDelegateFactory();

    internal static ReflectionDelegateFactory Instance => (ReflectionDelegateFactory) LateBoundReflectionDelegateFactory._instance;

    public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
    {
      ValidationUtils.ArgumentNotNull((object) method, nameof (method));
      ConstructorInfo c;
      return (c = method as ConstructorInfo) != null ? (ObjectConstructor<object>) (a => c.Invoke(a)) : (ObjectConstructor<object>) (a => method.Invoke((object) null, a));
    }

    public override MethodCall<T, object> CreateMethodCall<T>(MethodBase method)
    {
      ValidationUtils.ArgumentNotNull((object) method, nameof (method));
      ConstructorInfo c;
      return (c = method as ConstructorInfo) != null ? (MethodCall<T, object>) ((o, a) => c.Invoke(a)) : (MethodCall<T, object>) ((o, a) => method.Invoke((object) o, a));
    }

    public override Func<T> CreateDefaultConstructor<T>(Type type)
    {
      ValidationUtils.ArgumentNotNull((object) type, nameof (type));
      if (type.IsValueType())
        return (Func<T>) (() => (T) Activator.CreateInstance(type));
      ConstructorInfo constructorInfo = ReflectionUtils.GetDefaultConstructor(type, true);
      return (Func<T>) (() => (T) constructorInfo.Invoke((object[]) null));
    }

    public override Func<T, object> CreateGet<T>(PropertyInfo propertyInfo)
    {
      ValidationUtils.ArgumentNotNull((object) propertyInfo, nameof (propertyInfo));
      return (Func<T, object>) (o => propertyInfo.GetValue((object) o, (object[]) null));
    }

    public override Func<T, object> CreateGet<T>(FieldInfo fieldInfo)
    {
      ValidationUtils.ArgumentNotNull((object) fieldInfo, nameof (fieldInfo));
      return (Func<T, object>) (o => fieldInfo.GetValue((object) o));
    }

    public override Action<T, object> CreateSet<T>(FieldInfo fieldInfo)
    {
      ValidationUtils.ArgumentNotNull((object) fieldInfo, nameof (fieldInfo));
      return (Action<T, object>) ((o, v) => fieldInfo.SetValue((object) o, v));
    }

    public override Action<T, object> CreateSet<T>(PropertyInfo propertyInfo)
    {
      ValidationUtils.ArgumentNotNull((object) propertyInfo, nameof (propertyInfo));
      return (Action<T, object>) ((o, v) => propertyInfo.SetValue((object) o, v, (object[]) null));
    }
  }
}
