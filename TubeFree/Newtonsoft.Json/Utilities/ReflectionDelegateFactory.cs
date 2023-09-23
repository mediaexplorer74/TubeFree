﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ReflectionDelegateFactory
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Reflection;

namespace Newtonsoft.Json.Utilities
{
  internal abstract class ReflectionDelegateFactory
  {
    public Func<T, object> CreateGet<T>(MemberInfo memberInfo)
    {
      switch (memberInfo)
      {
        case PropertyInfo propertyInfo:
          if (propertyInfo.PropertyType.IsByRef)
            throw new InvalidOperationException("Could not create getter for {0}. ByRef return values are not supported.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) propertyInfo));
          return this.CreateGet<T>(propertyInfo);
        case FieldInfo fieldInfo:
          return this.CreateGet<T>(fieldInfo);
        default:
          throw new Exception("Could not create getter for {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberInfo));
      }
    }

    public Action<T, object> CreateSet<T>(MemberInfo memberInfo)
    {
      switch (memberInfo)
      {
        case PropertyInfo propertyInfo:
          return this.CreateSet<T>(propertyInfo);
        case FieldInfo fieldInfo:
          return this.CreateSet<T>(fieldInfo);
        default:
          throw new Exception("Could not create setter for {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) memberInfo));
      }
    }

    public abstract MethodCall<T, object> CreateMethodCall<T>(MethodBase method);

    public abstract ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method);

    public abstract Func<T> CreateDefaultConstructor<T>(Type type);

    public abstract Func<T, object> CreateGet<T>(PropertyInfo propertyInfo);

    public abstract Func<T, object> CreateGet<T>(FieldInfo fieldInfo);

    public abstract Action<T, object> CreateSet<T>(FieldInfo fieldInfo);

    public abstract Action<T, object> CreateSet<T>(PropertyInfo propertyInfo);
  }
}
