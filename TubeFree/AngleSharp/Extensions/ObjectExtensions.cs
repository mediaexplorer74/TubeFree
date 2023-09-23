// Decompiled with JetBrains decompiler
// Type: AngleSharp.Extensions.ObjectExtensions
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace AngleSharp.Extensions
{
  internal static class ObjectExtensions
  {
    public static Dictionary<string, string> ToDictionary(this object values)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      if (values != null)
      {
        foreach (PropertyInfo property in values.GetType().GetProperties())
        {
          object obj = property.GetValue(values, (object[]) null) ?? (object) string.Empty;
          dictionary.Add(property.Name, obj.ToString());
        }
      }
      return dictionary;
    }

    public static T? TryGet<T>(this IDictionary<string, object> values, string key) where T : struct
    {
      object obj1 = (object) null;
      return values.TryGetValue(key, out obj1) && obj1 is T obj2 ? new T?(obj2) : new T?();
    }

    public static object TryGet(this IDictionary<string, object> values, string key)
    {
      object obj = (object) null;
      values.TryGetValue(key, out obj);
      return obj;
    }

    public static U GetOrDefault<T, U>(this IDictionary<T, U> values, T key, U defaultValue)
    {
      U u = default (U);
      return !values.TryGetValue(key, out u) ? defaultValue : u;
    }

    public static double Constraint(this double value, double min, double max)
    {
      if (value < min)
        return min;
      return value <= max ? value : max;
    }

    public static string GetMessage<T>(this T code) where T : struct => typeof (T).GetTypeInfo().GetDeclaredField(code.ToString()).GetCustomAttribute<DomDescriptionAttribute>()?.Description ?? "An unknown error occurred.";
  }
}
