// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonTypeReflector
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Serialization
{
  internal static class JsonTypeReflector
  {
    private static bool? _dynamicCodeGeneration;
    private static bool? _fullyTrusted;
    public const string IdPropertyName = "$id";
    public const string RefPropertyName = "$ref";
    public const string TypePropertyName = "$type";
    public const string ValuePropertyName = "$value";
    public const string ArrayValuesPropertyName = "$values";
    public const string ShouldSerializePrefix = "ShouldSerialize";
    public const string SpecifiedPostfix = "Specified";
    public const string ConcurrentDictionaryTypeName = "System.Collections.Concurrent.ConcurrentDictionary`2";
    private static readonly ThreadSafeStore<Type, Func<object[], object>> CreatorCache = new ThreadSafeStore<Type, Func<object[], object>>(new Func<Type, Func<object[], object>>(JsonTypeReflector.GetCreator));
    private static readonly ThreadSafeStore<Type, Type> AssociatedMetadataTypesCache = new ThreadSafeStore<Type, Type>(new Func<Type, Type>(JsonTypeReflector.GetAssociateMetadataTypeFromAttribute));
    private static ReflectionObject _metadataTypeAttributeReflectionObject;

    public static T GetCachedAttribute<T>(object attributeProvider) where T : Attribute => CachedAttributeGetter<T>.GetAttribute(attributeProvider);

    public static DataContractAttribute GetDataContractAttribute(Type type)
    {
      for (Type type1 = type; type1 != null; type1 = type1.BaseType())
      {
        DataContractAttribute attribute = CachedAttributeGetter<DataContractAttribute>.GetAttribute((object) type1);
        if (attribute != null)
          return attribute;
      }
      return (DataContractAttribute) null;
    }

    public static DataMemberAttribute GetDataMemberAttribute(MemberInfo memberInfo)
    {
      if (memberInfo.MemberType() == MemberTypes.Field)
        return CachedAttributeGetter<DataMemberAttribute>.GetAttribute((object) memberInfo);
      PropertyInfo propertyInfo = (PropertyInfo) memberInfo;
      DataMemberAttribute attribute = CachedAttributeGetter<DataMemberAttribute>.GetAttribute((object) propertyInfo);
      if (attribute == null && propertyInfo.IsVirtual())
      {
        for (Type type = propertyInfo.DeclaringType; attribute == null && type != null; type = type.BaseType())
        {
          PropertyInfo memberInfoFromType = (PropertyInfo) ReflectionUtils.GetMemberInfoFromType(type, (MemberInfo) propertyInfo);
          if (memberInfoFromType != null && memberInfoFromType.IsVirtual())
            attribute = CachedAttributeGetter<DataMemberAttribute>.GetAttribute((object) memberInfoFromType);
        }
      }
      return attribute;
    }

    public static MemberSerialization GetObjectMemberSerialization(
      Type objectType,
      bool ignoreSerializableAttribute)
    {
      JsonObjectAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonObjectAttribute>((object) objectType);
      if (cachedAttribute != null)
        return cachedAttribute.MemberSerialization;
      return JsonTypeReflector.GetDataContractAttribute(objectType) != null ? MemberSerialization.OptIn : MemberSerialization.OptOut;
    }

    public static JsonConverter GetJsonConverter(object attributeProvider)
    {
      JsonConverterAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonConverterAttribute>(attributeProvider);
      if (cachedAttribute != null)
      {
        Func<object[], object> func = JsonTypeReflector.CreatorCache.Get(cachedAttribute.ConverterType);
        if (func != null)
          return (JsonConverter) func(cachedAttribute.ConverterParameters);
      }
      return (JsonConverter) null;
    }

    public static JsonConverter CreateJsonConverterInstance(Type converterType, object[] args) => (JsonConverter) JsonTypeReflector.CreatorCache.Get(converterType)(args);

    public static NamingStrategy CreateNamingStrategyInstance(
      Type namingStrategyType,
      object[] args)
    {
      return (NamingStrategy) JsonTypeReflector.CreatorCache.Get(namingStrategyType)(args);
    }

    public static NamingStrategy GetContainerNamingStrategy(
      JsonContainerAttribute containerAttribute)
    {
      if (containerAttribute.NamingStrategyInstance == null)
      {
        if (containerAttribute.NamingStrategyType == null)
          return (NamingStrategy) null;
        containerAttribute.NamingStrategyInstance = JsonTypeReflector.CreateNamingStrategyInstance(containerAttribute.NamingStrategyType, containerAttribute.NamingStrategyParameters);
      }
      return containerAttribute.NamingStrategyInstance;
    }

    private static Func<object[], object> GetCreator(Type type)
    {
      Func<object> defaultConstructor = ReflectionUtils.HasDefaultConstructor(type, false) ? JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type) : (Func<object>) null;
      return (Func<object[], object>) (parameters =>
      {
        try
        {
          if (parameters != null)
          {
            ConstructorInfo constructor = type.GetConstructor((IList<Type>) ((IEnumerable<object>) parameters).Select<object, Type>((Func<object, Type>) (param =>
            {
              return param != null ? param.GetType() : throw new InvalidOperationException("Cannot pass a null parameter to the constructor.");
            })).ToArray<Type>());
            if (constructor != null)
              return JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor((MethodBase) constructor)(parameters);
            throw new JsonException("No matching parameterized constructor found for '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type));
          }
          if (defaultConstructor == null)
            throw new JsonException("No parameterless constructor defined for '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type));
          return defaultConstructor();
        }
        catch (Exception ex)
        {
          throw new JsonException("Error creating '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) type), ex);
        }
      });
    }

    private static Type GetAssociatedMetadataType(Type type) => JsonTypeReflector.AssociatedMetadataTypesCache.Get(type);

    private static Type GetAssociateMetadataTypeFromAttribute(Type type)
    {
      foreach (Attribute attribute in ReflectionUtils.GetAttributes((object) type, (Type) null, true))
      {
        Type type1 = attribute.GetType();
        if (string.Equals(type1.FullName, "System.ComponentModel.DataAnnotations.MetadataTypeAttribute", StringComparison.Ordinal))
        {
          if (JsonTypeReflector._metadataTypeAttributeReflectionObject == null)
            JsonTypeReflector._metadataTypeAttributeReflectionObject = ReflectionObject.Create(type1, "MetadataClassType");
          return (Type) JsonTypeReflector._metadataTypeAttributeReflectionObject.GetValue((object) attribute, "MetadataClassType");
        }
      }
      return (Type) null;
    }

    private static T GetAttribute<T>(Type type) where T : Attribute
    {
      Type associatedMetadataType = JsonTypeReflector.GetAssociatedMetadataType(type);
      if (associatedMetadataType != null)
      {
        T attribute = ReflectionUtils.GetAttribute<T>((object) associatedMetadataType, true);
        if ((object) attribute != null)
          return attribute;
      }
      T attribute1 = ReflectionUtils.GetAttribute<T>((object) type, true);
      if ((object) attribute1 != null)
        return attribute1;
      foreach (object attributeProvider in type.GetInterfaces())
      {
        T attribute2 = ReflectionUtils.GetAttribute<T>(attributeProvider, true);
        if ((object) attribute2 != null)
          return attribute2;
      }
      return default (T);
    }

    private static T GetAttribute<T>(MemberInfo memberInfo) where T : Attribute
    {
      Type associatedMetadataType = JsonTypeReflector.GetAssociatedMetadataType(memberInfo.DeclaringType);
      if (associatedMetadataType != null)
      {
        MemberInfo memberInfoFromType = ReflectionUtils.GetMemberInfoFromType(associatedMetadataType, memberInfo);
        if (memberInfoFromType != null)
        {
          T attribute = ReflectionUtils.GetAttribute<T>((object) memberInfoFromType, true);
          if ((object) attribute != null)
            return attribute;
        }
      }
      T attribute1 = ReflectionUtils.GetAttribute<T>((object) memberInfo, true);
      if ((object) attribute1 != null)
        return attribute1;
      if (memberInfo.DeclaringType != null)
      {
        foreach (Type targetType in memberInfo.DeclaringType.GetInterfaces())
        {
          MemberInfo memberInfoFromType = ReflectionUtils.GetMemberInfoFromType(targetType, memberInfo);
          if (memberInfoFromType != null)
          {
            T attribute2 = ReflectionUtils.GetAttribute<T>((object) memberInfoFromType, true);
            if ((object) attribute2 != null)
              return attribute2;
          }
        }
      }
      return default (T);
    }

    public static T GetAttribute<T>(object provider) where T : Attribute
    {
      switch (provider)
      {
        case Type type:
          return JsonTypeReflector.GetAttribute<T>(type);
        case MemberInfo memberInfo:
          return JsonTypeReflector.GetAttribute<T>(memberInfo);
        default:
          return ReflectionUtils.GetAttribute<T>(provider, true);
      }
    }

    public static bool DynamicCodeGeneration
    {
      get
      {
        if (!JsonTypeReflector._dynamicCodeGeneration.HasValue)
          JsonTypeReflector._dynamicCodeGeneration = new bool?(false);
        return JsonTypeReflector._dynamicCodeGeneration.GetValueOrDefault();
      }
    }

    public static bool FullyTrusted
    {
      get
      {
        if (!JsonTypeReflector._fullyTrusted.HasValue)
          JsonTypeReflector._fullyTrusted = new bool?(true);
        return JsonTypeReflector._fullyTrusted.GetValueOrDefault();
      }
    }

    public static ReflectionDelegateFactory ReflectionDelegateFactory => ExpressionReflectionDelegateFactory.Instance;
  }
}
