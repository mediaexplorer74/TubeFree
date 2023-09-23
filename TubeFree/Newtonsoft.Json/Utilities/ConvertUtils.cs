﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ConvertUtils
// Assembly: Newtonsoft.Json, Version=12.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: A4A4D6C6-3EFA-4DC8-AAEA-DA1EC7F2D4DE
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\Newtonsoft.Json.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Newtonsoft.Json.Utilities
{
  internal static class ConvertUtils
  {
    private static readonly Dictionary<Type, PrimitiveTypeCode> TypeCodeMap = new Dictionary<Type, PrimitiveTypeCode>()
    {
      {
        typeof (char),
        PrimitiveTypeCode.Char
      },
      {
        typeof (char?),
        PrimitiveTypeCode.CharNullable
      },
      {
        typeof (bool),
        PrimitiveTypeCode.Boolean
      },
      {
        typeof (bool?),
        PrimitiveTypeCode.BooleanNullable
      },
      {
        typeof (sbyte),
        PrimitiveTypeCode.SByte
      },
      {
        typeof (sbyte?),
        PrimitiveTypeCode.SByteNullable
      },
      {
        typeof (short),
        PrimitiveTypeCode.Int16
      },
      {
        typeof (short?),
        PrimitiveTypeCode.Int16Nullable
      },
      {
        typeof (ushort),
        PrimitiveTypeCode.UInt16
      },
      {
        typeof (ushort?),
        PrimitiveTypeCode.UInt16Nullable
      },
      {
        typeof (int),
        PrimitiveTypeCode.Int32
      },
      {
        typeof (int?),
        PrimitiveTypeCode.Int32Nullable
      },
      {
        typeof (byte),
        PrimitiveTypeCode.Byte
      },
      {
        typeof (byte?),
        PrimitiveTypeCode.ByteNullable
      },
      {
        typeof (uint),
        PrimitiveTypeCode.UInt32
      },
      {
        typeof (uint?),
        PrimitiveTypeCode.UInt32Nullable
      },
      {
        typeof (long),
        PrimitiveTypeCode.Int64
      },
      {
        typeof (long?),
        PrimitiveTypeCode.Int64Nullable
      },
      {
        typeof (ulong),
        PrimitiveTypeCode.UInt64
      },
      {
        typeof (ulong?),
        PrimitiveTypeCode.UInt64Nullable
      },
      {
        typeof (float),
        PrimitiveTypeCode.Single
      },
      {
        typeof (float?),
        PrimitiveTypeCode.SingleNullable
      },
      {
        typeof (double),
        PrimitiveTypeCode.Double
      },
      {
        typeof (double?),
        PrimitiveTypeCode.DoubleNullable
      },
      {
        typeof (DateTime),
        PrimitiveTypeCode.DateTime
      },
      {
        typeof (DateTime?),
        PrimitiveTypeCode.DateTimeNullable
      },
      {
        typeof (DateTimeOffset),
        PrimitiveTypeCode.DateTimeOffset
      },
      {
        typeof (DateTimeOffset?),
        PrimitiveTypeCode.DateTimeOffsetNullable
      },
      {
        typeof (Decimal),
        PrimitiveTypeCode.Decimal
      },
      {
        typeof (Decimal?),
        PrimitiveTypeCode.DecimalNullable
      },
      {
        typeof (Guid),
        PrimitiveTypeCode.Guid
      },
      {
        typeof (Guid?),
        PrimitiveTypeCode.GuidNullable
      },
      {
        typeof (TimeSpan),
        PrimitiveTypeCode.TimeSpan
      },
      {
        typeof (TimeSpan?),
        PrimitiveTypeCode.TimeSpanNullable
      },
      {
        typeof (Uri),
        PrimitiveTypeCode.Uri
      },
      {
        typeof (string),
        PrimitiveTypeCode.String
      },
      {
        typeof (byte[]),
        PrimitiveTypeCode.Bytes
      }
    };
    private static readonly ThreadSafeStore<StructMultiKey<Type, Type>, Func<object, object>> CastConverters = new ThreadSafeStore<StructMultiKey<Type, Type>, Func<object, object>>(new Func<StructMultiKey<Type, Type>, Func<object, object>>(ConvertUtils.CreateCastConverter));

    public static PrimitiveTypeCode GetTypeCode(Type t) => ConvertUtils.GetTypeCode(t, out bool _);

    public static PrimitiveTypeCode GetTypeCode(Type t, out bool isEnum)
    {
      PrimitiveTypeCode typeCode;
      if (ConvertUtils.TypeCodeMap.TryGetValue(t, out typeCode))
      {
        isEnum = false;
        return typeCode;
      }
      if (t.IsEnum())
      {
        isEnum = true;
        return ConvertUtils.GetTypeCode(Enum.GetUnderlyingType(t));
      }
      if (ReflectionUtils.IsNullableType(t))
      {
        Type underlyingType = Nullable.GetUnderlyingType(t);
        if (underlyingType.IsEnum())
        {
          Type t1 = typeof (Nullable<>).MakeGenericType(Enum.GetUnderlyingType(underlyingType));
          isEnum = true;
          return ConvertUtils.GetTypeCode(t1);
        }
      }
      isEnum = false;
      return PrimitiveTypeCode.Object;
    }

    public static bool IsConvertible(Type t) => t == typeof (bool) || t == typeof (byte) || t == typeof (char) || t == typeof (DateTime) || t == typeof (Decimal) || t == typeof (double) || t == typeof (short) || t == typeof (int) || t == typeof (long) || t == typeof (sbyte) || t == typeof (float) || t == typeof (string) || t == typeof (ushort) || t == typeof (uint) || t == typeof (ulong) || t.IsEnum();

    public static TimeSpan ParseTimeSpan(string input) => TimeSpan.Parse(input, (IFormatProvider) CultureInfo.InvariantCulture);

    private static Func<object, object> CreateCastConverter(StructMultiKey<Type, Type> t)
    {
      Type type1 = t.Value1;
      Type type2 = t.Value2;
      MethodInfo method1 = type2.GetMethod("op_Implicit", (IList<Type>) new Type[1]
      {
        type1
      });
      if (method1 == null)
        method1 = type2.GetMethod("op_Explicit", (IList<Type>) new Type[1]
        {
          type1
        });
      MethodInfo method2 = method1;
      if (method2 == null)
        return (Func<object, object>) null;
      MethodCall<object, object> call = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>((MethodBase) method2);
      return (Func<object, object>) (o => call((object) null, new object[1]
      {
        o
      }));
    }

    public static object Convert(object initialValue, CultureInfo culture, Type targetType)
    {
      object obj;
      switch (ConvertUtils.TryConvertInternal(initialValue, culture, targetType, out obj))
      {
        case ConvertUtils.ConvertResult.Success:
          return obj;
        case ConvertUtils.ConvertResult.CannotConvertNull:
          throw new Exception("Can not convert null {0} into non-nullable {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) initialValue.GetType(), (object) targetType));
        case ConvertUtils.ConvertResult.NotInstantiableType:
          throw new ArgumentException("Target type {0} is not a value type or a non-abstract class.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) targetType), nameof (targetType));
        case ConvertUtils.ConvertResult.NoValidConversion:
          throw new InvalidOperationException("Can not convert from {0} to {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) initialValue.GetType(), (object) targetType));
        default:
          throw new InvalidOperationException("Unexpected conversion result.");
      }
    }

    private static bool TryConvert(
      object initialValue,
      CultureInfo culture,
      Type targetType,
      out object value)
    {
      try
      {
        if (ConvertUtils.TryConvertInternal(initialValue, culture, targetType, out value) == ConvertUtils.ConvertResult.Success)
          return true;
        value = (object) null;
        return false;
      }
      catch
      {
        value = (object) null;
        return false;
      }
    }

    private static ConvertUtils.ConvertResult TryConvertInternal(
      object initialValue,
      CultureInfo culture,
      Type targetType,
      out object value)
    {
      if (initialValue == null)
        throw new ArgumentNullException(nameof (initialValue));
      if (ReflectionUtils.IsNullableType(targetType))
        targetType = Nullable.GetUnderlyingType(targetType);
      Type type = initialValue.GetType();
      if (targetType == type)
      {
        value = initialValue;
        return ConvertUtils.ConvertResult.Success;
      }
      if (ConvertUtils.IsConvertible(initialValue.GetType()) && ConvertUtils.IsConvertible(targetType))
      {
        if (targetType.IsEnum())
        {
          if (initialValue is string)
          {
            value = Enum.Parse(targetType, initialValue.ToString(), true);
            return ConvertUtils.ConvertResult.Success;
          }
          if (ConvertUtils.IsInteger(initialValue))
          {
            value = Enum.ToObject(targetType, initialValue);
            return ConvertUtils.ConvertResult.Success;
          }
        }
        value = System.Convert.ChangeType(initialValue, targetType, (IFormatProvider) culture);
        return ConvertUtils.ConvertResult.Success;
      }
      switch (initialValue)
      {
        case DateTime dateTime when targetType == typeof (DateTimeOffset):
          value = (object) new DateTimeOffset(dateTime);
          return ConvertUtils.ConvertResult.Success;
        case byte[] b when targetType == typeof (Guid):
          value = (object) new Guid(b);
          return ConvertUtils.ConvertResult.Success;
        case Guid guid when targetType == typeof (byte[]):
          value = (object) guid.ToByteArray();
          return ConvertUtils.ConvertResult.Success;
        case string str:
          if (targetType == typeof (Guid))
          {
            value = (object) new Guid(str);
            return ConvertUtils.ConvertResult.Success;
          }
          if (targetType == typeof (Uri))
          {
            value = (object) new Uri(str, UriKind.RelativeOrAbsolute);
            return ConvertUtils.ConvertResult.Success;
          }
          if (targetType == typeof (TimeSpan))
          {
            value = (object) ConvertUtils.ParseTimeSpan(str);
            return ConvertUtils.ConvertResult.Success;
          }
          if (targetType == typeof (byte[]))
          {
            value = (object) System.Convert.FromBase64String(str);
            return ConvertUtils.ConvertResult.Success;
          }
          if (targetType == typeof (Version))
          {
            Version result;
            if (ConvertUtils.VersionTryParse(str, out result))
            {
              value = (object) result;
              return ConvertUtils.ConvertResult.Success;
            }
            value = (object) null;
            return ConvertUtils.ConvertResult.NoValidConversion;
          }
          if (typeof (Type).IsAssignableFrom(targetType))
          {
            value = (object) Type.GetType(str, true);
            return ConvertUtils.ConvertResult.Success;
          }
          break;
      }
      if (targetType.IsInterface() || targetType.IsGenericTypeDefinition() || targetType.IsAbstract())
      {
        value = (object) null;
        return ConvertUtils.ConvertResult.NotInstantiableType;
      }
      value = (object) null;
      return ConvertUtils.ConvertResult.NoValidConversion;
    }

    public static object ConvertOrCast(object initialValue, CultureInfo culture, Type targetType)
    {
      if (targetType == typeof (object))
        return initialValue;
      if (initialValue == null && ReflectionUtils.IsNullable(targetType))
        return (object) null;
      object obj;
      return ConvertUtils.TryConvert(initialValue, culture, targetType, out obj) ? obj : ConvertUtils.EnsureTypeAssignable(initialValue, ReflectionUtils.GetObjectType(initialValue), targetType);
    }

    private static object EnsureTypeAssignable(object value, Type initialType, Type targetType)
    {
      Type type = value?.GetType();
      if (value != null)
      {
        if (targetType.IsAssignableFrom(type))
          return value;
        Func<object, object> func = ConvertUtils.CastConverters.Get(new StructMultiKey<Type, Type>(type, targetType));
        if (func != null)
          return func(value);
      }
      else if (ReflectionUtils.IsNullable(targetType))
        return (object) null;
      throw new ArgumentException("Could not cast or convert from {0} to {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) (initialType?.ToString() ?? "{null}"), (object) targetType));
    }

    public static bool VersionTryParse(string input, out Version result) => Version.TryParse(input, out result);

    public static bool IsInteger(object value)
    {
      switch (ConvertUtils.GetTypeCode(value.GetType()))
      {
        case PrimitiveTypeCode.SByte:
        case PrimitiveTypeCode.Int16:
        case PrimitiveTypeCode.UInt16:
        case PrimitiveTypeCode.Int32:
        case PrimitiveTypeCode.Byte:
        case PrimitiveTypeCode.UInt32:
        case PrimitiveTypeCode.Int64:
        case PrimitiveTypeCode.UInt64:
          return true;
        default:
          return false;
      }
    }

    public static ParseResult Int32TryParse(char[] chars, int start, int length, out int value)
    {
      value = 0;
      if (length == 0)
        return ParseResult.Invalid;
      bool flag = chars[start] == '-';
      if (flag)
      {
        if (length == 1)
          return ParseResult.Invalid;
        ++start;
        --length;
      }
      int num1 = start + length;
      if (length > 10 || length == 10 && (int) chars[start] - 48 > 2)
      {
        for (int index = start; index < num1; ++index)
        {
          int num2 = (int) chars[index] - 48;
          if (num2 < 0 || num2 > 9)
            return ParseResult.Invalid;
        }
        return ParseResult.Overflow;
      }
      for (int index1 = start; index1 < num1; ++index1)
      {
        int num3 = (int) chars[index1] - 48;
        if (num3 < 0 || num3 > 9)
          return ParseResult.Invalid;
        int num4 = 10 * value - num3;
        if (num4 > value)
        {
          for (int index2 = index1 + 1; index2 < num1; ++index2)
          {
            int num5 = (int) chars[index2] - 48;
            if (num5 < 0 || num5 > 9)
              return ParseResult.Invalid;
          }
          return ParseResult.Overflow;
        }
        value = num4;
      }
      if (!flag)
      {
        if (value == int.MinValue)
          return ParseResult.Overflow;
        value = -value;
      }
      return ParseResult.Success;
    }

    public static ParseResult Int64TryParse(char[] chars, int start, int length, out long value)
    {
      value = 0L;
      if (length == 0)
        return ParseResult.Invalid;
      bool flag = chars[start] == '-';
      if (flag)
      {
        if (length == 1)
          return ParseResult.Invalid;
        ++start;
        --length;
      }
      int num1 = start + length;
      if (length > 19)
      {
        for (int index = start; index < num1; ++index)
        {
          int num2 = (int) chars[index] - 48;
          if (num2 < 0 || num2 > 9)
            return ParseResult.Invalid;
        }
        return ParseResult.Overflow;
      }
      for (int index1 = start; index1 < num1; ++index1)
      {
        int num3 = (int) chars[index1] - 48;
        if (num3 < 0 || num3 > 9)
          return ParseResult.Invalid;
        long num4 = 10L * value - (long) num3;
        if (num4 > value)
        {
          for (int index2 = index1 + 1; index2 < num1; ++index2)
          {
            int num5 = (int) chars[index2] - 48;
            if (num5 < 0 || num5 > 9)
              return ParseResult.Invalid;
          }
          return ParseResult.Overflow;
        }
        value = num4;
      }
      if (!flag)
      {
        if (value == long.MinValue)
          return ParseResult.Overflow;
        value = -value;
      }
      return ParseResult.Success;
    }

    public static ParseResult DecimalTryParse(
      char[] chars,
      int start,
      int length,
      out Decimal value)
    {
      value = 0M;
      if (length == 0)
        return ParseResult.Invalid;
      bool flag1 = chars[start] == '-';
      if (flag1)
      {
        if (length == 1)
          return ParseResult.Invalid;
        ++start;
        --length;
      }
      int index = start;
      int num1 = start + length;
      int num2 = num1;
      int num3 = num1;
      int num4 = 0;
      ulong num5 = 0;
      ulong num6 = 0;
      int num7 = 0;
      int num8 = 0;
      char? nullable1 = new char?();
      bool? nullable2 = new bool?();
      for (; index < num1; ++index)
      {
        char ch1 = chars[index];
        if (ch1 != '.')
        {
          if (ch1 != 'E' && ch1 != 'e')
            goto label_29;
label_12:
          if (index == start || index == num2)
            return ParseResult.Invalid;
          ++index;
          if (index == num1)
            return ParseResult.Invalid;
          if (num2 < num1)
            num3 = index - 1;
          char ch2 = chars[index];
          bool flag2 = false;
          switch (ch2)
          {
            case '+':
              ++index;
              break;
            case '-':
              flag2 = true;
              ++index;
              break;
          }
          for (; index < num1; ++index)
          {
            char ch3 = chars[index];
            if (ch3 < '0' || ch3 > '9')
              return ParseResult.Invalid;
            int num9 = 10 * num4 + ((int) ch3 - 48);
            if (num4 < num9)
              num4 = num9;
          }
          if (flag2)
          {
            num4 = -num4;
            continue;
          }
          continue;
label_29:
          if (ch1 < '0' || ch1 > '9')
            return ParseResult.Invalid;
          if (index == start && ch1 == '0')
          {
            ++index;
            if (index != num1)
            {
              switch (chars[index])
              {
                case '.':
                  goto label_9;
                case 'E':
                case 'e':
                  goto label_12;
                default:
                  return ParseResult.Invalid;
              }
            }
          }
          if (num7 < 29)
          {
            if (num7 == 28)
            {
              bool? nullable3 = nullable2;
              int num10;
              if (!nullable3.HasValue)
              {
                nullable2 = new bool?(num5 > 7922816251426433759UL || num5 == 7922816251426433759UL && (num6 > 354395033UL || num6 == 354395033UL && ch1 > '5'));
                num10 = nullable2.GetValueOrDefault() ? 1 : 0;
              }
              else
                num10 = nullable3.GetValueOrDefault() ? 1 : 0;
              if (num10 != 0)
                goto label_45;
            }
            if (num7 < 19)
              num5 = num5 * 10UL + (ulong) ((int) ch1 - 48);
            else
              num6 = num6 * 10UL + (ulong) ((int) ch1 - 48);
            ++num7;
            continue;
          }
label_45:
          if (!nullable1.HasValue)
            nullable1 = new char?(ch1);
          ++num8;
          continue;
        }
label_9:
        if (index == start || index + 1 == num1 || num2 != num1)
          return ParseResult.Invalid;
        num2 = index + 1;
      }
      int scale = num4 + num8 - (num3 - num2);
      value = num7 > 19 ? (Decimal) num5 / new Decimal(1, 0, 0, false, (byte) (num7 - 19)) + (Decimal) num6 : (Decimal) num5;
      if (scale > 0)
      {
        int num11 = num7 + scale;
        if (num11 > 29)
          return ParseResult.Overflow;
        if (num11 == 29)
        {
          if (scale > 1)
          {
            value /= new Decimal(1, 0, 0, false, (byte) (scale - 1));
            if (value > 7922816251426433759354395033M)
              return ParseResult.Overflow;
          }
          else if (value == 7922816251426433759354395033M)
          {
            char? nullable4 = nullable1;
            int? nullable5 = nullable4.HasValue ? new int?((int) nullable4.GetValueOrDefault()) : new int?();
            int num12 = 53;
            if (nullable5.GetValueOrDefault() > num12 & nullable5.HasValue)
              return ParseResult.Overflow;
          }
          value *= 10M;
        }
        else
          value /= new Decimal(1, 0, 0, false, (byte) scale);
      }
      else
      {
        char? nullable6 = nullable1;
        int? nullable7 = nullable6.HasValue ? new int?((int) nullable6.GetValueOrDefault()) : new int?();
        int num13 = 53;
        if (nullable7.GetValueOrDefault() >= num13 & nullable7.HasValue && scale >= -28)
          ++value;
        if (scale < 0)
        {
          if (num7 + scale + 28 <= 0)
          {
            value = flag1 ? 0M : 0M;
            return ParseResult.Success;
          }
          if (scale >= -28)
          {
            value *= new Decimal(1, 0, 0, false, (byte) -scale);
          }
          else
          {
            value /= 10000000000000000000000000000M;
            value *= new Decimal(1, 0, 0, false, (byte) (-scale - 28));
          }
        }
      }
      if (flag1)
        value = -value;
      return ParseResult.Success;
    }

    public static bool TryConvertGuid(string s, out Guid g) => Guid.TryParseExact(s, "D", out g);

    public static bool TryHexTextToInt(char[] text, int start, int end, out int value)
    {
      value = 0;
      for (int index = start; index < end; ++index)
      {
        char ch = text[index];
        int num;
        if (ch <= '9' && ch >= '0')
          num = (int) ch - 48;
        else if (ch <= 'F' && ch >= 'A')
          num = (int) ch - 55;
        else if (ch <= 'f' && ch >= 'a')
        {
          num = (int) ch - 87;
        }
        else
        {
          value = 0;
          return false;
        }
        value += num << (end - 1 - index) * 4;
      }
      return true;
    }

    internal enum ConvertResult
    {
      Success,
      CannotConvertNull,
      NotInstantiableType,
      NoValidConversion,
    }
  }
}
