// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.MethodBinder
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.Utilities
{
  internal static class MethodBinder
  {
    private static readonly Type[] PrimitiveTypes = new Type[12]
    {
      typeof (bool),
      typeof (char),
      typeof (sbyte),
      typeof (byte),
      typeof (short),
      typeof (ushort),
      typeof (int),
      typeof (uint),
      typeof (long),
      typeof (ulong),
      typeof (float),
      typeof (double)
    };
    private static readonly int[] WideningMasks = new int[12]
    {
      1,
      4066,
      3412,
      4090,
      3408,
      4066,
      3392,
      3968,
      3328,
      3584,
      3072,
      2048
    };

    private static bool CanConvertPrimitive(Type from, Type to)
    {
      if (from == to)
        return true;
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < MethodBinder.PrimitiveTypes.Length; ++index)
      {
        if (MethodBinder.PrimitiveTypes[index] == from)
          num1 = MethodBinder.WideningMasks[index];
        else if (MethodBinder.PrimitiveTypes[index] == to)
          num2 = 1 << index;
        if (num1 != 0 && num2 != 0)
          break;
      }
      return (num1 & num2) != 0;
    }

    private static bool FilterParameters(
      ParameterInfo[] parameters,
      IList<Type> types,
      bool enableParamArray)
    {
      ValidationUtils.ArgumentNotNull((object) parameters, nameof (parameters));
      ValidationUtils.ArgumentNotNull((object) types, nameof (types));
      if (parameters.Length == 0)
        return types.Count == 0;
      if (parameters.Length > types.Count)
        return false;
      Type type1 = (Type) null;
      if (enableParamArray)
      {
        ParameterInfo parameter = parameters[parameters.Length - 1];
        if (parameter.ParameterType.IsArray && parameter.IsDefined(typeof (ParamArrayAttribute)))
          type1 = parameter.ParameterType.GetElementType();
      }
      if (type1 == null && parameters.Length != types.Count)
        return false;
      for (int index = 0; index < types.Count; ++index)
      {
        Type type2 = type1 == null || index < parameters.Length - 1 ? parameters[index].ParameterType : type1;
        if (type2 != types[index] && type2 != typeof (object))
        {
          if (type2.IsPrimitive())
          {
            if (!types[index].IsPrimitive() || !MethodBinder.CanConvertPrimitive(types[index], type2))
              return false;
          }
          else if (!type2.IsAssignableFrom(types[index]))
            return false;
        }
      }
      return true;
    }

    public static TMethod SelectMethod<TMethod>(IEnumerable<TMethod> candidates, IList<Type> types) where TMethod : MethodBase
    {
      ValidationUtils.ArgumentNotNull((object) candidates, nameof (candidates));
      ValidationUtils.ArgumentNotNull((object) types, nameof (types));
      return candidates.Where<TMethod>((Func<TMethod, bool>) (m => MethodBinder.FilterParameters(m.GetParameters(), types, false))).OrderBy<TMethod, ParameterInfo[]>((Func<TMethod, ParameterInfo[]>) (m => m.GetParameters()), (IComparer<ParameterInfo[]>) new MethodBinder.ParametersMatchComparer(types, false)).FirstOrDefault<TMethod>();
    }

    private class ParametersMatchComparer : IComparer<ParameterInfo[]>
    {
      private readonly IList<Type> _types;
      private readonly bool _enableParamArray;

      public ParametersMatchComparer(IList<Type> types, bool enableParamArray)
      {
        ValidationUtils.ArgumentNotNull((object) types, nameof (types));
        this._types = types;
        this._enableParamArray = enableParamArray;
      }

      public int Compare(ParameterInfo[] parameters1, ParameterInfo[] parameters2)
      {
        ValidationUtils.ArgumentNotNull((object) parameters1, nameof (parameters1));
        ValidationUtils.ArgumentNotNull((object) parameters2, nameof (parameters2));
        if (parameters1.Length == 0)
          return -1;
        if (parameters2.Length == 0)
          return 1;
        Type type1 = (Type) null;
        Type type2 = (Type) null;
        if (this._enableParamArray)
        {
          ParameterInfo element1 = parameters1[parameters1.Length - 1];
          if (element1.ParameterType.IsArray && element1.IsDefined(typeof (ParamArrayAttribute)))
            type1 = element1.ParameterType.GetElementType();
          ParameterInfo element2 = parameters2[parameters2.Length - 1];
          if (element2.ParameterType.IsArray && element2.IsDefined(typeof (ParamArrayAttribute)))
            type2 = element2.ParameterType.GetElementType();
          if (type1 != null && type2 == null)
            return 1;
          if (type2 != null && type1 == null)
            return -1;
        }
        for (int index = 0; index < this._types.Count; ++index)
        {
          Type type1_1 = type1 == null || index < parameters1.Length - 1 ? parameters1[index].ParameterType : type1;
          Type type2_1 = type2 == null || index < parameters2.Length - 1 ? parameters2[index].ParameterType : type2;
          if (type1_1 != type2_1)
          {
            if (type1_1 == this._types[index])
              return -1;
            if (type2_1 == this._types[index])
              return 1;
            int num = MethodBinder.ParametersMatchComparer.ChooseMorePreciseType(type1_1, type2_1);
            if (num != 0)
              return num;
          }
        }
        return 0;
      }

      private static int ChooseMorePreciseType(Type type1, Type type2)
      {
        if (type1.IsByRef || type2.IsByRef)
        {
          if (type1.IsByRef && type2.IsByRef)
          {
            type1 = type1.GetElementType();
            type2 = type2.GetElementType();
          }
          else if (type1.IsByRef)
          {
            type1 = type1.GetElementType();
            if (type1 == type2)
              return 1;
          }
          else
          {
            type2 = type2.GetElementType();
            if (type2 == type1)
              return -1;
          }
        }
        bool flag1;
        bool flag2;
        if (type1.IsPrimitive() && type2.IsPrimitive())
        {
          flag1 = MethodBinder.CanConvertPrimitive(type2, type1);
          flag2 = MethodBinder.CanConvertPrimitive(type1, type2);
        }
        else
        {
          flag1 = type1.IsAssignableFrom(type2);
          flag2 = type2.IsAssignableFrom(type1);
        }
        if (flag1 == flag2)
          return 0;
        return !flag1 ? -1 : 1;
      }
    }
  }
}
