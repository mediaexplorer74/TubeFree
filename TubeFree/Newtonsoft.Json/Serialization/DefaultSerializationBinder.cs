// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.DefaultSerializationBinder
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Newtonsoft.Json.Serialization
{
  public class DefaultSerializationBinder : SerializationBinder, ISerializationBinder
  {
    internal static readonly DefaultSerializationBinder Instance = new DefaultSerializationBinder();
    private readonly ThreadSafeStore<StructMultiKey<string, string>, Type> _typeCache;

    public DefaultSerializationBinder() => this._typeCache = new ThreadSafeStore<StructMultiKey<string, string>, Type>(new Func<StructMultiKey<string, string>, Type>(this.GetTypeFromTypeNameKey));

    private Type GetTypeFromTypeNameKey(StructMultiKey<string, string> typeNameKey)
    {
      string assemblyName = typeNameKey.Value1;
      string str = typeNameKey.Value2;
      if (assemblyName == null)
        return Type.GetType(str);
      Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
      Type typeFromTypeNameKey = assembly != null ? assembly.GetType(str) : throw new JsonSerializationException("Could not load assembly '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) assemblyName));
      if (typeFromTypeNameKey == null)
      {
        if (str.IndexOf('`') >= 0)
        {
          try
          {
            typeFromTypeNameKey = this.GetGenericTypeFromTypeName(str, assembly);
          }
          catch (Exception ex)
          {
            throw new JsonSerializationException("Could not find type '{0}' in assembly '{1}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) str, (object) assembly.FullName), ex);
          }
        }
        if (typeFromTypeNameKey == null)
          throw new JsonSerializationException("Could not find type '{0}' in assembly '{1}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) str, (object) assembly.FullName));
      }
      return typeFromTypeNameKey;
    }

    private Type GetGenericTypeFromTypeName(string typeName, Assembly assembly)
    {
      Type typeFromTypeName = (Type) null;
      int length = typeName.IndexOf('[');
      if (length >= 0)
      {
        string name = typeName.Substring(0, length);
        Type type = assembly.GetType(name);
        if (type != null)
        {
          List<Type> typeList = new List<Type>();
          int num1 = 0;
          int startIndex = 0;
          int num2 = typeName.Length - 1;
          for (int index = length + 1; index < num2; ++index)
          {
            switch (typeName[index])
            {
              case '[':
                if (num1 == 0)
                  startIndex = index + 1;
                ++num1;
                break;
              case ']':
                --num1;
                if (num1 == 0)
                {
                  StructMultiKey<string, string> typeNameKey = ReflectionUtils.SplitFullyQualifiedTypeName(typeName.Substring(startIndex, index - startIndex));
                  typeList.Add(this.GetTypeByName(typeNameKey));
                  break;
                }
                break;
            }
          }
          typeFromTypeName = type.MakeGenericType(typeList.ToArray());
        }
      }
      return typeFromTypeName;
    }

    private Type GetTypeByName(StructMultiKey<string, string> typeNameKey) => this._typeCache.Get(typeNameKey);

    public override Type BindToType(string assemblyName, string typeName) => this.GetTypeByName(new StructMultiKey<string, string>(assemblyName, typeName));

    public override void BindToName(
      Type serializedType,
      out string assemblyName,
      out string typeName)
    {
      assemblyName = serializedType.GetTypeInfo().Assembly.FullName;
      typeName = serializedType.FullName;
    }
  }
}
