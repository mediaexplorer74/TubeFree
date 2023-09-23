// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.TypeExtensions
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.Utilities
{
  internal static class TypeExtensions
  {
    private static readonly BindingFlags DefaultFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

    public static MethodInfo GetGetMethod(this PropertyInfo propertyInfo) => propertyInfo.GetGetMethod(false);

    public static MethodInfo GetGetMethod(this PropertyInfo propertyInfo, bool nonPublic)
    {
      MethodInfo getMethod = propertyInfo.GetMethod;
      return getMethod != null && getMethod.IsPublic | nonPublic ? getMethod : (MethodInfo) null;
    }

    public static MethodInfo GetSetMethod(this PropertyInfo propertyInfo) => propertyInfo.GetSetMethod(false);

    public static MethodInfo GetSetMethod(this PropertyInfo propertyInfo, bool nonPublic)
    {
      MethodInfo setMethod = propertyInfo.SetMethod;
      return setMethod != null && setMethod.IsPublic | nonPublic ? setMethod : (MethodInfo) null;
    }

    public static bool IsSubclassOf(this Type type, Type c) => type.GetTypeInfo().IsSubclassOf(c);

    public static bool IsAssignableFrom(this Type type, Type c) => type.GetTypeInfo().IsAssignableFrom(c.GetTypeInfo());

    public static bool IsInstanceOfType(this Type type, object o) => o != null && type.IsAssignableFrom(o.GetType());

    public static MethodInfo Method(this Delegate d) => d.GetMethodInfo();

    public static MemberTypes MemberType(this MemberInfo memberInfo)
    {
      switch (memberInfo)
      {
        case PropertyInfo _:
          return MemberTypes.Property;
        case FieldInfo _:
          return MemberTypes.Field;
        case EventInfo _:
          return MemberTypes.Event;
        case MethodInfo _:
          return MemberTypes.Method;
        default:
          return (MemberTypes) 0;
      }
    }

    public static bool ContainsGenericParameters(this Type type) => type.GetTypeInfo().ContainsGenericParameters;

    public static bool IsInterface(this Type type) => type.GetTypeInfo().IsInterface;

    public static bool IsGenericType(this Type type) => type.GetTypeInfo().IsGenericType;

    public static bool IsGenericTypeDefinition(this Type type) => type.GetTypeInfo().IsGenericTypeDefinition;

    public static Type BaseType(this Type type) => type.GetTypeInfo().BaseType;

    public static System.Reflection.Assembly Assembly(this Type type) => type.GetTypeInfo().Assembly;

    public static bool IsEnum(this Type type) => type.GetTypeInfo().IsEnum;

    public static bool IsClass(this Type type) => type.GetTypeInfo().IsClass;

    public static bool IsSealed(this Type type) => type.GetTypeInfo().IsSealed;

    public static PropertyInfo GetProperty(
      this Type type,
      string name,
      BindingFlags bindingFlags,
      object placeholder1,
      Type propertyType,
      IList<Type> indexParameters,
      object placeholder2)
    {
      return type.GetProperties(bindingFlags).Where<PropertyInfo>((Func<PropertyInfo, bool>) (p => (name == null || !(name != p.Name)) && (propertyType == null || propertyType == p.PropertyType) && (indexParameters == null || ((IEnumerable<ParameterInfo>) p.GetIndexParameters()).Select<ParameterInfo, Type>((Func<ParameterInfo, Type>) (ip => ip.ParameterType)).SequenceEqual<Type>((IEnumerable<Type>) indexParameters)))).SingleOrDefault<PropertyInfo>();
    }

    public static IEnumerable<MemberInfo> GetMember(
      this Type type,
      string name,
      MemberTypes memberType,
      BindingFlags bindingFlags)
    {
      return (IEnumerable<MemberInfo>) type.GetMemberInternal(name, new MemberTypes?(memberType), bindingFlags);
    }

    public static MethodInfo GetBaseDefinition(this MethodInfo method) => method.GetRuntimeBaseDefinition();

    public static bool IsDefined(this Type type, Type attributeType, bool inherit) => type.GetTypeInfo().CustomAttributes.Any<CustomAttributeData>((Func<CustomAttributeData, bool>) (a => a.AttributeType == attributeType));

    public static MethodInfo GetMethod(this Type type, string name) => type.GetMethod(name, TypeExtensions.DefaultFlags);

    public static MethodInfo GetMethod(this Type type, string name, BindingFlags bindingFlags) => type.GetTypeInfo().GetDeclaredMethod(name);

    public static MethodInfo GetMethod(this Type type, IList<Type> parameterTypes) => type.GetMethod((string) null, parameterTypes);

    public static MethodInfo GetMethod(this Type type, string name, IList<Type> parameterTypes) => type.GetMethod(name, TypeExtensions.DefaultFlags, (object) null, parameterTypes, (object) null);

    public static MethodInfo GetMethod(
      this Type type,
      string name,
      BindingFlags bindingFlags,
      object placeHolder1,
      IList<Type> parameterTypes,
      object placeHolder2)
    {
      return MethodBinder.SelectMethod<MethodInfo>(type.GetTypeInfo().DeclaredMethods.Where<MethodInfo>((Func<MethodInfo, bool>) (m => (name == null || m.Name == name) && TypeExtensions.TestAccessibility((MethodBase) m, bindingFlags))), parameterTypes);
    }

    public static IEnumerable<ConstructorInfo> GetConstructors(this Type type) => type.GetConstructors(TypeExtensions.DefaultFlags);

    public static IEnumerable<ConstructorInfo> GetConstructors(
      this Type type,
      BindingFlags bindingFlags)
    {
      return type.GetTypeInfo().DeclaredConstructors.Where<ConstructorInfo>((Func<ConstructorInfo, bool>) (c => TypeExtensions.TestAccessibility((MethodBase) c, bindingFlags)));
    }

    public static ConstructorInfo GetConstructor(this Type type, IList<Type> parameterTypes) => type.GetConstructor(TypeExtensions.DefaultFlags, (object) null, parameterTypes, (object) null);

    public static ConstructorInfo GetConstructor(
      this Type type,
      BindingFlags bindingFlags,
      object placeholder1,
      IList<Type> parameterTypes,
      object placeholder2)
    {
      return MethodBinder.SelectMethod<ConstructorInfo>(type.GetConstructors(bindingFlags), parameterTypes);
    }

    public static MemberInfo[] GetMember(this Type type, string member) => type.GetMemberInternal(member, new MemberTypes?(), TypeExtensions.DefaultFlags);

    public static MemberInfo[] GetMember(this Type type, string member, BindingFlags bindingFlags) => type.GetMemberInternal(member, new MemberTypes?(), bindingFlags);

    public static MemberInfo[] GetMemberInternal(
      this Type type,
      string member,
      MemberTypes? memberType,
      BindingFlags bindingFlags)
    {
      return type.GetTypeInfo().GetMembersRecursive().Where<MemberInfo>((Func<MemberInfo, bool>) (m =>
      {
        if (m.Name == member)
        {
          if (memberType.HasValue)
          {
            MemberTypes memberTypes = m.MemberType();
            MemberTypes? nullable1 = memberType;
            MemberTypes? nullable2 = nullable1.HasValue ? new MemberTypes?(memberTypes | nullable1.GetValueOrDefault()) : new MemberTypes?();
            MemberTypes? nullable3 = memberType;
            if (!(nullable2.GetValueOrDefault() == nullable3.GetValueOrDefault() & nullable2.HasValue == nullable3.HasValue))
              goto label_4;
          }
          return TypeExtensions.TestAccessibility(m, bindingFlags);
        }
label_4:
        return false;
      })).ToArray<MemberInfo>();
    }

    public static FieldInfo GetField(this Type type, string member) => type.GetField(member, TypeExtensions.DefaultFlags);

    public static FieldInfo GetField(this Type type, string member, BindingFlags bindingFlags)
    {
      FieldInfo declaredField = type.GetTypeInfo().GetDeclaredField(member);
      return declaredField == null || !TypeExtensions.TestAccessibility(declaredField, bindingFlags) ? (FieldInfo) null : declaredField;
    }

    public static IEnumerable<PropertyInfo> GetProperties(this Type type, BindingFlags bindingFlags) => (bindingFlags.HasFlag((Enum) BindingFlags.DeclaredOnly) ? (IEnumerable<PropertyInfo>) type.GetTypeInfo().DeclaredProperties.ToList<PropertyInfo>() : (IEnumerable<PropertyInfo>) type.GetTypeInfo().GetPropertiesRecursive()).Where<PropertyInfo>((Func<PropertyInfo, bool>) (p => TypeExtensions.TestAccessibility(p, bindingFlags)));

    private static bool ContainsMemberName(IEnumerable<MemberInfo> members, string name)
    {
      foreach (MemberInfo member in members)
      {
        if (member.Name == name)
          return true;
      }
      return false;
    }

    private static IList<MemberInfo> GetMembersRecursive(this TypeInfo type)
    {
      TypeInfo typeInfo = type;
      List<MemberInfo> members = new List<MemberInfo>();
      Type baseType;
      for (; typeInfo != null; typeInfo = baseType != null ? baseType.GetTypeInfo() : (TypeInfo) null)
      {
        foreach (MemberInfo declaredMember in typeInfo.DeclaredMembers)
        {
          if (!TypeExtensions.ContainsMemberName((IEnumerable<MemberInfo>) members, declaredMember.Name))
            members.Add(declaredMember);
        }
        baseType = typeInfo.BaseType;
      }
      return (IList<MemberInfo>) members;
    }

    private static IList<PropertyInfo> GetPropertiesRecursive(this TypeInfo type)
    {
      TypeInfo typeInfo = type;
      List<PropertyInfo> members = new List<PropertyInfo>();
      Type baseType;
      for (; typeInfo != null; typeInfo = baseType != null ? baseType.GetTypeInfo() : (TypeInfo) null)
      {
        foreach (PropertyInfo declaredProperty in typeInfo.DeclaredProperties)
        {
          if (!TypeExtensions.ContainsMemberName((IEnumerable<MemberInfo>) members, declaredProperty.Name))
            members.Add(declaredProperty);
        }
        baseType = typeInfo.BaseType;
      }
      return (IList<PropertyInfo>) members;
    }

    private static IList<FieldInfo> GetFieldsRecursive(this TypeInfo type)
    {
      TypeInfo typeInfo = type;
      List<FieldInfo> members = new List<FieldInfo>();
      Type baseType;
      for (; typeInfo != null; typeInfo = baseType != null ? baseType.GetTypeInfo() : (TypeInfo) null)
      {
        foreach (FieldInfo declaredField in typeInfo.DeclaredFields)
        {
          if (!TypeExtensions.ContainsMemberName((IEnumerable<MemberInfo>) members, declaredField.Name))
            members.Add(declaredField);
        }
        baseType = typeInfo.BaseType;
      }
      return (IList<FieldInfo>) members;
    }

    public static IEnumerable<MethodInfo> GetMethods(this Type type, BindingFlags bindingFlags) => type.GetTypeInfo().DeclaredMethods;

    public static PropertyInfo GetProperty(this Type type, string name) => type.GetProperty(name, TypeExtensions.DefaultFlags);

    public static PropertyInfo GetProperty(this Type type, string name, BindingFlags bindingFlags)
    {
      PropertyInfo declaredProperty = type.GetTypeInfo().GetDeclaredProperty(name);
      return declaredProperty == null || !TypeExtensions.TestAccessibility(declaredProperty, bindingFlags) ? (PropertyInfo) null : declaredProperty;
    }

    public static IEnumerable<FieldInfo> GetFields(this Type type) => type.GetFields(TypeExtensions.DefaultFlags);

    public static IEnumerable<FieldInfo> GetFields(this Type type, BindingFlags bindingFlags) => (IEnumerable<FieldInfo>) (bindingFlags.HasFlag((Enum) BindingFlags.DeclaredOnly) ? (IEnumerable<FieldInfo>) type.GetTypeInfo().DeclaredFields.ToList<FieldInfo>() : (IEnumerable<FieldInfo>) type.GetTypeInfo().GetFieldsRecursive()).Where<FieldInfo>((Func<FieldInfo, bool>) (f => TypeExtensions.TestAccessibility(f, bindingFlags))).ToList<FieldInfo>();

    private static bool TestAccessibility(PropertyInfo member, BindingFlags bindingFlags) => member.GetMethod != null && TypeExtensions.TestAccessibility((MethodBase) member.GetMethod, bindingFlags) || member.SetMethod != null && TypeExtensions.TestAccessibility((MethodBase) member.SetMethod, bindingFlags);

    private static bool TestAccessibility(MemberInfo member, BindingFlags bindingFlags)
    {
      switch (member)
      {
        case FieldInfo member1:
          return TypeExtensions.TestAccessibility(member1, bindingFlags);
        case MethodBase member2:
          return TypeExtensions.TestAccessibility(member2, bindingFlags);
        case PropertyInfo member3:
          return TypeExtensions.TestAccessibility(member3, bindingFlags);
        default:
          throw new ArgumentOutOfRangeException("Unexpected member type.");
      }
    }

    private static bool TestAccessibility(FieldInfo member, BindingFlags bindingFlags) => ((!member.IsPublic || !bindingFlags.HasFlag((Enum) BindingFlags.Public) ? (member.IsPublic ? 0 : (bindingFlags.HasFlag((Enum) BindingFlags.NonPublic) ? 1 : 0)) : 1) & (!member.IsStatic || !bindingFlags.HasFlag((Enum) BindingFlags.Static) ? (member.IsStatic ? (false ? 1 : 0) : (bindingFlags.HasFlag((Enum) BindingFlags.Instance) ? 1 : 0)) : (true ? 1 : 0))) != 0;

    private static bool TestAccessibility(MethodBase member, BindingFlags bindingFlags) => ((!member.IsPublic || !bindingFlags.HasFlag((Enum) BindingFlags.Public) ? (member.IsPublic ? 0 : (bindingFlags.HasFlag((Enum) BindingFlags.NonPublic) ? 1 : 0)) : 1) & (!member.IsStatic || !bindingFlags.HasFlag((Enum) BindingFlags.Static) ? (member.IsStatic ? (false ? 1 : 0) : (bindingFlags.HasFlag((Enum) BindingFlags.Instance) ? 1 : 0)) : (true ? 1 : 0))) != 0;

    public static Type[] GetGenericArguments(this Type type) => type.GetTypeInfo().GenericTypeArguments;

    public static IEnumerable<Type> GetInterfaces(this Type type) => type.GetTypeInfo().ImplementedInterfaces;

    public static IEnumerable<MethodInfo> GetMethods(this Type type) => type.GetTypeInfo().DeclaredMethods;

    public static bool IsAbstract(this Type type) => type.GetTypeInfo().IsAbstract;

    public static bool IsVisible(this Type type) => type.GetTypeInfo().IsVisible;

    public static bool IsValueType(this Type type) => type.GetTypeInfo().IsValueType;

    public static bool IsPrimitive(this Type type) => type.GetTypeInfo().IsPrimitive;

    public static bool AssignableToTypeName(
      this Type type,
      string fullTypeName,
      bool searchInterfaces,
      out Type match)
    {
      for (Type type1 = type; type1 != null; type1 = type1.BaseType())
      {
        if (string.Equals(type1.FullName, fullTypeName, StringComparison.Ordinal))
        {
          match = type1;
          return true;
        }
      }
      if (searchInterfaces)
      {
        foreach (Type type2 in type.GetInterfaces())
        {
          if (string.Equals(type2.Name, fullTypeName, StringComparison.Ordinal))
          {
            match = type;
            return true;
          }
        }
      }
      match = (Type) null;
      return false;
    }

    public static bool AssignableToTypeName(
      this Type type,
      string fullTypeName,
      bool searchInterfaces)
    {
      return type.AssignableToTypeName(fullTypeName, searchInterfaces, out Type _);
    }

    public static bool ImplementInterface(this Type type, Type interfaceType)
    {
      for (Type type1 = type; type1 != null; type1 = type1.BaseType())
      {
        foreach (Type type2 in type1.GetInterfaces())
        {
          if (type2 == interfaceType || type2 != null && type2.ImplementInterface(interfaceType))
            return true;
        }
      }
      return false;
    }
  }
}
