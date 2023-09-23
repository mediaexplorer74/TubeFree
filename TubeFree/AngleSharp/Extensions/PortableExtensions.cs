// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.PortableExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AngleSharp.Extensions
{
  internal static class PortableExtensions
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ConvertFromUtf32(this int utf32) => char.ConvertFromUtf32(utf32);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ConvertToUtf32(this string s, int index) => char.ConvertToUtf32(s, index);

    public static Task Delay(this CancellationToken token, int timeout) => Task.Delay(Math.Max(timeout, 4), token);

    public static bool Implements<T>(this Type type) => type.GetTypeInfo().ImplementedInterfaces.Contains<Type>(typeof (T));

    public static PropertyInfo[] GetProperties(this Type type) => type.GetRuntimeProperties().ToArray<PropertyInfo>();

    public static ConstructorInfo[] GetConstructors(this Type type) => type.GetTypeInfo().DeclaredConstructors.Where<ConstructorInfo>((Func<ConstructorInfo, bool>) (c => c.IsPublic && !c.IsStatic)).ToArray<ConstructorInfo>();

    public static FieldInfo GetField(this Type type, string name) => type.GetTypeInfo().GetDeclaredField(name);

    public static PropertyInfo GetProperty(this Type type, string name) => type.GetTypeInfo().GetDeclaredProperty(name);

    public static bool IsAbstractClass(this Type type) => type.GetTypeInfo().IsAbstract;

    public static Type[] GetTypes(this Assembly assembly) => assembly.DefinedTypes.Select<TypeInfo, Type>((Func<TypeInfo, Type>) (t => t.AsType())).ToArray<Type>();

    public static Assembly GetAssembly(this Type type) => type.GetTypeInfo().Assembly;
  }
}
